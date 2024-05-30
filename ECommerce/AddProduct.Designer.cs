namespace ECommerce
{
    partial class AddProduct
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbProductPhoto = new System.Windows.Forms.PictureBox();
            this.radioYes = new System.Windows.Forms.RadioButton();
            this.radioNo = new System.Windows.Forms.RadioButton();
            this.numericUnitsInStock = new System.Windows.Forms.NumericUpDown();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.comboProductCategory = new System.Windows.Forms.ComboBox();
            this.txtProductDescription = new System.Windows.Forms.RichTextBox();
            this.lblPicture = new System.Windows.Forms.Label();
            this.lblProductAvailable = new System.Windows.Forms.Label();
            this.lblUnitsInStock = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblProductDescription = new System.Windows.Forms.Label();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnChoosePhoto = new System.Windows.Forms.Button();
            this.btnAddProduct = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbProductPhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUnitsInStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pbProductPhoto
            // 
            this.pbProductPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbProductPhoto.Location = new System.Drawing.Point(371, 165);
            this.pbProductPhoto.Name = "pbProductPhoto";
            this.pbProductPhoto.Size = new System.Drawing.Size(100, 100);
            this.pbProductPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbProductPhoto.TabIndex = 27;
            this.pbProductPhoto.TabStop = false;
            // 
            // radioYes
            // 
            this.radioYes.AutoSize = true;
            this.radioYes.Location = new System.Drawing.Point(371, 142);
            this.radioYes.Name = "radioYes";
            this.radioYes.Size = new System.Drawing.Size(47, 17);
            this.radioYes.TabIndex = 26;
            this.radioYes.TabStop = true;
            this.radioYes.Text = "Evet";
            this.radioYes.UseVisualStyleBackColor = true;
            // 
            // radioNo
            // 
            this.radioNo.AutoSize = true;
            this.radioNo.Location = new System.Drawing.Point(371, 119);
            this.radioNo.Name = "radioNo";
            this.radioNo.Size = new System.Drawing.Size(49, 17);
            this.radioNo.TabIndex = 25;
            this.radioNo.TabStop = true;
            this.radioNo.Text = "Hayır";
            this.radioNo.UseVisualStyleBackColor = true;
            // 
            // numericUnitsInStock
            // 
            this.numericUnitsInStock.Location = new System.Drawing.Point(146, 273);
            this.numericUnitsInStock.Name = "numericUnitsInStock";
            this.numericUnitsInStock.Size = new System.Drawing.Size(100, 20);
            this.numericUnitsInStock.TabIndex = 24;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(146, 247);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(100, 20);
            this.txtPrice.TabIndex = 23;
            // 
            // comboProductCategory
            // 
            this.comboProductCategory.FormattingEnabled = true;
            this.comboProductCategory.Location = new System.Drawing.Point(146, 220);
            this.comboProductCategory.Name = "comboProductCategory";
            this.comboProductCategory.Size = new System.Drawing.Size(100, 21);
            this.comboProductCategory.TabIndex = 22;
            // 
            // txtProductDescription
            // 
            this.txtProductDescription.Location = new System.Drawing.Point(146, 118);
            this.txtProductDescription.Name = "txtProductDescription";
            this.txtProductDescription.Size = new System.Drawing.Size(100, 96);
            this.txtProductDescription.TabIndex = 21;
            this.txtProductDescription.Text = "";
            // 
            // lblPicture
            // 
            this.lblPicture.AutoSize = true;
            this.lblPicture.Location = new System.Drawing.Point(288, 165);
            this.lblPicture.Name = "lblPicture";
            this.lblPicture.Size = new System.Drawing.Size(77, 13);
            this.lblPicture.TabIndex = 20;
            this.lblPicture.Text = "Ürün Fotoğrafı:";
            // 
            // lblProductAvailable
            // 
            this.lblProductAvailable.AutoSize = true;
            this.lblProductAvailable.Location = new System.Drawing.Point(291, 121);
            this.lblProductAvailable.Name = "lblProductAvailable";
            this.lblProductAvailable.Size = new System.Drawing.Size(74, 13);
            this.lblProductAvailable.TabIndex = 19;
            this.lblProductAvailable.Text = "Ürün Hazır Mı:";
            // 
            // lblUnitsInStock
            // 
            this.lblUnitsInStock.AutoSize = true;
            this.lblUnitsInStock.Location = new System.Drawing.Point(35, 275);
            this.lblUnitsInStock.Name = "lblUnitsInStock";
            this.lblUnitsInStock.Size = new System.Drawing.Size(105, 13);
            this.lblUnitsInStock.TabIndex = 18;
            this.lblUnitsInStock.Text = "Stoktaki Ürün Sayısı:";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(108, 250);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(32, 13);
            this.lblPrice.TabIndex = 17;
            this.lblPrice.Text = "Fiyat:";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(91, 223);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(49, 13);
            this.lblCategory.TabIndex = 16;
            this.lblCategory.Text = "Kategori:";
            // 
            // lblProductDescription
            // 
            this.lblProductDescription.AutoSize = true;
            this.lblProductDescription.Location = new System.Drawing.Point(54, 121);
            this.lblProductDescription.Name = "lblProductDescription";
            this.lblProductDescription.Size = new System.Drawing.Size(86, 13);
            this.lblProductDescription.TabIndex = 15;
            this.lblProductDescription.Text = "Ürün Açıklaması:";
            // 
            // pbLogo
            // 
            this.pbLogo.Image = global::ECommerce.Properties.Resources.bayraktar;
            this.pbLogo.Location = new System.Drawing.Point(217, 0);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(100, 100);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 28;
            this.pbLogo.TabStop = false;
            // 
            // btnChoosePhoto
            // 
            this.btnChoosePhoto.Location = new System.Drawing.Point(371, 271);
            this.btnChoosePhoto.Name = "btnChoosePhoto";
            this.btnChoosePhoto.Size = new System.Drawing.Size(100, 23);
            this.btnChoosePhoto.TabIndex = 29;
            this.btnChoosePhoto.Text = "Fotoğraf Seç";
            this.btnChoosePhoto.UseVisualStyleBackColor = true;
            this.btnChoosePhoto.Click += new System.EventHandler(this.btnChoosePhoto_Click);
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Location = new System.Drawing.Point(111, 328);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(325, 23);
            this.btnAddProduct.TabIndex = 30;
            this.btnAddProduct.Text = "Ürün Ekle";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // AddProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 411);
            this.Controls.Add(this.btnAddProduct);
            this.Controls.Add(this.btnChoosePhoto);
            this.Controls.Add(this.pbLogo);
            this.Controls.Add(this.pbProductPhoto);
            this.Controls.Add(this.radioYes);
            this.Controls.Add(this.radioNo);
            this.Controls.Add(this.numericUnitsInStock);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.comboProductCategory);
            this.Controls.Add(this.txtProductDescription);
            this.Controls.Add(this.lblPicture);
            this.Controls.Add(this.lblProductAvailable);
            this.Controls.Add(this.lblUnitsInStock);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblProductDescription);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AddProduct";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ürün Ekle";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddProduct_FormClosed);
            this.Load += new System.EventHandler(this.AddProduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbProductPhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUnitsInStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbProductPhoto;
        private System.Windows.Forms.RadioButton radioYes;
        private System.Windows.Forms.RadioButton radioNo;
        private System.Windows.Forms.NumericUpDown numericUnitsInStock;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.ComboBox comboProductCategory;
        private System.Windows.Forms.RichTextBox txtProductDescription;
        private System.Windows.Forms.Label lblPicture;
        private System.Windows.Forms.Label lblProductAvailable;
        private System.Windows.Forms.Label lblUnitsInStock;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblProductDescription;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Button btnChoosePhoto;
        private System.Windows.Forms.Button btnAddProduct;
    }
}