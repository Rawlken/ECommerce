using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace ECommerce
{
    internal class SupplierAccountInfo
    {
        DatabaseOperations dbo = new DatabaseOperations();
        MySqlConnection mysql;
        MySqlCommand command;

        private string _contactFirstName;
        private string _contactLastName;
        private string _supplierPhoneNumber;
        private string _supplierEmail;
        private string _supplierPassword;
        private string _supplierCountry;
        private string _supplierCity;
        private string _supplierRegion;
        private string _supplierAdress;
        private int _paymentMethod;
        private Image _image;
        private string _filePath;

        public SupplierAccountInfo(string contactFirstName, string contactLastName, string supplierPhoneNumber, string supplierEmail, string supplierPassword, string supplierCountry, string supplierCity, string supplierRegion, string supplierAdress, int paymentMethod, Image image, string filePath)
        {
            _contactFirstName = contactFirstName;
            _contactLastName = contactLastName;
            _supplierPhoneNumber = supplierPhoneNumber;
            _supplierEmail = supplierEmail;
            _supplierPassword = supplierPassword;
            _supplierCountry = supplierCountry;
            _supplierCity = supplierCity;
            _supplierRegion = supplierRegion;
            _supplierAdress = supplierAdress;
            _paymentMethod = paymentMethod;
            _image = image;
            _filePath = filePath;
        }

        public void UpdateInfo()
        {
            try
            {
                mysql = dbo.Connect();
                if (mysql.State != ConnectionState.Open)
                {
                    mysql.Open();
                }
                command = new MySqlCommand("UPDATE supplier SET contactFirstName = @contactFirstName, contactLastName = @contactLastName, supplierPhoneNumber = @supplierPhoneNumber, supplierPassword = @supplierPassword, supplierCountry = @supplierCountry, supplierCity = @supplierCity, supplierRegion = @supplierRegion, supplierAdress = @supplierAdress, paymentMethod = @paymentMethod, logo = @logo WHERE supplierEmail = @supplierEmail", mysql);
                command.Parameters.AddWithValue("@contactFirstName", _contactFirstName);
                command.Parameters.AddWithValue("@contactLastName", _contactLastName);
                command.Parameters.AddWithValue("@supplierPhoneNumber", _supplierPhoneNumber);
                command.Parameters.AddWithValue("@supplierPassword", _supplierPassword);
                command.Parameters.AddWithValue("@supplierCountry", _supplierCountry);
                command.Parameters.AddWithValue("@supplierCity", _supplierCity);
                command.Parameters.AddWithValue("@supplierRegion", _supplierRegion);
                command.Parameters.AddWithValue("@supplierAdress", _supplierAdress);
                command.Parameters.AddWithValue("@paymentMethod", _paymentMethod);
                FileStream fs = new FileStream(_filePath, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                byte[] img = br.ReadBytes((int)fs.Length);
                br.Close();
                fs.Close();
                command.Parameters.Add("@logo", MySqlDbType.Blob, img.Length).Value = img;
                command.Parameters.AddWithValue("@supplierEmail", _supplierEmail);
                command.ExecuteNonQuery();
                mysql.Close();
                MessageBox.Show("Başarıyla Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
