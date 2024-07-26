using Student_Information_Management.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Microsoft.VisualBasic;
using System.Net.Mail;
using System.Net;

namespace Student_Information_Management.BusinessLogic
{
    internal class LoginLogic
    {
		/// <summary>
		/// This class is the operations for validating the Login username and password. 
		/// The signup method will be used to create a new user and save the information to the text file for valid login to happen
		/// </summary>
		/// <param name="username"></param>
		/// <param name="password"></param>
		/// <returns></returns>
		public bool ValidatePassword(string username, string password)
        {
            bool login = false;
            FileHandler handler = new FileHandler();
            string[] list = handler.ReadFromFile();

            foreach (string user in list)
            {
                string[] userDetails = user.Split(',');
                string storedUsername = userDetails[0];
                string storedPassword = userDetails[1];
                if (username == storedUsername && password == storedPassword)
                {
                    login = true;
                }
            }

            if (login) {
                MessageBox.Show("Login successful");
                frmMainForm frmMain = new frmMainForm();
                frmMain.Show();
            } else {
				MessageBox.Show("Incorrect Password or Username, Sign up if you are a new user");
			}
            return login;
        }

        public void SignUp(string username, string password)
        {
            FileHandler handler = new FileHandler();
            string[] list = handler.ReadFromFile();

            //Uniqueness Check -> Username not taken
            bool nameTaken = false;
            foreach (string user in list)
            {
                string[] userDetails = user.Split(',');
                string storedUsername = userDetails[0];

                if (username == storedUsername)
                {
                    nameTaken = true;
                }
            }
            if (nameTaken) { MessageBox.Show("Username is taken"); }
                
            //Length Requirements username -> Min 5 Max 20
            bool nameLenth = false;
            if (username.Length < 5 || username.Length > 20) 
            {
                nameLenth = true;
            }
            if (nameLenth) { MessageBox.Show("Username is too short or too long -> Min 5 Max 20 "); }

            //Character Restrictions username -> No spaces, or special character except for "_ - ."
            string pattern = @"^[a-zA-Z0-9_.-]+$";
            Regex regex = new Regex(pattern);
            bool usernameValidCharacter = regex.IsMatch(username);
            if (!usernameValidCharacter) { MessageBox.Show("Username should not contain spaces or special characters exept for '_' '-' '.'"); }

            //Length Requirements password -> Min 8 Max
            bool passwordLength = false;
            if (password.Length == 8)
            {
                passwordLength = true;
            }
            if (!passwordLength) { MessageBox.Show("Password is not 8 characters long"); }

            //Requirements password -> At least one uppercase letter -> At least one lowercase letter -> At least one digit -> At least one special character
            string lowrcase = @"[a-z]";
            string uppercase = @"[A-Z]";
            string specialcharacter = @"[a-z]";
            string number = @"[0-9]";

            bool passwordValidCharacters = Regex.IsMatch(password, lowrcase) && Regex.IsMatch(password, uppercase) && Regex.IsMatch(password, specialcharacter) && Regex.IsMatch(password, number);
            if (!passwordValidCharacters) { MessageBox.Show("Password does not meet specification. Should contain at least one lowercase, one uppercase, one digit and one special character"); }
            
            //Adding new user to text file if name and password meet specifications
            if(!nameTaken && !nameLenth && usernameValidCharacter && passwordLength && passwordValidCharacters) 
            {
                Random random = new Random();
                string otp = random.Next(1000, 9999).ToString();

                using (var client = new SmtpClient("smtp.gmail.com"))
                {
                    client.Port = 587;
                    client.Credentials = new NetworkCredential("prg282.project1@gmail.com", "vpsf vaqv tlxt risg");
                    client.EnableSsl = true;

                    MailMessage message = new MailMessage();
                    message.From = new MailAddress("prg282.project1@gmail.com");
                    message.Subject = "OTP for Verification";
                    message.Body = $"Your OTP is: {otp}";
                    message.To.Add("joshuamoll0907@gmail.com");
                    message.To.Add("annika.kritzinger@gmail.com");
                    message.To.Add("zoetreutens@gmail.com");
                    message.To.Add("booger20030518@gmail.com");
                    try
                    {
                        client.Send(message);
                        MessageBox.Show("OTP has been sent");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"OTP did not send: {ex.Message}");
                    }
                }

                //MessageBox.Show(otp);
                if (Interaction.InputBox("Enter Verification Code") == otp)
                {
                    handler.WriteToFile(username, password);
                }
                else
                    MessageBox.Show("Incorrect validation");   
            }
        }
    }
}