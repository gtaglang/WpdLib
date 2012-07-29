
namespace WpdLib
{
	/// <summary>
	/// ストレージ種別を表します。
	/// 値の内容は WPD_STORAGE_TYPE_VALUES に対応しています。
	/// </summary>
	public enum WpdStorageType
	{
		/// <summary>
		/// 未知のストレージ。
		/// </summary>
		Unknown = 0,

		/// <summary>
		/// 読み取り専用の固定ストレージ。
		/// </summary>
		FixedROM = 1,

		/// <summary>
		/// 読み取り専用のリムーバブル ストレージ。
		/// </summary>
		RemovableROM = 2,

		/// <summary>
		/// 読み書き可能な固定ストレージ。
		/// </summary>
		FixedRAM = 3,

		/// <summary>
		/// 読み書き可能なリムーバブル ストレージ。
		/// </summary>
		RemovableRAM = 4,
	}
}
