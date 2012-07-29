using System.Collections.ObjectModel;
using System.Diagnostics;
using Livet;
using WpdLib.Sample.Models;
using System;

namespace WpdLib.Sample.ViewModels
{
	/// <summary>
	/// ポータブル デバイスを表す ViewModel です。
	/// </summary>
	sealed class PortableDeviceViewModel : ViewModel
	{
		/// <summary>
		/// インスタンスを初期化します。
		/// </summary>
		/// <param name="model">モデル。</param>
		public PortableDeviceViewModel( PortableDevice model )
		{
			this._model = model;
			this._model.Open( OnDeviceEvent );
		}

		/// <summary>
		/// デバイスのサブ フォルダ コレクションを取得します。
		/// </summary>
		public ObservableCollection< PortableDeviceObjectViewModel > Children
		{
			get
			{
				if( this._folders == null )
				{
					this._folders = new ObservableCollection< PortableDeviceObjectViewModel >();
					foreach( var child in this._model.EnumChildren() )
					{
						this._folders.Add( new PortableDeviceObjectViewModel( child ) );
					}
				}

				return this._folders;
			}
		}

		/// <summary>
		/// リソースを破棄します。
		/// </summary>
		/// <param name="disposing">マネージリソースを破棄する場合は true。それ以外は false。</param>
		protected override void Dispose( bool disposing )
		{
			try
			{
				if( this._model != null )
				{
					this._model.Dispose();
					this._model = null;
				}
			}
			catch( Exception exp )
			{
				Debug.WriteLine( exp );
			}
			finally
			{
				base.Dispose( disposing );
			}
		}

		/// <summary>
		/// デバイスでイベントが起きた時に発生します。
		/// </summary>
		/// <param name="e">イベント データ。</param>
		private void OnDeviceEvent( WpdEventArgs e )
		{
			Debug.WriteLine( "OnDeviceEvent: Type = {0}, Object = {1}, Parent = {2}, Device = {3}", e.Type, e.ObjectId, e.ParentObjectId, e.DeviceId );
		}

		/// <summary>
		/// バッテリー残量を取得します。
		/// </summary>
		public int BatteryLevel { get { return this._model.BatteryLevel; } }

		/// <summary>
		/// デバイスの表示名を取得します。
		/// </summary>
		public string DisplayName
		{
			get
			{
				if( this.IsOpened && this._displayName == null )
				{
					var name = this._model.FriendlyName;
					if( String.IsNullOrEmpty( name ) )
					{
						name = this._model.Model;
					}

					this._displayName = name;
				}

				return this._displayName;
			}
		}

		/// <summary>
		/// ファームウェアのバージョン情報を取得します。
		/// </summary>
		public string FirmwareVersion { get { return this._model.FirmwareVersion; } }

		/// <summary>
		/// デバイス名を取得します。
		/// </summary>
		public string FriendlyName { get { return this._model.FriendlyName; } }

		/// <summary>
		/// デバイスの識別子を取得します。
		/// </summary>
		public string Id { get { return this._model.Id; } }

		/// <summary>
		/// デバイスが開かれていることを示す値を取得します。
		/// </summary>
		public bool IsOpened { get { return this._model.IsOpened; } }

		/// <summary>
		/// モデル情報を取得します。
		/// </summary>
		public string Model { get { return this._model.Model; } }

		/// <summary>
		/// 製造番号を取得します。
		/// </summary>
		public string SerialNumber { get { return this._model.SerialNumber; } }

		/// <summary>
		/// デバイスの表示名。
		/// </summary>
		private string _displayName;

		/// <summary>
		/// サブ フォルダのコレクション。
		/// </summary>
		private ObservableCollection< PortableDeviceObjectViewModel > _folders;

		/// <summary>
		/// モデル。
		/// </summary>
		private PortableDevice _model;
	}
}
