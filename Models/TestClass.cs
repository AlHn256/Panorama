using System;
using System.Collections.Generic;
using System.Linq;
using ImageMagick;
using System.Text;
using System.Threading.Tasks;

namespace TestWinForm.Models
{
    internal class TestClass
    {
        public void Test()
        {

            // Save the result
            //image.Write("Snakeware.100x100.png");


            MagickImage image = new MagickImage("input.bmp");

            // Modify the image
            // image.Rotate(90);

            //image.BackgroundColor = MagickColors.Cornsilk;
            //image.VirtualPixelMethod = VirtualPixelMethod.Background;



            //image.Distort(DistortMethod.Barrel, [0.0, 0.0, -0.075, 1.1]);
            //image.Distort(DistortMethod.Barrel, [0.0, 0.0, -0.2, 1.3]);
            image.Distort(DistortMethod.Barrel, [0.0, -0.2, -0.0, 1.3]);

            //var size = new MagickGeometry(100, 100);
            //// This will resize the image to a fixed size without maintaining the aspect ratio.
            //// Normally an image will be resized to fit inside the specified size.
            //size.IgnoreAspectRatio = true;

            //image.Resize(size);

            // Get the image as a byte array
            byte[] imageData = image.ToByteArray();

            // Save the byte array to a new file
            File.WriteAllBytes("output.jpg", imageData);

        }
    }
}
