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

namespace SE_4220_HW3_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// https://stackoverflow.com/questions/33439604/how-do-i-represent-a-graph-given-as-an-adjacency-list-in-c
    public partial class MainWindow : Window
    {
        private Dictionary<Button, List<Button>> matrix = new Dictionary<Button, List<Button>>();
        private int count = 0;

        public MainWindow()
        {
            InitializeComponent();

            // Adjacency List for the buttons
            matrix[btn00] = new List<Button> { btn01, btn10 };
            matrix[btn01] = new List<Button> { btn00, btn11, btn02 };
            matrix[btn02] = new List<Button> { btn01, btn12, btn03 };
            matrix[btn03] = new List<Button> { btn04, btn13, btn02 };
            matrix[btn04] = new List<Button> { btn03, btn14 };
            matrix[btn10] = new List<Button> { btn00, btn11, btn20 };
            matrix[btn11] = new List<Button> { btn01, btn21, btn12, btn10 };
            matrix[btn12] = new List<Button> { btn11, btn22, btn13, btn02 };
            matrix[btn13] = new List<Button> { btn12, btn23, btn14, btn03 };
            matrix[btn14] = new List<Button> { btn04, btn13, btn24 };
            matrix[btn20] = new List<Button> { btn10, btn21, btn30 };
            matrix[btn21] = new List<Button> { btn11, btn22, btn31, btn20 };
            matrix[btn22] = new List<Button> { btn12, btn23, btn32, btn21 };
            matrix[btn23] = new List<Button> { btn13, btn24, btn33, btn22 };
            matrix[btn24] = new List<Button> { btn14, btn23, btn34 };
            matrix[btn30] = new List<Button> { btn20, btn31, btn40 };
            matrix[btn31] = new List<Button> { btn30, btn21, btn32, btn41 };
            matrix[btn32] = new List<Button> { btn22, btn33, btn42, btn31 };
            matrix[btn33] = new List<Button> { btn23, btn34, btn43, btn32 };
            matrix[btn34] = new List<Button> { btn24, btn33, btn44 };
            matrix[btn40] = new List<Button> { btn30, btn41 };
            matrix[btn41] = new List<Button> { btn40, btn31, btn42 };
            matrix[btn42] = new List<Button> { btn41, btn32, btn43 };
            matrix[btn43] = new List<Button> { btn42, btn33, btn44 };
            matrix[btn44] = new List<Button> { btn43, btn34 };
        }

        // Button click event for the game buttons
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = e.OriginalSource as Button;
            count += 1;
            Count.Text = count.ToString();

            foreach (KeyValuePair<Button,List<Button>> button in matrix)
            {
                if (btn.Name == button.Key.Name)
                {
                    toggle(button.Key);
                    for (int i = 0; i < button.Value.Count; i++)
                        toggle(button.Value.ElementAt(i));
                    return;
                }
            }
        }

        // Toggles the game buttons
        private void toggle(Button button)
        {
            if (button.Background == System.Windows.Media.Brushes.White)
                button.Background = System.Windows.Media.Brushes.Black;
            else
                button.Background = System.Windows.Media.Brushes.White;
        }

        // Resets the game to a blank canvas
        private void reset(object sender, RoutedEventArgs e)
        {
            int val = 0;
            Count.Text = val.ToString();
            foreach (KeyValuePair<Button, List<Button>> key in matrix)
            {
                key.Key.Background = System.Windows.Media.Brushes.White;
                for (int i = 0; i < key.Value.Count; i++)
                    key.Value.ElementAt(i).Background = System.Windows.Media.Brushes.White;
            }
        }

        private void addShape(object sender, RoutedEventArgs e)
        {
            byte[] array = new byte[3];
            Random r = new Random();
            r.NextBytes(array); //for ints

            Ellipse ellipse = new Ellipse();
            SolidColorBrush colorBrush = new SolidColorBrush();
            colorBrush.Color = Color.FromArgb(array[0], array[1], array[2], 0);
            if (colorBrush == System.Windows.Media.Brushes.White)
                colorBrush = System.Windows.Media.Brushes.Black;
            ellipse.Fill = colorBrush;
            ellipse.Height = r.Next(0, 100);
            ellipse.Width = r.Next(0, 100);
            shapePanel.Children.Add(ellipse);
        }

        private void imgDockLeft(object sender, RoutedEventArgs e)
        {
            Thickness margin = imgDock.Margin;
            margin.Right += 10;
            margin.Left -= 10;
            imgDock.Margin = margin;
        }

        private void imgDockRight(object sender, RoutedEventArgs e)
        {
            Thickness margin = imgDock.Margin;
            margin.Left += 10;
            margin.Right -= 10;
            imgDock.Margin = margin;
        }
    }
}
