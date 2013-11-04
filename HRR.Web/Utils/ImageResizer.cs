using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using Telerik.Web.UI;

namespace HRR.Web.Utils
{
    public class ImageResize
    {
        public static byte[] ResizeFromByteArray(int MaxSideSize, Byte[] byteArrayIn, string fileName)
        {
            byte[] byteArray = null;  // really make this an error gif
            MemoryStream ms = new MemoryStream(byteArrayIn);
            byteArray = ImageResize.ResizeFromStream(MaxSideSize, ms, fileName);

            return byteArray;
        }

        public static byte[] GetImageBytes(string ImagePath)
        {
            byte[] byteArray = null;  // really make this an error gif
            if (!string.IsNullOrEmpty(ImagePath))
            {
                if (ImagePath.Contains("http://") || ImagePath.Contains("www."))
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(ImagePath);
                    request.Method = "GET";
                    request.Accept = "image/*";
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    Stream s = response.GetResponseStream();
                    var memstream = new MemoryStream();
                    s.CopyTo(memstream);
                    byteArray = memstream.ToArray();
                }
                else
                {
                    try
                    {
                        byteArray = System.IO.File.ReadAllBytes(System.Web.HttpContext.Current.Server.MapPath(ImagePath));
                    }
                    catch (FileNotFoundException fnfe)
                    {
                        byteArray = System.IO.File.ReadAllBytes(System.Web.HttpContext.Current.Server.MapPath(HRR.Core.ResourceStrings.DummyImagePath));
                    }
                }
            }


            return byteArray;
        }

        public static byte[] ResizeFromImagePath(int MaxSideSize, string ImagePath, string fileName)
        {
            byte[] byteArray = null;  // really make this an error gif
            if (ImagePath.Contains("http://") || ImagePath.Contains("www."))
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(ImagePath);
                request.Method = "GET";
                request.Accept = "image/gif";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream s = response.GetResponseStream();
                byteArray = ImageResize.ResizeFromStream(MaxSideSize, s, fileName);
            }
            else
            {
                byteArray = null;  // really make this an error gif
                MemoryStream ms = new MemoryStream(System.IO.File.ReadAllBytes(System.Web.HttpContext.Current.Server.MapPath(ImagePath)));
                byteArray = ImageResize.ResizeFromStream(MaxSideSize, ms, fileName);
            }
            

