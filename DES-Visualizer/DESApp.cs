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

        private void btn_randomKey_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int l = random.Next();
            int r = random.Next();
            string res = l.ToString("X8") + r.ToString("X8");
            rtb_key.Text = res;
        }

        private void btn_saveKey_Click(object sender, EventArgs e)
        {
            string key = rtb_key.Text.Replace(" ",string.Empty).ToLower().Trim();
            if (IsValidHex(key) && key.Length == 16)
            {
                lbl_key.Text = $"Key: {key.ToUpper()}";
            }
            else
                MessageBox.Show("Key must be 64-bit Hexadecimal format", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
