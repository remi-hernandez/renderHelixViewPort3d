using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HelixToolkit.Wpf;
using System.IO;

namespace testHelix
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Create3DViewPort();
        }

        private void Create3DViewPort()
        {
            var hvp3d = new HelixViewport3D();
            Viewport3D vp3d = new Viewport3D();
            var lights = new DefaultLights();
            var tp = new Teapot();

            hvp3d.Children.Add(lights);
            hvp3d.Children.Add(tp);

            vp3d = hvp3d.Viewport;
            tata.Children.Add(vp3d); // comenter ca pour test

            /* MEGA TEST DE L'ESPACE SUBSAHARIEN */

            RenderTargetBitmap bmp = new RenderTargetBitmap(800, 800, 96, 96, PixelFormats.Pbgra32);
            var rect = new Rect(0, 0, 800, 800);
            vp3d.Measure(new Size(800, 800));
            vp3d.Arrange(rect);
            vp3d.InvalidateVisual();
            
            bmp.Render(vp3d);

            PngBitmapEncoder png = new PngBitmapEncoder();
            png.Frames.Add(BitmapFrame.Create(bmp));

            String filepath = "C:\\Users\\Remi\\Desktop\\canardmasque.png";
            using (Stream stm = File.Create(filepath))
            {
                png.Save(stm);
            }
        }
    }
}
