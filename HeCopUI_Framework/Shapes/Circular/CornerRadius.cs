using HeCopUI_Framework.Converter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeCopUI_Framework.Shapes.Circular
{
    [Serializable]
    [TypeConverter(typeof(CornerRadiusConverter))]
    //[ComVisible(true)]
    public struct CornerRadius
    {
        private bool _all;      // Do NOT rename (binary serialization).
        private float _topLeft;   // Renamed from _top to _topLeft.
        private float _topRight;  // New field for TopRight.
        private float _bottomLeft; // New field for BottomLeft.
        private float _bottomRight; // New field for BottomRight.

#pragma warning disable IDE1006 // Naming Styles: Shipped API
        public static CornerRadius Empty = new CornerRadius(0);
#pragma warning restore IDE1006


        public CornerRadius(float all)
        {
            _all = true;
            _topLeft = _topRight = _bottomLeft = _bottomRight = all;
            Debug_SanityCheck();
        }

        public CornerRadius(float all, float offset=0)
        {
            _all = true;
            _topLeft = _topRight = _bottomLeft = _bottomRight = all-offset;
            Debug_SanityCheck();
        }

        public CornerRadius(float topLeft, float topRight, float bottomLeft, float bottomRight, float offset=0)
        {
            _topLeft = topLeft - offset;
            _topRight = topRight - offset;
            _bottomLeft = bottomLeft - offset;
            _bottomRight = bottomRight - offset;
            _all = _topLeft == _topRight && _topLeft == _bottomLeft && _topLeft == _bottomRight;
            Debug_SanityCheck();
        }

        public CornerRadius(CornerRadius radius, float offset=0)
        {
            _topLeft = radius.TopLeft - offset;
            _topRight = radius.TopRight - offset;
            _bottomLeft = radius.BottomLeft - offset;
            _bottomRight = radius.BottomRight - offset;
            _all = _topLeft == _topRight && _topLeft == _bottomLeft && _topLeft == _bottomRight;
            Debug_SanityCheck();
        }

        #region Properties

        [RefreshProperties(RefreshProperties.All)]
        public float All
        {
            get => _all ? _topLeft : -1;
            set
            {
                if (_all != true || _topLeft != value)
                {
                    _all = true;
                    _topLeft = _topRight = _bottomLeft = _bottomRight = value;
                }

                Debug_SanityCheck();
            }
        }

        [RefreshProperties(RefreshProperties.All)]
        public float BottomLeft
        {
            get => _all ? _topLeft : _bottomLeft;
            set
            {
                if (_all || _bottomLeft != value)
                {
                    _all = false;
                    _bottomLeft = value;
                }

                Debug_SanityCheck();
            }
        }

        [RefreshProperties(RefreshProperties.All)]
        public float BottomRight
        {
            get => _all ? _topLeft : _bottomRight;
            set
            {
                if (_all || _bottomRight != value)
                {
                    _all = false;
                    _bottomRight = value;
                }

                Debug_SanityCheck();
            }
        }

        [RefreshProperties(RefreshProperties.All)]
        public float TopLeft
        {
            get => _topLeft;
            set
            {
                if (_all || _topLeft != value)
                {
                    _all = false;
                    _topLeft = value;
                }

                Debug_SanityCheck();
            }
        }

        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [RefreshProperties(RefreshProperties.All)]
        public float TopRight
        {
            get => _all ? _topLeft : _topRight;
            set
            {
                if (_all || _topRight != value)
                {
                    _all = false;
                    _topRight = value;
                }

                Debug_SanityCheck();
            }
        }

        #endregion

        public bool Equals(CornerRadius other) =>
            TopLeft == other.TopLeft
                && BottomLeft == other.BottomLeft
                && TopRight == other.TopRight
                && BottomRight == other.BottomRight;

        //public override string ToString()
        //{
        //    return $"{{TopLeft={TopLeft},TopRight={TopRight},BottomLeft={BottomLeft},BottomRight={BottomRight}}}";
        //}

        public override string ToString()
        {
            return "{Left=" + TopLeft.ToString(CultureInfo.CurrentCulture) + ",Top=" + TopRight.ToString(CultureInfo.CurrentCulture) +
                ",Right=" + BottomLeft.ToString(CultureInfo.CurrentCulture) + ",Bottom=" + BottomRight.ToString(CultureInfo.CurrentCulture) + "}";
        }


        private void ResetAll() => All = 0;

        private void ResetBottomLeft() => BottomLeft = 0;

        private void ResetBottomRight() => BottomRight = 0;

        private void ResetTopLeft() => TopLeft = 0;

        private void ResetTopRight() => TopRight = 0;


        internal bool ShouldSerializeAll() => _all;

        [Conditional("DEBUG")]
        private void Debug_SanityCheck()
        {
            if (_all)
            {
                Debug.Assert(ShouldSerializeAll(), "_all is true, but ShouldSerializeAll() is false.");
                Debug.Assert(All == TopLeft && TopLeft == TopRight && TopRight == BottomLeft && BottomLeft == BottomRight, "_all is true, but All/TopLeft/TopRight/BottomLeft/BottomRight inconsistent.");
            }
            else
            {
                Debug.Assert(All == -1, "_all is false, but All != -1.");
                Debug.Assert(!ShouldSerializeAll(), "ShouldSerializeAll() should not be true when all flag is not set.");
            }
        }
    }
}
