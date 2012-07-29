using System;
using PortableDeviceApiLib;

namespace WpdLib
{
	/// <summary>
	/// ポータブル デバイス上で発生したイベントをハンドリングします。
	/// </summary>
	sealed class WpdEventCallback : IPortableDeviceEventCallback
	{
		/// <summary>
		/// インスタンスを初期化します。
		/// </summary>
		/// <param name="handler">イベントの通知先。</param>
		public WpdEventCallback( Action< WpdEventArgs > handler )
		{
			this._handler = handler;
		}

		/// <summary>
		/// ポータブル デバイス上で変更が生じた時に発生します。
		/// </summary>
		/// <param name="pEventParameters">イベント データ。</param>
		public void OnEvent( IPortableDeviceValues pEventParameters )
		{
			if( this._handler != null )
			{
				this._handler( new WpdEventArgs( pEventParameters ) );
			}
		}

		/// <summary>
		/// デバイスで発生したイベントの通知先。
		/// </summary>
		private Action< WpdEventArgs > _handler;
	}
}
