namespace Malchikov6404Server
{
    partial class Server
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
            this.components = new System.ComponentModel.Container();
            this.logs = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.myIP = new System.Windows.Forms.Label();
            this.ipadress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.directory = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.getDirectory = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.genKey = new System.Windows.Forms.Button();
            this.label111 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.Pkey = new System.Windows.Forms.Label();
            this.Qkey = new System.Windows.Forms.Label();
            this.Ekey = new System.Windows.Forms.Label();
            this.Nkey = new System.Windows.Forms.Label();
            this.Phikey = new System.Windows.Forms.Label();
            this.Dkey = new System.Windows.Forms.Label();
            this.Ykey = new System.Windows.Forms.Label();
            this.NODkey = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.GetCryptFile = new System.Windows.Forms.Button();
            this.superkey11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.getSuperkey_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // logs
            // 
            this.logs.Location = new System.Drawing.Point(283, 12);
            this.logs.Name = "logs";
            this.logs.Size = new System.Drawing.Size(227, 476);
            this.logs.TabIndex = 0;
            this.logs.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 214);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(261, 37);
            this.button1.TabIndex = 1;
            this.button1.Text = "(тестовый) Запустить сервер (для приёма файла)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // myIP
            // 
            this.myIP.AutoSize = true;
            this.myIP.Location = new System.Drawing.Point(10, 371);
            this.myIP.Name = "myIP";
            this.myIP.Size = new System.Drawing.Size(47, 13);
            this.myIP.TabIndex = 2;
            this.myIP.Text = "Мой IP=";
            // 
            // ipadress
            // 
            this.ipadress.Location = new System.Drawing.Point(12, 13);
            this.ipadress.Name = "ipadress";
            this.ipadress.Size = new System.Drawing.Size(154, 20);
            this.ipadress.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(172, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "ipV4 адрес клиента";
            // 
            // directory
            // 
            this.directory.Location = new System.Drawing.Point(12, 39);
            this.directory.Name = "directory";
            this.directory.Size = new System.Drawing.Size(154, 20);
            this.directory.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(172, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Папка сохранения";
            // 
            // getDirectory
            // 
            this.getDirectory.Location = new System.Drawing.Point(12, 65);
            this.getDirectory.Name = "getDirectory";
            this.getDirectory.Size = new System.Drawing.Size(261, 23);
            this.getDirectory.TabIndex = 7;
            this.getDirectory.Text = "[1] Выбрать папку";
            this.getDirectory.UseVisualStyleBackColor = true;
            this.getDirectory.Click += new System.EventHandler(this.getDirectory_Click);
            // 
            // genKey
            // 
            this.genKey.Location = new System.Drawing.Point(12, 94);
            this.genKey.Name = "genKey";
            this.genKey.Size = new System.Drawing.Size(261, 23);
            this.genKey.TabIndex = 8;
            this.genKey.Text = "[2] Запустить сервер (для генерации ключей)";
            this.genKey.UseVisualStyleBackColor = true;
            this.genKey.Click += new System.EventHandler(this.genKey_Click);
            // 
            // label111
            // 
            this.label111.AutoSize = true;
            this.label111.Location = new System.Drawing.Point(9, 397);
            this.label111.Name = "label111";
            this.label111.Size = new System.Drawing.Size(38, 13);
            this.label111.TabIndex = 9;
            this.label111.Text = "PKey=";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 410);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "QKey=";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 423);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "EKey=";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 436);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "NKey=";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 449);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "PhiKey=";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 462);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "DKey=";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 475);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "YKey=";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 384);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "NODKey=";
            // 
            // Pkey
            // 
            this.Pkey.AutoSize = true;
            this.Pkey.Location = new System.Drawing.Point(53, 397);
            this.Pkey.Name = "Pkey";
            this.Pkey.Size = new System.Drawing.Size(27, 13);
            this.Pkey.TabIndex = 17;
            this.Pkey.Text = "xxxx";
            // 
            // Qkey
            // 
            this.Qkey.AutoSize = true;
            this.Qkey.Location = new System.Drawing.Point(53, 410);
            this.Qkey.Name = "Qkey";
            this.Qkey.Size = new System.Drawing.Size(27, 13);
            this.Qkey.TabIndex = 18;
            this.Qkey.Text = "xxxx";
            // 
            // Ekey
            // 
            this.Ekey.AutoSize = true;
            this.Ekey.Location = new System.Drawing.Point(53, 423);
            this.Ekey.Name = "Ekey";
            this.Ekey.Size = new System.Drawing.Size(27, 13);
            this.Ekey.TabIndex = 19;
            this.Ekey.Text = "xxxx";
            // 
            // Nkey
            // 
            this.Nkey.AutoSize = true;
            this.Nkey.Location = new System.Drawing.Point(53, 436);
            this.Nkey.Name = "Nkey";
            this.Nkey.Size = new System.Drawing.Size(27, 13);
            this.Nkey.TabIndex = 20;
            this.Nkey.Text = "xxxx";
            // 
            // Phikey
            // 
            this.Phikey.AutoSize = true;
            this.Phikey.Location = new System.Drawing.Point(53, 449);
            this.Phikey.Name = "Phikey";
            this.Phikey.Size = new System.Drawing.Size(27, 13);
            this.Phikey.TabIndex = 21;
            this.Phikey.Text = "xxxx";
            // 
            // Dkey
            // 
            this.Dkey.AutoSize = true;
            this.Dkey.Location = new System.Drawing.Point(53, 462);
            this.Dkey.Name = "Dkey";
            this.Dkey.Size = new System.Drawing.Size(27, 13);
            this.Dkey.TabIndex = 22;
            this.Dkey.Text = "xxxx";
            // 
            // Ykey
            // 
            this.Ykey.AutoSize = true;
            this.Ykey.Location = new System.Drawing.Point(53, 475);
            this.Ykey.Name = "Ykey";
            this.Ykey.Size = new System.Drawing.Size(27, 13);
            this.Ykey.TabIndex = 23;
            this.Ykey.Text = "xxxx";
            // 
            // NODkey
            // 
            this.NODkey.AutoSize = true;
            this.NODkey.Location = new System.Drawing.Point(63, 384);
            this.NODkey.Name = "NODkey";
            this.NODkey.Size = new System.Drawing.Size(27, 13);
            this.NODkey.TabIndex = 24;
            this.NODkey.Text = "xxxx";
            // 
            // GetCryptFile
            // 
            this.GetCryptFile.Location = new System.Drawing.Point(12, 167);
            this.GetCryptFile.Name = "GetCryptFile";
            this.GetCryptFile.Size = new System.Drawing.Size(261, 41);
            this.GetCryptFile.TabIndex = 25;
            this.GetCryptFile.Text = "[7] Получить зашифрованный файл и расшифровать";
            this.GetCryptFile.UseVisualStyleBackColor = true;
            this.GetCryptFile.Click += new System.EventHandler(this.GetCryptFile_Click);
            // 
            // superkey11
            // 
            this.superkey11.AutoSize = true;
            this.superkey11.Location = new System.Drawing.Point(10, 358);
            this.superkey11.Name = "superkey11";
            this.superkey11.Size = new System.Drawing.Size(50, 13);
            this.superkey11.TabIndex = 26;
            this.superkey11.Text = "superkey";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 345);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 13);
            this.label10.TabIndex = 27;
            this.label10.Text = "label10";
            // 
            // getSuperkey_Button
            // 
            this.getSuperkey_Button.Location = new System.Drawing.Point(12, 123);
            this.getSuperkey_Button.Name = "getSuperkey_Button";
            this.getSuperkey_Button.Size = new System.Drawing.Size(261, 38);
            this.getSuperkey_Button.TabIndex = 28;
            this.getSuperkey_Button.Text = "[5] Запустить сервер (для получения суперключа)";
            this.getSuperkey_Button.UseVisualStyleBackColor = true;
            this.getSuperkey_Button.Click += new System.EventHandler(this.button2_Click);
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 494);
            this.Controls.Add(this.getSuperkey_Button);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.superkey11);
            this.Controls.Add(this.GetCryptFile);
            this.Controls.Add(this.NODkey);
            this.Controls.Add(this.Ykey);
            this.Controls.Add(this.Dkey);
            this.Controls.Add(this.Phikey);
            this.Controls.Add(this.Nkey);
            this.Controls.Add(this.Ekey);
            this.Controls.Add(this.Qkey);
            this.Controls.Add(this.Pkey);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label111);
            this.Controls.Add(this.genKey);
            this.Controls.Add(this.getDirectory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.directory);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ipadress);
            this.Controls.Add(this.myIP);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.logs);
            this.Name = "Server";
            this.Text = "Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox logs;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label myIP;
        private System.Windows.Forms.TextBox ipadress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox directory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button getDirectory;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button genKey;
        private System.Windows.Forms.Label label111;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label Pkey;
        private System.Windows.Forms.Label Qkey;
        private System.Windows.Forms.Label Ekey;
        private System.Windows.Forms.Label Nkey;
        private System.Windows.Forms.Label Phikey;
        private System.Windows.Forms.Label Dkey;
        private System.Windows.Forms.Label Ykey;
        private System.Windows.Forms.Label NODkey;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button GetCryptFile;
        private System.Windows.Forms.Label superkey11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button getSuperkey_Button;
    }
}

