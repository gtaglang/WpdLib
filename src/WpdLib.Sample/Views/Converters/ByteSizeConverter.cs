using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Globalization;
using WpdLib.Sample.Models;

namespace WpdLib.Sample.Views.Converters
{
	/// <summary>
	/// サイズ ( バイト単位 ) と文字列の相互変換をおこないます。
	/// </summary>
	[ValueConversion( typeof( long ), typeof( String ) )]
	sealed class ByteSizeConverter : IValueConverter
	{
		/// <summary>
		/// サイズ ( バイト単位 ) を文字列に変換します。
		/// </summary>
		/// <param name="value">変換するデータ。</param>
		/// <param name="targetType">変換する型。</param>
		/// <param name="parameter">パラメータ。</param>
		/// <param name="culture">カルチャー情報。</param>
		/// <returns>変換したデータ。</returns>
		public object Convert( object value, Type targetType, object parameter, CultureInfo culture )
		{
			return ByteSizeToString( ( long )value );
		}

		/// <summary>
		/// 文字列をサイズ ( バイト単位 ) に変換します。
		/// </summary>
		/// <param name="value">変換するデータ。</param>
		/// <param name="targetType">変換する型。</param>
		/// <param name="parameter">パラメータ。</param>
		/// <param name="culture">カルチャー情報。</param>
		/// <returns>変換したデータ。</returns>
		public object ConvertBack( object value, Type targetType, object parameter, CultureInfo culture )
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// サイズ ( バイト単位 ) を文字列に変換します。
		/// </summary>
		/// <param name="size">サイズ ( バイト単位 )。</param>
		/// <returns>文字列。</returns>
		public static string ByteSizeToString( long size )
		{
			var builder = new StringBuilder( 32 );
			var result = Interop.StrFormatByteSize( size, builder, 32 );
			return ( result == IntPtr.Zero ? String.Format( "{0}Byte(s)", size ) : builder.ToString() );
		}
	}
}
