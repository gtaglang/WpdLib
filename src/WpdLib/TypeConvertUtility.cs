using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpdLib
{
	/// <summary>
	/// 型変換に関するユーティリティです。
	/// </summary>
	static class TypeConvertUtility
	{
		/// <summary>
		/// GUID をデバイスのイベント種別に変換します。
		/// </summary>
		/// <param name="guid">GUID。</param>
		/// <returns>イベント種別。</returns>
		public static WpdEventType GuidToEventType( Guid guid )
		{
			if(      guid.Equals( WpdGuids.WPD_EVENT_DEVICE_CAPABILITIES_UPDATED ) ) { return WpdEventType.DeviceCapabilitiesUpdated; }
			else if( guid.Equals( WpdGuids.WPD_EVENT_DEVICE_REMOVED              ) ) { return WpdEventType.DeviceRemoved;             }
			else if( guid.Equals( WpdGuids.WPD_EVENT_DEVICE_RESET                ) ) { return WpdEventType.DeviceReset;               }
			else if( guid.Equals( WpdGuids.WPD_EVENT_NOTIFICATION                ) ) { return WpdEventType.Notification;              }
			else if( guid.Equals( WpdGuids.WPD_EVENT_OBJECT_ADDED                ) ) { return WpdEventType.ObjectAdded;               }
			else if( guid.Equals( WpdGuids.WPD_EVENT_OBJECT_REMOVED              ) ) { return WpdEventType.ObjectRemoved;             }
			else if( guid.Equals( WpdGuids.WPD_EVENT_OBJECT_TRANSFER_REQUESTED   ) ) { return WpdEventType.ObjectTransferRequested;   }
			else if( guid.Equals( WpdGuids.WPD_EVENT_OBJECT_UPDATED              ) ) { return WpdEventType.ObjectUpdated;             }
			else if( guid.Equals( WpdGuids.WPD_EVENT_STORAGE_FORMAT              ) ) { return WpdEventType.StorageFormat;             }

			return WpdEventType.Unknown;
		}
	}
}
