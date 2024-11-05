using HeCopUI_Framework.Converter;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;
using System.Windows.Media.Media3D;

namespace HeCopUI_Framework.Structs
{
    [Serializable]
    [TypeConverter(typeof(CornerRadiusConverter))]
    public struct CornerRadius : IEquatable<CornerRadius>
    {
        private bool _all;

        private float _topLeft;
        private float _topRight;
        private float _bottomLeft;
        private float _bottomRight;

        public static readonly CornerRadius Empty = new CornerRadius(0f);


        [RefreshProperties(RefreshProperties.All)]
        public float All
        {
            get => _all ? _topLeft : -1f;
            set
            {
                if (!_all || _topLeft != value)
                {
                    _all = true;
                    _topLeft = _topRight = _bottomLeft = _bottomRight = value;
                }
            }
        }

        // Các thuộc tính cho từng góc
        [RefreshProperties(RefreshProperties.All)]
        public float TopLeft
        {
            get => _all ? _topLeft : _topLeft;
            set
            {
                if (_all || _topLeft != value)
                {
                    _all = false;
                    _topLeft = value;
                }
            }
        }

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
            }
        }

        public CornerRadius(float all)
        {
            _all = true;
            _topLeft = _topRight = _bottomLeft = _bottomRight = all;
        }

        public CornerRadius(float topLeft, float topRight, float bottomLeft, float bottomRight)
        {
            _topLeft = topLeft;
            _topRight = topRight;
            _bottomLeft = bottomLeft;
            _bottomRight = bottomRight;
            _all = _topLeft == _topRight && _topLeft == _bottomLeft && _topLeft == _bottomRight;
        }

        public CornerRadius(float topLeft, float topRight, float bottomLeft, float bottomRight, float offSet)
        {
            _topLeft = topLeft - offSet;
            _topRight = topRight - offSet;
            _bottomLeft = bottomLeft - offSet;
            _bottomRight = bottomRight - offSet;
            _all = _topLeft == _topRight && _topLeft == _bottomLeft && _topLeft == _bottomRight;
        }

        public override bool Equals(object obj)
        {
            return obj is CornerRadius other && this == other;
        }

     

        public override int GetHashCode()
        {
            return _topLeft.GetHashCode() ^ _topRight.GetHashCode() ^ _bottomLeft.GetHashCode() ^ _bottomRight.GetHashCode();
        }

        public override string ToString()
        {
            return $"{{TopLeft={TopLeft.ToString(CultureInfo.CurrentCulture)}, TopRight={TopRight.ToString(CultureInfo.CurrentCulture)}, BottomLeft={BottomLeft.ToString(CultureInfo.CurrentCulture)}, BottomRight={BottomRight.ToString(CultureInfo.CurrentCulture)}}}";
        }

        public static bool operator ==(CornerRadius c1, CornerRadius c2)
        {
            return c1.TopLeft == c2.TopLeft && c1.TopRight == c2.TopRight &&
                   c1.BottomLeft == c2.BottomLeft && c1.BottomRight == c2.BottomRight;
        }

        public static CornerRadius operator +(CornerRadius c1, CornerRadius c2)
        {
            return new CornerRadius(c1.TopLeft + c2.TopLeft, c1.TopRight + c2.TopRight, c1.BottomLeft + c2.BottomLeft, c1.BottomRight + c2.BottomRight);
        }

        public static CornerRadius operator -(CornerRadius c1, CornerRadius c2)
        {
            return new CornerRadius(c1.TopLeft - c2.TopLeft, c1.TopRight - c2.TopRight, c1.BottomLeft - c2.BottomLeft, c1.BottomRight - c2.BottomRight);
        }

        public static bool operator !=(CornerRadius c1, CornerRadius c2)
        {
            return !(c1 == c2);
        }

        public static CornerRadius Add(CornerRadius p1, CornerRadius p2)
        {
            return p1 + p2;
        }

        public static CornerRadius Subtract(CornerRadius p1, CornerRadius p2)
        {
            return p1 - p2;
        }

        public bool Equals(CornerRadius other)
        {
            return this == other;
        }
    }
}
