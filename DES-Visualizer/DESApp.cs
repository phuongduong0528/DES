using DES;
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

namespace DESUI
{
    public partial class DESApp : Form
    {
        private DES.DESMain des;
        private string key;
        private string iv;
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
            display += $"\nFinal data:  {final}\n\n";
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
            {
                if (key.Length > 16)
                {
                    MessageBox.Show("Input must be 64-bit Hexadecimal format", "Error",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    txt_key.Text = key.PadLeft(16, '0').ToUpper();
                    btn_saveKey_Click(sender, e);
                }
            }
        }

        private void btn_encrypt_Click(object sender, EventArgs e)
        {
            if (!ckb_cbc.Checked)
                Encrypt();
            else
                EncryptCBC();

        }

        private void EncryptCBC()
        {
            try
            {
                string input = txt_input.Text.Replace(" ", string.Empty).ToLower().Trim();
                if (IsValidHex(input) && input.Length % 16 == 0)
                {
                    DESCBC descbc = new DESCBC(key, iv);
                    descbc.Create();
                    descbc.EncryptCBC(input);
                    rtb_main.Text = $"Input:   {input}\nOutput: {descbc.CbcCipherText}";
                }
                else
                {
                    txt_input.Text = input.PadLeft((16 * ((input.Length / 16) + 1)), '0').ToUpper();
                    EncryptCBC();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Keys or IV not saved!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Encrypt()
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
                    if(input.Length > 16)
                    {
                        MessageBox.Show("Input must be 64-bit Hexadecimal format", "Error",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        txt_input.Text = input.PadLeft(16, '0').ToUpper();
                        Encrypt();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No keys!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_decrypt_Click(object sender, EventArgs e)
        {
            if (!ckb_cbc.Checked)
                Decrypt();
            else
                DecryptCBC();
        }

        private void DecryptCBC()
        {
            try
            {
                string input = txt_input.Text.Replace(" ", string.Empty).ToLower().Trim();
                if (IsValidHex(input) && input.Length % 16 == 0)
                {
                    DESCBC descbc = new DESCBC(key, iv);
                    descbc.Create();
                    descbc.DecryptCBC(input);
                    rtb_main.Text = $"Input:   {input}\nOutput: {descbc.CbcDecryptText}";
                }
                else
                {
                    txt_input.Text = input.PadLeft((16 * ((input.Length / 16) + 1)), '0').ToUpper();
                    DecryptCBC();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Keys or IV not saved!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Decrypt()
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
                    if (input.Length > 16)
                    {
                        MessageBox.Show("Input must be 64-bit Hexadecimal format", "Error",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        txt_input.Text = input.PadLeft(16, '0').ToUpper();
                        Decrypt();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No keys!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ckb_cbc_CheckedChanged(object sender, EventArgs e)
        {
            if (!ckb_cbc.Checked)
            {
                btn_iv_ran.Enabled = false;
                btn_iv_sav.Enabled = false;
                txt_iv.Enabled = false;
                lbl_iv.Enabled = false;
            }
            else
            {
                btn_iv_ran.Enabled = true;
                btn_iv_sav.Enabled = true;
                txt_iv.Enabled = true;
                lbl_iv.Enabled = true;
            }
        }

        private void btn_iv_ran_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int l = random.Next();
            int r = random.Next();
            string res = l.ToString("X8") + r.ToString("X8");
            txt_iv.Text = res;
        }

        private void btn_iv_sav_Click(object sender, EventArgs e)
        {
            string iv = txt_iv.Text.Replace(" ", string.Empty).ToLower().Trim();
            if (IsValidHex(iv) && iv.Length == 16)
            {
                lbl_iv1.Text = $"IV: {iv.ToUpper()}";
                this.iv = iv;
            }
            else
                MessageBox.Show("IV must be 64-bit Hexadecimal format", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
