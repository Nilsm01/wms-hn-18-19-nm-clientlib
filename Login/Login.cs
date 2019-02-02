using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientLib.Login
{
    public partial class Login : MetroFramework.Forms.MetroForm
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
        }

        private void Login_Shown(object sender, EventArgs e)
        {
            
        }

        private void metroTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                PerformLogin();
            }
        }

        private void PerformLogin()
        {
            Resources.ServerResources.Username = metroTextBox1.Text;
            Resources.ServerResources.Password = metroTextBox2.Text;
            if (metroToggle1.Checked)
            {
                Resources.ServerResources.AutoLogin = true;
                Resources.ServerResources.settings.autoLogin = true;
            }
            else
            {
                Resources.ServerResources.AutoLogin = false;
                Resources.ServerResources.settings.autoLogin = false;
            }
            Resources.ServerResources.settings.lastUsername = metroTextBox1.Text;
            Resources.ServerResources.settings.password = metroTextBox2.Text;
            Resources.Services.FileCreater.UpdateSettingsFile(Resources.ServerResources.settings);
            metroTextBox1.Clear();
            metroTextBox2.Clear();
            this.Close();
        }

        private void metroButton1_Click_1(object sender, EventArgs e)
        {
            PerformLogin();
        }
    }
}
