
namespace LowLevelMouseHook
{
	/// <summary>
	/// Flags representing mouse message in low-level hooks
	/// </summary>
	internal enum MouseMessages
	{
		/// <summary>
		/// Mouse pointer is moved
		/// </summary>
		Move = 0x0200,

		/// <summary>
		/// Left mouse button is down
		/// </summary>
		LBtnDown = 0x0201,
		/// <summary>
		/// Left mouse button is up
		/// </summary>
		LBtnUp = 0x0202,
		/// <summary>
		/// Left mouse button is double-clicked
		/// </summary>
		LBtnDblClick = 0x0203,

		/// <summary>
		/// Right mouse button is down
		/// </summary>
		RBtnDown = 0x0204,
		/// <summary>
		/// Right mouse button is up
		/// </summary>
		RBtnUp = 0x0205,
		/// <summary>
		/// Right mouse button is double-clicked
		/// </summary>
		RBtnDblClick = 0x0206,

		/// <summary>
		/// Middle mouse button is down
		/// </summary>
		MBtnDown = 0x0207,
		/// <summary>
		/// Middle mouse button is up
		/// </summary>
		MBtnUp = 0x0208,
		/// <summary>
		/// Middle mouse button is double-clicked
		/// </summary>
		MBtnDblClick = 0x0209,

		/// <summary>
		/// Mouse wheel is moved
		/// </summary>
		Wheel = 0x020E
	}
}
