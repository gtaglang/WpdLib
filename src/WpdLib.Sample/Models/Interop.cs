using System;
using System.Text;
using System.Runtime.InteropServices;

namespace WpdLib.Sample.Models
{
	/// <summary>
	/// ネイティブ API との相互運用を担当します。
	/// </summary>
	static class Interop
	{
		/// <summary>
		/// バイト数をあらわす整数値をサイズ文字列に変換します。
		/// </summary>
		/// <param name="fileSize">バイト数をあらわす整数値。</param>
		/// <param name="buffer">変換した文字列を格納するバッファ。</param>
		/// <param name="bufferSize">バッファのサイズ ( バイト数 )。</param>
		/// <returns>成功時は変換後の文字列ポインタ。それ以外は IntPtr.Zero。</returns>
		[DllImport( "shlwapi.dll", CharSet = CharSet.Auto )]
		public static extern IntPtr StrFormatByteSize( long fileSize, StringBuilder buffer, int bufferSize );
	}
}
