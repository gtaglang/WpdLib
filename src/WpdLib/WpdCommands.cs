using System;
using PortableDeviceApiLib;

namespace WpdLib
{
	/// <summary>
	/// Windows Portable Device のコマンド種別を定義します。
	/// 値の内容は Windows SDK v7.0A の PortableDevice.h を基準としています。
	/// </summary>
	public static class WpdCommands
	{
		// Supporting the Property Commands
		// http://msdn.microsoft.com/en-us/library/windows/hardware/ff597705(v=vs.85).aspx
		//
		public static readonly _tagpropertykey WPD_COMMAND_OBJECT_PROPERTIES_GET = new _tagpropertykey() { fmtid = new Guid( 0x9E5582E4, 0x0814, 0x44E6, 0x98, 0x1A, 0xB2, 0x99, 0x8D, 0x58, 0x38, 0x04 ), pid = 4 };
		public static readonly _tagpropertykey WPD_COMMAND_OBJECT_PROPERTIES_GET_ALL = new _tagpropertykey() { fmtid = new Guid( 0x9E5582E4, 0x0814, 0x44E6, 0x98, 0x1A, 0xB2, 0x99, 0x8D, 0x58, 0x38, 0x04 ), pid = 6 };
		public static readonly _tagpropertykey WPD_COMMAND_OBJECT_PROPERTIES_GET_ATTRIBUTES = new _tagpropertykey() { fmtid = new Guid( 0x9E5582E4, 0x0814, 0x44E6, 0x98, 0x1A, 0xB2, 0x99, 0x8D, 0x58, 0x38, 0x04 ), pid = 3 };
		public static readonly _tagpropertykey WPD_COMMAND_OBJECT_PROPERTIES_GET_SUPPORTED = new _tagpropertykey() { fmtid = new Guid( 0x9E5582E4, 0x0814, 0x44E6, 0x98, 0x1A, 0xB2, 0x99, 0x8D, 0x58, 0x38, 0x04 ), pid = 2 };
		public static readonly _tagpropertykey WPD_COMMAND_OBJECT_PROPERTIES_DELETE = new _tagpropertykey() { fmtid = new Guid( 0x9E5582E4, 0x0814, 0x44E6, 0x98, 0x1A, 0xB2, 0x99, 0x8D, 0x58, 0x38, 0x04 ), pid = 7 };
		public static readonly _tagpropertykey WPD_COMMAND_OBJECT_PROPERTIES_SET = new _tagpropertykey() { fmtid = new Guid( 0x9E5582E4, 0x0814, 0x44E6, 0x98, 0x1A, 0xB2, 0x99, 0x8D, 0x58, 0x38, 0x04 ), pid = 5 };

		// Supporting the Property Range Attributes
		// http://msdn.microsoft.com/en-us/library/windows/hardware/ff597701(v=vs.85).aspx
		//
		public static readonly _tagpropertykey WPD_COMMAND_OBJECT_ENUMERATION_END_FIND = new _tagpropertykey() { fmtid = new Guid( 0xB7474E91, 0xE7F8, 0x4AD9, 0xB4, 0x00, 0xAD, 0x1A, 0x4B, 0x58, 0xEE, 0xEC ), pid = 4 };
		public static readonly _tagpropertykey WPD_COMMAND_OBJECT_ENUMERATION_FIND_NEXT = new _tagpropertykey() { fmtid = new Guid( 0xB7474E91, 0xE7F8, 0x4AD9, 0xB4, 0x00, 0xAD, 0x1A, 0x4B, 0x58, 0xEE, 0xEC ), pid = 3 };
		public static readonly _tagpropertykey WPD_COMMAND_OBJECT_ENUMERATION_START_FIND = new _tagpropertykey() { fmtid = new Guid( 0xB7474E91, 0xE7F8, 0x4AD9, 0xB4, 0x00, 0xAD, 0x1A, 0x4B, 0x58, 0xEE, 0xEC ), pid = 2 };

