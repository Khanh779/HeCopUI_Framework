using HeCopUI_Framework.Win32.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeCopUI_Framework.Win32.Struct
{
    public struct TCHITTESTINFO
    {
        private readonly Point _point;

        public readonly TabControlHitTest flags;

        private TCHITTESTINFO(TabControlHitTest hitTest)
        {
            this = default(TCHITTESTINFO);
            flags = hitTest;
        }

        public TCHITTESTINFO(Point point, TabControlHitTest hitTest)
            : this(hitTest)
        {
            _point = point;
        }

        public TCHITTESTINFO(int x, int y, TabControlHitTest hitTest)
            : this(hitTest)
        {
            Point point = new Point(x, y);
        }
    }

}
