using System.Drawing;

namespace HeCopUI_Framework.Global
{
    internal class PrimaryColors
    {
        public static Color ForeNormalColor1 { get; set; } = Color.White;
        public static Color ForeNormalColor2 { get; set; } = Color.White;

        public static Color BackNormalColor1 { get; set; } = Color.FromArgb(0, 168, 148);
        public static Color BackNormalColor2 { get; set; } = Color.DodgerBlue;

        public static Color BackHoverColor1 { get; set; } = Color.DodgerBlue;
        public static Color BackHoverColor2 { get; set; } = Color.FromArgb(0, 168, 148);

        public static Color BackPressColor1 { get; set; } = Color.SteelBlue;
        public static Color BackPressColor2 { get; set; } = Color.RoyalBlue;

        public static Color ForePressColor1 { get; set; } = Color.WhiteSmoke;
        public static Color ForePressColor2 { get; set; } = Color.Gray;

        public static Color BorderNormalColor1 { get; set; } = Color.Gray;
        public static Color BorderNormalColor2 { get; set; } = Color.Gray;
        public static Color BorderHoverColor1 { get; set; } = Color.Gray;
        public static Color BorderHoverColor2 { get; set; } = Color.Gray;

        public static Color BorderPressColor1 { get; set; } = Color.Gray;
        public static Color BorderPressColor2 { get; set; } = Color.Gray;

        public static Color ProgressBarColor1 { get; set; } = Color.DodgerBlue;
        public static Color ProgressBarColor2 { get; set; } = Color.FromArgb(0, 168, 148);

        public static Color BaseProgressBarColor1 { get; set; } = Color.Silver;
        public static Color BaseProgressBarColor2 { get; set; } = Color.Silver;

        public static Color BorderProgressBarColor1 { get; set; } = Color.Gray;
        public static Color BorderProgressBarColor2 { get; set; } = Color.Gray;

        public static Color LeverToggleButtonColor
        {
            get => Color.White;
        }
        public static Color OnToggleButtonColor
        {
            get => Color.FromArgb(0, 168, 142);
        }

        public static Color OffToggleButtonColor
        {
            get => Color.DimGray;
        }

        public static Color GaugeBarColor
        {
            get => Color.FromArgb(0, 168, 142);
        }

        public static Color BaseGaugeColor
        {
            get => Color.Gainsboro;
        }
    }
}
