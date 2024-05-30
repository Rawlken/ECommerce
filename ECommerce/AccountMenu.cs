using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Cms;
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
    public partial class AccountMenu : Form
    {
        public AccountMenu()
        {
            InitializeComponent();
        }

        DatabaseOperations dbo = new DatabaseOperations();
        MySqlConnection mysql;
        MySqlDataAdapter adapter;
        MySqlCommand command;
        DataTable dt;
        string filePath;

        private void ListInformation()
        {
            try
            {
                adapter = new MySqlDataAdapter("SELECT customerId, customerFirstName, customerLastName, customerNickname, customerEmail, customerPassword, customerPhoneNumber, customerGender, customerBirthDate, customerCountry, customerCity, customerRegion, customerAdress, customerCreditCardNumber, creditCardTypeId, customerCreditCardExpDate, customerCreditCardCVV FROM customer WHERE customerNickname = @customerNickname", mysql);
                adapter.SelectCommand.Parameters.AddWithValue("@customerNickname", LoginInfo.nickname);
                dt = new DataTable();
                adapter.Fill(dt);
                lblId.Text = dt.Rows[0]["customerId"].ToString();
                txtFirstName.Text = dt.Rows[0]["customerFirstName"].ToString();
                txtLastName.Text = dt.Rows[0]["customerLastName"].ToString();
                txtNickname.Text = dt.Rows[0]["customerNickname"].ToString();
                txtEmail.Text = dt.Rows[0]["customerEmail"].ToString();
                txtPassword.Text = dt.Rows[0]["customerPassword"].ToString();
                txtPhoneNumber.Text = dt.Rows[0]["customerPhoneNumber"].ToString();
                comboGender.SelectedItem = dt.Rows[0]["customerGender"].ToString();
                dateBirthDate.Value = Convert.ToDateTime(dt.Rows[0]["customerBirthDate"].ToString());
                comboCountry.SelectedItem = dt.Rows[0]["customerCountry"].ToString();
                comboCity.SelectedItem = dt.Rows[0]["customerCity"].ToString();
                comboRegion.SelectedItem = dt.Rows[0]["customerRegion"].ToString();
                txtAdress.Text = dt.Rows[0]["customerAdress"].ToString();
                txtCreditCardNumber.Text = dt.Rows[0]["customerCreditCardNumber"].ToString();
                comboCreditCardType.SelectedValue = Convert.ToInt32(dt.Rows[0]["creditCardTypeId"]);
                comboMonth.SelectedItem = dt.Rows[0]["customerCreditCardExpDate"].ToString().Split('/')[0];
                comboYear.SelectedItem = dt.Rows[0]["customerCreditCardExpDate"].ToString().Split('/')[1];
                txtCreditCardCVV.Text = dt.Rows[0]["customerCreditCardCVV"].ToString();
                mysql.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SupplierListInformation()
        {
            try
            {
                adapter = new MySqlDataAdapter("SELECT supplierId, companyName, contactFirstName, contactLastName, supplierPhoneNumber, supplierEmail, supplierPassword, supplierCountry, supplierCity, supplierRegion, supplierAdress, paymentMethod, logo FROM supplier WHERE supplierEmail = @supplierEmail ", mysql);
                adapter.SelectCommand.Parameters.AddWithValue("@supplierEmail", LoginInfo.email);
                dt = new DataTable();
                adapter.Fill(dt);
                lblSupplierId.Text = dt.Rows[0]["supplierId"].ToString();
                txtCompanyName.Text = dt.Rows[0]["companyName"].ToString();
                txtContactFirstName.Text = dt.Rows[0]["contactFirstName"].ToString();
                txtContactLastName.Text = dt.Rows[0]["contactLastName"].ToString();
                txtSupplierPhoneNumber.Text = dt.Rows[0]["supplierPhoneNumber"].ToString();
                txtSupplierEmail.Text = dt.Rows[0]["supplierEmail"].ToString();
                txtSupplierPassword.Text = dt.Rows[0]["supplierPassword"].ToString();
                comboSupplierCountry.SelectedItem = dt.Rows[0]["supplierCountry"].ToString();
                comboSupplierCity.SelectedItem = dt.Rows[0]["supplierCity"].ToString();
                comboSupplierRegion.SelectedItem = dt.Rows[0]["supplierRegion"].ToString();
                txtSupplierAdress.Text = dt.Rows[0]["supplierAdress"].ToString();
                comboPaymentMethod.SelectedValue = Convert.ToInt32(dt.Rows[0]["paymentMethod"]);
                byte[] img = (byte[])dt.Rows[0]["logo"];
                MemoryStream ms = new MemoryStream(img);
                pbSupplierLogo.Image = Image.FromStream(ms);
                mysql.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AccountMenu_Load(object sender, EventArgs e)
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
                if (LoginInfo.isSupplier == false)
                {
                    groupAccount.Visible = true;
                    groupSupplierAccount.Visible = false;
                    ListInformation();
                }
                else
                {
                    groupAccount.Visible = true;
                    groupSupplierAccount.Visible = true;
                    SupplierListInformation();
                    MessageBox.Show("Hatayla Karşılaşmamak İçin Fotoğrafı Tekrar Seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AccountMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainMenu mm = new MainMenu();
            mm.Show();
            this.Hide();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                AccountInfo accountInfo = new AccountInfo(txtFirstName.Text, txtLastName.Text, txtNickname.Text, txtPassword.Text, txtPhoneNumber.Text, comboGender.SelectedItem.ToString(), dateBirthDate.Value.Date, comboCountry.SelectedItem.ToString(), comboCity.SelectedItem.ToString(), comboRegion.SelectedItem.ToString(), txtAdress.Text, txtCreditCardNumber.Text, Convert.ToInt32(comboCreditCardType.SelectedValue), (comboMonth.SelectedItem.ToString() + "/" + comboYear.SelectedItem.ToString()), Convert.ToInt32(txtCreditCardCVV.Text));
                accountInfo.UpdateInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChoosePhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(*.jpg; *.jpeg; *.png;)|*.jpg; *.jpeg; *.png;";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filePath = Path.GetFullPath(ofd.FileName);
                pbSupplierLogo.Image = Image.FromFile(filePath);
            }
        }

        private void btnUpdateSupplier_Click(object sender, EventArgs e)
        {
            try
            {
                filePath = pbSupplierLogo.ImageLocation;
                MessageBox.Show(filePath);
                SupplierAccountInfo supplierAccountInfo = new SupplierAccountInfo(txtContactFirstName.Text, txtContactLastName.Text, txtSupplierPhoneNumber.Text, txtSupplierEmail.Text, txtSupplierPassword.Text, comboSupplierCountry.SelectedItem.ToString(), comboSupplierCity.SelectedItem.ToString(), comboSupplierRegion.SelectedItem.ToString(), txtSupplierAdress.Text, Convert.ToInt32(comboPaymentMethod.SelectedValue), pbSupplierLogo.Image, filePath);
                supplierAccountInfo.UpdateInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            try
            {
                mysql = dbo.Connect();
                if(mysql.State != ConnectionState.Open)
                {
                    mysql.Open();
                }
                DialogResult dialogResult = MessageBox.Show("Hesabınızı Silmek İstediğinize Emin Misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(dialogResult == DialogResult.Yes)
                {
                    command = new MySqlCommand("DELETE FROM customer WHERE customerId = @customerId", mysql);
                    command.Parameters.AddWithValue("@customerId", int.Parse(lblId.Text));
                    command.ExecuteNonQuery();
                    MessageBox.Show("Hesabınız Başarıyla Silinmiştir!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteSupplierAccount_Click(object sender, EventArgs e)
        {
            try
            {
                mysql = dbo.Connect();
                if (mysql.State != ConnectionState.Open)
                {
                    mysql.Open();
                }
                DialogResult dialogResult = MessageBox.Show("Hesabınızı Silmek İstediğinize Emin Misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                 
                    command = new MySqlCommand("DELETE FROM product WHERE supplierId = @supplierId", mysql);
                    command.Parameters.AddWithValue("@supplierId", int.Parse(lblSupplierId.Text));
                    command.ExecuteNonQuery();
                    command = new MySqlCommand("DELETE FROM supplier WHERE supplierId = @supplierId", mysql);
                    command.Parameters.AddWithValue("@supplierId", int.Parse(lblSupplierId.Text));
                    command.ExecuteNonQuery();
                    MessageBox.Show("Hesabınız Başarıyla Silinmiştir!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