		// Supporting the Capability Commands
		// http://msdn.microsoft.com/en-us/library/windows/hardware/ff597702(v=vs.85).aspx
		//
		public static readonly _tagpropertykey WPD_COMMAND_CAPABILITIES_GET_COMMAND_OPTIONS = new _tagpropertykey() { fmtid = new Guid( 0x0CABEC78, 0x6B74, 0x41C6, 0x92, 0x16, 0x26, 0x39, 0xD1, 0xFC, 0xE3, 0x56 ), pid = 3 };
		public static readonly _tagpropertykey WPD_COMMAND_CAPABILITIES_GET_EVENT_OPTIONS = new _tagpropertykey() { fmtid = new Guid( 0x0CABEC78, 0x6B74, 0x41C6, 0x92, 0x16, 0x26, 0x39, 0xD1, 0xFC, 0xE3, 0x56 ), pid = 11 };
		public static readonly _tagpropertykey WPD_COMMAND_CAPABILITIES_GET_FIXED_PROPERTY_ATTRIBUTES = new _tagpropertykey() { fmtid = new Guid( 0x0CABEC78, 0x6B74, 0x41C6, 0x92, 0x16, 0x26, 0x39, 0xD1, 0xFC, 0xE3, 0x56 ), pid = 9 };
		public static readonly _tagpropertykey WPD_COMMAND_CAPABILITIES_GET_FUNCTIONAL_OBJECTS = new _tagpropertykey() { fmtid = new Guid( 0x0CABEC78, 0x6B74, 0x41C6, 0x92, 0x16, 0x26, 0x39, 0xD1, 0xFC, 0xE3, 0x56 ), pid = 5 };
		public static readonly _tagpropertykey WPD_COMMAND_CAPABILITIES_GET_SUPPORTED_COMMANDS = new _tagpropertykey() { fmtid = new Guid( 0x0CABEC78, 0x6B74, 0x41C6, 0x92, 0x16, 0x26, 0x39, 0xD1, 0xFC, 0xE3, 0x56 ), pid = 2 };
		public static readonly _tagpropertykey WPD_COMMAND_CAPABILITIES_GET_SUPPORTED_CONTENT_TYPES = new _tagpropertykey() { fmtid = new Guid( 0x0CABEC78, 0x6B74, 0x41C6, 0x92, 0x16, 0x26, 0x39, 0xD1, 0xFC, 0xE3, 0x56 ), pid = 6 };
		public static readonly _tagpropertykey WPD_COMMAND_CAPABILITIES_GET_SUPPORTED_EVENTS = new _tagpropertykey() { fmtid = new Guid( 0x0CABEC78, 0x6B74, 0x41C6, 0x92, 0x16, 0x26, 0x39, 0xD1, 0xFC, 0xE3, 0x56 ), pid = 10 };
		public static readonly _tagpropertykey WPD_COMMAND_CAPABILITIES_GET_SUPPORTED_FORMAT_PROPERTIES = new _tagpropertykey() { fmtid = new Guid( 0x0CABEC78, 0x6B74, 0x41C6, 0x92, 0x16, 0x26, 0x39, 0xD1, 0xFC, 0xE3, 0x56 ), pid = 8 };
		public static readonly _tagpropertykey WPD_COMMAND_CAPABILITIES_GET_SUPPORTED_FORMATS = new _tagpropertykey() { fmtid = new Guid( 0x0CABEC78, 0x6B74, 0x41C6, 0x92, 0x16, 0x26, 0x39, 0xD1, 0xFC, 0xE3, 0x56 ), pid = 7 };
		public static readonly _tagpropertykey WPD_COMMAND_CAPABILITIES_GET_SUPPORTED_FUNCTIONAL_CATEGORIES = new _tagpropertykey() { fmtid = new Guid( 0x0CABEC78, 0x6B74, 0x41C6, 0x92, 0x16, 0x26, 0x39, 0xD1, 0xFC, 0xE3, 0x56 ), pid = 4 };

