namespace FindPrintArea
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param00000000000000000000>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbBlankProduct = new System.Windows.Forms.PictureBox();
            this.btnChooseBlank = new System.Windows.Forms.Button();
            this.btnChooseArt = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.textDesignPath = new System.Windows.Forms.TextBox();
            this.btnSaveDesign = new System.Windows.Forms.Button();
            this.btnResizeAll = new System.Windows.Forms.Button();
            this.btnRenameAll = new System.Windows.Forms.Button();
            this.btnConvertToJpeg = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbBlankProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // pbBlankProduct
            // 
            this.pbBlankProduct.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbBlankProduct.Location = new System.Drawing.Point(12, 12);
            this.pbBlankProduct.Name = "pbBlankProduct";
            this.pbBlankProduct.Size = new System.Drawing.Size(361, 490);
            this.pbBlankProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbBlankProduct.TabIndex = 0;
            this.pbBlankProduct.TabStop = false;
            // 
            // btnChooseBlank
            // 
            this.btnChooseBlank.AutoSize = true;
            this.btnChooseBlank.Location = new System.Drawing.Point(379, 12);
            this.btnChooseBlank.Name = "btnChooseBlank";
            this.btnChooseBlank.Size = new System.Drawing.Size(139, 25);
            this.btnChooseBlank.TabIndex = 1;
            this.btnChooseBlank.Text = "Load Blank Products";
            this.btnChooseBlank.UseVisualStyleBackColor = true;
            this.btnChooseBlank.Click += new System.EventHandler(this.btnChooseBlank_Click);
            // 
            // btnChooseArt
            // 
            this.btnChooseArt.AutoSize = true;
            this.btnChooseArt.Location = new System.Drawing.Point(379, 43);
            this.btnChooseArt.Name = "btnChooseArt";
            this.btnChooseArt.Size = new System.Drawing.Size(139, 25);
            this.btnChooseArt.TabIndex = 3;
            this.btnChooseArt.Text = "Select Design";
            this.btnChooseArt.UseVisualStyleBackColor = true;
            this.btnChooseArt.Click += new System.EventHandler(this.btnChooseArt_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(379, 192);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(139, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Create";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // textDesignPath
            // 
            this.textDesignPath.Location = new System.Drawing.Point(379, 99);
            this.textDesignPath.Name = "textDesignPath";
            this.textDesignPath.Size = new System.Drawing.Size(139, 23);
            this.textDesignPath.TabIndex = 6;
            // 
            // btnSaveDesign
            // 
            this.btnSaveDesign.Location = new System.Drawing.Point(379, 128);
            this.btnSaveDesign.Name = "btnSaveDesign";
            this.btnSaveDesign.Size = new System.Drawing.Size(139, 23);
            this.btnSaveDesign.TabIndex = 7;
            this.btnSaveDesign.Text = "Set Design Folder";
            this.btnSaveDesign.UseVisualStyleBackColor = true;
            this.btnSaveDesign.Click += new System.EventHandler(this.btnSaveDesign_Click);
            // 
            // btnResizeAll
            // 
            this.btnResizeAll.Location = new System.Drawing.Point(379, 327);
            this.btnResizeAll.Name = "btnResizeAll";
            this.btnResizeAll.Size = new System.Drawing.Size(139, 23);
            this.btnResizeAll.TabIndex = 8;
            this.btnResizeAll.Text = "Resize All Blanks";
            this.btnResizeAll.UseVisualStyleBackColor = true;
            this.btnResizeAll.Click += new System.EventHandler(this.btnResizeAll_Click);
            // 
            // btnRenameAll
            // 
            this.btnRenameAll.Location = new System.Drawing.Point(379, 356);
            this.btnRenameAll.Name = "btnRenameAll";
            this.btnRenameAll.Size = new System.Drawing.Size(139, 23);
            this.btnRenameAll.TabIndex = 9;
            this.btnRenameAll.Text = "Rename All Blanks";
            this.btnRenameAll.UseVisualStyleBackColor = true;
            this.btnRenameAll.Click += new System.EventHandler(this.btnRenameAll_Click);
            // 
            // btnConvertToJpeg
            // 
            this.btnConvertToJpeg.Location = new System.Drawing.Point(379, 385);
            this.btnConvertToJpeg.Name = "btnConvertToJpeg";
            this.btnConvertToJpeg.Size = new System.Drawing.Size(139, 23);
            this.btnConvertToJpeg.TabIndex = 10;
            this.btnConvertToJpeg.Text = "Convert To JPEG";
            this.btnConvertToJpeg.UseVisualStyleBackColor = true;
            this.btnConvertToJpeg.Click += new System.EventHandler(this.btnConvertToJpeg_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 514);
            this.Controls.Add(this.btnConvertToJpeg);
            this.Controls.Add(this.btnRenameAll);
            this.Controls.Add(this.btnResizeAll);
            this.Controls.Add(this.btnSaveDesign);
            this.Controls.Add(this.textDesignPath);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnChooseArt);
            this.Controls.Add(this.btnChooseBlank);
            this.Controls.Add(this.pbBlankProduct);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pbBlankProduct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pbBlankProduct;
        private Button btnChooseBlank;
        private Button btnChooseArt;
        private Button btnSave;
        private TextBox textDesignPath;
        private Button btnSaveDesign;
        private Button btnResizeAll;
        private Button btnRenameAll;
        private Button btnConvertToJpeg;
    }
}