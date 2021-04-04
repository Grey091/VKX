using System;
using System.Runtime.InteropServices;

namespace LowLevelMouseHook
{
	/// <summary>
	/// Static class for invoking native Windows functions
	/// </summary>
	internal static class WinApi
	{
		/// <summary>
		/// Installs a hook procedure that monitors low-level mouse input events. 
		/// </summary>
		internal const int WH_MOUSE_LL = 0x000E;

		internal delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);

		/// <summary>
		/// Installs an application-defined hook procedure into a hook chain. 
		/// You would install a hook procedure to monitor the system for certain types of events. 
		/// These events are associated either with a specific thread or with all threads in the 
		/// same desktop as the calling thread.
		/// </summary>
		/// <param name="idHook">The type of hook procedure to be installed.</param>
		/// <param name="lpfn">A pointer to the hook procedure. If the dwThreadId parameter is 
		/// zero or specifies the identifier of a thread created by a different process, the 
		/// lpfn parameter must point to a hook procedure in a DLL. Otherwise, lpfn can point 
		/// to a hook procedure in the code associated with the current process.</param>
		/// <param name="hMod">A _handle to the DLL containing the hook procedure pointed to by 
		/// the lpfn parameter. The hMod parameter must be set to NULL if the dwThreadId 
		/// parameter specifies a thread created by the current process and if the hook procedure 
		/// is within the code associated with the current process.</param>
		/// <param name="dwThreadId">The identifier of the thread with which the hook procedure is 
		/// to be associated. For desktop apps, if this parameter is zero, the hook procedure is 
		/// associated with all existing threads running in the same desktop as the calling thread.</param>
		/// <returns>If the function succeeds, the return value is the _handle to the hook procedure.
		/// If the function fails, the return value is NULL. To get extended error information, call GetLastError.</returns>
		[DllImport("User32")]
		internal static extern IntPtr SetWindowsHookEx(int idHook, LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);

		/// <summary>
		/// Removes a hook procedure installed in a hook chain by the SetWindowsHookEx function.
		/// </summary>
		/// <param name="hhk">A _handle to the hook to be removed. This parameter is a hook _handle 
		/// obtained by a previous call to SetWindowsHookEx.</param>
		/// <returns>If the function succeeds, the return value is nonzero.
		/// If the function fails, the return value is zero. To get extended error information, call GetLastError.</returns>
		[DllImport("User32")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool UnhookWindowsHookEx(IntPtr hhk);

		/// <summary>
		/// Passes the hook information to the next hook procedure in the current hook chain. 
		/// A hook procedure can call this function either before or after processing the hook 
		/// information.
		/// </summary>
		/// <param name="hhk">This parameter is ignored.</param>
		/// <param name="nCode">The hook code passed to the current hook procedure. The next hook 
		/// procedure uses this code to determine how to process the hook information.</param>
		/// <param name="wParam">The wParam value passed to the current hook procedure. The 
		/// meaning of this parameter depends on the type of hook associated with the current 
		/// hook chain.</param>
		/// <param name="lParam">The lParam value passed to the current hook procedure. The 
		/// meaning of this parameter depends on the type of hook associated with the current 
		/// hook chain.</param>
		/// <returns>This value is returned by the next hook procedure in the chain. The current 
		/// hook procedure must also return this value. The meaning of the return value depends 
		/// on the hook type. For more information, see the descriptions of the individual hook 
		/// procedures.</returns>
		[DllImport("User32", CharSet = CharSet.Auto, SetLastError = true)]
		internal static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

		/// <summary>
		/// Retrieves a module _handle for the specified module. The module must have been loaded 
		/// by the calling process.
		/// </summary>
		/// <param name="lpModuleName">The name of the loaded module (either a .dll or .exe file). 
		/// If the file name extension is omitted, the default library extension .dll is appended. 
		/// The file name string can include a trailing point character (.) to indicate that the 
		/// module name has no extension. The string does not have to specify a path. When 
		/// specifying a path, be sure to use backslashes (\), not forward slashes (/). The name 
		/// is compared (case independently) to the names of modules currently mapped into the 
		/// address space of the calling process.
		/// If this parameter is NULL, GetModuleHandle returns a _handle to the file used to create 
		/// the calling process (.exe file).</param>
		/// <returns>If the function succeeds, the return value is a _handle to the specified module.
		/// If the function fails, the return value is NULL. To get extended error information, 
		/// call GetLastError.</returns>
		[DllImport("Kernel32", CharSet = CharSet.Auto, SetLastError = true)]
		internal static extern IntPtr GetModuleHandle(string lpModuleName);
	}
}
