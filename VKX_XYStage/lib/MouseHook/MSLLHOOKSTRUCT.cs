using System;
using System.Runtime.InteropServices;

namespace LowLevelMouseHook
{
	/// <summary>
	/// Contains information about a low-level mouse input event.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	internal struct MSLLHOOKSTRUCT
	{
		/// <summary>
		/// The x- and y-coordinates of the cursor, in screen coordinates.
		/// </summary>
		public POINT Point;
		/// <summary>
		/// If the message is Wheel, the high-order word of this member is the wheel delta. 
		/// The low-order word is reserved. A positive value indicates that the wheel was rotated 
		/// forward, away from the user; a negative value indicates that the wheel was rotated 
		/// backward, toward the user. One wheel click is defined as WHEEL_DELTA, which is 120.
		/// 
		/// If the message is WM_XBUTTONDOWN, WM_XBUTTONUP, WM_XBUTTONDBLCLK, WM_NCXBUTTONDOWN, 
		/// WM_NCXBUTTONUP, or WM_NCXBUTTONDBLCLK, the high-order word specifies which X button 
		/// was pressed or released, and the low-order word is reserved. This value can be one 
		/// or more of the following values. Otherwise, mouseData is not used.
		/// 
		/// XBUTTON1 (0x0001) - The first X button was pressed or released.
		/// XBUTTON2 (0x0002) - The second X button was pressed or released.
		/// </summary>
		public uint MouseData;
		/// <summary>
		/// The event-injected flag. An application can use the following value to test the mouse flags.
		/// LLMHF_INJECTED (0x00000001) - Test the event-injected flag.
		/// </summary>
		public uint Flags;
		/// <summary>
		/// The time stamp for this message.
		/// </summary>
		public uint Time;
		/// <summary>
		/// Additional information associated with the message.
		/// </summary>
		public IntPtr ExtraInfo;
	}
}