		// Object resource
		//
		public static readonly _tagpropertykey WPD_COMMAND_OBJECT_RESOURCES_CLOSE = new _tagpropertykey() { fmtid = new Guid( 0xB3A2B22D, 0xA595, 0x4108, 0xBE, 0x0A, 0xFC, 0x3C, 0x96, 0x5F, 0x3D, 0x4A ), pid = 7 };
		public static readonly _tagpropertykey WPD_COMMAND_OBJECT_RESOURCES_CREATE_RESOURCE = new _tagpropertykey() { fmtid = new Guid( 0xB3A2B22D, 0xA595, 0x4108, 0xBE, 0x0A, 0xFC, 0x3C, 0x96, 0x5F, 0x3D, 0x4A ), pid = 9 };
		public static readonly _tagpropertykey WPD_COMMAND_OBJECT_RESOURCES_DELETE = new _tagpropertykey() { fmtid = new Guid( 0xB3A2B22D, 0xA595, 0x4108, 0xBE, 0x0A, 0xFC, 0x3C, 0x96, 0x5F, 0x3D, 0x4A ), pid = 8 };
		public static readonly _tagpropertykey WPD_COMMAND_OBJECT_RESOURCES_GET_SUPPORTED = new _tagpropertykey() { fmtid = new Guid( 0xB3A2B22D, 0xA595, 0x4108, 0xBE, 0x0A, 0xFC, 0x3C, 0x96, 0x5F, 0x3D, 0x4A ), pid = 2 };
		public static readonly _tagpropertykey WPD_COMMAND_OBJECT_RESOURCES_GET_ATTRIBUTES = new _tagpropertykey() { fmtid = new Guid( 0xB3A2B22D, 0xA595, 0x4108, 0xBE, 0x0A, 0xFC, 0x3C, 0x96, 0x5F, 0x3D, 0x4A ), pid = 3 };
		public static readonly _tagpropertykey WPD_COMMAND_OBJECT_RESOURCES_OPEN = new _tagpropertykey() { fmtid = new Guid( 0xB3A2B22D, 0xA595, 0x4108, 0xBE, 0x0A, 0xFC, 0x3C, 0x96, 0x5F, 0x3D, 0x4A ), pid = 4 };
		public static readonly _tagpropertykey WPD_COMMAND_OBJECT_RESOURCES_READ = new _tagpropertykey() { fmtid = new Guid( 0xB3A2B22D, 0xA595, 0x4108, 0xBE, 0x0A, 0xFC, 0x3C, 0x96, 0x5F, 0x3D, 0x4A ), pid = 5 };
		public static readonly _tagpropertykey WPD_COMMAND_OBJECT_RESOURCES_REVERT = new _tagpropertykey() { fmtid = new Guid( 0xB3A2B22D, 0xA595, 0x4108, 0xBE, 0x0A, 0xFC, 0x3C, 0x96, 0x5F, 0x3D, 0x4A ), pid = 10 };
		public static readonly _tagpropertykey WPD_COMMAND_OBJECT_RESOURCES_SEEK = new _tagpropertykey() { fmtid = new Guid( 0xB3A2B22D, 0xA595, 0x4108, 0xBE, 0x0A, 0xFC, 0x3C, 0x96, 0x5F, 0x3D, 0x4A ), pid = 11 };
		public static readonly _tagpropertykey WPD_COMMAND_OBJECT_RESOURCES_WRITE = new _tagpropertykey() { fmtid = new Guid( 0xB3A2B22D, 0xA595, 0x4108, 0xBE, 0x0A, 0xFC, 0x3C, 0x96, 0x5F, 0x3D, 0x4A ), pid = 6 };

