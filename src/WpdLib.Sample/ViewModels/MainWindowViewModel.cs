using System.Collections.ObjectModel;
using Livet;
using WpdLib.Sample.Models;
using System.Windows;

namespace WpdLib.Sample.ViewModels
{
	/// <summary>
	/// メイン ウィンドウの ViewModel です。
	/// </summary>
	sealed class MainWindowViewModel : ViewModel
	{
		/// <summary>
		/// インスタンスを初期化します。
		/// </summary>
		public void Initialize()
		{
			this._client = new WpdClient( ResUtility.GetString( "Strings.Common.AppName" ), 1, 0 );
			this.Devices = new ObservableCollection< PortableDeviceViewModel >();
		}

		/// <summary>
		/// デバイスを列挙します。
		/// </summary>
		public void EnumDevice()
		{
			this.Devices.Clear();
			foreach( var device in PortableDevice.EnumDevice( this._client ) )
			{
				this.Devices.Add( new PortableDeviceViewModel( device ) );
			}

			this.RaisePropertyChanged( "Devices" );

			if( this.Devices.Count == 0 )
			{
				MessageBox.Show( ResUtility.GetString( "Strings.Message.DeviceNotFound" ), ResUtility.GetString( "Strings.Common.Info" ), MessageBoxButton.OK, MessageBoxImage.Information );
			}
		}

		/// <summary>
		/// リソースを破棄します。
		/// </summary>
		/// <param name="disposing"></param>
		protected override void Dispose( bool disposing )
		{
			base.Dispose( disposing );

			foreach( var device in this.Devices )
			{
				device.Dispose();
			}
		}

		/// <summary>
		/// ポータブル デバイスのコレクションを取得します。
		/// </summary>
		public ObservableCollection< PortableDeviceViewModel > Devices { get; private set; }

		/// <summary>
		/// ポータブル デバイスに接続するクライアント情報。
		/// </summary>
		private WpdClient _client;
	}
}
