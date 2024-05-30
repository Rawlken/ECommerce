using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ECommerce
{
    internal class AccountInfo
    {
        DatabaseOperations dbo = new DatabaseOperations();
        MySqlConnection mysql;
        MySqlCommand command;

        private string _firstName;
        private string _lastName;
        private string _nickname;
        private string _password;
        private string _phoneNumber;
        private string _gender;
        private DateTime _birthDate;
        private string _country;
        private string _city;
        private string _region;
        private string _address;
        private string _creditCardNumber;
        private int _creditCardTypeId;
        private string _creditCardExpDate;
        private int _creditCardCVV;

        public AccountInfo(string firstName, string lastName, string nickname, string password, string phoneNumber, string gender, DateTime birthDate, string country, string city, string region, string adress, string creditCardNumber, int creditCardTypeId, string creditCardExpDate, int creditCardCVV)
        {
            _firstName = firstName;
            _lastName = lastName;
            _nickname = nickname;
            _password = password;
            _phoneNumber = phoneNumber;
            _gender = gender;
            _birthDate = birthDate;
            _country = country;
            _city = city;
            _region = region;
            _address = adress;
            _creditCardNumber = creditCardNumber;
            _creditCardTypeId = creditCardTypeId;
            _creditCardExpDate = creditCardExpDate;
            _creditCardCVV = creditCardCVV;
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
                command = new MySqlCommand("UPDATE customer SET customerFirstName = @customerFirstName, customerLastName = @customerLastName, customerPassword = @customerPassword, customerPhoneNumber = @customerPhoneNumber, customerGender = @customerGender, customerBirthDate = @customerBirthDate, customerCountry = @customerCountry, customerCity = @customerCity, customerRegion = @customerRegion, customerAdress = @customerAdress, customerCreditCardNumber = @customerCreditCardNumber, creditCardTypeId = @creditCardTypeId, customerCreditCardExpDate = @customerCreditCardExpDate, customerCreditCardCVV = @customerCreditCardCVV WHERE customerNickname = @customerNickname", mysql);
                command.Parameters.AddWithValue("@customerFirstName", _firstName);
                command.Parameters.AddWithValue("@customerLastName", _lastName);
                command.Parameters.AddWithValue("@customerPassword", _password);
                command.Parameters.AddWithValue("@customerPhoneNumber", _phoneNumber);
                command.Parameters.AddWithValue("@customerGender", _gender);
                command.Parameters.AddWithValue("@customerBirthDate", _birthDate);
                command.Parameters.AddWithValue("@customerCountry", _country);
                command.Parameters.AddWithValue("@customerCity", _city);
                command.Parameters.AddWithValue("@customerRegion", _region);
                command.Parameters.AddWithValue("@customerAdress", _address);
                command.Parameters.AddWithValue("@customerCreditCardNumber", _creditCardNumber);
                command.Parameters.AddWithValue("@creditCardTypeId", _creditCardTypeId);
                command.Parameters.AddWithValue("@customerCreditCardExpDate", _creditCardExpDate);
                command.Parameters.AddWithValue("@customerCreditCardCVV", _creditCardCVV);
                command.Parameters.AddWithValue("@customerNickname", _nickname);
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
