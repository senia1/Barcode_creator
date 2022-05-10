using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.Rendering;
using ZXing.QrCode;
using ZXing.Common;

namespace Barcode_creator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDown;
        }

        public static Image CreateCode(string text, int w, int h, BarcodeFormat format) 
        {
            try
            {
                BarcodeWriter writer = new BarcodeWriter
                {
                    Format = format,
                    Options = new QrCodeEncodingOptions
                    {
                        Width = w,
                        Height = h,
                        CharacterSet = "UTF-8"
                    },
                    Renderer = new BitmapRenderer()
                };
                return writer.Write(text);
            }
            catch (Exception)
            {

                throw;
            }

            return null;

        }
        public static string[] CodeScan(Bitmap bmp)
        {
            try
            {
                BarcodeReader reader = new BarcodeReader
                {
                    AutoRotate = true,
                    TryInverted = true,
                    Options = new DecodingOptions
                    {
                        TryHarder = true
                    }
                };
                Result[] results = reader.DecodeMultiple(bmp);
                if (results != null)
                    return results.Where(x => x != null && !string.IsNullOrEmpty(x.Text)).Select(x => x.Text).ToArray();
            }
            catch (Exception)
            {

                throw;
            }
            return null;
        }
        public static string DecodeImage(Image img)
        {
            string outString = "";
            string[] results = CodeScan((Bitmap)img);
            if (results != null)
                outString = string.Join(Environment.NewLine + Environment.NewLine, results);
            return outString;
        }
        private BarcodeFormat GetFormat() 
        {
            switch (comboBox1.Text)
            {
                case "CODEBAR": return BarcodeFormat.CODABAR;
                case "CODE_39": return BarcodeFormat.CODE_39;
                case "CODE_93": return BarcodeFormat.CODE_93;
                case "CODE_128": return BarcodeFormat.CODE_128;
                case "QR_CODE": return BarcodeFormat.QR_CODE;
                case "MSI": return BarcodeFormat.MSI;
                case "DATA_MATRIX": return BarcodeFormat.DATA_MATRIX;
                default: return BarcodeFormat.CODABAR;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