            return byteArray;
        }

        public static void ResizeImage(int MaxSideSize, string ImagePath, RadBinaryImage radImage)
        {
            byte[] byteArray = null;  // really make this an error gif
            if (ImagePath.Contains("http://") || ImagePath.Contains("www."))
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(ImagePath);
                request.Method = "GET";
                request.Accept = "image/gif";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream s = response.GetResponseStream();
                byteArray = ImageResize.ResizeFromStream(MaxSideSize, s, "ProfilePic");
            }
            else
            {
                byteArray = null;  // really make this an error gif
                MemoryStream ms = new MemoryStream(System.IO.File.ReadAllBytes(System.Web.HttpContext.Current.Server.MapPath(ImagePath)));
                byteArray = ImageResize.ResizeFromStream(MaxSideSize, ms, "ProfilePic");
            }


            radImage.DataValue = byteArray;
            radImage.ResizeMode = Telerik.Web.UI.BinaryImageResizeMode.Crop;
        }


        public static byte[] ResizeFromStream(int MaxSideSize, Stream Buffer, string fileName)
        {
            byte[] byteArray = null;  // really make this an error gif 

            try
            {

                Bitmap bitMap = new Bitmap(Buffer);
                int intOldWidth = bitMap.Width;
                int intOldHeight = bitMap.Height;

                int intNewWidth;
                int intNewHeight;

                int intMaxSide;

                if (intOldWidth >= intOldHeight)
                {
                    intMaxSide = intOldWidth;
                }
                else
                {
                    intMaxSide = intOldHeight;
                }

                if (intMaxSide > MaxSideSize)
                {
                    //set new width and height
                    double dblCoef = MaxSideSize / (double)intMaxSide;
                    intNewWidth = Convert.ToInt32(dblCoef * intOldWidth);
                    intNewHeight = Convert.ToInt32(dblCoef * intOldHeight);
                }
                else
                {
                    intNewWidth = intOldWidth;
                    intNewHeight = intOldHeight;
                }

                Size ThumbNailSize = new Size(intNewWidth, intNewHeight);
                System.Drawing.Image oImg = System.Drawing.Image.FromStream(Buffer);
                System.Drawing.Image oThumbNail = new Bitmap(ThumbNailSize.Width, ThumbNailSize.Height);

                Graphics oGraphic = Graphics.FromImage(oThumbNail);
                oGraphic.CompositingQuality = CompositingQuality.HighQuality;
                oGraphic.SmoothingMode = SmoothingMode.HighQuality;
                oGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
                Rectangle oRectangle = new Rectangle
                    (0, 0, ThumbNailSize.Width, ThumbNailSize.Height);

                oGraphic.DrawImage(oImg, oRectangle);

                MemoryStream ms = new MemoryStream();
                oThumbNail.Save(ms, ImageFormat.Jpeg);
                byteArray = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(byteArray, 0, Convert.ToInt32(ms.Length));

                oGraphic.Dispose();
                oImg.Dispose();
                ms.Close();
                ms.Dispose();
            }
            catch (Exception)
            {
                int newSize = MaxSideSize - 20;
                Bitmap bitMap = new Bitmap(newSize, newSize);
                Graphics g = Graphics.FromImage(bitMap);
                g.FillRectangle(new SolidBrush(Color.Gray), new Rectangle(0, 0, newSize, newSize));

                Font font = new Font("Courier", 8);
                SolidBrush solidBrush = new SolidBrush(Color.Red);
                g.DrawString("Failed File.  Use Different Image", font, solidBrush, 10, 5);
                g.DrawString(fileName, font, solidBrush, 10, 50);

                MemoryStream ms = new MemoryStream();
                bitMap.Save(ms, ImageFormat.Jpeg);
                byteArray = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(byteArray, 0, Convert.ToInt32(ms.Length));

                ms.Close();
                ms.Dispose();
                bitMap.Dispose();
                solidBrush.Dispose();
                g.Dispose();
                font.Dispose();

            }
            return byteArray;
        }
        public static byte[] AddWaterMark(Byte[] byteArrayIn, string watermarkText, Brush brushcolor)
        {
            byte[] byteArray = null;
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image img = System.Drawing.Image.FromStream(ms);

            ImageCodecInfo jgpEncoder = GetEncoder(ImageFormat.Jpeg);
            Encoder myEncoder = Encoder.Quality;
            EncoderParameters myEncoderParameters = new EncoderParameters(1);
            EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 75L);
            myEncoderParameters.Param[0] = myEncoderParameter;

            Graphics gr = Graphics.FromImage(img);
            gr.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            gr.DrawString(watermarkText, new Font("Tahoma", 10), brushcolor, new Point(0, 0));

            MemoryStream output = new MemoryStream();
            img.Save(output, jgpEncoder, myEncoderParameters);
            byteArray = new byte[output.Length];
            output.Position = 0;
            output.Read(byteArray, 0, Convert.ToInt32(output.Length));
            return byteArray;
        }
        public static byte[] AddWaterMarkWithQualitySetting(Byte[] byteArrayIn, string watermarkText, Brush brushcolor)
        {
            byte[] byteArray = null;
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image img = System.Drawing.Image.FromStream(ms);

            ImageCodecInfo jgpEncoder = GetEncoder(ImageFormat.Jpeg);
            Encoder myEncoder = Encoder.Quality;
            EncoderParameters myEncoderParameters = new EncoderParameters(1);
            EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 75L); //%75
            myEncoderParameters.Param[0] = myEncoderParameter;

            Graphics gr = Graphics.FromImage(img);
            gr.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            gr.DrawString(watermarkText, new Font("Tahoma", 10), brushcolor, new Point(0, 0));

            MemoryStream output = new MemoryStream();
            img.Save(output, jgpEncoder, myEncoderParameters);
            byteArray = new byte[output.Length];
            output.Position = 0;
            output.Read(byteArray, 0, Convert.ToInt32(output.Length));
            return byteArray;
        }
        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }
    }
}