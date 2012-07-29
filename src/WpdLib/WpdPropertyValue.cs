using System;
using System.Collections.Generic;
using System.Diagnostics;
using PortableDeviceApiLib;

namespace WpdLib
{
	/// <summary>
	/// ポータブル デバイス上のオブジェクトが持つプロパティ値を表します。
	/// </summary>
	public sealed class WpdPropertyValue
	{
		/// <summary>
		/// インスタンスを初期化します。
		/// </summary>
		/// <param name="key">識別子。</param>
		/// <param name="info">プロパティ値の情報。</param>
		/// <param name="values">値。</param>
		internal WpdPropertyValue( _tagpropertykey key, tag_inner_PROPVARIANT info, IPortableDeviceValues values )
		{
			this.Key      = key;
			this.HasValue = true;

			switch( ( PropVariantTypes )info.vt )
			{
			case PropVariantTypes.VT_BOOL:
				this.Type      = WpdPropertyValueType.Bool;
				this.ValueBool = WpdPropertyValue.ReadBool( key, values );
				break;

			case PropVariantTypes.VT_DATE:
				this.Type          = WpdPropertyValueType.DateTime;
				this.ValueDateTime = WpdPropertyValue.ReadDateTime( key, values );
				break;

			case PropVariantTypes.VT_CLSID:
				this.Type      = WpdPropertyValueType.Guid;
				this.ValueGuid = WpdPropertyValue.ReadGuid( key, values );
				break;

			case PropVariantTypes.VT_I4:
				this.Type       = WpdPropertyValueType.Int32;
				this.ValueInt32 = WpdPropertyValue.ReadInt32( key, values );
				break;

			case PropVariantTypes.VT_I8:
				this.Type       = WpdPropertyValueType.Int64;
				this.ValueInt64 = WpdPropertyValue.ReadInt64( key, values );
				break;

			case PropVariantTypes.VT_BSTR:
			case PropVariantTypes.VT_LPSTR:
			case PropVariantTypes.VT_LPWSTR:
				this.Type        = WpdPropertyValueType.String;
				this.ValueString = WpdPropertyValue.ReadString( key, values );
				break;

			case PropVariantTypes.VT_UI4:
				this.Type        = WpdPropertyValueType.UInt32;
				this.ValueUInt32 = WpdPropertyValue.ReadUInt32( key, values );
				break;

			case PropVariantTypes.VT_UI8:
				this.Type        = WpdPropertyValueType.UInt64;
				this.ValueUInt64 = WpdPropertyValue.ReadUInt64( key, values );
				break;

			default:
				this.Type     = WpdPropertyValueType.Unknown;
				this.HasValue = false;
				break;
			}
		}

		/// <summary>
		/// オブジェクトのプロパティ値を列挙します。
		/// </summary>
		/// <param name="id">オブジェクトの識別子。</param>
		/// <param name="properties">プロパティ情報。</param>
		/// <returns>プロパティ値のコレクション。</returns>
		internal static IEnumerable< WpdPropertyValue > EnumValues( string id, IPortableDeviceProperties properties )
		{
			IPortableDeviceKeyCollection keys;
			properties.GetSupportedProperties( id, out keys );

			IPortableDeviceValues values;
			properties.GetValues( id, keys, out values );

			uint count = 0;
			values.GetCount( ref count );

			var key  = new _tagpropertykey();
			var info = new tag_inner_PROPVARIANT();

			for( uint i = 0; i < count; ++i )
			{
				values.GetAt( i, ref key, ref info );
				yield return new WpdPropertyValue( key, info, values );
			}
		}

		/// <summary>
		/// プロパティ値から、真偽値を読み取ります。
		/// </summary>
		/// <param name="key">識別子。</param>
		/// <param name="values">プロパティ値。</param>
		/// <returns>成功時は読み取った値。それ以外は null。</returns>
		public static bool? ReadBool( _tagpropertykey key, IPortableDeviceValues values )
		{
			try
			{
				int value;
				values.GetBoolValue( key, out value );
				return ( value != 0 );
			}
			catch( Exception exp )
			{
				Debug.WriteLine( exp.Message );
				return null;
			}
		}

		/// <summary>
		/// プロパティ値から、日時値を読み取ります。
		/// </summary>
		/// <param name="key">識別子。</param>
		/// <param name="values">プロパティ値。</param>
		/// <returns>成功時は読み取った値。それ以外は null。</returns>
		public static DateTime? ReadDateTime( _tagpropertykey key, IPortableDeviceValues values )
		{
			try
			{
				float value;
				values.GetFloatValue( ref key, out value );
				return DateTime.FromOADate( value );
			}
			catch( Exception exp )
			{
				Debug.WriteLine( exp.Message );
				return null;
			}
		}

