using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeCopUI_Framework.Enums
{
    /// <summary>
    /// Enum representing different kernel modes in image processing.
    /// </summary>
    public enum KernelMode
    {
        /// <summary>
        /// Box Blur mode: Applies a simple kernel, averaging pixel values around to blur the image.
        /// </summary>
        BoxBlur,

        /// <summary>
        /// Gaussian Blur mode: Uses a Gaussian distribution kernel to blur the image, creating a soft, smooth blur effect.
        /// </summary>
        GaussianBlur
    }

}
