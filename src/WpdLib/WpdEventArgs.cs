using System;
using System.Collections.Generic;
using PortableDeviceApiLib;

namespace WpdLib
{
	/// <summary>
	/// ポータブル デバイス上で発生したイベントのデータを格納します。
	/// </summary>
	public sealed class WpdEventArgs : EventArgs
	{
		/// <summary>
		/// インスタンスを初期化します。
		/// </summary>
		/// <param name="values">イベント データのコレクション。</param>
		internal WpdEventArgs( IPortableDeviceValues values )
		{
			uint count = 0;
			values.GetCount( ref count );
			if( count < 1 )
			{
				this.Values = new List< WpdPropertyValue >( 0 );
				return;
			}

			this.Values = new List< WpdPropertyValue >( ( int )count );
			var key     = new _tagpropertykey();
			var info    = new tag_inner_PROPVARIANT();

			for( uint i = 0; i < count; ++i )
			{
				values.GetAt( i, ref key, ref info );

				var value = new WpdPropertyValue( key, info, values );
				if( value.Key.Equals( WpdProperties.WPD_EVENT_PARAMETER_PNP_DEVICE_ID ) )
				{
					this.DeviceId = value.ValueString;
				}
				else if( value.Key.Equals( WpdProperties.WPD_OBJECT_ID ) )
				{
					this.ObjectId = value.ValueString;
				}
				else if( value.Key.Equals( WpdProperties.WPD_OBJECT_PARENT_ID ) )
				{
					this.ParentObjectId = value.ValueString;
				}
				else if( value.Key.Equals( WpdProperties.WPD_EVENT_PARAMETER_EVENT_ID ) )
				{
					if( value.ValueGuid != null ) { this.Type = TypeConvertUtility.GuidToEventType( value.ValueGuid.Value ); }
				}
				else
				{
					this.Values.Add( value );
				}
			}
		}

		/// <summary>
		/// イベントの発生したデバイスの識別子を取得します。
		/// </summary>
		public string DeviceId { get; private set; }

		/// <summary>
		/// イベント発生対象のオブジェクト識別子を取得します。
		/// </summary>
		public string ObjectId { get; private set; }

		/// <summary>
		/// イベント発生対象の親オブジェクトの識別子を取得します。
		/// </summary>
		public string ParentObjectId { get; private set; }

		/// <summary>
		/// イベント種別を取得します。
		/// </summary>
		public WpdEventType Type { get; private set; }

		/// <summary>
		/// イベント データのコレクションを取得します。
		/// </summary>
		public List< WpdPropertyValue > Values { get; private set; }
	}
}
