
namespace WpdLib
{
	/// <summary>
	/// ポータブル デバイスの種別を表します。
	/// 値の内容は PortableDevice.h の WPD_DEVICE_TYPES 列挙体に対応しています。
	/// 
	/// WPD_DEVICE_TYPES enumeration : http://msdn.microsoft.com/en-us/library/windows/hardware/ff597867(v=vs.85).aspx
	/// </summary>
	public enum WpdDeviceType
	{
		/// <summary>
		/// 汎用。
		/// </summary>
		Generic = 0,

		/// <summary>
		/// カメラ。
		/// </summary>
		Camera = 1,

		/// <summary>
		/// メディア プレーヤー。
		/// </summary>
		MediaPlayer = 2,

		/// <summary>
		/// 電話。
		/// </summary>
		Phone = 3,

		/// <summary>
		/// ビデオ。
		/// </summary>
		Video = 4,

		/// <summary>
		/// 個人情報の管理用端末 ( PDA 的なもの？ )。
		/// </summary>
		PersonalInformationManager = 5,

		/// <summary>
		/// 録音機器。
		/// </summary>
		AudioRecoder = 6
	}
}