		// Object properties
		//
		public static readonly _tagpropertykey WPD_COMMAND_OBJECT_PROPERTIES_BULK_GET_VALUES_BY_OBJECT_FORMAT_END = new _tagpropertykey() { fmtid = new Guid( 0x11C824DD, 0x04CD, 0x4E4E, 0x8C, 0x7B, 0xF6, 0xEF, 0xB7, 0x94, 0xD8, 0x4E ), pid = 7 };
		public static readonly _tagpropertykey WPD_COMMAND_OBJECT_PROPERTIES_BULK_GET_VALUES_BY_OBJECT_FORMAT_NEXT = new _tagpropertykey() { fmtid = new Guid( 0x11C824DD, 0x04CD, 0x4E4E, 0x8C, 0x7B, 0xF6, 0xEF, 0xB7, 0x94, 0xD8, 0x4E ), pid = 6 };
		public static readonly _tagpropertykey WPD_COMMAND_OBJECT_PROPERTIES_BULK_GET_VALUES_BY_OBJECT_FORMAT_START = new _tagpropertykey() { fmtid = new Guid( 0x11C824DD, 0x04CD, 0x4E4E, 0x8C, 0x7B, 0xF6, 0xEF, 0xB7, 0x94, 0xD8, 0x4E ), pid = 5 };
		public static readonly _tagpropertykey WPD_COMMAND_OBJECT_PROPERTIES_BULK_GET_VALUES_BY_OBJECT_LIST_END = new _tagpropertykey() { fmtid = new Guid( 0x11C824DD, 0x04CD, 0x4E4E, 0x8C, 0x7B, 0xF6, 0xEF, 0xB7, 0x94, 0xD8, 0x4E ), pid = 4 };
		public static readonly _tagpropertykey WPD_COMMAND_OBJECT_PROPERTIES_BULK_GET_VALUES_BY_OBJECT_LIST_NEXT = new _tagpropertykey() { fmtid = new Guid( 0x11C824DD, 0x04CD, 0x4E4E, 0x8C, 0x7B, 0xF6, 0xEF, 0xB7, 0x94, 0xD8, 0x4E ), pid = 3 };
		public static readonly _tagpropertykey WPD_COMMAND_OBJECT_PROPERTIES_BULK_GET_VALUES_BY_OBJECT_LIST_START = new _tagpropertykey() { fmtid = new Guid( 0x11C824DD, 0x04CD, 0x4E4E, 0x8C, 0x7B, 0xF6, 0xEF, 0xB7, 0x94, 0xD8, 0x4E ), pid = 2 };
		public static readonly _tagpropertykey WPD_COMMAND_OBJECT_PROPERTIES_BULK_SET_VALUES_BY_OBJECT_LIST_END = new _tagpropertykey() { fmtid = new Guid( 0x11C824DD, 0x04CD, 0x4E4E, 0x8C, 0x7B, 0xF6, 0xEF, 0xB7, 0x94, 0xD8, 0x4E ), pid = 10 };
		public static readonly _tagpropertykey WPD_COMMAND_OBJECT_PROPERTIES_BULK_SET_VALUES_BY_OBJECT_LIST_NEXT = new _tagpropertykey() { fmtid = new Guid( 0x11C824DD, 0x04CD, 0x4E4E, 0x8C, 0x7B, 0xF6, 0xEF, 0xB7, 0x94, 0xD8, 0x4E ), pid = 9 };
		public static readonly _tagpropertykey WPD_COMMAND_OBJECT_PROPERTIES_BULK_SET_VALUES_BY_OBJECT_LIST_START = new _tagpropertykey() { fmtid = new Guid( 0x11C824DD, 0x04CD, 0x4E4E, 0x8C, 0x7B, 0xF6, 0xEF, 0xB7, 0x94, 0xD8, 0x4E ), pid = 8 };

		// Common
		//
		public static readonly _tagpropertykey WPD_COMMAND_COMMON_GET_OBJECT_IDS_FROM_PERSISTENT_UNIQUE_IDS = new _tagpropertykey() { fmtid = new Guid( 0xF0422A9C, 0x5DC8, 0x4440, 0xB5, 0xBD, 0x5D, 0xF2, 0x88, 0x35, 0x65, 0x8A ), pid = 3 };
		public static readonly _tagpropertykey WPD_COMMAND_COMMON_RESET_DEVICE = new _tagpropertykey() { fmtid = new Guid( 0xF0422A9C, 0x5DC8, 0x4440, 0xB5, 0xBD, 0x5D, 0xF2, 0x88, 0x35, 0x65, 0x8A ), pid = 2 };
		public static readonly _tagpropertykey WPD_COMMAND_COMMON_SAVE_CLIENT_INFORMATION = new _tagpropertykey() { fmtid = new Guid( 0xF0422A9C, 0x5DC8, 0x4440, 0xB5, 0xBD, 0x5D, 0xF2, 0x88, 0x35, 0x65, 0x8A ), pid = 4 };

