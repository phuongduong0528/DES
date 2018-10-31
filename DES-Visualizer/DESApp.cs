using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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

        private void CalculateAndDisplay(string hex, string key, int mode)
        {
            string display = "";
            string final;
            Stopwatch sw;
            DES.DESMain des = new DES.DESMain(key);
            des.Create();
            if (mode == 0)
            {
                sw = Stopwatch.StartNew();
                des.Encrypt(hex);
                sw.Stop();
                final = des.CipherText.ToUpper();
            }
            else
            {
                sw = Stopwatch.StartNew();
                des.Decrypt(hex);
                sw.Stop();
                final = des.DecryptText.ToUpper();
            }

            display += $"Input data:  {hex.ToUpper()}";
            display += $"\nFinal data: {final}\n\n";
            display += $"After Initial Permutation: {des.TraceInit}\n\n";
            display += "Left".PadLeft(24) + "Right".PadLeft(21) + "Key".PadLeft(14) + "\n";
            display += "--------------------------------------------------------------------\n";
            int count = 0;
            foreach (string[] item in des.TraceRound)
            {
                count++;
                display += "Round" + $"{count}".PadLeft(3) + item[0].PadLeft(20) + item[1].PadLeft(20) + item[2].PadLeft(20) + "\n";
            }
            display += $"\nBefore FinalPermutation: {des.TraceFinal}\n";
            display += $"Final:                   {final}";
            lbl_output.Text = $"Output: {final}";
            lbl_time.Text = $"Time: {sw.Elapsed.TotalMilliseconds}" + " ms";
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
                    CalculateAndDisplay(input, this.key, 0);
                }
                else
                {
                    MessageBox.Show("Input must be 64-bit Hexadecimal format", "Error",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("No keys!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_decrypt_Click(object sender, EventArgs e)
        {
            try
            {
                string input = txt_input.Text.Replace(" ", string.Empty).ToLower().Trim();
                if (IsValidHex(input) && input.Length == 16)
                {
                    lbl_input.Text = $"Input: {input.ToUpper()}";
                    CalculateAndDisplay(input, this.key, 1);
                }
                else
                {
                    MessageBox.Show("Input must be 64-bit Hexadecimal format", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No keys!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
