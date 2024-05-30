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
    public partial class LoginScreen : Form
    {
        public LoginScreen()
        {
            InitializeComponent();
        }

        DatabaseOperations dbo = new DatabaseOperations();
        MySqlConnection mysql;
        MySqlDataAdapter adapter;
        MySqlCommand command;
        DataTable dt;
        string filePath;

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                mysql = dbo.Connect();
                if (mysql.State != ConnectionState.Open)
                {
                    mysql.Open();
                }
                if (txtPassword.Text == txtPasswordAgain.Text)
                {
                    if (txtEmail.Text == null)
                    {
                        MessageBox.Show("Alanları boş bırakamazsınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    string cEmail = "";
                    command = new MySqlCommand("SELECT customerEmail FROM customer WHERE customerEmail = @customerEmail", mysql);
                    command.Parameters.AddWithValue("@customerEmail", txtEmail.Text);
                    var result = command.ExecuteScalar();
                    if (result != null)
                    {
                        cEmail = result.ToString();
                    }
                    mysql.Close();
                    if (cEmail == txtEmail.Text)
                    {
                        MessageBox.Show("Email zaten kullanılmakta!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        mysql.Open();
                        command = new MySqlCommand("INSERT INTO customer(customerFirstName, customerLastName, customerNickname, customerEmail, customerPassword, customerPhoneNumber, customerGender, customerBirthDate, customerCountry, customerCity, customerRegion, customerAdress, customerCreditCardNumber, creditCardTypeId, customerCreditCardExpDate, customerCreditCardCVV) \r\nVALUES (@customerFirstName, @customerLastName, @customerNickname, @customerEmail, @customerPassword, @customerPhoneNumber, @customerGender, @customerBirthDate, @customerCountry, @customerCity, @customerRegion, @customerAdress, @customerCreditCardNumber, @creditCardTypeId, @customerCreditCardExpDate, @customerCreditCardCVV)", mysql);
                        command.Parameters.AddWithValue("@customerFirstName", txtFirstName.Text);
                        command.Parameters.AddWithValue("@customerLastName", txtLastName.Text);
                        command.Parameters.AddWithValue("@customerNickname", txtNickname.Text);
                        command.Parameters.AddWithValue("@customerEmail", txtEmail.Text);
                        command.Parameters.AddWithValue("@customerPassword", txtPassword.Text);
                        command.Parameters.AddWithValue("@customerPhoneNumber", txtPhoneNumber.Text);
                        command.Parameters.AddWithValue("@customerGender", comboGender.SelectedItem.ToString());
                        command.Parameters.AddWithValue("@customerBirthDate", Convert.ToString(dateBirthDate.Value.Year) + '-' + Convert.ToString(dateBirthDate.Value.Month) + '-' + Convert.ToString(dateBirthDate.Value.Day));
                        command.Parameters.AddWithValue("@customerCountry", comboCountry.SelectedItem.ToString());
                        command.Parameters.AddWithValue("@customerCity", comboCity.SelectedItem.ToString());
                        command.Parameters.AddWithValue("@customerRegion", comboRegion.SelectedItem.ToString());
                        command.Parameters.AddWithValue("@customerAdress", txtAdress.Text);
                        command.Parameters.AddWithValue("@customerCreditCardNumber", txtCreditCardNumber.Text);
                        command.Parameters.AddWithValue("@creditCardTypeId", comboCreditCardType.SelectedValue);
                        command.Parameters.AddWithValue("@customerCreditCardExpDate", (comboMonth.SelectedItem.ToString() + '/' + comboYear.SelectedItem.ToString()));
                        command.Parameters.AddWithValue("@customerCreditCardCVV", int.Parse(txtCreditCardCVV.Text));
                        command.ExecuteNonQuery();
                        mysql.Close();
                        MessageBox.Show("Kayıt başarılı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Şifreler uyuşmuyor!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoginScreen_Load(object sender, EventArgs e)
        {
            try
            {
                mysql = dbo.Connect();
                if (mysql.State != ConnectionState.Open)
                {
                    mysql.Open();
                }
                adapter = new MySqlDataAdapter("SELECT * FROM credit_card_type", mysql);
                dt = new DataTable();
                adapter.Fill(dt);
                comboCreditCardType.DataSource = dt;
                comboCreditCardType.DisplayMember = "creditCardTypeName";
                comboCreditCardType.ValueMember = "creditCardTypeId";
                adapter = new MySqlDataAdapter("SELECT * FROM payment", mysql);
                dt = new DataTable();
                adapter.Fill(dt);
                comboPaymentMethod.DataSource = dt;
                comboPaymentMethod.DisplayMember = "paymentType";
                comboPaymentMethod.ValueMember = "paymentId";
                mysql.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoginScreen_Click(object sender, EventArgs e)
        {
            groupLogin.Visible = true;
            groupSupplierRegister.Visible = false;
        }

        private void btnRegisterScreen_Click(object sender, EventArgs e)
        {
            groupLogin.Visible = false;
            groupSupplierRegister.Visible = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                mysql = dbo.Connect();
                if (mysql.State != ConnectionState.Open)
                {
                    mysql.Open();
                }
                string cNickcame = "";
                string cPassword = "";
                command = new MySqlCommand("SELECT customerNickname FROM customer WHERE customerNickname = @customerLoginNickname", mysql);
                command.Parameters.AddWithValue("@customerLoginNickname", txtLoginNickname.Text);
                var result = command.ExecuteScalar();
                if (result != null)
                {
                    cNickcame = result.ToString();
                }
                command = new MySqlCommand("SELECT customerPassword FROM customer WHERE customerPassword = @customerLoginPassword", mysql);
                command.Parameters.AddWithValue("@customerLoginPassword", txtLoginPassword.Text);
                result = command.ExecuteScalar();
                if (result != null)
                {
                    cPassword = result.ToString();
                }
                if (cNickcame == txtLoginNickname.Text && cPassword == txtLoginPassword.Text)
                {
                    MainMenu mm = new MainMenu();
                    mm.Show();
                    this.Hide();
                    LoginInfo.isSupplier = false;
                    LoginInfo.nickname = txtLoginNickname.Text;
                }
                else
                {
                    MessageBox.Show("Email veya şifre hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSeekPassword_Click(object sender, EventArgs e)
        {
            btnSeePassword.Visible = true;
            btnSeekPassword.Visible = false;
            txtLoginPassword.PasswordChar = '\0';
        }

        private void btnSeePassword_Click(object sender, EventArgs e)
        {
            btnSeekPassword.Visible = true;
            btnSeePassword.Visible = false;
            txtLoginPassword.PasswordChar = '*';
        }

        private void btnLoginSupplier_Click(object sender, EventArgs e)
        {
            groupSupplierRegister.Visible = true;
            groupSupplierLogin.Visible = true;
        }

        private void btnSupplierRegister_Click(object sender, EventArgs e)
        {
            groupRegister.Visible = true;
            groupLogin.Visible = true;
            groupSupplierRegister.Visible = true;
        }

        private void btnSupplierLoginScreen_Click(object sender, EventArgs e)
        {
            groupSupplierLogin.Visible = true;
        }

        private void btnUploadPhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(*.jpg; *.jpeg; *.png;)|*.jpg; *.jpeg; *.png;";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filePath = Path.GetFullPath(ofd.FileName);
                pbSupplierLogo.Image = Image.FromFile(filePath);
            }
        }

        private void btnRegisterAsSupplier_Click(object sender, EventArgs e)
        {
            try
            {
                mysql = dbo.Connect();
                if (mysql.State != ConnectionState.Open)
                {
                    mysql.Open();
                }
                if (txtSupplierPassword.Text == txtSupplierPasswordAgain.Text)
                {
                    string sEmail = "";
                    command = new MySqlCommand("SELECT supplierEmail FROM supplier WHERE supplierEmail = @supplierEmail", mysql);
                    command.Parameters.AddWithValue("@supplierEmail", txtSupplierEmail.Text);
                    var result = command.ExecuteScalar();
                    if (result != null)
                    {
                        sEmail = result.ToString();
                    }
                    mysql.Close();
                    if (sEmail == txtSupplierEmail.Text)
                    {
                        MessageBox.Show("Bu emaile kayıtlı bir satıcı bulunmakta!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        mysql.Open();
                        command = new MySqlCommand("INSERT INTO supplier(companyName, contactFirstName, contactLastName, supplierPhoneNumber, supplierEmail, supplierPassword, supplierCountry, supplierCity, supplierRegion, supplierAdress, paymentMethod, logo) VALUES (@companyName, @contactFirstName, @contactLastName, @supplierPhoneNumber, @supplierEmail, @supplierPassword, @supplierCountry, @supplierCity, @supplierRegion, @supplierAdress, @paymentMethod, @logo)", mysql);
                        command.Parameters.AddWithValue("@companyName", txtCompanyName.Text);
                        command.Parameters.AddWithValue("@contactFirstName", txtContactFirstName.Text);
                        command.Parameters.AddWithValue("@contactLastName", txtContactLastName.Text);
                        command.Parameters.AddWithValue("@supplierPhoneNumber", txtSupplierPhoneNumber.Text);
                        command.Parameters.AddWithValue("@supplierEmail", txtSupplierEmail.Text);
                        command.Parameters.AddWithValue("@supplierPassword", txtSupplierPassword.Text);
                        command.Parameters.AddWithValue("@supplierCountry", comboSupplierCountry.SelectedItem.ToString());
                        command.Parameters.AddWithValue("@supplierCity", comboSupplierCity.SelectedItem.ToString());
                        command.Parameters.AddWithValue("@supplierRegion", comboSupplierRegion.SelectedItem.ToString());
                        command.Parameters.AddWithValue("@supplierAdress", txtSupplierAdress.Text);
                        command.Parameters.AddWithValue("@paymentMethod", comboPaymentMethod.SelectedValue);
                        FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                        BinaryReader br = new BinaryReader(fs);
                        byte[] img = br.ReadBytes((int)fs.Length);
                        br.Close();
                        fs.Close();
                        command.Parameters.Add("@logo", MySqlDbType.Blob, img.Length).Value = img;
                        command.ExecuteNonQuery();
                        mysql.Close();
                        MessageBox.Show("Kayıt başarılı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Şifreler uyuşmuyor!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoginSupplierAccount_Click(object sender, EventArgs e)
        {
            try
            {
                mysql = dbo.Connect();
                if (mysql.State != ConnectionState.Open)
                {
                    mysql.Open();
                }
                string sEmail = "";
                string sPassword = "";
                command = new MySqlCommand("SELECT supplierEmail FROM supplier WHERE supplierEmail = @supplierEmail", mysql);
                command.Parameters.AddWithValue("@supplierEmail", txtSuppierLoginEmail.Text);
                var result = command.ExecuteScalar();
                if (result != null)
                {
                    sEmail = result.ToString();
                }
                command = new MySqlCommand("SELECT supplierPassword FROM supplier WHERE supplierPassword = @supplierPassword", mysql);
                command.Parameters.AddWithValue("@supplierPassword", txtSupplierLoginPassword.Text);
                result = command.ExecuteScalar();
                if (result != null)
                {
                    sPassword = result.ToString();
                }
                if (sEmail == txtSuppierLoginEmail.Text && sPassword == txtSupplierLoginPassword.Text)
                {
                    MainMenu mm = new MainMenu();
                    mm.Show();
                    this.Hide();
                    LoginInfo.isSupplier = true;
                    LoginInfo.email = txtSuppierLoginEmail.Text;
                    adapter = new MySqlDataAdapter("SELECT supplierId FROM supplier WHERE supplierEmail = @supplierEmail", mysql);
                    adapter.SelectCommand.Parameters.AddWithValue("@supplierEmail", LoginInfo.email);
                    dt = new DataTable();
                    adapter.Fill(dt);
                    LoginInfo.id = Convert.ToInt32(dt.Rows[0]["supplierId"]);
                }
                else
                {
                    MessageBox.Show("Email veya şifre hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSupplierSeePassword_Click(object sender, EventArgs e)
        {
            txtSupplierLoginPassword.PasswordChar = '*';
            btnSupplierSeekPassword.Visible = true;
            btnSupplierSeePassword.Visible = false;
        }

        private void btnSupplierSeekPassword_Click(object sender, EventArgs e)
        {
            txtSupplierLoginPassword.PasswordChar = '\0';
            btnSupplierSeePassword.Visible = true;
            btnSupplierSeekPassword.Visible = false;
        }

        private void btnBackToSupplierRegister_Click(object sender, EventArgs e)
        {
            groupSupplierLogin.Visible = false;
        }

        private void btnBackToLogin_Click(object sender, EventArgs e)
        {
            groupSupplierRegister.Visible = false;
        }

        private void btnGoToSupplierLogin_Click(object sender, EventArgs e)
        {
            groupSupplierLogin.Visible = true;
        }

        private void btnGoToSupplierRegister_Click(object sender, EventArgs e)
        {
            groupSupplierRegister.Visible = true;
        }

        private void btnBackToRegister_Click(object sender, EventArgs e)
        {
            groupLogin.Visible = false;
        }

        private void btnGoToLogin_Click(object sender, EventArgs e)
        {
            groupLogin.Visible = true;
        }
    }
}
