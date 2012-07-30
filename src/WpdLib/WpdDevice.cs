using System;
using System.Collections.Generic;
using PortableDeviceApiLib;
using System.Diagnostics;

namespace WpdLib
{
	/// <summary>
	/// ポータブル デバイスを表します。
	/// </summary>
	public sealed class WpdDevice : IDisposable
	{
		/// <summary>
		/// インスタンスを初期化します。
		/// </summary>
		/// <param name="id">デバイスの識別子。</param>
		/// <exception cref="ArgumentException">id が null 参照、もしくは空文字です。</exception>
		internal WpdDevice( string id )
		{
			if( String.IsNullOrEmpty( id ) ) { throw new ArgumentException( "'id' is null or empty." ); }

			this.Id = id;
			this._device = new PortableDeviceClass();
		}

		/// <summary>
		/// ファイナライザ。
		/// </summary>
		~WpdDevice()
		{
			this.Dispose( false );
		}

		/// <summary>
		/// デバイスを閉じます。
		/// </summary>
		public void Close()
		{
			if( !this.IsOpened ) { return; }

			this._device.Unadvise( this._deviceEventCookie );
			this._deviceEventHandler = null;
			this._deviceEventCookie  = null;

			this._device.Close();
			this._client  = null;
			this.IsOpened = false;
		}

		/// <summary>
		/// リソースを破棄します。
		/// </summary>
		public void Dispose()
		{
			this.Dispose( true );
			GC.SuppressFinalize( this );
		}

		/// <summary>
		/// リソースを破棄します。
		/// </summary>
		/// <param name="isDisposing">マネージリソースを破棄する場合は true。それ以外は false。</param>
		private void Dispose( bool isDisposing )
		{
			if( this._isDisposed ) { return; }
			this._isDisposed = true;

			this.Close();

			if( isDisposing )
			{
				this._device = null;
			}
		}

		/// <summary>
		/// ポータブル デバイスの子オブジェクト ( 内部ストレージなど ) を列挙します。
		/// </summary>
		/// <returns>子オブジェクトのコレクション。</returns>
		public IEnumerable< WpdObject > EnumChildren()
		{
			if( !this.IsOpened ) { yield break; }

			IPortableDeviceContent content;
			this._device.Content( out content );

			IPortableDeviceProperties properties;
			content.Properties( out properties );

			IEnumPortableDeviceObjectIDs children;
			content.EnumObjects( 0, WpdDevice.DeviceObjectId, null, out children );

			uint fetched = 0;
			do
			{
				string id;
				children.Next( 1, out id, ref fetched );
				if( fetched > 0 )
				{
					yield return new WpdObject( id, this._client, content, properties );
				}
			}
			while( fetched > 0 );
		}

		/// <summary>
		/// ポータブル デバイスを列挙します。
		/// </summary>
		/// <returns>ポータブル デバイスのコレクション。</returns>
		public static IEnumerable< WpdDevice > EnumDevices()
		{
			var m = new PortableDeviceManagerClass();

			uint count = 1;
			m.GetDevices( null, ref count );
			if( count == 0 ) { yield break; }

			var ids = new string[ count ];
			m.GetDevices( ids, ref count );

			foreach( var id in ids )
			{
				yield return new WpdDevice( id );
			}
		}

		/// <summary>
		/// デバイスを開きます。
		/// </summary>
		/// <param name="client">クライアント情報。</param>
		/// <param name="deviceEventHandler">デバイス上で発生したイベントのハンドラー。</param>
		public void Open( WpdClient client, Action< WpdEventArgs > deviceEventHandler )
		{
			if( client == null ) { throw new ArgumentNullException( "'client' is null." ); }

			if( this.IsOpened ) { return; }

			// 接続
			this._device.Open( this.Id, client.CreateDeviceValue() );
			this._client  = client;
			this.IsOpened = true;

			// プロパティ更新
			this.UpdateValues();

			// イベント ハンドラの設定
			this._deviceEventHandler = new WpdEventCallback( deviceEventHandler );
			this._device.Advise( 0, this._deviceEventHandler, null, out this._deviceEventCookie );
		}

		/// <summary>
		/// 最新のプロパティ情報を列挙します。
		/// </summary>
		private void UpdateValues()
		{
			IPortableDeviceContent content;
			this._device.Content( out content );

			IPortableDeviceProperties properties;
			content.Properties( out properties );

			foreach( var value in WpdPropertyValue.EnumValues( WpdDevice.DeviceObjectId, properties ) )
			{
				if( value.Key.Equals( WpdProperties.WPD_DEVICE_POWER_LEVEL ) )
				{
					if( value.ValueInt32 != null ) { this.BatteryLevel = value.ValueInt32.Value; }
				}
				else if( value.Key.Equals( WpdProperties.WPD_DEVICE_FIRMWARE_VERSION ) )
				{
					this.FirmwareVersion = value.ValueString;
				}
				else if( value.Key.Equals( WpdProperties.WPD_DEVICE_FRIENDLY_NAME ) )
				{
					this.FriendlyName = value.ValueString;
				}
				else if( value.Key.Equals( WpdProperties.WPD_DEVICE_MODEL ) )
				{
					this.Model = value.ValueString;
				}
				else if( value.Key.Equals( WpdProperties.WPD_DEVICE_SERIAL_NUMBER ) )
				{
					this.SerialNumber = value.ValueString;
				}
			}
		}

		/// <summary>
		/// バッテリー残量を取得します。
		/// </summary>
		public int BatteryLevel { get; private set; }

		/// <summary>
		/// ファームウェアのバージョン情報を取得します。
		/// </summary>
		public string FirmwareVersion { get; private set; }

		/// <summary>
		/// デバイス名を取得します。
		/// </summary>
		public string FriendlyName { get; private set; }

		/// <summary>
		/// デバイスの識別子を取得します。
		/// </summary>
		public string Id { get; private set; }

		/// <summary>
		/// デバイスが開かれていることを示す値を取得します。
		/// </summary>
		public bool IsOpened { get; private set; }

		/// <summary>
		/// モデル情報を取得します。
		/// </summary>
		public string Model { get; private set; }

		/// <summary>
		/// 製造番号を取得します。
		/// </summary>
		public string SerialNumber { get; private set; }

		/// <summary>
		/// ポータブル デバイスに接続するクライアント情報。
		/// </summary>
		private WpdClient _client;

		/// <summary>
		/// ポータブル デバイス。
		/// </summary>
		private PortableDeviceClass _device;

		/// <summary>
		/// ポータブル デバイス上で発生したイベントのハンドラー識別子。
		/// </summary>
		private string _deviceEventCookie;

		/// <summary>
		/// ポータブル デバイス上で発生したイベントのハンドラー。
		/// </summary>
		private WpdEventCallback _deviceEventHandler;

		/// <summary>
		/// リソースが既に破棄されていることを示す値。
		/// </summary>
		private bool _isDisposed;

		/// <summary>
		/// デバイスのオブジェクト識別子。
		/// </summary>
		private static readonly string DeviceObjectId = "DEVICE";
	}
}
