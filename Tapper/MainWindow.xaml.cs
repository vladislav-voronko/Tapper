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
using static MathData.MathData;
using System.Numerics;

namespace Tapper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            string oops = "4858450636189713423582095962494202044581400587983244549483093085061934704708809928450644769865524364849997247024915119110411605739177407856919754326571855442057210445735883681829823754139634338225199452191651284348332905131193199953502413758765239264874613394906870130562295813219481113685339535565290850023875092856892694555974281546386510730049106723058933586052544096664351265349363643957125565695936815184334857605266940161251266951421550539554519153785457525756590740540157929001765967965480064427829131488548259914721248506352686630476300";
            BigInteger hella = BigInteger.Parse(oops);
            TestBox1.Text = $"{DecToBin(hella)}";
            DrawGraph(Canvas1, BinToGraph(DecToBin(hella)));
            //PutNewPointInCanvas(Canvas1, 10, 10);
        }
        private void PutNewPointInCanvas(Canvas canvas, int x, int y, int color)
        {
            var myPolygon = new Polygon();
            myPolygon.StrokeThickness = 5;
            if (color == 1) 
            myPolygon.Stroke = System.Windows.Media.Brushes.Black;
            else
                myPolygon.Stroke = System.Windows.Media.Brushes.White;
            myPolygon.Points = new PointCollection { new Point(x, y), new Point(x, y) };
            canvas.Children.Add(myPolygon);
        }
        public void DrawGraph(Canvas canvas, List<string> data)
        {
            char[] divData;
            int color1;
            int xParam = 0;
            int yParam = 0;
            for(var i = 0; i < data.Count; i++)
            {
                divData = data[i].ToCharArray(0, 17);
                for(var j = 16; j >= 0; j--)
                {
                    if (divData[j] == '1')
                        color1 = 1;
                    else color1 = 0;
                    PutNewPointInCanvas(Canvas1, xParam, yParam, color1);
                    yParam += 6;
                }
                xParam += 6;
                yParam = 0;
            }
        }
    }
}
