
using System;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace HeCopUI_Framework.Extensions
{
    public class HFonts
    {

        /// <summary>
        /// Gets the font for the most of controls.
        /// </summary>
        /// <param name="size">The Size of the Segoe WP Semilight font.</param>
        /// <returns>The Segoe WP Semilight font with the given size.</returns>

        /// <summary>
        /// Gets the font stored from resources.
        /// </summary>
        /// <param name="fontbyte">The Font stored from resources.</param>
        /// <param name="size">The Desired size for the font. Default value is 11.</param>
        /// <returns>The Font stored from resources with desired size.</returns>
        public static Font GetFont(byte[] fontbyte, float size = 11)
        {
            using (PrivateFontCollection privateFontCollection = new PrivateFontCollection())
            {
                byte[] fnt = fontbyte;
                IntPtr buffer = Marshal.AllocCoTaskMem(fnt.Length);
                Marshal.Copy(fnt, 0, buffer, fnt.Length);
                privateFontCollection.AddMemoryFont(buffer, fnt.Length);
                return new Font(privateFontCollection.Families[0].Name, size);
            }
        }

        /// <summary>
        /// Get Roboto Medimum font from resources.
        /// </summary>
        /// <param name="size">Gets or sets size of font. Default value is 11.</param>
        /// <returns></returns>
        public static Font GetRobotoMediumFont(float size = 11f)
        {
            return GetFont(Properties.Resources.Roboto_Medium, size);
        }

        /// <summary>
        /// Get Roboto Regular font from resources.
        /// </summary>
        /// <param name="size">Gets or sets size of font. Default value is 11.</param>
        /// <returns></returns>
        public static Font GetRobotoRegularFont(float size = 11f)
        {
            return GetFont(Properties.Resources.Roboto_Regular, size);
        }


        /// <summary>
        /// Get Roboto Thin font from resources.
        /// </summary>
        /// <param name="size">Gets or sets size of font. Default value is 11.</param>
        /// <returns></returns>
        public static Font GetRobotoThinFont(float size = 11f)
        {
            return GetFont(Properties.Resources.Roboto_Thin, size);
        }

        /// <summary>
        /// Get HeCopUI font from resources.
        /// </summary>
        /// <param name="size">Gets or sets size of font</param>
        /// <returns></returns>
        public static Font GetHeCopUIFont(float size = 11f)
        {
            return GetFont(Properties.Resources.Roboto_Medium, size);
        }
    }
}