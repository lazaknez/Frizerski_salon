﻿namespace Server
{
    partial class FormaServer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormaServer));
            this.btnZaustavi = new System.Windows.Forms.Button();
            this.btnPokreni = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnZaustavi
            // 
            this.btnZaustavi.Enabled = false;
            this.btnZaustavi.Location = new System.Drawing.Point(477, 30);
            this.btnZaustavi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnZaustavi.Name = "btnZaustavi";
            this.btnZaustavi.Size = new System.Drawing.Size(260, 52);
            this.btnZaustavi.TabIndex = 7;
            this.btnZaustavi.Text = "Zaustavi server";
            this.btnZaustavi.UseVisualStyleBackColor = true;
            this.btnZaustavi.Click += new System.EventHandler(this.btnZaustavi_Click);
            // 
            // btnPokreni
            // 
            this.btnPokreni.Location = new System.Drawing.Point(16, 30);
            this.btnPokreni.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPokreni.Name = "btnPokreni";
            this.btnPokreni.Size = new System.Drawing.Size(260, 52);
            this.btnPokreni.TabIndex = 6;
            this.btnPokreni.Text = "Pokreni server";
            this.btnPokreni.UseVisualStyleBackColor = true;
            this.btnPokreni.Click += new System.EventHandler(this.btnPokreni_Click);
            // 
            // FormaServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 113);
            this.Controls.Add(this.btnZaustavi);
            this.Controls.Add(this.btnPokreni);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormaServer";
            this.Text = "Frizerski salon - Server";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnZaustavi;
        private System.Windows.Forms.Button btnPokreni;
    }
}