		// Management
		//
		public static readonly _tagpropertykey WPD_COMMAND_OBJECT_MANAGEMENT_COMMIT_OBJECT = new _tagpropertykey() { fmtid = new Guid( 0xEF1E43DD, 0xA9ED, 0x4341, 0x8B, 0xCC, 0x18, 0x61, 0x92, 0xAE, 0xA0, 0x89 ), pid = 5 };
		public static readonly _tagpropertykey WPD_COMMAND_OBJECT_MANAGEMENT_COPY_OBJECTS = new _tagpropertykey() { fmtid = new Guid( 0xEF1E43DD, 0xA9ED, 0x4341, 0x8B, 0xCC, 0x18, 0x61, 0x92, 0xAE, 0xA0, 0x89 ), pid = 9 };
		public static readonly _tagpropertykey WPD_COMMAND_OBJECT_MANAGEMENT_CREATE_OBJECT_WITH_PROPERTIES_AND_DATA = new _tagpropertykey() { fmtid = new Guid( 0xEF1E43DD, 0xA9ED, 0x4341, 0x8B, 0xCC, 0x18, 0x61, 0x92, 0xAE, 0xA0, 0x89 ), pid = 3 };
		public static readonly _tagpropertykey WPD_COMMAND_OBJECT_MANAGEMENT_CREATE_OBJECT_WITH_PROPERTIES_ONLY = new _tagpropertykey() { fmtid = new Guid( 0xEF1E43DD, 0xA9ED, 0x4341, 0x8B, 0xCC, 0x18, 0x61, 0x92, 0xAE, 0xA0, 0x89 ), pid = 2 };
		public static readonly _tagpropertykey WPD_COMMAND_OBJECT_MANAGEMENT_DELETE_OBJECTS = new _tagpropertykey() { fmtid = new Guid( 0xEF1E43DD, 0xA9ED, 0x4341, 0x8B, 0xCC, 0x18, 0x61, 0x92, 0xAE, 0xA0, 0x89 ), pid = 7 };
		public static readonly _tagpropertykey WPD_COMMAND_OBJECT_MANAGEMENT_MOVE_OBJECTS = new _tagpropertykey() { fmtid = new Guid( 0xEF1E43DD, 0xA9ED, 0x4341, 0x8B, 0xCC, 0x18, 0x61, 0x92, 0xAE, 0xA0, 0x89 ), pid = 8 };
		public static readonly _tagpropertykey WPD_COMMAND_OBJECT_MANAGEMENT_REVERT_OBJECT = new _tagpropertykey() { fmtid = new Guid( 0xEF1E43DD, 0xA9ED, 0x4341, 0x8B, 0xCC, 0x18, 0x61, 0x92, 0xAE, 0xA0, 0x89 ), pid = 6 };
		public static readonly _tagpropertykey WPD_COMMAND_OBJECT_MANAGEMENT_WRITE_OBJECT_DATA = new _tagpropertykey() { fmtid = new Guid( 0xEF1E43DD, 0xA9ED, 0x4341, 0x8B, 0xCC, 0x18, 0x61, 0x92, 0xAE, 0xA0, 0x89 ), pid = 4 };

