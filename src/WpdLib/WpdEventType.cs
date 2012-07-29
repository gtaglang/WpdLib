using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpdLib
{
	/// <summary>
	/// ポータブル デバイスのイベント種別を定義します。
	/// </summary>
	public enum WpdEventType
	{
		/// <summary>
		/// 未知のイベント。
		/// </summary>
		Unknown,

		/// <summary>
		/// オブジェクトが追加された。
		/// </summary>
		ObjectAdded,

		/// <summary>
		/// オブジェクトが削除された。
		/// </summary>
		ObjectRemoved,

		/// <summary>
		/// オブジェクトが更新された。
		/// </summary>
		ObjectUpdated,

		/// <summary>
		/// オブジェクトの転送を要求された。
		/// </summary>
		ObjectTransferRequested,

		/// <summary>
		/// デバイスがリセットされた。
		/// </summary>
		DeviceReset,

		/// <summary>
		/// デバイスの機能が更新された。
		/// </summary>
		DeviceCapabilitiesUpdated,

		/// <summary>
		/// デバイスが削除された。
		/// </summary>
		DeviceRemoved,

		/// <summary>
		/// 通知がおこなわれた。
		/// </summary>
		Notification,

		/// <summary>
		/// ストレージがフォーマットされた。
		/// </summary>
		StorageFormat
	}


}
