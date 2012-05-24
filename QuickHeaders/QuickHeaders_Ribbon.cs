using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Office = Microsoft.Office.Core;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.Drawing;
using System.Windows.Forms;

// TODO:  Follow these steps to enable the Ribbon (XML) item:

// 1: Copy the following code block into the ThisAddin, ThisWorkbook, or ThisDocument class.

//  protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
//  {
//      return new QuickHeaders_Ribbon();
//  }

// 2. Create callback methods in the "Ribbon Callbacks" region of this class to handle user
//    actions, such as clicking a button. Note: if you have exported this Ribbon from the Ribbon designer,
//    move your code from the event handlers to the callback methods and modify the code to work with the
//    Ribbon extensibility (RibbonX) programming model.

// 3. Assign attributes to the control tags in the Ribbon XML file to identify the appropriate callback methods in your code.  

// For more information, see the Ribbon XML documentation in the Visual Studio Tools for Office Help.


namespace QuickHeaders {

    internal class PictureConverter : AxHost {
        private PictureConverter() : base(String.Empty) { }

        static public stdole.IPictureDisp ImageToPictureDisp(Image image) {
            return (stdole.IPictureDisp)GetIPictureDispFromPicture(image);
        }

        static public stdole.IPictureDisp IconToPictureDisp(Icon icon) {
            return ImageToPictureDisp(icon.ToBitmap());
        }

        static public stdole.IPictureDisp BitmapToPictureDisp(Bitmap icon) {
            return ImageToPictureDisp(icon);
        }

        static public Image PictureDispToImage(stdole.IPictureDisp picture) {
            return GetPictureFromIPicture(picture);
        }
    }

    [ComVisible(true)]
    public class QuickHeaders_Ribbon : Office.IRibbonExtensibility {
        
        private Office.IRibbonUI ribbon;

        public QuickHeaders_Ribbon() { }

        #region IRibbonExtensibility Members

        public string GetCustomUI(string ribbonID) {
            return GetResourceText("QuickHeaders.QuickHeaders_Ribbon.xml");
        }

        #endregion

        #region Ribbon Callbacks
        //Create callback methods here. For more information about adding callback methods, select the Ribbon XML item in Solution Explorer and then press F1

        public void Ribbon_Load(Office.IRibbonUI ribbonUI) {
            this.ribbon = ribbonUI;
        }

        #endregion

        #region Helpers

        private static string GetResourceText(string resourceName) {
            Assembly asm = Assembly.GetExecutingAssembly();
            string[] resourceNames = asm.GetManifestResourceNames();
            for (int i = 0; i < resourceNames.Length; ++i) {
                if (string.Compare(resourceName, resourceNames[i], StringComparison.OrdinalIgnoreCase) == 0) {
                    using (StreamReader resourceReader = new StreamReader(asm.GetManifestResourceStream(resourceNames[i]))) {
                        if (resourceReader != null) {
                            return resourceReader.ReadToEnd();
                        }
                    }
                }
            }
            return null;
        }

        #endregion

        public void contextMenuShowHeaders(Office.IRibbonControl control) {

            string SchemaTransportHeader = @"http://schemas.microsoft.com/mapi/proptag/0x007D001E";

            var item = control.Context as Outlook.Selection;
            var mailItem = item[1] as Outlook.MailItem;

            Outlook.PropertyAccessor oPA = mailItem.PropertyAccessor;

            string Transport = (string)oPA.GetProperty(SchemaTransportHeader);
            string FormattedTransport = @"{\rtf1\ansi ";

            string[] TransportLines = System.Text.RegularExpressions.Regex.Split(Transport, "\r\n");

            QuickHeaders.QuickHeaders_HeaderForm headersWin = new QuickHeaders_HeaderForm();

            foreach (string TransportLine in TransportLines) {

                string name = "";
                string value = "";

                try {

                    if (TransportLine.Contains(": ")) {
                        name = TransportLine.Substring(0, TransportLine.IndexOf(':'));
                        value = TransportLine.Substring(TransportLine.IndexOf(':'));
                    } else {
                        name = "\\t";
                        value = TransportLine;
                    }

                } catch {

                }

                FormattedTransport += String.Format("\\line \\b {0}\\b0{1} ", name, value);
            }

            FormattedTransport += "}";

            headersWin.rtbHeaderContent.Rtf = FormattedTransport;

            headersWin.Show();

        }

        public stdole.IPictureDisp GetImage(string imageName) {

            Assembly myAssembly = Assembly.GetExecutingAssembly();

            Stream myStream = myAssembly.GetManifestResourceStream(imageName);
            Bitmap bmp = new Bitmap(myStream);

            return PictureConverter.BitmapToPictureDisp(bmp);

        }

    }

}
