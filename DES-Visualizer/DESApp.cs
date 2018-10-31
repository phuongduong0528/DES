using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DES_Visualizer
{
    public partial class DESApp : Form
    {
        private DES.DESMain des;
        private string key;
        private string output;

        public DESApp()
        {
            InitializeComponent();
        }

        private bool IsValidHex(string hex)
        {
            foreach(char c in hex)
            {
                if (!((c >= '0' && c <= '9') || (c >= 'a' && c <= 'f')))
                    return false;
            }
            return true;
        }

        private void CalculateAndDisplay(string hex, string key)
        {
            string display = "";
            DES.DESMain des = new DES.DESMain(key);
            des.Create();
            des.Encrypt(hex);
            display += $"Input data:  {hex.ToUpper()}";
            display += $"\nCipher text: {des.CipherText.ToUpper()}";
            rtb_main.Text = display;
        }

        private void btn_randomKey_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int l = random.Next();
            int r = random.Next();
            string res = l.ToString("X8") + r.ToString("X8");
            txt_key.Text = res;
        }

        private void btn_saveKey_Click(object sender, EventArgs e)
        {
            string key = txt_key.Text.Replace(" ",string.Empty).ToLower().Trim();
            if (IsValidHex(key) && key.Length == 16)
            {
                lbl_key.Text = $"Key: {key.ToUpper()}";
                this.key = key;
            }
            else
                MessageBox.Show("Key must be 64-bit Hexadecimal format", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btn_encrypt_Click(object sender, EventArgs e)
        {
            try
            {
                string input = txt_input.Text.Replace(" ", string.Empty).ToLower().Trim();
                if (IsValidHex(input) && input.Length == 16)
                {
                    lbl_input.Text = $"Input: {input.ToUpper()}";
                    CalculateAndDisplay(input, this.key);
                }
                else
                    MessageBox.Show("Key must be 64-bit Hexadecimal format", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(Exception ex)
            {
                if (key == "" || key == null)
                    MessageBox.Show("You must save keys first.", "Information", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
