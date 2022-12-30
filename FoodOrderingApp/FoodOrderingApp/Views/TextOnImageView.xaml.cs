extern alias Drawing1;
using System;
using System.Collections.Generic;
using System.Drawing;
using Drawing1.System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodOrderingApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TextOnImageView : ContentView
    {
        private string savedFilename;
        public TextOnImageView()
        {
            InitializeComponent();
            CreateImage("world");
            image.Source = "number.png";
        }

        private void CreateImage(string text)
        {
            //creating a image object   
            string filename = System.IO.Path.Combine(
                System.Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                "white.png"
            );
            Drawing1::System.Drawing.Image bitmap = (Drawing1::System.Drawing.Image) Drawing1::System.Drawing.Bitmap.FromFile(filename); // set image    
                                                                                                                                         //draw the image object using a Graphics object   
            Drawing1::System.Drawing.Graphics graphicsImage = Drawing1::System.Drawing.Graphics.FromImage(bitmap);

            //Set the alignment based on the coordinates      
            Drawing1::System.Drawing.StringFormat stringformat = new Drawing1::System.Drawing.StringFormat();
            stringformat.Alignment = Drawing1::System.Drawing.StringAlignment.Far;
            stringformat.LineAlignment = Drawing1::System.Drawing.StringAlignment.Far;

            //Set the font color/format/size etc..     
            //System.Drawing.Color StringColor = Drawing1::System.Drawing.ColorTranslator.FromHtml("#933eea");//direct color adding
            Drawing1::System.Drawing.Color StringColor = Drawing1::System.Drawing.Color.FromArgb(0x93, 0x33, 0xEA);//direct color adding   

            graphicsImage.DrawString(text, new Drawing1::System.Drawing.Font("arial", 40,
            Drawing1::System.Drawing.FontStyle.Regular), new Drawing1::System.Drawing.SolidBrush(StringColor), new Drawing1::System.Drawing.Point(268, 245),
            stringformat);
            //Response.ContentType = "image/jpeg";

            //savedFilename = System.IO.Path.Combine(
            //    System.Environment.GetFolderPath(Environment.SpecialFolder.Personal),
            //    "number.png"
            //);
            bitmap.Save("number.png");
        }
    }
}