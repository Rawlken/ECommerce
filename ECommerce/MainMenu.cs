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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        List<int> randomProductIds;
        DatabaseOperations dbo = new DatabaseOperations();
        MySqlConnection mysql;
        MySqlDataAdapter adapter;
        MySqlCommand command;
        DataTable dt;
        double totalPrice = 0;

        private bool isClicked;
        private Point location;

        private void MainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
            Application.ExitThread();
        }

        private void MainMenu_MouseDown(object sender, MouseEventArgs e)
        {
            isClicked = true;
            location = e.Location;
        }

        private void MainMenu_MouseMove(object sender, MouseEventArgs e)
        {
            if (isClicked == true)
            {
                this.Location = new Point(this.Location.X - location.X + e.X, this.Location.Y - location.Y + e.Y);
                this.Update();
            }
        }

        private void MainMenu_MouseUp(object sender, MouseEventArgs e)
        {
            isClicked = false;
        }

        private void topMenuAccount_Click(object sender, EventArgs e)
        {
            AccountMenu accountMenu = new AccountMenu();
            accountMenu.Show();
            this.Hide();
        }

        private void MainMenu_Shown(object sender, EventArgs e)
        {
            if (LoginInfo.isSupplier == true)
            {
                topMenuProduct.Visible = true;
            }
            else
            {
                topMenuProduct.Visible = false;
            }
        }

        private void topMenuAddProduct_Click(object sender, EventArgs e)
        {
            AddProduct addProduct = new AddProduct();
            addProduct.Show();
            this.Hide();
        }

        private void topMenuProducts_Click(object sender, EventArgs e)
        {
            Products products = new Products();
            products.Show();
            this.Hide();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            try
            {
                List<int> productIds = new List<int>();

                using (var mysql = dbo.Connect())
                {
                    if (mysql.State != ConnectionState.Open)
                    {
                        mysql.Open();
                    }

                    // Tüm productId'leri çek
                    string getAllProductIdsQuery = "SELECT productId FROM product WHERE productAvailable = b'1'";
                    using (var adapter = new MySqlDataAdapter(getAllProductIdsQuery, mysql))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        foreach (DataRow row in dt.Rows)
                        {
                            productIds.Add(Convert.ToInt32(row["productId"]));
                        }
                    }

                    Random rnd = new Random();
                    randomProductIds = new List<int>();

                    while (randomProductIds.Count < 3)
                    {
                        int randomIndex = rnd.Next(0, productIds.Count);
                        int randomId = productIds[randomIndex];

                        if (!randomProductIds.Contains(randomId))
                        {
                            randomProductIds.Add(randomId);
                        }
                    }

                    string getRandomProductsQuery = "SELECT p.productDescription, s.logo, p.price, p.productAvailable, p.picture, p.ranking " +
                                                    "FROM product p JOIN supplier s ON p.supplierId = s.supplierId " +
                                                    "WHERE p.productId IN (@productId1, @productId2, @productId3)";

                    using (var adapter = new MySqlDataAdapter(getRandomProductsQuery, mysql))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@productId1", randomProductIds[0]);
                        adapter.SelectCommand.Parameters.AddWithValue("@productId2", randomProductIds[1]);
                        adapter.SelectCommand.Parameters.AddWithValue("@productId3", randomProductIds[2]);

                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Ürün 1
                        lblRandomProductOne.Text = dt.Rows[0]["productDescription"].ToString();
                        byte[] img = (byte[])dt.Rows[0]["logo"];
                        using (MemoryStream ms = new MemoryStream(img))
                        {
                            pbSupplierLogoOne.Image = Image.FromStream(ms);
                        }
                        lblRandomProductPriceOne.Text = dt.Rows[0]["price"].ToString();
                        btnAddToCartOne.Enabled = (dt.Rows[0]["productAvailable"].ToString() == "1");
                        img = (byte[])dt.Rows[0]["picture"];
                        using (MemoryStream ms = new MemoryStream(img))
                        {
                            pbRandomProductOne.Image = Image.FromStream(ms);
                        }
                        lblRandomProductRankOne.Text = dt.Rows[0]["ranking"].ToString();

                        // Ürün 2
                        lblRandomProductTwo.Text = dt.Rows[1]["productDescription"].ToString();
                        img = (byte[])dt.Rows[1]["logo"];
                        using (MemoryStream ms = new MemoryStream(img))
                        {
                            pbSupplierLogoTwo.Image = Image.FromStream(ms);
                        }
                        lblRandomProductPriceTwo.Text = dt.Rows[1]["price"].ToString();
                        btnAddToCartTwo.Enabled = (dt.Rows[1]["productAvailable"].ToString() == "1");
                        img = (byte[])dt.Rows[1]["picture"];
                        using (MemoryStream ms = new MemoryStream(img))
                        {
                            pbRandomProductTwo.Image = Image.FromStream(ms);
                        }
                        lblRandomProductRankTwo.Text = dt.Rows[1]["ranking"].ToString();

                        // Ürün 3
                        lblRandomProductThree.Text = dt.Rows[2]["productDescription"].ToString();
                        img = (byte[])dt.Rows[2]["logo"];
                        using (MemoryStream ms = new MemoryStream(img))
                        {
                            pbSupplierLogoThree.Image = Image.FromStream(ms);
                        }
                        lblRandomProductPriceThree.Text = dt.Rows[2]["price"].ToString();
                        btnAddToCartThree.Enabled = (dt.Rows[2]["productAvailable"].ToString() == "1");
                        img = (byte[])dt.Rows[2]["picture"];
                        using (MemoryStream ms = new MemoryStream(img))
                        {
                            pbRandomProductThree.Image = Image.FromStream(ms);
                        }
                        lblRandomProductRankThree.Text = dt.Rows[2]["ranking"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void topMenuCart_Click(object sender, EventArgs e)
        {
            groupRandomProduct.Visible = true;
            groupCart.Visible = true;
        }

        private void topMenuClothes_Click(object sender, EventArgs e)
        {
            try
            {
                mysql = dbo.Connect();
                if (mysql.State != ConnectionState.Open)
                {
                    mysql.Open();
                }
                adapter = new MySqlDataAdapter("SELECT productId, productDescription FROM product WHERE categoryId = 1 AND productAvailable = b'1'", mysql);
                dt = new DataTable();
                adapter.Fill(dt);
                if(dt.Rows.Count == 0)
                {
                    MessageBox.Show("Bu kategoriye ait bir ürün bulunmamakta.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                    groupRandomProduct.Visible = true;
                }
                else
                {
                    groupRandomProduct.Visible = false;
                    groupCart.Visible = false;
                    comboProducts.DataSource = dt;
                    comboProducts.DisplayMember = "productDescription";
                    comboProducts.ValueMember = "productId";
                }
                mysql.Close();
            }
            catch (Exception ex)
            {
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
                adapter = new MySqlDataAdapter("SELECT p.productDescription, s.logo, p.price, p.productAvailable, p.picture, p.ranking FROM product p JOIN supplier s ON p.supplierId = s.supplierId WHERE p.productId = @productId AND p.productAvailable = b'1'", mysql);
                adapter.SelectCommand.Parameters.AddWithValue("@productId", comboProducts.SelectedValue);
                dt = new DataTable();
                adapter.Fill(dt);
                lblDescription.Text = dt.Rows[0]["productDescription"].ToString();
                byte[] img = (byte[])dt.Rows[0]["logo"];
                MemoryStream ms = new MemoryStream(img);
                pbSupplier.Image = Image.FromStream(ms);
                lblPrice.Text = dt.Rows[0]["price"].ToString();
                img = (byte[])dt.Rows[0]["picture"];
                ms = new MemoryStream(img);
                pbProduct.Image = Image.FromStream(ms);
                lblRanking.Text = dt.Rows[0]["ranking"].ToString();
                mysql.Close();
            }
            catch (Exception ex)
            {
            }
        }

        private void pbLogo_Click(object sender, EventArgs e)
        {
            groupRandomProduct.Visible = true;
            groupCart.Visible = false;
        }

        private void topMenuShoes_Click(object sender, EventArgs e)
        {
            try
            {
                mysql = dbo.Connect();
                if (mysql.State != ConnectionState.Open)
                {
                    mysql.Open();
                }
                adapter = new MySqlDataAdapter("SELECT productId, productDescription FROM product WHERE categoryId = 2 AND productAvailable = b'1'", mysql);
                dt = new DataTable();
                adapter.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Bu kategoriye ait bir ürün bulunmamakta.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    groupRandomProduct.Visible = true;
                }
                else
                {
                    groupRandomProduct.Visible = false;
                    groupCart.Visible = false;
                    comboProducts.DataSource = dt;
                    comboProducts.DisplayMember = "productDescription";
                    comboProducts.ValueMember = "productId";
                }
                mysql.Close();
            }
            catch (Exception ex)
            {
            }
        }

        private void topMenuBag_Click(object sender, EventArgs e)
        {
            try
            {
                mysql = dbo.Connect();
                if (mysql.State != ConnectionState.Open)
                {
                    mysql.Open();
                }
                adapter = new MySqlDataAdapter("SELECT productId, productDescription FROM product WHERE categoryId = 3 AND productAvailable = b'1'", mysql);
                dt = new DataTable();
                adapter.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Bu kategoriye ait bir ürün bulunmamakta.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    groupRandomProduct.Visible = true;
                }
                else
                {
                    groupRandomProduct.Visible = false; 
                    groupCart.Visible = false;
                    comboProducts.DataSource = dt;
                    comboProducts.DisplayMember = "productDescription";
                    comboProducts.ValueMember = "productId";
                }
                mysql.Close();
            }
            catch (Exception ex)
            {
            }
        }

        private void topMenuCosmetic_Click(object sender, EventArgs e)
        {
            try
            {
                mysql = dbo.Connect();
                if (mysql.State != ConnectionState.Open)
                {
                    mysql.Open();
                }
                adapter = new MySqlDataAdapter("SELECT productId, productDescription FROM product WHERE categoryId = 4 AND productAvailable = b'1'", mysql);
                dt = new DataTable();
                adapter.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Bu kategoriye ait bir ürün bulunmamakta.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    groupRandomProduct.Visible = true;
                }
                else
                {
                    groupRandomProduct.Visible = false;
                    groupCart.Visible = false;
                    comboProducts.DataSource = dt;
                    comboProducts.DisplayMember = "productDescription";
                    comboProducts.ValueMember = "productId";
                }
                mysql.Close();
            }
            catch (Exception ex)
            {
            }
        }

        private void topMenuSport_Click(object sender, EventArgs e)
        {
            try
            {
                mysql = dbo.Connect();
                if (mysql.State != ConnectionState.Open)
                {
                    mysql.Open();
                }
                adapter = new MySqlDataAdapter("SELECT productId, productDescription FROM product WHERE categoryId = 5 AND productAvailable = b'1'", mysql);
                dt = new DataTable();
                adapter.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Bu kategoriye ait bir ürün bulunmamakta.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    groupRandomProduct.Visible = true;
                }
                else
                {
                    groupRandomProduct.Visible = false;
                    groupCart.Visible = false;
                    comboProducts.DataSource = dt;
                    comboProducts.DisplayMember = "productDescription";
                    comboProducts.ValueMember = "productId";
                }
                mysql.Close();
            }
            catch (Exception ex)
            {
            }
        }

        private void topMenuElectronic_Click(object sender, EventArgs e)
        {
            try
            {
                mysql = dbo.Connect();
                if (mysql.State != ConnectionState.Open)
                {
                    mysql.Open();
                }
                adapter = new MySqlDataAdapter("SELECT productId, productDescription FROM product WHERE categoryId = 6 AND productAvailable = b'1'", mysql);
                dt = new DataTable();
                adapter.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Bu kategoriye ait bir ürün bulunmamakta.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    groupRandomProduct.Visible = true;
                }
                else
                {
                    groupRandomProduct.Visible = false;
                    groupCart.Visible = false;
                    comboProducts.DataSource = dt;
                    comboProducts.DisplayMember = "productDescription";
                    comboProducts.ValueMember = "productId";
                }
                mysql.Close();
            }
            catch (Exception ex)
            {
            }
        }

        private void topMenuFurniture_Click(object sender, EventArgs e)
        {
            try
            {
                mysql = dbo.Connect();
                if (mysql.State != ConnectionState.Open)
                {
                    mysql.Open();
                }
                adapter = new MySqlDataAdapter("SELECT productId, productDescription FROM product WHERE categoryId = 7 AND productAvailable = b'1'", mysql);
                dt = new DataTable();
                adapter.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Bu kategoriye ait bir ürün bulunmamakta.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    groupRandomProduct.Visible = true;
                }
                else
                {
                    groupRandomProduct.Visible = false;
                    groupCart.Visible = false;
                    comboProducts.DataSource = dt;
                    comboProducts.DisplayMember = "productDescription";
                    comboProducts.ValueMember = "productId";
                }
                mysql.Close();
            }
            catch (Exception ex)
            {
            }
        }

        private void topMenuDecoration_Click(object sender, EventArgs e)
        {
            try
            {
                mysql = dbo.Connect();
                if (mysql.State != ConnectionState.Open)
                {
                    mysql.Open();
                }
                adapter = new MySqlDataAdapter("SELECT productId, productDescription FROM product WHERE categoryId = 8 AND productAvailable = b'1'", mysql);
                dt = new DataTable();
                adapter.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Bu kategoriye ait bir ürün bulunmamakta.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    groupRandomProduct.Visible = true;
                }
                else
                {
                    groupRandomProduct.Visible = false;
                    groupCart.Visible = false;
                    comboProducts.DataSource = dt;
                    comboProducts.DisplayMember = "productDescription";
                    comboProducts.ValueMember = "productId";
                }
                mysql.Close();
            }
            catch (Exception ex)
            {
            }
        }

        private void topMenuBook_Click(object sender, EventArgs e)
        {
            try
            {
                mysql = dbo.Connect();
                if (mysql.State != ConnectionState.Open)
                {
                    mysql.Open();
                }
                adapter = new MySqlDataAdapter("SELECT productId, productDescription FROM product WHERE categoryId = 9 AND productAvailable = b'1'", mysql);
                dt = new DataTable();
                adapter.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Bu kategoriye ait bir ürün bulunmamakta.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    groupRandomProduct.Visible = true;
                }
                else
                {
                    groupRandomProduct.Visible = false;
                    groupCart.Visible = false;
                    comboProducts.DataSource = dt;
                    comboProducts.DisplayMember = "productDescription";
                    comboProducts.ValueMember = "productId";
                }
                mysql.Close();
            }
            catch (Exception ex)
            {
            }
        }

        private void btnAddToCartOne_Click(object sender, EventArgs e)
        {
            try
            {
                listProductsInCart.Items.Add(lblRandomProductOne.Text);
                totalPrice += Convert.ToDouble(lblRandomProductPriceOne.Text);
                lblTotalPrice.Text = totalPrice.ToString("0.##");
                MessageBox.Show("Ürün sepetinize eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddToCartTwo_Click(object sender, EventArgs e)
        {
            try
            {
                listProductsInCart.Items.Add(lblRandomProductTwo.Text);
                totalPrice += Convert.ToDouble(lblRandomProductPriceTwo.Text);
                lblTotalPrice.Text = totalPrice.ToString("0.##");
                MessageBox.Show("Ürün sepetinize eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddToCartThree_Click(object sender, EventArgs e)
        {
            try
            {
                listProductsInCart.Items.Add(lblRandomProductThree.Text);
                totalPrice += Convert.ToDouble(lblRandomProductPriceThree.Text);
                lblTotalPrice.Text = totalPrice.ToString("0.##");
                MessageBox.Show("Ürün sepetinize eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            try
            {
                listProductsInCart.Items.Add(lblDescription.Text);
                totalPrice += Convert.ToDouble(lblPrice.Text);
                lblTotalPrice.Text = totalPrice.ToString("0.##");
                MessageBox.Show("Ürün sepetinize eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listProductsInCart_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                mysql = dbo.Connect();
                if (mysql.State != ConnectionState.Open)
                {
                    mysql.Open();
                }
                adapter = new MySqlDataAdapter("SELECT p.productDescription, s.logo, p.price, p.picture, p.ranking FROM product p JOIN supplier s ON p.supplierId = s.supplierId WHERE p.productDescription = @productDescription", mysql);
                adapter.SelectCommand.Parameters.AddWithValue("@productDescription", listProductsInCart.SelectedItem.ToString());
                dt = new DataTable();
                adapter.Fill(dt);
                lblProductDescription.Text = dt.Rows[0]["productDescription"].ToString();
                byte[] img = (byte[])dt.Rows[0]["logo"];
                MemoryStream ms = new MemoryStream(img);
                pbCartSupplier.Image = Image.FromStream(ms);
                lblCartPrice.Text = dt.Rows[0]["price"].ToString();
                img = (byte[])dt.Rows[0]["picture"];
                ms = new MemoryStream(img);
                pbCartProduct.Image = Image.FromStream(ms);
                lblCartRanking.Text = dt.Rows[0]["ranking"].ToString();
                lblOrderCount.Text = "1";
                mysql.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveFromCart_Click(object sender, EventArgs e)
        {
            try
            {
                if (listProductsInCart.Items.Count != 1)
                {
                    DialogResult dialogResult = MessageBox.Show("Ürünü sepetinizden çıkarmak istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        int index = listProductsInCart.SelectedIndex;
                        if (index == 0)
                        {
                            totalPrice -= Convert.ToDouble(lblCartPrice.Text);
                            listProductsInCart.SelectedIndex = 1;
                            listProductsInCart.Items.RemoveAt(index);
                        }
                        else
                        {
                            totalPrice -= Convert.ToDouble(lblCartPrice.Text);
                            listProductsInCart.SelectedIndex = 0;
                            listProductsInCart.Items.RemoveAt(index);
                        }
                        MessageBox.Show("Ürün sepetinizden çıkarıldı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lblTotalPrice.Text = totalPrice.ToString("0.##");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            lblOrderCount.Text = (Convert.ToInt32(lblOrderCount.Text) + 1).ToString();
            totalPrice += Convert.ToDouble(lblCartPrice.Text);
            lblTotalPrice.Text = totalPrice.ToString("0.##");
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (!(int.Parse(lblOrderCount.Text) <= 0))
            {
                lblOrderCount.Text = (Convert.ToInt32(lblOrderCount.Text) - 1).ToString();
                totalPrice -= Convert.ToDouble(lblCartPrice.Text);
                lblTotalPrice.Text = totalPrice.ToString("0.##");
            }
        }

        private void btnCompleteTheOrder_Click(object sender, EventArgs e)
        {
            try
            {
                mysql = dbo.Connect();
                if (mysql.State != ConnectionState.Open)
                {
                    mysql.Open();
                }
                adapter = new MySqlDataAdapter("SELECT customerId FROM customer WHERE customerNickname = @customerNickname", mysql);
                adapter.SelectCommand.Parameters.AddWithValue("@customerNickname", LoginInfo.nickname);
                int customerId = Convert.ToInt32(adapter.SelectCommand.ExecuteScalar());
                command = new MySqlCommand("INSERT INTO orders(customerId, paymentId, orderDate, shipperId, paid) VALUES (@customerId, @paymentId, @orderDate, @shipperId, @paid)", mysql);
                command.Parameters.AddWithValue("@customerId", customerId);
                command.Parameters.AddWithValue("@paymentId", 3);
                command.Parameters.AddWithValue("@orderDate", DateTime.Now);
                Random rnd = new Random();
                command.Parameters.AddWithValue("@shipperId", rnd.Next(1, 3));
                command.Parameters.AddWithValue("@paid", 1);
                command.ExecuteNonQuery();
                MessageBox.Show("Siparişiniz Alınmıştır! En Yakın Zamanda Teslim Edilecektir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mysql.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                mysql = dbo.Connect();
                if (mysql.State != ConnectionState.Open)
                {
                    mysql.Open();
                }
                adapter = new MySqlDataAdapter("SELECT productId FROM product WHERE productDescription = @productDescription", mysql);
                adapter.SelectCommand.Parameters.AddWithValue("@productDescription", listProductsInCart.SelectedItem.ToString());
                int id = Convert.ToInt32(adapter.SelectCommand.ExecuteScalar());
                command = new MySqlCommand("INSERT INTO order_details(productId, price, count, totalPrice) VALUES (@productId, @price, @count, @totalPrice)", mysql);
                command.Parameters.AddWithValue("@productId", id);
                command.Parameters.AddWithValue("@price", double.Parse(lblCartPrice.Text));
                command.Parameters.AddWithValue("@count", int.Parse(lblOrderCount.Text));
                command.Parameters.AddWithValue("@totalPrice", double.Parse(lblCartPrice.Text) * int.Parse(lblOrderCount.Text));
                command.ExecuteNonQuery();
                mysql.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