		/// <summary>
		/// プロパティ値から、GUID 値を読み取ります。
		/// </summary>
		/// <param name="key">識別子。</param>
		/// <param name="values">プロパティ値。</param>
		/// <returns>成功時は読み取った値。それ以外は null。</returns>
		public static Guid? ReadGuid( _tagpropertykey key, IPortableDeviceValues values )
		{
			try
			{
				Guid value;
				values.GetGuidValue( key, out value );
				return value;
			}
			catch( Exception exp )
			{
				Debug.WriteLine( exp.Message );
				return null;
			}
		}

		/// <summary>
		/// プロパティ値から、符号付き 32 ビット整数値を読み取ります。
		/// </summary>
		/// <param name="key">識別子。</param>
		/// <param name="values">プロパティ値。</param>
		/// <returns>成功時は読み取った値。それ以外は null。</returns>
		public static int? ReadInt32( _tagpropertykey key, IPortableDeviceValues values )
		{
			try
			{
				int value;
				values.GetSignedIntegerValue( key, out value );
				return value;
			}
			catch( Exception exp )
			{
				Debug.WriteLine( exp.Message );
				return null;
			}
		}

		/// <summary>
		/// プロパティ値から、符号付き 64 ビット整数値を読み取ります。
		/// </summary>
		/// <param name="key">識別子。</param>
		/// <param name="values">プロパティ値。</param>
		/// <returns>成功時は読み取った値。それ以外は null。</returns>
		public static long? ReadInt64( _tagpropertykey key, IPortableDeviceValues values )
		{
			try
			{
				long value;
				values.GetSignedLargeIntegerValue( key, out value );
				return value;
			}
			catch( Exception exp )
			{
				Debug.WriteLine( exp.Message );
				return null;
			}
		}

		/// <summary>
		/// プロパティ値から、文字列値を読み取ります。
		/// </summary>
		/// <param name="key">識別子。</param>
		/// <param name="values">プロパティ値。</param>
		/// <returns>成功時は読み取った値。それ以外は null。</returns>
		public static string ReadString( _tagpropertykey key, IPortableDeviceValues values )
		{
			try
			{
				string value;
				values.GetStringValue( key, out value );
				return String.IsNullOrEmpty( value ) ? String.Empty : value;
			}
			catch( Exception exp )
			{
				Debug.WriteLine( exp.Message );
				return String.Empty;
			}
		}

		/// <summary>
		/// プロパティ値から、符号なし 32 ビット整数値を読み取ります。
		/// </summary>
		/// <param name="key">識別子。</param>
		/// <param name="values">プロパティ値。</param>
		/// <returns>成功時は読み取った値。それ以外は null。</returns>
		public static uint? ReadUInt32( _tagpropertykey key, IPortableDeviceValues values )
		{
			try
			{
				uint value;
				values.GetUnsignedIntegerValue( key, out value );
				return value;
			}
			catch( Exception exp )
			{
				Debug.WriteLine( exp.Message );
				return null;
			}
		}

		/// <summary>
		/// プロパティ値から、符号なし 64 ビット整数値を読み取ります。
		/// </summary>
		/// <param name="key">識別子。</param>
		/// <param name="values">プロパティ値。</param>
		/// <returns>成功時は読み取った値。それ以外は null。</returns>
		public static ulong? ReadUInt64( _tagpropertykey key, IPortableDeviceValues values )
		{
			try
			{
				ulong value;
				values.GetUnsignedLargeIntegerValue( key, out value );
				return value;
			}
			catch( Exception exp )
			{
				Debug.WriteLine( exp.Message );
				return null;
			}
		}

		/// <summary>
		/// 値を所持していることを示す値を取得します。
		/// </summary>
		public bool HasValue { get; private set; }

		/// <summary>
		/// プロパティの識別子を取得します。
		/// </summary>
		public _tagpropertykey Key { get; private set; }

		/// <summary>
		/// 値の型を取得します。
		/// </summary>
		public WpdPropertyValueType Type { get; private set; }

		/// <summary>
		/// 真偽値を取得します。
		/// </summary>
		public bool? ValueBool { get; private set; }

		/// <summary>
		/// 日時を取得します。
		/// </summary>
		public DateTime? ValueDateTime { get; private set; }

		/// <summary>
		/// 浮動小数を取得します。
		/// </summary>
		public float? ValueFloat { get; private set; }

		/// <summary>
		/// GUID を取得します。
		/// </summary>
		public Guid? ValueGuid { get; private set; }

		/// <summary>
		/// 符号付き 32 ビット整数を取得します。
		/// </summary>
		public int? ValueInt32 { get; private set; }


		/// <summary>
		/// 符号付き 64 ビット整数を取得します。
		/// </summary>
		public long? ValueInt64 { get; private set; }

		/// <summary>
		/// 文字列を取得します。
		/// </summary>
		public string ValueString { get; private set; }

		/// <summary>
		/// 符号なし 32 ビット整数を取得します。
		/// </summary>
		public uint? ValueUInt32 { get; private set; }

		/// <summary>
		/// 符号なし 64 ビット整数を取得します。
		/// </summary>
		public ulong? ValueUInt64 { get; private set; }
	}
}
