using HeCopUI_Framework.Converter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Media3D;

namespace HeCopUI_Framework.Struct
{

    [Serializable]
    //[TypeConverterAttribute(typeof(CornerRadiusConverter))]
    [TypeConverter(typeof(CornerRadiusConverter))]
    public struct CornerRadius
    {
        private bool _all;      // Do NOT rename (binary serialization).
        private float _topLeft;   // Renamed from _top to _topLeft.                         
        private float _topRight;  // New field for TopRight.
        private float _bottomLeft; // New field for BottomLeft.
        private float _bottomRight; // New field for BottomRight.

        public static CornerRadius Empty = new CornerRadius(0);
        
      
        public CornerRadius(float all) :this(all, all, all, all)
        {
            _all = true;
            //_topLeft = _topRight = _bottomLeft = _bottomRight = all;
            //Debug_SanityCheck();
        }

        public CornerRadius(float topLeft, float topRight, float bottomLeft, float bottomRight)
        {
            _topLeft = topLeft;
            _topRight = topRight;
            _bottomLeft = bottomLeft;
            _bottomRight = bottomRight;
            _all = _topLeft == _topRight && _topLeft == _bottomLeft && _topLeft == _bottomRight;
            Debug_SanityCheck();
        }


        public CornerRadius(float topLeft, float topRight, float bottomLeft, float bottomRight, float offset)
            : this(topLeft - offset, topRight - offset, bottomLeft - offset, bottomRight - offset)
        {
        }

        public CornerRadius(CornerRadius radius, float offset = 0)
            : this(radius.TopLeft - offset, radius.TopRight - offset, radius.BottomLeft - offset, radius.BottomRight - offset)
        {
        }

        //public static CornerRadius Subtract(CornerRadius p1, CornerRadius p2)
        //{
        //    return p1 - p2;
        //}

        //public static CornerRadius Add(CornerRadius p1, CornerRadius p2)
        //{
        //    return p1 + p2;
        //}

        //public override bool Equals(object other)
        //{
        //    if (other is CornerRadius)
        //    {
        //        return (CornerRadius)other == this;
        //    }

        //    return false;
        //}

        //public static CornerRadius operator +(CornerRadius p1, CornerRadius p2)
        //{
        //    return new CornerRadius(p1.TopLeft + p2.TopLeft, p1.BottomLeft + p2.BottomLeft, p1.TopRight + p2.TopRight, p1.BottomLeft + p2.BottomRight);
        //}

        //public static CornerRadius operator -(CornerRadius p1, CornerRadius p2)
        //{
        //    return new CornerRadius(p1.TopLeft - p2.TopLeft, p1.BottomLeft - p2.BottomLeft, p1.TopRight- p2.TopRight, p1.BottomLeft - p2.BottomRight);
        //}

        //public static bool operator ==(CornerRadius p1, CornerRadius p2)
        //{
        //    if (p1.TopLeft == p2.TopLeft && p1.TopRight == p2.TopRight && p1.BottomLeft == p2.BottomLeft)
        //    {
        //        return p1.BottomRight == p2.BottomRight;
        //    }

        //    return false;
        //}

        //public static bool operator !=(CornerRadius p1, CornerRadius p2)
        //{
        //    return !(p1 == p2);
        //}

        internal void Scale(float dx, float dy)
        {
            _topLeft = (int)((float)_topLeft * dy);
            _topRight = (int)((float)_topRight * dx);
            _bottomLeft = (int)((float)_bottomLeft * dx);
            _bottomRight = (int)((float)_bottomRight * dy);
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


        public override string ToString()
        {
            return "{TopLeft=" + TopLeft.ToString() + ",TopRight=" + TopRight.ToString() + 
                ",BottomLeft=" + BottomLeft.ToString() + ",BottomRight=" + BottomRight.ToString() + "}";
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
