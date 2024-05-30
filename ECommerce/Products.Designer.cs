namespace ECommerce
{
    partial class Products
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
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.comboProducts = new System.Windows.Forms.ComboBox();
            this.btnChoosePhoto = new System.Windows.Forms.Button();
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
            this.btnUpdateProduct = new System.Windows.Forms.Button();
            this.btnDeleteProduct = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProductPhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUnitsInStock)).BeginInit();
            this.SuspendLayout();
            // 
            // pbLogo
            // 
            this.pbLogo.Image = global::ECommerce.Properties.Resources.bayraktar;
            this.pbLogo.Location = new System.Drawing.Point(242, 0);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(100, 100);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 1;
            this.pbLogo.TabStop = false;
            // 
            // comboProducts
            // 
            this.comboProducts.FormattingEnabled = true;
            this.comboProducts.Location = new System.Drawing.Point(77, 120);
            this.comboProducts.Name = "comboProducts";
            this.comboProducts.Size = new System.Drawing.Size(433, 21);
            this.comboProducts.TabIndex = 59;
            this.comboProducts.TabStop = false;
            this.comboProducts.SelectedIndexChanged += new System.EventHandler(this.comboProducts_SelectedIndexChanged);
            // 
            // btnChoosePhoto
            // 
            this.btnChoosePhoto.Location = new System.Drawing.Point(410, 318);
            this.btnChoosePhoto.Name = "btnChoosePhoto";
            this.btnChoosePhoto.Size = new System.Drawing.Size(100, 23);
            this.btnChoosePhoto.TabIndex = 58;
            this.btnChoosePhoto.TabStop = false;
            this.btnChoosePhoto.Text = "Fotoğraf Seç";
            this.btnChoosePhoto.UseVisualStyleBackColor = true;
            this.btnChoosePhoto.Click += new System.EventHandler(this.btnChoosePhoto_Click);
            // 
            // pbProductPhoto
            // 
            this.pbProductPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbProductPhoto.Location = new System.Drawing.Point(410, 212);
            this.pbProductPhoto.Name = "pbProductPhoto";
            this.pbProductPhoto.Size = new System.Drawing.Size(100, 100);
            this.pbProductPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbProductPhoto.TabIndex = 57;
            this.pbProductPhoto.TabStop = false;
            // 
            // radioYes
            // 
            this.radioYes.AutoSize = true;
            this.radioYes.Location = new System.Drawing.Point(410, 189);
            this.radioYes.Name = "radioYes";
            this.radioYes.Size = new System.Drawing.Size(47, 17);
            this.radioYes.TabIndex = 56;
            this.radioYes.Text = "Evet";
            this.radioYes.UseVisualStyleBackColor = true;
            // 
            // radioNo
            // 
            this.radioNo.AutoSize = true;
            this.radioNo.Location = new System.Drawing.Point(410, 166);
            this.radioNo.Name = "radioNo";
            this.radioNo.Size = new System.Drawing.Size(49, 17);
            this.radioNo.TabIndex = 55;
            this.radioNo.Text = "Hayır";
            this.radioNo.UseVisualStyleBackColor = true;
            // 
            // numericUnitsInStock
            // 
            this.numericUnitsInStock.Location = new System.Drawing.Point(185, 320);
            this.numericUnitsInStock.Name = "numericUnitsInStock";
            this.numericUnitsInStock.Size = new System.Drawing.Size(100, 20);
            this.numericUnitsInStock.TabIndex = 54;
            this.numericUnitsInStock.TabStop = false;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(185, 294);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(100, 20);
            this.txtPrice.TabIndex = 53;
            this.txtPrice.TabStop = false;
            // 
            // comboProductCategory
            // 
            this.comboProductCategory.FormattingEnabled = true;
            this.comboProductCategory.Location = new System.Drawing.Point(185, 267);
            this.comboProductCategory.Name = "comboProductCategory";
            this.comboProductCategory.Size = new System.Drawing.Size(100, 21);
            this.comboProductCategory.TabIndex = 52;
            this.comboProductCategory.TabStop = false;
            // 
            // txtProductDescription
            // 
            this.txtProductDescription.Location = new System.Drawing.Point(185, 165);
            this.txtProductDescription.Name = "txtProductDescription";
            this.txtProductDescription.Size = new System.Drawing.Size(100, 96);
            this.txtProductDescription.TabIndex = 51;
            this.txtProductDescription.TabStop = false;
            this.txtProductDescription.Text = "";
            // 
            // lblPicture
            // 
            this.lblPicture.AutoSize = true;
            this.lblPicture.Location = new System.Drawing.Point(327, 212);
            this.lblPicture.Name = "lblPicture";
            this.lblPicture.Size = new System.Drawing.Size(77, 13);
            this.lblPicture.TabIndex = 50;
            this.lblPicture.Text = "Ürün Fotoğrafı:";
            // 
            // lblProductAvailable
            // 
            this.lblProductAvailable.AutoSize = true;
            this.lblProductAvailable.Location = new System.Drawing.Point(330, 168);
            this.lblProductAvailable.Name = "lblProductAvailable";
            this.lblProductAvailable.Size = new System.Drawing.Size(74, 13);
            this.lblProductAvailable.TabIndex = 49;
            this.lblProductAvailable.Text = "Ürün Hazır Mı:";
            // 
            // lblUnitsInStock
            // 
            this.lblUnitsInStock.AutoSize = true;
            this.lblUnitsInStock.Location = new System.Drawing.Point(74, 322);
            this.lblUnitsInStock.Name = "lblUnitsInStock";
            this.lblUnitsInStock.Size = new System.Drawing.Size(105, 13);
            this.lblUnitsInStock.TabIndex = 48;
            this.lblUnitsInStock.Text = "Stoktaki Ürün Sayısı:";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(147, 297);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(32, 13);
            this.lblPrice.TabIndex = 47;
            this.lblPrice.Text = "Fiyat:";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(130, 270);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(49, 13);
            this.lblCategory.TabIndex = 46;
            this.lblCategory.Text = "Kategori:";
            // 
            // lblProductDescription
            // 
            this.lblProductDescription.AutoSize = true;
            this.lblProductDescription.Location = new System.Drawing.Point(93, 168);
            this.lblProductDescription.Name = "lblProductDescription";
            this.lblProductDescription.Size = new System.Drawing.Size(86, 13);
            this.lblProductDescription.TabIndex = 45;
            this.lblProductDescription.Text = "Ürün Açıklaması:";
            // 
            // btnUpdateProduct
            // 
            this.btnUpdateProduct.Location = new System.Drawing.Point(181, 367);
            this.btnUpdateProduct.Name = "btnUpdateProduct";
            this.btnUpdateProduct.Size = new System.Drawing.Size(223, 23);
            this.btnUpdateProduct.TabIndex = 61;
            this.btnUpdateProduct.TabStop = false;
            this.btnUpdateProduct.Text = "Bilgileri Güncelle";
            this.btnUpdateProduct.UseVisualStyleBackColor = true;
            this.btnUpdateProduct.Click += new System.EventHandler(this.btnUpdateProduct_Click);
            // 
            // btnDeleteProduct
            // 
            this.btnDeleteProduct.Location = new System.Drawing.Point(181, 396);
            this.btnDeleteProduct.Name = "btnDeleteProduct";
            this.btnDeleteProduct.Size = new System.Drawing.Size(223, 23);
            this.btnDeleteProduct.TabIndex = 62;
            this.btnDeleteProduct.Text = "Ürünü Sil";
            this.btnDeleteProduct.UseVisualStyleBackColor = true;
            this.btnDeleteProduct.Click += new System.EventHandler(this.btnDeleteProduct_Click);
            // 
            // Products
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.btnDeleteProduct);
            this.Controls.Add(this.btnUpdateProduct);
            this.Controls.Add(this.comboProducts);
            this.Controls.Add(this.btnChoosePhoto);
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
            this.Controls.Add(this.pbLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Products";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ürünler";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Products_FormClosed);
            this.Load += new System.EventHandler(this.Products_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProductPhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUnitsInStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.ComboBox comboProducts;
        private System.Windows.Forms.Button btnChoosePhoto;
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
        private System.Windows.Forms.Button btnUpdateProduct;
        private System.Windows.Forms.Button btnDeleteProduct;
    }
}