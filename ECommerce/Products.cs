using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ECommerce
{
    public partial class Products : Form
    {
        public Products()
        {
            InitializeComponent();
        }

        DatabaseOperations dbo = new DatabaseOperations();
        MySqlConnection mysql;
        MySqlDataAdapter adapter;
        MySqlCommand command;
        DataTable dt;
        string filePath;

        private void Products_Load(object sender, EventArgs e)
        {
            try
            {
                mysql = dbo.Connect();
                if (mysql.State != ConnectionState.Open)
                {
                    mysql.Open();
                }
                command = new MySqlCommand("SELECT productId, productDescription FROM product WHERE supplierId = @supplierId", mysql);
                command.Parameters.AddWithValue("@supplierId", LoginInfo.id);
                adapter = new MySqlDataAdapter(command);
                dt = new DataTable();
                adapter.Fill(dt);
                comboProducts.DataSource = dt;
                comboProducts.DisplayMember = "productDescription";
                comboProducts.ValueMember = "productId";
                adapter = new MySqlDataAdapter("SELECT * FROM categories", mysql);
                dt = new DataTable();
                adapter.Fill(dt);
                comboProductCategory.DataSource = dt;
                comboProductCategory.DisplayMember = "categoryName";
                comboProductCategory.ValueMember = "categoryId";
                mysql.Close();
                MessageBox.Show("Hatayla Karşılaşmamak İçin Fotoğrafı Tekrar Seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void comboProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                mysql = dbo.Connect();
                if (mysql.State != ConnectionState.Open)
                {
                    mysql.Open();
                }
                command = new MySqlCommand("SELECT * FROM product WHERE productId = @productId", mysql);
                command.Parameters.AddWithValue("@productId", comboProducts.SelectedValue);
                command.ExecuteNonQuery();
                adapter = new MySqlDataAdapter(command);
                dt = new DataTable();
                adapter.Fill(dt);
                txtProductDescription.Text = dt.Rows[0]["productDescription"].ToString();
                comboProductCategory.SelectedValue = dt.Rows[0]["categoryId"];
                txtPrice.Text = dt.Rows[0]["price"].ToString();
                txtPrice.Text = txtPrice.Text.Replace(",", ".");
                numericUnitsInStock.Value = Convert.ToInt32(dt.Rows[0]["unitsInStock"]);
                if (dt.Rows[0]["productAvailable"].ToString() == "1")
                {
                    radioYes.Checked = true;
                }
                else
                {
                    radioNo.Checked = true;
                }
                byte[] img = (byte[])dt.Rows[0]["picture"];
                MemoryStream ms = new MemoryStream(img);
                pbProductPhoto.Image = Image.FromStream(ms);
                mysql.Close();
            }
            catch (Exception ex)
            {

            }
        }

        private void Products_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainMenu mm = new MainMenu();
            mm.Show();
            this.Hide();
        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            try
            {
                mysql = dbo.Connect();
                if (mysql.State != ConnectionState.Open)
                {
                    mysql.Open();
                }
                command = new MySqlCommand("UPDATE product SET productDescription = @productDescription, categoryId = @categoryId, price = @price, unitsInStock = @unitsInStock, productAvailable = @productAvailable, picture = @picture WHERE productId = @productId", mysql);
                command.Parameters.AddWithValue("@productId", comboProducts.SelectedValue);
                command.Parameters.AddWithValue("@productDescription", txtProductDescription.Text);
                command.Parameters.AddWithValue("@categoryId", comboProductCategory.SelectedValue);
                command.Parameters.AddWithValue("@price", txtPrice.Text);
                command.Parameters.AddWithValue("@unitsInStock", numericUnitsInStock.Value);
                command.Parameters.AddWithValue("@productAvailable", CheckRadioButtons());
                FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                byte[] img = br.ReadBytes((int)fs.Length);
                br.Close();
                fs.Close();
                command.Parameters.Add("@picture", MySqlDbType.Blob, img.Length).Value = img;
                command.ExecuteNonQuery();
                mysql.Close();
                MessageBox.Show("Ürün başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int CheckRadioButtons()
        {
            if (radioNo.Checked)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        private void btnChoosePhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Resim Dosyası |*.jpg;*.png;*.jpeg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filePath = ofd.FileName;
                pbProductPhoto.Image = Image.FromFile(filePath);
            }
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            try
            {
                mysql = dbo.Connect();
                if (mysql.State != ConnectionState.Open)
                {
                    mysql.Open();
                }
                command = new MySqlCommand("DELETE FROM product WHERE supplierId = @supplierId AND productId = @productId", mysql);
                command.Parameters.AddWithValue("@supplierId", LoginInfo.id);
                command.Parameters.AddWithValue("@productId", comboProducts.SelectedValue);
                command.ExecuteNonQuery();
                MessageBox.Show("Ürün Başarıyla Silindi!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                MainMenu mm = new MainMenu();
                mm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
