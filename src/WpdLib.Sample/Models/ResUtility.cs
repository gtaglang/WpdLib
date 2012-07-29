
namespace WpdLib.Sample.Models
{
	/// <summary>
	/// リソースに関するユーティリティです。
	/// </summary>
	static class ResUtility
	{
		/// <summary>
		/// リソースから文字列を取得します。
		/// </summary>
		/// <param name="id">リソース識別子。</param>
		/// <returns>成功時は文字列。それ以外は false。</returns>
		public static string GetString( string id )
		{
			return ( App.Current.Resources[ id ] as string );
		}
	}
}
