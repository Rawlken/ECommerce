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
using MySql.Data.MySqlClient;

namespace ECommerce
{
    public partial class AddProduct : Form
    {
        public AddProduct()
        {
            InitializeComponent();
        }

        DatabaseOperations dbo = new DatabaseOperations();
        MySqlConnection mysql;
        MySqlDataAdapter adapter;
        MySqlCommand command;
        DataTable dt;
        string filePath;

        private void btnChoosePhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(*.jpg; *.jpeg; *.png;)|*.jpg; *.jpeg; *.png;";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filePath = Path.GetFullPath(ofd.FileName);
                pbProductPhoto.Image = Image.FromFile(filePath);
            }
        }

        private bool CheckRadioButtons()
        {
            if (radioNo.Checked)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                mysql = dbo.Connect();
                if (mysql.State != ConnectionState.Open)
                {
                    mysql.Open();
                }
                adapter = new MySqlDataAdapter("SELECT supplierId FROM supplier WHERE supplierEmail = @supplierEmail", mysql);
                adapter.SelectCommand.Parameters.AddWithValue("@supplierEmail", LoginInfo.email);
                dt = new DataTable();
                adapter.Fill(dt);
                command = new MySqlCommand("INSERT INTO product(productDescription, supplierId, categoryId, price, unitsInStock, productAvailable, picture) VALUES (@productDescription, @supplierId, @categoryId, @price, @unitsInStock, @productAvailable, @picture)", mysql);
                command.Parameters.AddWithValue("@productDescription", txtProductDescription.Text);
                command.Parameters.AddWithValue("@supplierId", dt.Rows[0]["supplierId"].ToString());
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
                MessageBox.Show("Ürün başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddProduct_Load(object sender, EventArgs e)
        {
            try
            {
                mysql = dbo.Connect();
                if (mysql.State != ConnectionState.Open)
                {
                    mysql.Open();
                }
                adapter = new MySqlDataAdapter("SELECT * FROM categories", mysql);
                dt = new DataTable();
                adapter.Fill(dt);
                comboProductCategory.DataSource = dt;
                comboProductCategory.DisplayMember = "categoryName";
                comboProductCategory.ValueMember = "categoryId";
                mysql.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddProduct_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainMenu mm = new MainMenu();
            mm.Show();
            this.Hide();
        }
    }
}
