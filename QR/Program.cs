using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QRCoder;

namespace QR
{
    class Program
    {
        private string dato = "Aqui viene la URL del sitio o pagina a visitar";

        static void Main(string[] args)
        {
            Program qr = new Program();
            qr.GeneratorQR();
        }
        private void GeneratorQR()
        {
            QRCodeGenerator codeGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = codeGenerator.CreateQrCode(dato, QRCodeGenerator.ECCLevel.Q);

            GetImgQrCode(qrCodeData);
        }

        private  void GetImgQrCode(QRCodeData qr)
        {

            QRCode qrCode = new QRCode(qr);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);

            qrCodeImage.Save("QR Code", System.Drawing.Imaging.ImageFormat.Png);
        } 
    }
}
