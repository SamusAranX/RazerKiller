using System;
using System.Runtime.InteropServices;

namespace RazerKiller {
	public static class WinApi {
		public const int SW_MINIMIZE = 6;

		[DllImport("user32.dll")]
		public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
	}
}