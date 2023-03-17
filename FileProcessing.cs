using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FindPrintArea
{
    public static class FileProcessing
    {
        public static String BASE_DECORATED_FOLDER_NAME = "DECORATED_";
        private static String baseFolder;
        public static string BaseFolder { get => baseFolder; set => baseFolder = value; }

        public static Rectangle GetBounds(this Bitmap bmp, Color color)
        {
            int minX = int.MaxValue;
            int minY = int.MaxValue;
            int maxX = int.MinValue;
            int maxY = int.MinValue;
            int blackCount = 0;
            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    var c = bmp.GetPixel(x, y);
                    if (color == c)
                    {
                        blackCount++;
                        if (x < minX) minX = x;
                        if (x > maxX) maxX = x;
                        if (y < minY) minY = y;
                        if (y > maxY) maxY = y;
                    }
                }
            }

            var width = maxX - minX;
            var height = maxY - minY;
            if (width <= 0 || height <= 0)
            {
                // Handle case where no color was found, or if color is a single row/column 
                System.Diagnostics.Debug.WriteLine("Color: " + color.Name + " couldnt be found!");
                return default;
            }
            return new Rectangle(minX, minY, width, height);
        }

        public static List<BlankProduct> GetBlankProducts(String baseFolderPath)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            List<String> fileList = Directory.GetFiles(baseFolderPath, "*", SearchOption.AllDirectories).ToList();
            List<BlankProduct> products = new List<BlankProduct>();
            System.Diagnostics.Debug.WriteLine("listing files & folders took {" + (Double)stopwatch.ElapsedMilliseconds / 1000.0 + "} seconds.");

            Stopwatch stopwatchLoop = new Stopwatch();
            stopwatchLoop.Start();
            foreach (String file in fileList)
            {
                stopwatchLoop.Restart();
                if (!file.Contains("print_region"))
                {
                    string side = Directory.GetParent(file).Name;
                    if (side == "front")
                    {
                        BlankProduct product = new BlankProduct();
                        product.Name = Path.GetFileName(file);
                        product.Path = file;
                        product.ParentFolder = Directory.GetParent(file).FullName;
                        product.PrintRegion = getPrintRegion(file);
                        //product.PrintRegion = findPrintRegion(product.ParentFolder);
                        product.Side = Path.GetDirectoryName(product.ParentFolder);
                        products.Add(product);
                    }
                }
                System.Diagnostics.Debug.WriteLine("loop took {" + stopwatchLoop.ElapsedMilliseconds + "} miliseconds.");
            }
            stopwatch.Stop();
            System.Diagnostics.Debug.WriteLine("getting products took {" + (Double)stopwatch.ElapsedMilliseconds / 1000.0 + "} seconds.");
            System.Diagnostics.Debug.WriteLine("blank product number is= " + products.Count);
            return products;
        }

        public static List<Design> GetDesigns(String[] fileNamesArr)
        {
            List<Design> designs = new List<Design>();

            foreach (String file in fileNamesArr)
            {
                Design design = new Design();
                design.Path = file;
                design.FileName = Path.GetFileName(file);
                design.Image = resizeDesignTo600(file);
                design.DefaultDesignName = Path.GetFileNameWithoutExtension(file).Replace(" ", "_"); //.Replace("_", " ");

                designs.Add(design);
            }
            System.Diagnostics.Debug.WriteLine("design number is= " + designs.Count);
            return designs;
        }

        public static List<Image> fromFileNamesToImages(List<String> fileNames, List<Image> images)
        {
            foreach (String name in fileNames)
            {
                Image img = Image.FromFile(name);
                images.Add(img);
            }
            return images;
        }

        public static Rectangle findPrintRegion(String parentFolder)
        {
            List<String> fileNameList = Directory.GetFiles(parentFolder, "*.png").ToList();
            Rectangle printRegion;
            String printRegionFileName = fileNameList.Find(i => i.Contains("print_region"));
            fileNameList.Remove(printRegionFileName);
            Image imgPrintRegion = Image.FromFile(printRegionFileName);
            printRegion = FileProcessing.GetBounds(imgPrintRegion as Bitmap, Color.FromArgb(255, 0, 0, 0));

            imgPrintRegion.Dispose();

            return printRegion;
        }

        public static Rectangle getPrintRegion(String path)
        {
            Rectangle printRegion = new Rectangle();

            if (path.Contains("Baseball_Caps"))
                return new Rectangle(135, 201, 332, 175);
            else if (path.Contains("Brushed_Cotton_Twill_Hats"))
                return new Rectangle(125, 201, 369, 194);
            else if (path.Contains("Bucket_Hats"))
                return new Rectangle(162, 237, 291, 123);
            else if (path.Contains("Camouflage_Cotton_Twill_Cap"))
                return new Rectangle(96, 165, 408, 220);
            else if (path.Contains("Colorblock_Camouflage_Cotton_Twill_Cap"))
                return new Rectangle(93, 189, 408, 220);
            else if (path.Contains("Cotton_Twill_Hats"))
                return new Rectangle(100, 170, 400, 215);
            else if (path.Contains("Distressed_Cotton_Twil_Cap"))
                return new Rectangle(126, 163, 377, 199);
            else if (path.Contains("Foam_Trucker_Hats"))
                return new Rectangle(113, 221, 377, 199);
            else if (path.Contains("Knit_Beanies"))
                return new Rectangle(105, 393, 389, 149);
            else if (path.Contains("Knit_Caps"))
                return new Rectangle(127, 399, 355, 146);
            else if (path.Contains("Knit_Pom_Caps"))
                return new Rectangle(125, 418, 348, 140);
            else if (path.Contains("New_Era_Baseball_Mesh_Caps"))
                return new Rectangle(114, 197, 357, 205);
            else if (path.Contains("New_Era_Snapback_Caps"))
                return new Rectangle(118, 201, 364, 221);
            else if (path.Contains("Retro_Trucker_Hats"))
                return new Rectangle(120, 199, 362, 200);
            else if (path.Contains("Ripstop_Camouflage_Cotton_Twill_Cap"))
                return new Rectangle(115, 183, 368, 212);
            else if (path.Contains("Snapback_Hats"))
                return new Rectangle(147, 240, 320, 185);
            else if (path.Contains("Trucker_Hats"))
                return new Rectangle(135, 248, 330, 185);
            else if (path.Contains("Youth_Six_Panel_Twill_Caps"))
                return new Rectangle(140, 184, 330, 185);


            //printRegion = new Rectangle(minX, minY, width, height);
            return printRegion;
        }
        public static Image applyDesignOnBlank(BlankProduct blankProduct, Design design)
        {
            Bitmap bmpBlank = new Bitmap(blankProduct.Path);
            Bitmap bmpArt = design.Image;
            Rectangle newSize = fitImageIntoPrintRegion(design.Image, blankProduct.PrintRegion);

            Image mergedImage = new Bitmap(bmpBlank);
            var graphics = Graphics.FromImage(mergedImage);
            graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
            graphics.DrawImage(bmpArt, newSize.X, newSize.Y, newSize.Width, newSize.Height);

            //bmpArt.Dispose();
            bmpBlank.Dispose();
            graphics.Dispose();
            return mergedImage;
        }

        public static void saveImage(Image image, BlankProduct product, Design design)
        {
            String currentPath = product.ParentFolder;
            String newFolderName = design.GivenDesignName == null ? design.DefaultDesignName : design.GivenDesignName;
            String newFolderPath = Path.Combine(currentPath, newFolderName);

            if (!File.Exists(newFolderPath))
            {
                Directory.CreateDirectory(newFolderPath);
            }

            string file = Path.Combine(newFolderPath, design.DefaultDesignName + "_" + product.Name);
            if (!File.Exists(file))
            {
                image.Save(file, ImageFormat.Jpeg);
            }

            image.Dispose();
        }

        public static Rectangle fitImageIntoPrintRegion(Bitmap design, Rectangle printRegion)
        {
            Rectangle newSize;

            // Figure out the ratio
            double ratioX = (double)printRegion.Width / (double)design.Width;
            double ratioY = (double)printRegion.Height / (double)design.Height;
            // use whichever multiplier is smaller
            double ratio = ratioX < ratioY ? ratioX : ratioY;

            // now we can get the new height and width
            int newHeight = Convert.ToInt32(design.Height * ratio);
            int newWidth = Convert.ToInt32(design.Width * ratio);

            // Now calculate the X,Y position of the upper-left corner 

            int posX = printRegion.X + ((printRegion.Width - newWidth) / 2);
            int posY = printRegion.Y + ((printRegion.Height - newHeight) / 2);

            newSize = new Rectangle(posX, posY, newWidth, newHeight);

            //design.Dispose();

            return newSize;
        }

        /*
        public static Bitmap resizeDesignImage(String path, Rectangle maxSize)
        {
            Bitmap currentImage = new Bitmap(path);

            // Figure out the ratio
            double ratioX = (double)maxSize.Width / (double)currentImage.Width;
            double ratioY = (double)maxSize.Height / (double)currentImage.Height;
            // use whichever multiplier is smaller
            double ratio = ratioX < ratioY ? ratioX : ratioY;

            // now we can get the new height and width
            int newHeight = Convert.ToInt32(currentImage.Height * ratio);
            int newWidth = Convert.ToInt32(currentImage.Width * ratio);

            // Now calculate the X,Y position of the upper-left corner 

            int posX = maxSize.X + ((maxSize.Width - newWidth) / 2);
            int posY = maxSize.Y + ((maxSize.Height - newHeight) / 2);

            Rectangle newSize = new Rectangle(posX, posY, newWidth, newHeight);

            Bitmap bmp =
        }
        */

        public static void resizeAllBlankProductsTo600(String baseFolderPath)
        {
            List<String> fileList = Directory.GetFiles(baseFolderPath, "*.png", SearchOption.AllDirectories).ToList();

            foreach (String filePath in fileList)
            {
                Image old = Image.FromFile(filePath);
                if (old.Size != new Size(600, 600))
                {
                    Bitmap bmp = new Bitmap(old, new Size(600, 600));
                    old.Dispose();
                    bmp.Save(filePath);
                    bmp.Dispose();
                }
                else
                    old.Dispose();
            }
        }

        public static Bitmap resizeDesignTo600(String filePath)
        {
            Image old = Image.FromFile(filePath);
            Bitmap bmp = new Bitmap(old, new Size(600, 600));
            
            old.Dispose();
            //bmp.Dispose();

            return bmp;
        }

        public static void convertAllToJPEG(String baseFolderPath)
        {
            List<String> fileList = Directory.GetFiles(baseFolderPath, "*.png", SearchOption.AllDirectories).ToList();
            String newFilePath = @"C:\Workspace\Teesty\front jpegs\";

            foreach (String filePath in fileList)
            {
                String fileName = Path.GetFileNameWithoutExtension(filePath);
                Image img = Image.FromFile(filePath);

                //Bitmap bmp = new Bitmap(img.Width, img.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);


                using (Bitmap bmp = new Bitmap(img.Width, img.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb))
                {
                    ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);

                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.Clear(Color.FromArgb(246, 246, 246));
                        g.DrawImage(img, new Rectangle(new Point(), img.Size), new Rectangle(new Point(), img.Size), GraphicsUnit.Pixel);
                    }

                    // Create an Encoder object based on the GUID  
                    // for the Quality parameter category.  
                    System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;

                    // Create an EncoderParameters object.  
                    // An EncoderParameters object has an array of EncoderParameter  
                    // objects. In this case, there is only one  
                    // EncoderParameter object in the array.  

                    String newPath = Path.Combine(newFilePath, fileName);
                    //newPath = Path.Combine(newPath, ".jpg");

                    System.Diagnostics.Debug.WriteLine("newPath= " + newPath);
                    //renk 246,246,246
                    EncoderParameters myEncoderParameters = new EncoderParameters(1);

                    EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 80L);
                    myEncoderParameters.Param[0] = myEncoderParameter;

                    bmp.Save(filePath.Replace("png", "jpeg"), jpgEncoder, myEncoderParameters);


                    /*
                    myEncoderParameter = new EncoderParameter(myEncoder, 100L);
                    myEncoderParameters.Param[0] = myEncoderParameter;
                    bmp.Save(newPath + "_TestPhotoQuality100.jpg", jpgEncoder, myEncoderParameters);
                    */

                    // Save the bitmap as a JPG file with zero quality level compression.  
                    //myEncoderParameter = new EncoderParameter(myEncoder, 0L);
                    //myEncoderParameters.Param[0] = myEncoderParameter;
                    //bmp.Save(newPath + "_TestPhotoQuality0.jpg", jpgEncoder, myEncoderParameters);
                    img.Dispose();
                    bmp.Dispose();
                    File.Delete(filePath);
                }
            }
        }

        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        public static void renameAllBlankProducts(String baseFolderPath)
        {
            List<String> fileList = Directory.GetFiles(baseFolderPath, "*.png", SearchOption.AllDirectories).ToList();
            String baseFolderName = Path.GetFileName(baseFolderPath);

            foreach (String filePath in fileList)
            {
                String folder = Path.GetDirectoryName(filePath);
                String fileName = Path.GetFileName(filePath);

                String afterFolder = folder.Substring(folder.IndexOf(baseFolderName) + baseFolderName.Length + 1);

                String newFileName = afterFolder.Replace("\\", "_") + "_" + fileName;

                System.Diagnostics.Debug.WriteLine("baseFolderName: " + baseFolderName);
                System.Diagnostics.Debug.WriteLine("afterFolder: " + afterFolder);
                System.Diagnostics.Debug.WriteLine("folder: " + folder);
                System.Diagnostics.Debug.WriteLine("fileName: " + fileName);
                System.Diagnostics.Debug.WriteLine("newFileName: " + newFileName);

                File.Move(filePath, Path.Combine(folder, newFileName));

            }
        }
    }
}
