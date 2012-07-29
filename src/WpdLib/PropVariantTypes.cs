
namespace WpdLib
{
	/// <summary>
	/// tag_inner_PROPVARIANT.vt の示す型を表します。
	/// PROPVARIANT structure : http://msdn.microsoft.com/en-us/library/windows/desktop/aa380072(v=vs.85).aspx
	/// </summary>
	enum PropVariantTypes
	{
		/// <summary>
		/// 値が設定されていない。
		/// </summary>
		VT_EMPTY = 0,

		/// <summary>
		/// 値は null 参照。
		/// </summary>
		VT_NULL = 1,

		/// <summary>
		/// 符号付き 16 ビット ( 2 byte ) 整数。
		/// </summary>
		VT_I2 = 2,

		/// <summary>
		/// 符号付き 32 ビット ( 4 byte ) 整数。
		/// </summary>
		VT_I4 = 3,

		/// <summary>
		/// 32 ビット ( 4 byte ) 浮動小数。
		/// </summary>
		VT_R4 = 4,

		/// <summary>
		/// 64 ビット ( 8 byte ) 浮動小数。
		/// </summary>
		VT_R8 = 5,

		/// <summary>
		/// 64 ビット ( 8 byte ) 整数を 2 連結して表現 ( 10,000 スケール ) される、通貨 ( Currency ) 単位型。
		/// </summary>
		VT_CY = 6,

		/// <summary>
		/// 日時。
		/// </summary>
		VT_DATE = 7,

		/// <summary>
		/// NULL 終端 Unicode 文字列。
		/// </summary>
		VT_BSTR = 8,

		/// <summary>
		/// IDispatch インターフェイスのポインタ。
		/// </summary>
		VT_DISPATCH = 9,

		/// <summary>
		/// エラー情報を示す DWORD 値。
		/// </summary>
		VT_ERROR = 10,

		/// <summary>
		/// 真偽値を表す WORD 値。
		/// </summary>
		VT_BOOL = 11,

		/// <summary>
		/// 汎用型。
		/// </summary>
		VT_VARIANT = 12,

		/// <summary>
		/// IUnknown インターフェイスのポインタ。
		/// </summary>
		VT_UNKNOWN = 13,

		/// <summary>
		/// 符号付き 96 ビット ( 12 byte ) 実数。
		/// </summary>
		VT_DECIMAL = 14,

		/// <summary>
		/// 符号付き 8 ビット ( 1 byte ) 整数。
		/// </summary>
		VT_I1 = 16,

		/// <summary>
		/// 符号なし 8 ビット ( 1 byte ) 整数。
		/// </summary>
		VT_UI1 = 17,

		/// <summary>
		/// 符号なし 16 ビット ( 2 byte ) 整数。
		/// </summary>
		VT_UI2 = 18,

		/// <summary>
		/// 符号なし 32 ビット ( 4 byte ) 整数。
		/// </summary>
		VT_UI4 = 19,

		/// <summary>
		/// 符号付き 64 ビット ( 8 byte ) 整数。
		/// </summary>
		VT_I8 = 20,

		/// <summary>
		/// 符号なし 64 ビット ( 8 byte ) 整数。
		/// </summary>
		VT_UI8 = 21,

		/// <summary>
		/// 符号付き 32 ビット ( 4 byte ) 整数。VT_I4 に相当する。
		/// </summary>
		VT_INT = 22,

		/// <summary>
		/// 符号なし 32 ビット ( 4 byte ) 整数。VT_UI4 に相当する。
		/// </summary>
		VT_UINT = 23,

		/// <summary>
		/// void ポインター。
		/// </summary>
		VT_VOID = 24,

		/// <summary>
		/// HRESULT ( LONG )。
		/// </summary>
		VT_HRESULT = 25,

		/// <summary>
		/// void ポインター。
		/// </summary>
		VT_PTR = 26,

		/// <summary>
		/// 配列。
		/// </summary>
		VT_SAFEARRAY = 27,

		/// <summary>
		/// 固定長 ( C は Constans の略？ ) 配列。
		/// </summary>
		VT_CARRAY = 28,

		/// <summary>
		/// ユーザー定義型。
		/// </summary>
		VT_USERDEFINED = 29,

		/// <summary>
		/// NULL 終端 ANSI ( システム依存のコード ページ ) 文字列。
		/// </summary>
		VT_LPSTR = 30,

		/// <summary>
		/// NULL 終端 Unicode 文字列。
		/// </summary>
		VT_LPWSTR = 31,

		/// <summary>
		/// FILETIME 構造体。
		/// </summary>
		VT_FILETIME = 64,

		/// <summary>
		/// 値のサイズ ( byte 数 ) となる DWORD 値。
		/// </summary>
		VT_BLOB = 65,

		/// <summary>
		/// IStream インターフェースのポインタ。
		/// </summary>
		VT_STREAM = 66,

		/// <summary>
		/// IStorege インターフェースのポインタ。
		/// </summary>
		VT_STORAGE = 67,

		/// <summary>
		/// シリアライズされたオブジェクトを含む IStream インタフェースのポインタ。
		/// </summary>
		VT_STREAMED_OBJECT = 68,

		/// <summary>
		/// シリアライズされたオブジェクトを含む IStorege インタフェースのポインタ。
		/// </summary>
		VT_STORED_OBJECT = 69,

		/// <summary>
		/// シリアライズされたオブジェクトに含まれる、BOLB データ。
		/// </summary>
		VT_BLOB_OBJECT = 70,

		/// <summary>
		/// CLIPDATA 構造体のポインタ。
		/// </summary>
		VT_CF = 71,

		/// <summary>
		/// COM のクラス識別子 ( CLSID )。
		/// </summary>
		VT_CLSID = 72,

		/// <summary>
		/// ベクター型。詳しくは以下を参照のこと。
		/// ベクター型の取得 (Windows) : http://msdn.microsoft.com/ja-jp/library/ee264327(v=vs.85).aspx
		/// </summary>
		VT_VECTOR = 0x1000
	}
}
