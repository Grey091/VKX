using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LowLevelMouseHook
{
	/// <summary>
	/// Low-level hook to detect global mouse movement
	/// </summary>
	public class MouseHook
	{
		#region Fields

		private static WinApi.LowLevelMouseProc _proc;
		private static IntPtr _handle;

		#endregion

		#region Events

		/// <summary>
		/// Occurs when the left mouse button is pressed down
		/// </summary>
		public static event MouseEventHandler LeftDown;

		/// <summary>
		/// Occurs when the left mouse button is released
		/// </summary>
		public static event MouseEventHandler LeftUp;

		/// <summary>
		/// Occurs when the left mouse button is double-clicked
		/// </summary>
		public static event MouseEventHandler LeftDoubleClick;

		/// <summary>
		/// Occurs when the right mouse button is pressed down
		/// </summary>
		public static event MouseEventHandler RightDown;

		/// <summary>
		/// Occurs when the right mouse button is released
		/// </summary>
		public static event MouseEventHandler RightUp;

		/// <summary>
		/// Occurs when the right mouse button is double-clicked
		/// </summary>
		public static event MouseEventHandler RightDoubleClick;

		/// <summary>
		/// Occurs when the middle mouse button is pressed down
		/// </summary>
		public static event MouseEventHandler MiddleDown;

		/// <summary>
		/// Occurs when the middle mouse button is pressed released
		/// </summary>
		public static event MouseEventHandler MiddleUp;

		/// <summary>
		/// Occurs when the middle mouse button is double-clicked
		/// </summary>
		public static event MouseEventHandler MiddleDoubleClick;

		/// <summary>
		/// Occurs when the mouse pointer is moved
		/// </summary>
		public static event MouseEventHandler Move;

		/// <summary>
		/// Occurs when the mouse wheel is moved
		/// </summary>
		public static event MouseEventHandler Wheel;

		#endregion

		/// <summary>
		/// Installes a low-level mouse hook into the current process
		/// </summary>
		/// <returns>A handle to the created hook procedure</returns>
		public static IntPtr InstallHook()
		{
			_proc = HookCallback;
			_handle = IntPtr.Zero;
			using (var curProcess = Process.GetCurrentProcess())
			{
				using (ProcessModule curModule = curProcess.MainModule)
				{
					var module = WinApi.GetModuleHandle(curModule.ModuleName);
					_handle = WinApi.SetWindowsHookEx(WinApi.WH_MOUSE_LL, _proc, module, 0);
				}
			}
			return _handle;
		}

		/// <summary>
		/// Unhooks and removes an installed low-level mouse hook
		/// </summary>
		public static void RemoveHook()
		{
			WinApi.UnhookWindowsHookEx(_handle);
		}

		private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
		{
			if (nCode >= 0)
			{
				var hook = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));
				var message = (MouseMessages)wParam;
				MouseEventArgs arg;
				switch (message)
				{
					case MouseMessages.Move:
						if (Move != null)
						{
							arg = new MouseEventArgs(MouseButtons.None, 0, hook.Point.X, hook.Point.Y, 0);
							Move(null, arg);
						}
						break;
					case MouseMessages.LBtnDown:
						if (LeftDown != null)
						{
							arg = new MouseEventArgs(MouseButtons.Left, 1, hook.Point.X, hook.Point.Y, 0);
							LeftDown(null, arg);
						}
						break;
					case MouseMessages.LBtnUp:
						if (LeftUp != null)
						{
							arg = new MouseEventArgs(MouseButtons.Left, 1, hook.Point.X, hook.Point.Y, 0);
							LeftUp(null, arg);
						}
						break;
					case MouseMessages.LBtnDblClick:
						if (LeftDoubleClick != null)
						{
							arg = new MouseEventArgs(MouseButtons.Left, 2, hook.Point.X, hook.Point.Y, 0);
							LeftDoubleClick(null, arg);
						}
						break;
					case MouseMessages.RBtnDown:
						if (RightDown != null)
						{
							arg = new MouseEventArgs(MouseButtons.Right, 1, hook.Point.X, hook.Point.Y, 0);
							RightDown(null, arg);
						}
						break;
					case MouseMessages.RBtnUp:
						if (RightUp != null)
						{
							arg = new MouseEventArgs(MouseButtons.Right, 1, hook.Point.X, hook.Point.Y, 0);
							RightUp(null, arg);
						}
						break;
					case MouseMessages.RBtnDblClick:
						if (RightDoubleClick != null)
						{
							arg = new MouseEventArgs(MouseButtons.Right, 2, hook.Point.X, hook.Point.Y, 0);
							RightDoubleClick(null, arg);
						}
						break;
					case MouseMessages.MBtnDown:
						if (MiddleDown != null)
						{
							arg = new MouseEventArgs(MouseButtons.Middle, 1, hook.Point.X, hook.Point.Y, 0);
							MiddleDown(null, arg);
						}
						break;
					case MouseMessages.MBtnUp:
						if (MiddleUp != null)
						{
							arg = new MouseEventArgs(MouseButtons.Middle, 1, hook.Point.X, hook.Point.Y, 0);
							MiddleUp(null, arg);
						}
						break;
					case MouseMessages.MBtnDblClick:
						if (MiddleDoubleClick != null)
						{
							arg = new MouseEventArgs(MouseButtons.Middle, 2, hook.Point.X, hook.Point.Y, 0);
							MiddleDoubleClick(null, arg);
						}
						break;
					case MouseMessages.Wheel:
						if (Wheel != null)
						{
							var delta = BitConverter.ToInt16(BitConverter.GetBytes(hook.MouseData), 2);
							arg = new MouseEventArgs(MouseButtons.None, 0, hook.Point.X, hook.Point.Y, delta);
							Wheel(null, arg);
						}
						break;
				}
			}
			return WinApi.CallNextHookEx(_handle, nCode, wParam, lParam);
		}
	}
}