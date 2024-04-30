using System.Drawing;

namespace HeCopUI_Framework.SuperNotifyIcon
{
    public partial class SuperNotifyIcon
    {
        public Point? GetLocation()
        {
            return GetLocation(0);
        }
        public Point? GetLocation(int accuracy)
        {
            return GetLocation(accuracy, false);
        }
        public Point? GetLocation(bool tryReturnIfHidden)
        {
            return GetLocation(0, tryReturnIfHidden);
        }

        public Point? GetLocation(int accuracy, bool tryReturnIfHidden)
        {
            // Try using APIs first
            Rectangle rect = NotifyIconHelpers.GetNotifyIconRectangle(NotifyIcon, tryReturnIfHidden);
            if (!rect.IsEmpty)
                return rect.Location;

            // Don't fallback if the icon isn't visible
            if (!tryReturnIfHidden)
            {
                Rectangle rect2 = NotifyIconHelpers.GetNotifyIconRectangle(NotifyIcon, true);
                if (rect2.IsEmpty)
                    return null;
            }

            // Ugly fallback time :(
            var finder = new HeCopUI_Framework.SuperNotifyIcon.Finder.NotifyIconColorFinder(NotifyIcon);
            Point? point = finder.GetLocation(accuracy);
            if (point.HasValue)
                return point;

            return null;
        }
    }
}
