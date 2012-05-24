namespace QuickHeaders {
    partial class QuickHeaders_HeaderForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.rtbHeaderContent = new System.Windows.Forms.RichTextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnMail = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnFontShrink = new System.Windows.Forms.Button();
            this.btnFontGrow = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtbHeaderContent
            // 
            this.rtbHeaderContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbHeaderContent.Location = new System.Drawing.Point(12, 53);
            this.rtbHeaderContent.Name = "rtbHeaderContent";
            this.rtbHeaderContent.Size = new System.Drawing.Size(813, 455);
            this.rtbHeaderContent.TabIndex = 0;
            this.rtbHeaderContent.Text = "";
            // 
            // btnMail
            // 
            this.btnMail.Image = global::QuickHeaders.Properties.Resources.IPML;
            this.btnMail.Location = new System.Drawing.Point(94, 12);
            this.btnMail.Name = "btnMail";
            this.btnMail.Size = new System.Drawing.Size(35, 35);
            this.btnMail.TabIndex = 4;
            this.btnMail.UseVisualStyleBackColor = true;
            this.btnMail.Click += new System.EventHandler(this.btnMail_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::QuickHeaders.Properties.Resources.filesave;
            this.btnSave.Location = new System.Drawing.Point(135, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(35, 35);
            this.btnSave.TabIndex = 3;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnFontShrink
            // 
            this.btnFontShrink.Image = global::QuickHeaders.Properties.Resources.charactershrinkfont;
            this.btnFontShrink.Location = new System.Drawing.Point(53, 12);
            this.btnFontShrink.Name = "btnFontShrink";
            this.btnFontShrink.Size = new System.Drawing.Size(35, 35);
            this.btnFontShrink.TabIndex = 2;
            this.btnFontShrink.UseVisualStyleBackColor = true;
            this.btnFontShrink.Click += new System.EventHandler(this.btnFontShrink_Click);
            // 
            // btnFontGrow
            // 
            this.btnFontGrow.Image = global::QuickHeaders.Properties.Resources.charactergrowfont;
            this.btnFontGrow.Location = new System.Drawing.Point(12, 12);
            this.btnFontGrow.Name = "btnFontGrow";
            this.btnFontGrow.Size = new System.Drawing.Size(35, 35);
            this.btnFontGrow.TabIndex = 1;
            this.btnFontGrow.UseVisualStyleBackColor = true;
            this.btnFontGrow.Click += new System.EventHandler(this.btnFontGrow_Click);
            // 
            // QuickHeaders_HeaderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 520);
            this.Controls.Add(this.btnMail);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnFontShrink);
            this.Controls.Add(this.btnFontGrow);
            this.Controls.Add(this.rtbHeaderContent);
            this.Name = "QuickHeaders_HeaderForm";
            this.Text = "Headers";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFontGrow;
        private System.Windows.Forms.Button btnFontShrink;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnMail;
        public System.Windows.Forms.RichTextBox rtbHeaderContent;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}