using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeCopUI_Framework.Win32.Enums
{
    [Flags]
#pragma warning disable CS3009 // Base type is not CLS-compliant
    public enum TrackPopupMenuFlags : uint
#pragma warning restore CS3009 // Base type is not CLS-compliant
    {
        TPM_LEFTBUTTON = 0x0000,       // Xử lý khi nhấn nút chuột trái (mặc định)
        TPM_RIGHTBUTTON = 0x0002,      // Xử lý khi nhấn nút chuột phải
        TPM_LEFTALIGN = 0x0000,        // Canh trái menu so với vị trí con trỏ
        TPM_CENTERALIGN = 0x0004,      // Canh giữa menu so với vị trí con trỏ
        TPM_RIGHTALIGN = 0x0008,       // Canh phải menu so với vị trí con trỏ
        TPM_TOPALIGN = 0x0000,         // Canh trên so với điểm tham chiếu
        TPM_VCENTERALIGN = 0x0010,     // Canh giữa theo trục dọc
        TPM_BOTTOMALIGN = 0x0020,      // Canh dưới theo trục dọc
        TPM_HORIZONTAL = 0x0000,       // Menu theo chiều ngang
        TPM_VERTICAL = 0x0040,         // Menu theo chiều dọc
        TPM_NONOTIFY = 0x0080,         // Không gửi thông báo WM_COMMAND khi chọn menu
        TPM_RETURNCMD = 0x0100,        // Trả về lệnh chọn trong hàm mà không gửi WM_COMMAND
        TPM_RECURSE = 0x0001,          // Hiển thị lại menu khi lệnh được thực thi
        TPM_HORPOSANIMATION = 0x0400,  // Hiển thị menu với hiệu ứng chuyển động ngang
        TPM_HORNEGANIMATION = 0x0800,  // Hiển thị menu với hiệu ứng chuyển động ngang ngược
        TPM_VERPOSANIMATION = 0x1000,  // Hiển thị menu với hiệu ứng chuyển động dọc
        TPM_VERNEGANIMATION = 0x2000,  // Hiển thị menu với hiệu ứng chuyển động dọc ngược
        TPM_NOANIMATION = 0x4000,      // Tắt hiệu ứng menu
        TPM_LAYOUTRTL = 0x8000         // Menu từ phải sang trái (RTL layout)
    }

}
