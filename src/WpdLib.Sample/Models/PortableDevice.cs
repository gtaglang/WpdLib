using System;
using System.Collections.Generic;
using Livet;

namespace WpdLib.Sample.Models
{
	/// <summary>
	/// ポータブル デバイスを表します。
	/// </summary>
	sealed class PortableDevice : NotificationObject, IDisposable
	{
		/// <summary>
		/// インスタンスを初期化します。
		/// </summary>
		/// <param name="client">ポータブル デバイスに接続するクライアント情報。</param>
		/// <param name="device">ポータブル デバイス</param>
		private PortableDevice( WpdClient client, WpdDevice device )
		{
			this._client = client;
			this._device = device;
		}

		/// <summary>
		/// デバイスを閉じます。
		/// </summary>
		public void Close()
		{
			this._device.Close();
		}

		/// <summary>
		/// 現在、PC に接続されているポータブル デバイスを列挙します。
		/// </summary>
		/// <param name="client">ポータブル デバイスに接続するクライアント情報。</param>
		/// <returns>ポータブル デバイスのコレクション。</returns>
		public static IEnumerable< PortableDevice > EnumDevice( WpdClient client )
		{
			foreach( var device in WpdDevice.EnumDevices() )
			{
				yield return new PortableDevice( client, device );
			}
		}

		/// <summary>
		/// デバイス直下のオブジェクトを列挙します。
		/// 直下には、内部ストレージやネットワーク設定などが配置されています。
		/// </summary>
		/// <returns>列挙されたオブジェクトのコレクション。</returns>
		public IEnumerable< PortableDeviceObject > EnumChildren()
		{
			foreach( var child in this._device.EnumChildren() )
			{
				yield return new PortableDeviceObject( child );
			}
		}

		/// <summary>
		/// リソースを破棄します。
		/// </summary>
		public void Dispose()
		{
			if( this._device != null )
			{
				this._device.Dispose();
				this._device = null;
			}

			GC.SuppressFinalize( this );
		}

		/// <summary>
		/// デバイスを開きます。
		/// </summary>
		public void Open( Action< WpdEventArgs > deviceEventHandler )
		{
			this._device.Open( this._client, deviceEventHandler );
		}

		/// <summary>
		/// バッテリー残量を取得します。
		/// </summary>
		public int BatteryLevel { get { return this._device.BatteryLevel; } }

		/// <summary>
		/// ファームウェアのバージョン情報を取得します。
		/// </summary>
		public string FirmwareVersion { get { return this._device.FirmwareVersion; } }

		/// <summary>
		/// デバイス名を取得します。
		/// </summary>
		public string FriendlyName { get { return this._device.FriendlyName; } }

		/// <summary>
		/// デバイスの識別子を取得します。
		/// </summary>
		public string Id { get { return this._device.Id; } }

		/// <summary>
		/// デバイスが開かれていることを示す値を取得します。
		/// </summary>
		public bool IsOpened { get { return this._device.IsOpened; } }

		/// <summary>
		/// モデル情報を取得します。
		/// </summary>
		public string Model { get { return this._device.Model; } }

		/// <summary>
		/// 製造番号を取得します。
		/// </summary>
		public string SerialNumber { get { return this._device.SerialNumber; } }

		/// <summary>
		/// ポータブル デバイスに接続するクライアント情報。
		/// </summary>
		private WpdClient _client;

		/// <summary>
		/// ポータブル デバイス。
		/// </summary>
		private WpdDevice _device;
	}
}
