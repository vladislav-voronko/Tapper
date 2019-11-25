using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
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
            //Вот почему здесь нельзя взять значение из текстового поля, а в текстовое поле по умолчанию установить вот это значение?
            //string oops = "4858450636189713423582095962494202044581400587983244549483093085061934704708809928450644769865524364849997247024915119110411605739177407856919754326571855442057210445735883681829823754139634338225199452191651284348332905131193199953502413758765239264874613394906870130562295813219481113685339535565290850023875092856892694555974281546386510730049106723058933586052544096664351265349363643957125565695936815184334857605266940161251266951421550539554519153785457525756590740540157929001765967965480064427829131488548259914721248506352686630476300";
            string oops = "2759209467180880234807239368961650563605658196838669877962142040837049674263670288381710105772409957017591588596512003761512678207572344644314272491066880585227824557264809884064396485626207608340483629155664507726622323561837438378701376891326796203812964845480194513751554826042981649293271233407463394830370526968147677950158224911051748141114671136518497152663814807860373249589248";
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
