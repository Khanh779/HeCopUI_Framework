using System;
using System.Runtime.InteropServices;

namespace HeCopUI_Framework.Win32
{
	internal static class Dwmapi
	{
		[Flags]
		public enum DWMWINDOWATTRIBUTE : uint
		{
			DWMWA_ALLOW_NCPAINT = 4u,
			DWMWA_CAPTION_BUTTON_BOUNDS = 5u,
			DWMWA_FORCE_ICONIC_REPRESENTATION = 7u,
			DWMWA_CLOAK = 0xDu,
			DWMWA_CLOAKED = 0xEu,
			DWMWA_FREEZE_REPRESENTATION = 0xFu,
			DWMWA_USE_IMMERSIVE_DARK_MODE = 0x14u,
			DWMWA_WINDOW_CORNER_PREFERENCE = 0x21u,
			DWMWA_BORDER_COLOR = 0x22u,
			DWMWA_CAPTION_COLOR = 0x23u,
			DWMWA_TEXT_COLOR = 0x24u,
			DWMWA_VISIBLE_FRAME_BORDER_THICKNESS = 0x25u,
			DWMWA_SYSTEMBACKDROP_TYPE = 0x26u,
			DWMWA_MICA_EFFECT = 0x405u
		}

		public enum PvAttribute
		{
			Disable,
			Enable
		}

		[DllImport("dwmapi.dll")]
		public static extern int DwmSetWindowAttribute(IntPtr hwnd, DWMWINDOWATTRIBUTE dwAttribute, ref int pvAttribute, int cbAttribute);
	}
}