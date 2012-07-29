
namespace WpdLib
{
	/// <summary>
	/// ポータブル デバイスのプロパティ値の型を表します。
	/// </summary>
	public enum WpdPropertyValueType
	{
		/// <summary>
		/// 未知の型。
		/// </summary>
		Unknown = 0,

		/// <summary>
		/// 真偽値。
		/// </summary>
		Bool,

		/// <summary>
		/// 日時。
		/// </summary>
		DateTime,

		/// <summary>
		/// 浮動小数。
		/// </summary>
		Float,

		/// <summary>
		/// GUID。
		/// </summary>
		Guid,

		/// <summary>
		/// 符号付き 32 ビット整数。
		/// </summary>
		Int32,

		/// <summary>
		/// 符号付き 64 ビット整数。
		/// </summary>
		Int64,

		/// <summary>
		/// 符号なし 32 ビット整数。
		/// </summary>
		UInt32,

		/// <summary>
		/// 符号なし 64 ビット整数。
		/// </summary>
		UInt64,

		/// <summary>
		/// 文字列。
		/// </summary>
		String
	}

}
