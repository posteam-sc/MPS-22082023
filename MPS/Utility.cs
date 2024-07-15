using MBMS.DAL;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace MPS
{
    public class Utility
    {
        /// <summary>
        /// Decrypt the input string ( Eg: EncryptString("ABC", string.Empty); )  
        /// </summary>
        public static string EncryptString(string PlainText, string EncryptKey)
        {
            byte[] Results;
            UTF8Encoding UTF8 = new UTF8Encoding();
            // Step 1. We hash the passphrase using MD5
            // We use the MD5 hash generator as the result is a 128 bit byte array
            // which is a valid length for the TripleDES encoder we use below
            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(EncryptKey));
            // Step 2. Create a new TripleDESCryptoServiceProvider object
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();
            // Step 3. Setup the encoder
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;
            // Step 4. Convert the input string to a byte[]
            byte[] DataToEncrypt = UTF8.GetBytes(PlainText);
            // Step 5.Attempt to encrypt the string
            try
            {
                ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
                Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
            }
            finally
            {
                // Clear the TripleDes and Hashprovider services of any sensitive information
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }
            // Step 6. Return the encrypted string as a base64 encoded string
            return Convert.ToBase64String(Results);
        }


        /// <summary>
        /// Decrypt the input string ( Eg: DecryptString("LoBCnf0JCg8=", string.Empty); )  
        /// </summary>
        public static string DecryptString(string PlainText, string EncryptKey)
        {
            byte[] Results;
            UTF8Encoding UTF8 = new UTF8Encoding();
            // Step 1. We hash the passphrase using MD5
            // We use the MD5 hash generator as the result is a 128 bit byte array
            // which is a valid length for the TripleDES encoder we use below
            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(EncryptKey));
            // Step 2. Create a new TripleDESCryptoServiceProvider object
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();
            // Step 3. Setup the decoder
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;
            // Step 4. Convert the input string to a byte[]
            byte[] DataToDecrypt = Convert.FromBase64String(PlainText);
            // Step 5. Attempt to decrypt the string
            try
            {
                ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
                Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
            }
            finally
            {
                // Clear the TripleDes and Hashprovider services of any sensitive information
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }
            // Step 6. Return the decrypted string in UTF8 format
            return UTF8.GetString(Results);
        }
        public static void BindShop(ComboBox cboCompanyName, bool includeALL = false)
        {
            if (includeALL)
            {
                MBMSEntities entity = new MBMSEntities();
                List<CompanyProfile> companyProfileList = new List<CompanyProfile>();

                CompanyProfile companyProfile = new CompanyProfile();
                companyProfile.CompanyName = "ALL";
                companyProfile.CompanyProfileID = null;

                var companys = entity.CompanyProfiles.ToList();
                companyProfileList.Add(companyProfile);
                companyProfileList.AddRange(companys);
                cboCompanyName.DataSource = companyProfileList;
                cboCompanyName.DisplayMember = "CompanyName";
                cboCompanyName.ValueMember = "CompanyProfileID";

                cboCompanyName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cboCompanyName.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
            else
            {
                MBMSEntities entity = new MBMSEntities();
                List<CompanyProfile> companyProfileList = new List<CompanyProfile>();
                cboCompanyName.DataSource = companyProfileList;

                cboCompanyName.DisplayMember = "CompanyName";
                cboCompanyName.ValueMember = "CompanyProfileID";
                cboCompanyName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cboCompanyName.AutoCompleteSource = AutoCompleteSource.ListItems;
            }

        }
        public static class SettingController
        {
            public static CompanyProfile defaultCompanyProfile
            {
                get
                {
                    MBMSEntities mbmsentity = new MBMSEntities();
                    CompanyProfile companyProfile = mbmsentity.CompanyProfiles.Where(x => x.Active == true).FirstOrDefault();
                    return companyProfile;
                }
            }

            public static int DefaultNoOfCopies
            {
                get
                {
                    MBMSEntities mbmsEntities = new MBMSEntities();
                    Setting currentSet = mbmsEntities.Settings.FirstOrDefault(x => x.Key == "default_noOfCopies");
                    if (currentSet != null)
                    {
                        return Convert.ToInt32(currentSet.Value);
                    }

                    return 1;
                }
                set
                {
                    MBMSEntities mbmsEntities = new MBMSEntities();
                    Setting currentSet = mbmsEntities.Settings.FirstOrDefault(x => x.Key == "default_noOfCopies");
                    if (currentSet == null)
                    {
                        currentSet = new Setting();
                        currentSet.Key = "default_noOfCopies";
                        currentSet.Value = value.ToString();
                        mbmsEntities.Settings.Add(currentSet);
                    }
                    else
                    {
                        currentSet.Value = value.ToString();
                    }
                    mbmsEntities.SaveChanges();
                }
            }
            public static string CompanyName
            {
                get
                {
                    MBMSEntities mbmsEntities = new MBMSEntities();
                    Setting currentSet = mbmsEntities.Settings.FirstOrDefault(x => x.Key == "company_name");
                    if (currentSet != null)
                    {
                        return Convert.ToString(currentSet.Value);
                    }

                    return string.Empty;
                }
                set
                {
                    MBMSEntities mbmsEntities = new MBMSEntities();
                    Setting currentSet = mbmsEntities.Settings.FirstOrDefault(x => x.Key == "company_name");
                    if (currentSet == null)
                    {
                        currentSet = new Setting();
                        currentSet.Key = "company_name";
                        currentSet.Value = value.ToString();
                        mbmsEntities.Settings.Add(currentSet);
                    }
                    else
                    {
                        currentSet.Value = value.ToString();
                    }
                    mbmsEntities.SaveChanges();
                }
            }
            public static string PhoneNo
            {
                get
                {
                    MBMSEntities mbmsEntities = new MBMSEntities();
                    Setting currentSet = mbmsEntities.Settings.FirstOrDefault(x => x.Key == "phone_number");
                    if (currentSet != null)
                    {
                        return Convert.ToString(currentSet.Value);
                    }

                    return string.Empty;
                }
                set
                {
                    MBMSEntities mbmsEntities = new MBMSEntities();
                    Setting currentSet = mbmsEntities.Settings.FirstOrDefault(x => x.Key == "phone_number");
                    if (currentSet == null)
                    {
                        currentSet = new Setting();
                        currentSet.Key = "phone_number";
                        currentSet.Value = value.ToString();
                        mbmsEntities.Settings.Add(currentSet);
                    }
                    else
                    {
                        currentSet.Value = value.ToString();
                    }
                    mbmsEntities.SaveChanges();
                }
            }

            public static string CompanyEmail
            {
                get
                {
                    MBMSEntities mbmsEntities = new MBMSEntities();
                    Setting currentSet = mbmsEntities.Settings.FirstOrDefault(x => x.Key == "company_email");
                    if (currentSet != null)
                    {
                        return Convert.ToString(currentSet.Value);
                    }

                    return string.Empty;
                }
                set
                {
                    MBMSEntities mbmsEntities = new MBMSEntities();
                    Setting currentSet = mbmsEntities.Settings.FirstOrDefault(x => x.Key == "company_email");
                    if (currentSet == null)
                    {
                        currentSet = new Setting();
                        currentSet.Key = "company_email";
                        currentSet.Value = value.ToString();
                        mbmsEntities.Settings.Add(currentSet);
                    }
                    else
                    {
                        currentSet.Value = value.ToString();
                    }
                    mbmsEntities.SaveChanges();
                }
            }

            public static string CompanyWebsite
            {
                get
                {
                    MBMSEntities mbmsEntities = new MBMSEntities();
                    Setting currentSet = mbmsEntities.Settings.FirstOrDefault(x => x.Key == "company_website");
                    if (currentSet != null)
                    {
                        return Convert.ToString(currentSet.Value);
                    }

                    return string.Empty;
                }
                set
                {
                    MBMSEntities mbmsEntities = new MBMSEntities();
                    Setting currentSet = mbmsEntities.Settings.FirstOrDefault(x => x.Key == "company_website");
                    if (currentSet == null)
                    {
                        currentSet = new Setting();
                        currentSet.Key = "company_website";
                        currentSet.Value = value.ToString();
                        mbmsEntities.Settings.Add(currentSet);
                    }
                    else
                    {
                        currentSet.Value = value.ToString();
                    }
                    mbmsEntities.SaveChanges();
                }
            }

            public static string CompanyAddress
            {
                get
                {
                    MBMSEntities mbmsEntities = new MBMSEntities();
                    Setting currentSet = mbmsEntities.Settings.FirstOrDefault(x => x.Key == "company_address");
                    if (currentSet != null)
                    {
                        return Convert.ToString(currentSet.Value);
                    }

                    return string.Empty;
                }
                set
                {
                    MBMSEntities mbmsEntities = new MBMSEntities();
                    Setting currentSet = mbmsEntities.Settings.FirstOrDefault(x => x.Key == "company_address");
                    if (currentSet == null)
                    {
                        currentSet = new Setting();
                        currentSet.Key = "company_address";
                        currentSet.Value = value.ToString();
                        mbmsEntities.Settings.Add(currentSet);
                    }
                    else
                    {
                        currentSet.Value = value.ToString();
                    }
                    mbmsEntities.SaveChanges();
                }
            }
            public static string BranchCode
            {
                get
                {
                    MBMSEntities mbmsEntities = new MBMSEntities();
                    Setting currentSet = mbmsEntities.Settings.FirstOrDefault(x => x.Key == "branchCode");
                    if (currentSet != null)
                    {
                        return currentSet.Value;
                    }

                    return string.Empty;
                }
                set
                {
                    MBMSEntities mbmsEntities = new MBMSEntities();
                    Setting currentSet = mbmsEntities.Settings.FirstOrDefault(x => x.Key == "branchCode");
                    if (currentSet == null)
                    {
                        currentSet = new Setting();
                        currentSet.Key = "branchCode";
                        currentSet.Value = value.ToString();
                        mbmsEntities.Settings.Add(currentSet);
                    }
                    else
                    {
                        currentSet.Value = value.ToString();
                    }
                    mbmsEntities.SaveChanges();
                }
            }

            public static string Division
            {
                get
                {
                    MBMSEntities mbmsEntities = new MBMSEntities();
                    Setting currentSet = mbmsEntities.Settings.FirstOrDefault(x => x.Key == "division");
                    if (currentSet != null)
                    {
                        return currentSet.Value;
                    }

                    return string.Empty;
                }
                set
                {
                    MBMSEntities mbmsEntities = new MBMSEntities();
                    Setting currentSet = mbmsEntities.Settings.FirstOrDefault(x => x.Key == "division");
                    if (currentSet == null)
                    {
                        currentSet = new Setting();
                        currentSet.Key = "division";
                        currentSet.Value = value.ToString();
                        mbmsEntities.Settings.Add(currentSet);
                    }
                    else
                    {
                        currentSet.Value = value.ToString();
                    }
                    mbmsEntities.SaveChanges();
                }
            }

            public static string TownShip
            {
                get
                {
                    MBMSEntities mbmsEntities = new MBMSEntities();
                    Setting currentSet = mbmsEntities.Settings.FirstOrDefault(x => x.Key == "Township");
                    if (currentSet != null)
                    {
                        return Convert.ToString(currentSet.Value);
                    }

                    return string.Empty;
                }
                set
                {
                    MBMSEntities mbmsEntities = new MBMSEntities();
                    Setting currentSet = mbmsEntities.Settings.FirstOrDefault(x => x.Key == "townShip");
                    if (currentSet == null)
                    {
                        currentSet = new Setting();
                        currentSet.Key = "townShip";
                        currentSet.Value = value.ToString();
                        mbmsEntities.Settings.Add(currentSet);
                    }
                    else
                    {
                        currentSet.Value = value.ToString();
                    }
                    mbmsEntities.SaveChanges();
                }
            }
            public static int StreetLightFees
            {
                get
                {
                    MBMSEntities mbmsEntities = new MBMSEntities();
                    Setting currentSet = mbmsEntities.Settings.FirstOrDefault(x => x.Key == "StreetLightFees");
                    if (currentSet != null)
                    {
                        return Convert.ToInt32(currentSet.Value);
                    }

                    return 0;
                }
                set
                {
                    MBMSEntities mbmsEntities = new MBMSEntities();
                    Setting currentSet = mbmsEntities.Settings.FirstOrDefault(x => x.Key == "StreetLightFees");
                    if (currentSet == null)
                    {
                        currentSet = new Setting();
                        currentSet.Key = "StreetLightFees";
                        currentSet.Value = value.ToString();
                        mbmsEntities.Settings.Add(currentSet);
                    }
                    else
                    {
                        currentSet.Value = value.ToString();
                    }
                    mbmsEntities.SaveChanges();
                }
            }

            public static string DateFormat
            {
                get
                {
                    MBMSEntities mbmsEntities = new MBMSEntities();
                    Setting currentSet = mbmsEntities.Settings.FirstOrDefault(x => x.Key == "DateFormat");
                    if (currentSet != null)
                    {
                        return currentSet.Value;
                    }
                    return string.Empty;
                }
                set
                {
                    MBMSEntities mbmsEntities = new MBMSEntities();
                    Setting currentSet = mbmsEntities.Settings.FirstOrDefault(x => x.Key == "DateFormat");
                    if (currentSet == null)
                    {
                        currentSet = new Setting();
                        currentSet.Key = "DateFormat";
                        currentSet.Value = value.ToString();
                        mbmsEntities.Settings.Add(currentSet);
                    }
                    else
                    {
                        currentSet.Value = value.ToString();
                    }
                    mbmsEntities.SaveChanges();
                }
            }

        }//end of Setting Controller

        public static class DefaultPrinter
        {
            public static string A4Printer
            {
                get
                {
                    MBMSEntities mbmsEntities = new MBMSEntities();
                    Setting currentSet = mbmsEntities.Settings.FirstOrDefault(x => x.Key == "a4_printer");
                    if (currentSet != null)
                    {
                        return Convert.ToString(currentSet.Value);
                    }

                    return string.Empty;
                }
                set
                {
                    MBMSEntities mbmsEntities = new MBMSEntities();
                    Setting currentSet = mbmsEntities.Settings.FirstOrDefault(x => x.Key == "a4_printer");
                    if (currentSet == null)
                    {
                        currentSet = new Setting();
                        currentSet.Key = "a4_printer";
                        currentSet.Value = value.ToString();
                        mbmsEntities.Settings.Add(currentSet);
                    }
                    else
                    {
                        currentSet.Value = value.ToString();
                    }
                    mbmsEntities.SaveChanges();
                }
            }
        }//end of DefaultPrinter

        public static string GetDefaultPrinter()
        {
            string printer = DefaultPrinter.A4Printer;
            return printer;
        }
        #region PrintFunctions

        public static class PrintDoc
        {

            private static IList<Stream> m_streams;
            private static int m_currentPageIndex;
            private static bool isA5Size = false;
            private static bool isDotMatrix = false;

            #region Printing Functions

            private static void Print()
            {
                try
                {
                    if (m_streams == null || m_streams.Count == 0)
                        return;

                    PrintDocument printDoc = new PrintDocument();
                    printDoc.PrinterSettings.PrinterName = DefaultPrinter.A4Printer;

                    if (!printDoc.PrinterSettings.IsValid)
                    {
                        string msg = String.Format("Printing can't be processed!.Can't find printer \"{0}\".", DefaultPrinter.A4Printer);
                        System.Diagnostics.Debug.WriteLine(msg);
                        MessageBox.Show(msg, "Change Printer Setting", MessageBoxButtons.OK);
                        return;
                    }
                    printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
                    printDoc.Print();

                    printDoc.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

            public static void PrintReport(ReportViewer rv)
            {
                m_currentPageIndex = 0;
                m_streams = null;
                Export(rv.LocalReport);
                Print();
                //  Dispose();
                rv.LocalReport.ReleaseSandboxAppDomain();
            }

            /// <summary>
            /// 
            /// </summary>        
            /// <param name="Type">BarcodeStricker||Slip </param>
            public static void PrintReport(ReportViewer rv, String Type)
            {
                m_currentPageIndex = 0;
                m_streams = null;

                if (Type == "HP LaserJet Pro M404-M405")
                {
                    isA5Size = true;
                }
                else

                {
                    isDotMatrix = true;
                }
                //else if (Type == "A4 Printer")
                //{
                //    isA4Size = true;
                //}
                //else
                //{
                //    isSlipSize = true;
                //}

                Export(rv.LocalReport);

                Print();

                //  Dispose();
                rv.LocalReport.ReleaseSandboxAppDomain();
            }

            // Export the given report as an EMF (Enhanced Metafile) file.
            private static void Export(LocalReport report)
            {
                string deviceInfo = string.Empty;
                //    if (isStickerSize)
                //    {
                //        deviceInfo =
                //          @"<DeviceInfo>
                //    <OutputFormat>EMF</OutputFormat>
                //    <PageWidth>3in</PageWidth>                
                //    <MarginTop>0in</MarginTop>
                //    <MarginLeft>0in</MarginLeft>
                //    <MarginRight>0in</MarginRight>
                //    <MarginBottom>0in</MarginBottom>
                //    </DeviceInfo>";
                //    }
                //    else if (isSlipSize)
                //    {
                //        deviceInfo =
                //          @"<DeviceInfo>
                //    <OutputFormat>EMF</OutputFormat>
                //    <PageWidth>3.1in</PageWidth>                
                //    <MarginTop>0in</MarginTop>
                //    <MarginLeft>0in</MarginLeft>
                //    <MarginRight>0in</MarginRight>
                //    <MarginBottom>0in</MarginBottom>
                //</DeviceInfo>";
                //    }
                //    else
                //    {
                if (isA5Size)
                {
                    deviceInfo =
                      @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageWidth>8.3in</PageWidth>
                <PageHeight>5.8in</PageHeight>
                <MarginTop>0in</MarginTop>
                <MarginLeft>0in</MarginLeft>
                <MarginRight>0in</MarginRight>
                <MarginBottom>0in</MarginBottom>
            </DeviceInfo>";
                }
                else if (isDotMatrix)
                {
                    deviceInfo =
                     @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageWidth>5.8in</PageWidth>
                <PageHeight>8.3in</PageHeight>
                <MarginTop>0in</MarginTop>
                <MarginLeft>0in</MarginLeft>
                <MarginRight>0in</MarginRight>
                <MarginBottom>0in</MarginBottom>
            </DeviceInfo>";
                }else
                {
                    deviceInfo =
                     @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageWidth>8.3in</PageWidth>
                <PageHeight>5.8in</PageHeight>
                <MarginTop>0in</MarginTop>
                <MarginLeft>0in</MarginLeft>
                <MarginRight>0in</MarginRight>
                <MarginBottom>0in</MarginBottom>
            </DeviceInfo>";
                }
                //    }
                Warning[] warnings;
                m_streams = new List<Stream>();

                report.Refresh();
                var ps = report.GetParameters();

                report.Render("Image", deviceInfo, CreateStream, out warnings);

                foreach (Stream stream in m_streams)
                    stream.Position = 0;
            }

            private static void PrintPage(object sender, PrintPageEventArgs ev)
            {
                Metafile pageImage = new Metafile(m_streams[m_currentPageIndex]);
                ev.Graphics.DrawImage(pageImage, ev.PageBounds);
                m_currentPageIndex++;
                ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
            }

            private static Stream CreateStream(string name, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
            {
                Stream stream = new MemoryStream();
                m_streams.Add(stream);
                return stream;
            }

            #endregion
        }

        #endregion
        public static void Get_Print(ReportViewer rv)
        {
            int copy = Convert.ToInt32(SettingController.DefaultNoOfCopies);
            for (int i = 0; i < copy; i++)
            {
                PrintDoc.PrintReport(rv, GetDefaultPrinter());
            }
        }
    }
}
                                                      