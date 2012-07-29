using System;
using PortableDeviceApiLib;

namespace WpdLib
{
	/// <summary>
	/// ポータブル デバイスに接続しているクライアント情報を表します。
	/// </summary>
	public sealed class WpdClient
	{
		/// <summary>s
		/// インスタンスを初期化します。
		/// </summary>
		/// <param name="name">クライアント名。</param>
		/// <param name="majorVersion">クライアントのメジャー バージョン。</param>
		/// <param name="minorVersion">クライアントのマイナー バージョン。</param>
		/// <exception cref="ArgumentException">name が null 参照、もしくは空文字です。</exception>
		public WpdClient( string name, float majorVersion, float minorVersion )
		{
			if( String.IsNullOrEmpty( name ) ) { throw new ArgumentException( "'name' is null or empty." ); }

			this.Name         = name;
			this.MajorVersion = majorVersion;
			this.MinorVersion = minorVersion;
		}

		/// <summary>
		/// デバイスを操作するためのプロパティ情報を生成します。
		/// </summary>
		/// <returns>プロパティ情報。</returns>
		internal IPortableDeviceValues CreateDeviceValue()
		{
			var client = ( IPortableDeviceValues )( new PortableDeviceTypesLib.PortableDeviceValuesClass() );
			{
				var key = WpdProperties.WPD_CLIENT_NAME;
				client.SetStringValue( ref key, this.Name );

				key = WpdProperties.WPD_CLIENT_MAJOR_VERSION;
				client.SetFloatValue( ref key, this.MajorVersion );

				key = WpdProperties.WPD_CLIENT_MINOR_VERSION;
				client.SetFloatValue( ref key, this.MinorVersion );
			}

			return client;
		}

		/// <summary>
		/// クライアント名を取得します。
		/// </summary>
		public string Name { get; private set; }

		/// <summary>
		/// クライアントのメジャー バージョンを取得します。
		/// </summary>
		public float MajorVersion { get; private set; }

		/// <summary>
		/// クライアントのマイナー バージョンを取得します。
		/// </summary>
		public float MinorVersion { get; private set; }
	}
}
