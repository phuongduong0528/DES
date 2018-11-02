namespace DES_Visualizer
{
    partial class DESApp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rtb_main = new System.Windows.Forms.RichTextBox();
            this.txt_key = new System.Windows.Forms.TextBox();
            this.txt_input = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_randomKey = new System.Windows.Forms.Button();
            this.btn_encrypt = new System.Windows.Forms.Button();
            this.btn_decrypt = new System.Windows.Forms.Button();
            this.lbl_key = new System.Windows.Forms.Label();
            this.lbl_input = new System.Windows.Forms.Label();
            this.lbl_time = new System.Windows.Forms.Label();
            this.lbl_output = new System.Windows.Forms.Label();
            this.btn_saveKey = new System.Windows.Forms.Button();
            this.ckb_cbc = new System.Windows.Forms.CheckBox();
            this.btn_iv_sav = new System.Windows.Forms.Button();
            this.btn_iv_ran = new System.Windows.Forms.Button();
            this.txt_iv = new System.Windows.Forms.TextBox();
            this.lbl_iv = new System.Windows.Forms.Label();
            this.lbl_iv1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rtb_main
            // 
            this.rtb_main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtb_main.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtb_main.Location = new System.Drawing.Point(279, 12);
            this.rtb_main.Name = "rtb_main";
            this.rtb_main.Size = new System.Drawing.Size(602, 473);
            this.rtb_main.TabIndex = 0;
            this.rtb_main.Text = "";
            // 
            // txt_key
            // 
            this.txt_key.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_key.Location = new System.Drawing.Point(9, 35);
            this.txt_key.Name = "txt_key";
            this.txt_key.Size = new System.Drawing.Size(257, 23);
            this.txt_key.TabIndex = 1;
            // 
            // txt_input
            // 
            this.txt_input.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_input.Location = new System.Drawing.Point(9, 224);
            this.txt_input.Name = "txt_input";
            this.txt_input.Size = new System.Drawing.Size(257, 23);
            this.txt_input.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Key";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Input";
            // 
            // btn_randomKey
            // 
            this.btn_randomKey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_randomKey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btn_randomKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_randomKey.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_randomKey.Location = new System.Drawing.Point(9, 57);
            this.btn_randomKey.Margin = new System.Windows.Forms.Padding(0);
            this.btn_randomKey.Name = "btn_randomKey";
            this.btn_randomKey.Size = new System.Drawing.Size(129, 23);
            this.btn_randomKey.TabIndex = 3;
            this.btn_randomKey.Text = "Random";
            this.btn_randomKey.UseVisualStyleBackColor = true;
            this.btn_randomKey.Click += new System.EventHandler(this.btn_randomKey_Click);
            // 
            // btn_encrypt
            // 
            this.btn_encrypt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_encrypt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btn_encrypt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_encrypt.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_encrypt.Location = new System.Drawing.Point(9, 246);
            this.btn_encrypt.Margin = new System.Windows.Forms.Padding(0);
            this.btn_encrypt.Name = "btn_encrypt";
            this.btn_encrypt.Size = new System.Drawing.Size(129, 23);
            this.btn_encrypt.TabIndex = 3;
            this.btn_encrypt.Text = "Encrypt";
            this.btn_encrypt.UseVisualStyleBackColor = true;
            this.btn_encrypt.Click += new System.EventHandler(this.btn_encrypt_Click);
            // 
            // btn_decrypt
            // 
            this.btn_decrypt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_decrypt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btn_decrypt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_decrypt.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_decrypt.Location = new System.Drawing.Point(137, 246);
            this.btn_decrypt.Margin = new System.Windows.Forms.Padding(0);
            this.btn_decrypt.Name = "btn_decrypt";
            this.btn_decrypt.Size = new System.Drawing.Size(129, 23);
            this.btn_decrypt.TabIndex = 3;
            this.btn_decrypt.Text = "Decrypt";
            this.btn_decrypt.UseVisualStyleBackColor = true;
            this.btn_decrypt.Click += new System.EventHandler(this.btn_decrypt_Click);
            // 
            // lbl_key
            // 
            this.lbl_key.AutoSize = true;
            this.lbl_key.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_key.Location = new System.Drawing.Point(12, 298);
            this.lbl_key.Name = "lbl_key";
            this.lbl_key.Size = new System.Drawing.Size(29, 17);
            this.lbl_key.TabIndex = 4;
            this.lbl_key.Text = "Key";
            // 
            // lbl_input
            // 
            this.lbl_input.AutoSize = true;
            this.lbl_input.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_input.Location = new System.Drawing.Point(12, 357);
            this.lbl_input.Name = "lbl_input";
            this.lbl_input.Size = new System.Drawing.Size(37, 17);
            this.lbl_input.TabIndex = 4;
            this.lbl_input.Text = "Input";
            // 
            // lbl_time
            // 
            this.lbl_time.AutoSize = true;
            this.lbl_time.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_time.Location = new System.Drawing.Point(12, 420);
            this.lbl_time.Name = "lbl_time";
            this.lbl_time.Size = new System.Drawing.Size(36, 17);
            this.lbl_time.TabIndex = 4;
            this.lbl_time.Text = "Time";
            // 
            // lbl_output
            // 
            this.lbl_output.AutoSize = true;
            this.lbl_output.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_output.Location = new System.Drawing.Point(12, 388);
            this.lbl_output.Name = "lbl_output";
            this.lbl_output.Size = new System.Drawing.Size(48, 17);
            this.lbl_output.TabIndex = 4;
            this.lbl_output.Text = "Output";
            // 
            // btn_saveKey
            // 
            this.btn_saveKey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_saveKey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btn_saveKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_saveKey.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_saveKey.Location = new System.Drawing.Point(137, 57);
            this.btn_saveKey.Margin = new System.Windows.Forms.Padding(0);
            this.btn_saveKey.Name = "btn_saveKey";
            this.btn_saveKey.Size = new System.Drawing.Size(129, 23);
            this.btn_saveKey.TabIndex = 3;
            this.btn_saveKey.Text = "Save";
            this.btn_saveKey.UseVisualStyleBackColor = true;
            this.btn_saveKey.Click += new System.EventHandler(this.btn_saveKey_Click);
            // 
            // ckb_cbc
            // 
            this.ckb_cbc.AutoSize = true;
            this.ckb_cbc.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckb_cbc.Location = new System.Drawing.Point(179, 203);
            this.ckb_cbc.Name = "ckb_cbc";
            this.ckb_cbc.Size = new System.Drawing.Size(50, 21);
            this.ckb_cbc.TabIndex = 5;
            this.ckb_cbc.Text = "CBC";
            this.ckb_cbc.UseVisualStyleBackColor = true;
            this.ckb_cbc.CheckedChanged += new System.EventHandler(this.ckb_cbc_CheckedChanged);
            // 
            // btn_iv_sav
            // 
            this.btn_iv_sav.Enabled = false;
            this.btn_iv_sav.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_iv_sav.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btn_iv_sav.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_iv_sav.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_iv_sav.Location = new System.Drawing.Point(137, 149);
            this.btn_iv_sav.Margin = new System.Windows.Forms.Padding(0);
            this.btn_iv_sav.Name = "btn_iv_sav";
            this.btn_iv_sav.Size = new System.Drawing.Size(129, 23);
            this.btn_iv_sav.TabIndex = 8;
            this.btn_iv_sav.Text = "Save";
            this.btn_iv_sav.UseVisualStyleBackColor = true;
            this.btn_iv_sav.Click += new System.EventHandler(this.btn_iv_sav_Click);
            // 
            // btn_iv_ran
            // 
            this.btn_iv_ran.Enabled = false;
            this.btn_iv_ran.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_iv_ran.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btn_iv_ran.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_iv_ran.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_iv_ran.Location = new System.Drawing.Point(9, 149);
            this.btn_iv_ran.Margin = new System.Windows.Forms.Padding(0);
            this.btn_iv_ran.Name = "btn_iv_ran";
            this.btn_iv_ran.Size = new System.Drawing.Size(129, 23);
            this.btn_iv_ran.TabIndex = 7;
            this.btn_iv_ran.Text = "Random";
            this.btn_iv_ran.UseVisualStyleBackColor = true;
            this.btn_iv_ran.Click += new System.EventHandler(this.btn_iv_ran_Click);
            // 
            // txt_iv
            // 
            this.txt_iv.Enabled = false;
            this.txt_iv.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_iv.Location = new System.Drawing.Point(9, 127);
            this.txt_iv.Name = "txt_iv";
            this.txt_iv.Size = new System.Drawing.Size(257, 23);
            this.txt_iv.TabIndex = 6;
            // 
            // lbl_iv
            // 
            this.lbl_iv.AutoSize = true;
            this.lbl_iv.Enabled = false;
            this.lbl_iv.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_iv.Location = new System.Drawing.Point(6, 107);
            this.lbl_iv.Name = "lbl_iv";
            this.lbl_iv.Size = new System.Drawing.Size(19, 17);
            this.lbl_iv.TabIndex = 2;
            this.lbl_iv.Text = "IV";
            // 
            // lbl_iv1
            // 
            this.lbl_iv1.AutoSize = true;
            this.lbl_iv1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_iv1.Location = new System.Drawing.Point(12, 328);
            this.lbl_iv1.Name = "lbl_iv1";
            this.lbl_iv1.Size = new System.Drawing.Size(19, 17);
            this.lbl_iv1.TabIndex = 4;
            this.lbl_iv1.Text = "IV";
            // 
            // DESApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 498);
            this.Controls.Add(this.btn_iv_sav);
            this.Controls.Add(this.btn_iv_ran);
            this.Controls.Add(this.txt_iv);
            this.Controls.Add(this.ckb_cbc);
            this.Controls.Add(this.lbl_output);
            this.Controls.Add(this.lbl_time);
            this.Controls.Add(this.lbl_input);
            this.Controls.Add(this.lbl_iv1);
            this.Controls.Add(this.lbl_key);
            this.Controls.Add(this.btn_decrypt);
            this.Controls.Add(this.btn_encrypt);
            this.Controls.Add(this.btn_saveKey);
            this.Controls.Add(this.btn_randomKey);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_iv);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_input);
            this.Controls.Add(this.txt_key);
            this.Controls.Add(this.rtb_main);
            this.Name = "DESApp";
            this.Text = "DES Visualizer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtb_main;
        private System.Windows.Forms.TextBox txt_key;
        private System.Windows.Forms.TextBox txt_input;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_randomKey;
        private System.Windows.Forms.Button btn_encrypt;
        private System.Windows.Forms.Button btn_decrypt;
        private System.Windows.Forms.Label lbl_key;
        private System.Windows.Forms.Label lbl_input;
        private System.Windows.Forms.Label lbl_time;
        private System.Windows.Forms.Label lbl_output;
        private System.Windows.Forms.Button btn_saveKey;
        private System.Windows.Forms.CheckBox ckb_cbc;
        private System.Windows.Forms.Button btn_iv_sav;
        private System.Windows.Forms.Button btn_iv_ran;
        private System.Windows.Forms.TextBox txt_iv;
        private System.Windows.Forms.Label lbl_iv;
        private System.Windows.Forms.Label lbl_iv1;
    }
}

