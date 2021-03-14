using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SongsAndVotesCommon.Repos;
using SongsAndVotesCommon.BusinessObjects;


namespace SongsAndVotesAdmin.Formular
{
    public partial class LoginForm : Form
    {
        private UserRepo userRepo;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            User user = new User(UsernameBox.Text, PasswordBox.Text);

            if (userRepo.Exists(user))
            {
                this.Close();
                this.Dispose();
                LoginForm MainForm = new LoginForm();
                MainForm.Show();
            }
            else
            {
                UsernameBox.BackColor = Color.Tomato;
                PasswordBox.BackColor = Color.Tomato;
            }
        }
    }
}
