using HeCopUI_Framework.Converter;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace HeCopUI_Framework.Struct
{
    /// <summary>
    /// Represents Corner Radius information associated with a user interface (UI)
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(CornerRadiusConverter))]
    public struct CornerRadius
    {
        private bool _all; // Do NOT rename (binary serialization).
        private float _topLeft; // Renamed from _top to _topLeft.                         
        private float _topRight; // New field for TopRight.
        private float _bottomLeft; // New field for BottomLeft.
        private float _bottomRight; // New field for BottomRight.

        public static CornerRadius Empty = new CornerRadius(0);

        public CornerRadius(float all = 0) : this(all, all, all, all)
        {
            _all = true;
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

        public CornerRadius(CornerRadius radius, float offset = 0) : this(radius.All - offset)
        {
        }

        public static bool TryParse(string s, out CornerRadius result)
        {
            result = new CornerRadius();
            if (string.IsNullOrEmpty(s))
            {
                return false;
            }
            s = s.Trim();
            if (s.Contains(","))
            {

                var split = s.Split(',');
                if (split.Length != 4)
                {
                    return false;
                }

                if (float.TryParse(split[0], out var topLeft) && float.TryParse(split[1], out var topRight) && float.TryParse(split[2], out var bottomLeft) && float.TryParse(split[3], out var bottomRight))
                {
                    result = new CornerRadius(topLeft, topRight, bottomLeft, bottomRight);
                    return true;
                }
            }
            else
            {
                result = new CornerRadius(float.Parse(s));
                return true;
            }

            return false;
        }

        public float All
        {
            get => _all ? _topLeft : -1;
            set
            {
                if (!_all || _topLeft != value)
                {
                    _all = true;
                    _topLeft = _topRight = _bottomLeft = _bottomRight = value;
                }
                Debug_SanityCheck();
            }
        }

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

        public bool Equals(CornerRadius other) =>
            TopLeft == other.TopLeft && BottomLeft == other.BottomLeft && TopRight == other.TopRight && BottomRight == other.BottomRight;

        //public override string ToString() =>
        //    "{TopLeft=" + TopLeft.ToString() + ",TopRight=" + TopRight.ToString() + ",BottomLeft=" + BottomLeft.ToString() + ",BottomRight=" + BottomRight.ToString() + "}";

        public override string ToString()
        {
            return $"{{TopLeft={TopLeft},TopRight={TopRight},BottomLeft={BottomLeft},BottomRight={BottomRight}}}";
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