using System;
using System.Collections.Generic;
using PortableDeviceApiLib;

namespace WpdLib
{
	/// <summary>
	/// ポータブル デバイスのオブジェクトを表します。
	/// </summary>
	public sealed class WpdObject
	{
		/// インスタンスを初期化します。
		/// </summary>
		/// <param name="id">オブジェクトの識別子。</param>
		/// <param name="client">デバイスに接続しているクライアント情報。</param>
		/// <param name="content">デバイスのコンテンツ情報。</param>
		/// <param name="properties">プロパティ。</param>
		internal WpdObject( string id, WpdClient client, IPortableDeviceContent content, IPortableDeviceProperties properties )
		{
			this.Id          = id;
			this._client     = client;
			this._content    = content;
			this._properties = properties;

			// プロパティ更新
			this.UpdateValues();
		}

		/// <summary>
		/// 子オブジェクトを列挙します。
		/// </summary>
		/// <returns></returns>
		public IEnumerable< WpdObject > EnumChildren()
		{
			IPortableDeviceProperties properties;
			this._content.Properties( out properties );

			IEnumPortableDeviceObjectIDs objects;
			this._content.EnumObjects( 0, this.Id, null, out objects );

			var children = new List< WpdObject >();
			uint fetched = 0;
			do
			{
				string id;
				objects.Next( 1, out id, ref fetched );
				if( fetched > 0 )
				{
					children.Add( new WpdObject( id, this._client, this._content, properties ) );
				}
			}
			while( fetched > 0 );

			return children;
		}

		/// <summary>
		/// 最新のプロパティ情報を列挙します。
		/// </summary>
		/// <param name="isUpdate">列挙したプロパティの内容を現在のインスタンスに反映するなら true。しない場合は false。</param>
		public void UpdateValues()
		{
			foreach( var value in WpdPropertyValue.EnumValues( this.Id, this._properties ) )
			{
				if( value.Key.Equals( WpdProperties.WPD_OBJECT_NAME ) )
				{
					this.Name = value.ValueString;
				}
				else if( value.Key.Equals( WpdProperties.WPD_OBJECT_CONTENT_TYPE ) )
				{
					if( value.ValueGuid != null ) { this.ContentType = value.ValueGuid.Value; }
				}
				else if( value.Key.Equals( WpdProperties.WPD_OBJECT_FORMAT ) )
				{
					if( value.ValueGuid != null ) { this.Format = value.ValueGuid.Value; }
				}
				else if( value.Key.Equals( WpdProperties.WPD_OBJECT_SIZE ) )
				{
					if( value.ValueUInt64 != null ) { this.Size = value.ValueUInt64.Value; }
				}
			}
		}

		/// <summary>
		/// コンテンツ種別 ( Guids.WPD_CONTENT_TYPE_～ 系の定数に対応 ) を取得します。
		/// </summary>
		public Guid ContentType { get; private set; }

		/// <summary>
		/// フォーマット情報 ( Guids.WPD_OBJECT_FORMAT_～ 系の定数に対応 ) を取得します。
		/// </summary>
		public Guid Format { get; private set; }

		/// <summary>
		/// オブジェクトの識別子を取得します。
		/// </summary>
		public string Id { get; private set; }

		/// <summary>
		/// オブジェクト名を取得します。
		/// </summary>
		public string Name { get; private set; }

		/// <summary>
		/// サイズを取得します。
		/// </summary>
		public ulong Size { get; private set; }

		/// <summary>
		/// デバイスに接続しているクライアント情報。
		/// </summary>
		private WpdClient _client;

		/// <summary>
		/// デバイスのコンテンツ情報。
		/// </summary>
		private IPortableDeviceContent _content;

		/// <summary>
		/// プロパティ。
		/// </summary>
		private IPortableDeviceProperties _properties;
	}
}
