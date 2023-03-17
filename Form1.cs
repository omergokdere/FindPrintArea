using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using System.Drawing.Imaging;

namespace FindPrintArea
{
    public partial class Form1 : Form
    {
        public List<BlankProduct> blankProducts { get; set; }
        public List<Design> designs { get; set; }
        public Design design { get; set; }
        public String designPath;
        public Image mergedImage;
        string baseFolderPath;

        public Form1()
        {
            InitializeComponent();
            design = new Design();
        }

        private void btnChooseBlank_Click(object sender, EventArgs e)
        {
            string baseFolderPath = getBaseFolder();
            FileProcessing.BaseFolder = baseFolderPath;
            blankProducts = FileProcessing.GetBlankProducts(baseFolderPath);

        }

        private String getBaseFolder()
        {
            string folderPath = null;
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.InitialDirectory = Directory.GetCurrentDirectory();

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                folderPath = dialog.SelectedPath;  //selected folder path

            }

            return folderPath;
        }

        private void btnChooseArt_Click(object sender, EventArgs e)
        {
            OpenFileDialog artSelection = new OpenFileDialog();
            artSelection.InitialDirectory = Directory.GetCurrentDirectory();
            artSelection.Filter = "PNG files (*.png)|*.png|BMP Files(*.bmp)|*.bmp";
            artSelection.Title = "Please select png/bmp design images to apply on blank products.";
            artSelection.Multiselect = true;
            DialogResult result = artSelection.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                designs = FileProcessing.GetDesigns(artSelection.FileNames);
                design.Path = artSelection.FileName;
                design.FileName = Path.GetFileName(design.Path);
                string text = artSelection.FileName;
                text = Path.GetFileNameWithoutExtension(text);
                text = text.Replace("_", " ");
                if(designs.Count == 1)
                    textDesignPath.Text = designs.FirstOrDefault().DefaultDesignName;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            foreach (Design design in designs)
            {
                foreach (BlankProduct bp in blankProducts)
                {
                    mergedImage = FileProcessing.applyDesignOnBlank(bp, design);
                    FileProcessing.saveImage(mergedImage, bp, design);
                    mergedImage.Dispose();
                }
            }
            stopwatch.Stop();
            System.Diagnostics.Debug.WriteLine("creating {" + designs.Count * blankProducts.Count + "} new products took {" + (Double)stopwatch.ElapsedMilliseconds / 1000.0 + "} seconds.");
        }

        private void btnSaveDesign_Click(object sender, EventArgs e)
        {
            if(textDesignPath.Text != "")
                design.GivenDesignName = textDesignPath.Text;
        }

        private void btnResizeAll_Click(object sender, EventArgs e)
        {
            FileProcessing.resizeAllBlankProductsTo600(FileProcessing.BaseFolder);
        }

        private void btnRenameAll_Click(object sender, EventArgs e)
        {
            FileProcessing.renameAllBlankProducts(FileProcessing.BaseFolder);
        }

        private void btnConvertToJpeg_Click(object sender, EventArgs e)
        {
            FileProcessing.convertAllToJPEG(FileProcessing.BaseFolder);
        }
    }
}