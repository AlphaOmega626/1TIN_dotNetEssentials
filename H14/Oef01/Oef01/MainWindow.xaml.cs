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

namespace Oef01
{
    public partial class MainWindow : Window
    {
        private String[] players = { "Computer", "User" };
        private int[] lucifers = new int[3];
        private String currentUser;
        public MainWindow()
        {
            InitializeComponent();
            FillLucifers();
            DrawLucifers();
            PickPlayer();
        }

        private void FillLucifers()
        {
            Random random = new Random();
            lucifers[0] = random.Next(1, 20);
            lucifers[1] = random.Next(1, 20);
            lucifers[2] = random.Next(1, 20);
        }

        private void PickPlayer()
        {
            Random random = new Random();
            currentUser = players[random.Next(0, 2)];
            currentPlayerLabel.Content = currentUser;
            if (currentUser.Equals("Computer"))
            {
                ComputerPlay();
            }
        }

        private void ComputerPlay()
        {
            stackCanvas1.IsEnabled = false;
            stackCanvas2.IsEnabled = false;
            stackCanvas2.IsEnabled = false;
            Canvas[] canvasArray = new Canvas[3];
            canvasArray[0] = stackCanvas1;
            canvasArray[1] = stackCanvas2;
            canvasArray[2] = stackCanvas3;
            Random random = new Random();
            Canvas tempCanvas = canvasArray[random.Next(0, 3)];
            tempCanvas.Children.Remove(tempCanvas.Children[random.Next(0, lucifers.Length)]);
            currentPlayerLabel.Content = players[1];
        }

        private void DrawLucifers()
        {
            for (int i = 0; i < lucifers.Length; i++)
            {
                for (int j = 1; j < lucifers[i] - 1; j++)
                {
                    Random random = new Random();
                    Line lucifer = new Line();
                    lucifer.MouseDown += lucifer_MouseDown;
                    lucifer.StrokeThickness = 10;
                    lucifer.Name = String.Format("lucifer{0}", j);
                    lucifer.Stroke = new SolidColorBrush(Colors.Black);
                    lucifer.X1 = 10;
                    lucifer.X2 = 200;
                    lucifer.Y1 = j * 15;
                    lucifer.Y2 = j * 15;
                    switch (i)
                    {
                        case 0:
                            stackCanvas1.Children.Add(lucifer);
                            break;
                        case 1:
                            stackCanvas2.Children.Add(lucifer);
                            break;
                        case 2:
                            stackCanvas3.Children.Add(lucifer);
                            break;
                    }
                }
            }

        }

        private void CheckChildren(Canvas canvas)
        {
            if (canvas.Children.Count == 0)
            {
                if (currentUser.Equals("Computer"))
                {
                    currentPlayerLabel.Content = String.Format("Proficiat, jij hebt stapel {0} gewonnen",canvas.Name.Substring(canvas.Name.Length - 1,1));
                }
                else
                {
                    currentPlayerLabel.Content = String.Format("De computer heeft stapel {0} gewonnen", canvas.Name.Substring(canvas.Name.Length - 1, 1));
                }
            }
        }

        void lucifer_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Line lucifer = (Line)sender;
            Canvas parentCanvas = (Canvas)VisualTreeHelper.GetParent(lucifer);
            parentCanvas.Children.Remove(lucifer);
            CheckChildren(parentCanvas);
            ComputerPlay();
        }
    }
}
