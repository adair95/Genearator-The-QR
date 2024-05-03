using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QRCoder;

namespace QR
{
    class Program
    {
        private readonly string dato = "https://ajuba.co/";

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
            /*Descomentar la linea 35 y 39 si el QR lo quieres en formato jpeg y
            comentar las lineas 36 y 37 */
            SvgQRCode qrCode = new SvgQRCode(qr);
            //Bitmap qrCodeImage = qrCode.GetGraphic(20); //Convierte la Data en Imagen
            String qrCodeSvg = qrCode.GetGraphic(20);
            String ruta = "D:/QR/QR/QR/bin/Debug/Ejemplo.svg"; //Ruta donde se va almacenar el QR
            File.WriteAllText(ruta, qrCodeSvg);
            //qrCodeImage.Save("Short", System.Drawing.Imaging.ImageFormat.Jpeg); //Descomentar si desea guardar la Img en jpg
        } 
    }

    /*SvgQRCode: -> Úselo si desea imprimir el código QR en un tamaño enorme
     * o cuando trabaje con aplicaciones web escalables (en el sentido del tamaño de pantalla). 
     * El SvgQRCode devuelve un gráfico vectorial escalable que nunca se vuelve borroso por su naturaleza.*/
}