		// Media
		//
		public static readonly _tagpropertykey WPD_COMMAND_MEDIA_CAPTURE_PAUSE = new _tagpropertykey() { fmtid = new Guid( 0x59B433BA, 0xFE44, 0x4D8D, 0x80, 0x8C, 0x6B, 0xCB, 0x9B, 0x0F, 0x15, 0xE8 ), pid = 4 };
		public static readonly _tagpropertykey WPD_COMMAND_MEDIA_CAPTURE_START = new _tagpropertykey() { fmtid = new Guid( 0x59B433BA, 0xFE44, 0x4D8D, 0x80, 0x8C, 0x6B, 0xCB, 0x9B, 0x0F, 0x15, 0xE8 ), pid = 2 };
		public static readonly _tagpropertykey WPD_COMMAND_MEDIA_CAPTURE_STOP = new _tagpropertykey() { fmtid = new Guid( 0x59B433BA, 0xFE44, 0x4D8D, 0x80, 0x8C, 0x6B, 0xCB, 0x9B, 0x0F, 0x15, 0xE8 ), pid = 3 };

		// Storage
		//
		public static readonly _tagpropertykey WPD_COMMAND_STORAGE_EJECT = new _tagpropertykey() { fmtid = new Guid( 0xD8F907A6, 0x34CC, 0x45FA, 0x97, 0xFB, 0xD0, 0x07, 0xFA, 0x47, 0xEC, 0x94 ), pid = 4 };
		public static readonly _tagpropertykey WPD_COMMAND_STORAGE_FORMAT = new _tagpropertykey() { fmtid = new Guid( 0xD8F907A6, 0x34CC, 0x45FA, 0x97, 0xFB, 0xD0, 0x07, 0xFA, 0x47, 0xEC, 0x94 ), pid = 2 };

		// Other
		//
		public static readonly _tagpropertykey WPD_COMMAND_CLASS_EXTENSION_WRITE_DEVICE_INFORMATION = new _tagpropertykey() { fmtid = new Guid( 0x33FB0D11, 0x64A3, 0x4FAC, 0xB4, 0xC7, 0x3D, 0xFE, 0xAA, 0x99, 0xB0, 0x51 ), pid = 2 };
		public static readonly _tagpropertykey WPD_COMMAND_COMMIT_KEYPAIR = new _tagpropertykey() { fmtid = new Guid( 0x78F9C6FC, 0x79B8, 0x473C, 0x90, 0x60, 0x6B, 0xD2, 0x3D, 0xD0, 0x72, 0xC4 ), pid = 3 };
		public static readonly _tagpropertykey WPD_COMMAND_DEVICE_HINTS_GET_CONTENT_LOCATION = new _tagpropertykey() { fmtid = new Guid( 0x0D5FB92B, 0xCB46, 0x4C4F, 0x83, 0x43, 0x0B, 0xC3, 0xD3, 0xF1, 0x7C, 0x84 ), pid = 2 };
		public static readonly _tagpropertykey WPD_COMMAND_GENERATE_KEYPAIR = new _tagpropertykey() { fmtid = new Guid( 0x78F9C6FC, 0x79B8, 0x473C, 0x90, 0x60, 0x6B, 0xD2, 0x3D, 0xD0, 0x72, 0xC4 ), pid = 2 };
		public static readonly _tagpropertykey WPD_COMMAND_PROCESS_WIRELESS_PROFILE = new _tagpropertykey() { fmtid = new Guid( 0x78F9C6FC, 0x79B8, 0x473C, 0x90, 0x60, 0x6B, 0xD2, 0x3D, 0xD0, 0x72, 0xC4 ), pid = 4 };
		public static readonly _tagpropertykey WPD_COMMAND_SMS_SEND = new _tagpropertykey() { fmtid = new Guid( 0xAFC25D66, 0xFE0D, 0x4114, 0x90, 0x97, 0x97, 0x0C, 0x93, 0xE9, 0x20, 0xD1 ), pid = 2 };
		public static readonly _tagpropertykey WPD_COMMAND_STILL_IMAGE_CAPTURE_INITIATE = new _tagpropertykey() { fmtid = new Guid( 0x4FCD6982, 0x22A2, 0x4B05, 0xA4, 0x8B, 0x62, 0xD3, 0x8B, 0xF2, 0x7B, 0x32 ), pid = 2 };
	}
}
