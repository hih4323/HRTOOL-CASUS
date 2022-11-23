namespace HRTOOL_CASUS
{
    partial class Inloggen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inloggen));
            this.InvoerGebruikersnaam = new System.Windows.Forms.TextBox();
            this.InvoerWachtwoord = new System.Windows.Forms.TextBox();
            this.Gebruikersnaam = new System.Windows.Forms.Label();
            this.Wachtwoord = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // InvoerGebruikersnaam
            // 
            this.InvoerGebruikersnaam.Location = new System.Drawing.Point(120, 20);
            this.InvoerGebruikersnaam.Name = "InvoerGebruikersnaam";
            this.InvoerGebruikersnaam.Size = new System.Drawing.Size(100, 23);
            this.InvoerGebruikersnaam.TabIndex = 0;
            this.InvoerGebruikersnaam.TextChanged += new System.EventHandler(this.InvoerGebruikersnaam_TextChanged);
            // 
            // InvoerWachtwoord
            // 
            this.InvoerWachtwoord.Location = new System.Drawing.Point(120, 49);
            this.InvoerWachtwoord.Name = "InvoerWachtwoord";
            this.InvoerWachtwoord.Size = new System.Drawing.Size(100, 23);
            this.InvoerWachtwoord.TabIndex = 1;
            this.InvoerWachtwoord.TextChanged += new System.EventHandler(this.InvoerWachtwoord_TextChanged);
            // 
            // Gebruikersnaam
            // 
            this.Gebruikersnaam.AutoSize = true;
            this.Gebruikersnaam.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Gebruikersnaam.Location = new System.Drawing.Point(21, 23);
            this.Gebruikersnaam.Name = "Gebruikersnaam";
            this.Gebruikersnaam.Size = new System.Drawing.Size(99, 15);
            this.Gebruikersnaam.TabIndex = 2;
            this.Gebruikersnaam.Text = "Gebruikersnaam";
            this.Gebruikersnaam.Click += new System.EventHandler(this.Gebruikersnaam_Click);
            // 
            // Wachtwoord
            // 
            this.Wachtwoord.AutoSize = true;
            this.Wachtwoord.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Wachtwoord.Location = new System.Drawing.Point(24, 53);
            this.Wachtwoord.Name = "Wachtwoord";
            this.Wachtwoord.Size = new System.Drawing.Size(74, 15);
            this.Wachtwoord.TabIndex = 3;
            this.Wachtwoord.Text = "Wachwoord";
            this.Wachtwoord.Click += new System.EventHandler(this.Wachtwoord_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 84);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(167, 84);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Afbreken";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Inloggen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 119);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Wachtwoord);
            this.Controls.Add(this.Gebruikersnaam);
            this.Controls.Add(this.InvoerWachtwoord);
            this.Controls.Add(this.InvoerGebruikersnaam);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Inloggen";
            this.Text = "Inloggen";
            this.Load += new System.EventHandler(this.Inloggen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox InvoerGebruikersnaam;
        private TextBox InvoerWachtwoord;
        private Label Gebruikersnaam;
        private Label Wachtwoord;
        private Button button1;
        private Button button2;
    }
}