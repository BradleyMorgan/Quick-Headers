using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Office = Microsoft.Office.Core;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace QuickHeaders {
    public partial class QuickHeaders_HeaderForm : Form {
        public QuickHeaders_HeaderForm() {
            InitializeComponent();
        }

        private void btnFontGrow_Click(object sender, EventArgs e) {
            Font current = rtbHeaderContent.SelectionFont;

            rtbHeaderContent.Font = new Font(current.FontFamily, current.SizeInPoints + 1);
        }

        private void btnFontShrink_Click(object sender, EventArgs e) {
            Font current = rtbHeaderContent.SelectionFont;

            if (current.SizeInPoints > 1) {
                rtbHeaderContent.Font = new Font(current.FontFamily, Math.Abs(current.SizeInPoints - 1));
            }
        }

        private void btnMail_Click(object sender, EventArgs e) {
            Outlook.MailItem mailItem = (Outlook.MailItem)QuickHeaders.Globals.AddIn.Application.CreateItem(Outlook.OlItemType.olMailItem);

            foreach (string line in rtbHeaderContent.Lines) {

                if (line.Contains("Subject: ")) {

                    mailItem.Subject = "Headers: [" + line.Substring(line.IndexOf(": ") + 2).Trim() + "]";

                }

                mailItem.Body += line;

            }

            mailItem.Display(false);
        }

        private void btnSave_Click(object sender, EventArgs e) {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) {

                StreamWriter outStream = new StreamWriter(saveFileDialog1.OpenFile());

                foreach (string line in rtbHeaderContent.Lines) {

                    outStream.WriteLine(line);

                }

                outStream.Close();

            }

        }

    }

}
