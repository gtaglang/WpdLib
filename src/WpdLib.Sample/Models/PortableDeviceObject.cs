using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Livet;

namespace WpdLib.Sample.Models
{
	/// <summary>
	/// ポータブル デバイス上のオブジェクト ( ファイル・フォルダ ) を表します。
	/// </summary>
	sealed class PortableDeviceObject : NotificationObject
	{
		/// <summary>
		/// インスタンスを初期化します。
		/// </summary>
		/// <param name="obj">ポータブル デバイス上のオブジェクト情報。</param>
		public PortableDeviceObject( WpdObject obj )
		{
			this._object  = obj;
			this.IsFolder = ( obj.ContentType == WpdGuids.WPD_CONTENT_TYPE_FOLDER || obj.ContentType == WpdGuids.WPD_CONTENT_TYPE_FUNCTIONAL_OBJECT );
		}

		/// <summary>
		/// 子オブジェクトを列挙します。
		/// </summary>
		/// <returns></returns>
		public IEnumerable< PortableDeviceObject > EnumChildren()
		{
			foreach( var child in this._object.EnumChildren() )
			{
				yield return new PortableDeviceObject( child );
			}
		}

		/// <summary>
		/// オブジェクトの識別子を取得します。
		/// </summary>
		public string Id { get { return this._object.Id; } }

		/// <summary>
		/// オブジェクト名を取得します。
		/// </summary>
		public string Name { get { return this._object.Name; } }

		/// <summary>
		/// サイズを取得します。
		/// </summary>
		public ulong Size { get { return this._object.Size; } }

		/// <summary>
		/// フォルダであることを示す値を取得します。
		/// </summary>
		public bool IsFolder { get; private set; }

		/// <summary>
		/// ポータブル デバイス上のオブジェクト情報。
		/// </summary>
		private WpdObject _object;
	}
}
