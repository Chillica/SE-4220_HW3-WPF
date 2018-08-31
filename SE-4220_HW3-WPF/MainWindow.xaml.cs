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

        public MainWindow()
        {
            InitializeComponent();
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
            /*
            matrix[btn00] = new List<Button> { btn01, btn11, btn10 };
            matrix[btn01] = new List<Button> { btn00, btn10, btn11, btn12, btn02 };
            matrix[btn02] = new List<Button> { btn01, btn13, btn11, btn12, btn03 };
            matrix[btn03] = new List<Button> { btn04, btn14, btn13, btn12, btn02 };
            matrix[btn04] = new List<Button> { btn03, btn13, btn14 };
            matrix[btn10] = new List<Button> { btn00, btn01, btn11, btn21, btn20 };
            matrix[btn11] = new List<Button> { btn00, btn01, btn02, btn12, btn22, btn21, btn20, btn10 };
            matrix[btn12] = new List<Button> { btn01, btn11, btn21, btn22, btn23, btn13, btn03, btn02 };
            matrix[btn13] = new List<Button> { btn02, btn12, btn22, btn23, btn24, btn14, btn04, btn03 };
            matrix[btn14] = new List<Button> { btn04, btn03, btn13, btn23, btn24 };
            matrix[btn20] = new List<Button> { btn10, btn11, btn21,btn21, btn31, btn30 };
            matrix[btn21] = new List<Button> { btn10, btn11, btn12, btn22, btn32, btn31, btn30, btn20 };
            matrix[btn22] = new List<Button> { btn11, btn12, btn13, btn23, btn33, btn32, btn31, btn21 };
            matrix[btn23] = new List<Button> { btn12, btn13, btn14, btn24, btn34, btn33, btn32, btn22 };
            matrix[btn24] = new List<Button> { btn14, btn13, btn23, btn33, btn34 };
            matrix[btn30] = new List<Button> { btn20, btn21, btn31, btn41, btn40 };
            matrix[btn31] = new List<Button> { btn20, btn21, btn22, btn32 };
            matrix[btn32] = new List<Button> { btn21, btn22, btn23, btn33, btn43, btn42, btn41, btn31 };
            matrix[btn33] = new List<Button> { btn22, btn23, btn24, btn34, btn44, btn43, btn42, btn32 };
            matrix[btn34] = new List<Button> { btn24, btn23, btn33, btn43, btn44 };
            matrix[btn40] = new List<Button> { btn30, btn31, btn41 };
            matrix[btn41] = new List<Button> { btn40, btn30, btn31, btn32, btn42 };
            matrix[btn42] = new List<Button> { btn41, btn31, btn32, btn33, btn43 };
            matrix[btn43] = new List<Button> { btn42, btn32, btn33, btn34, btn44 };
            matrix[btn44] = new List<Button> { btn42, btn33, btn34 };
             */
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = e.OriginalSource as Button;

            foreach(KeyValuePair<Button,List<Button>> key in matrix)
            {
                if (btn.Name == key.Key.Name)
                {
                    btn_toggle(key);
                    return;
                }
            }
        }

        private void btn_toggle(KeyValuePair<Button, List<Button>> button)
        {
            toggle(button.Key);
            for (int i = 0; i < button.Value.Count; i++)
                toggle(button.Value.ElementAt(i));
        }

        private void toggle(Button button)
        {
            if (button.Background == System.Windows.Media.Brushes.White)
                button.Background = System.Windows.Media.Brushes.Black;
            else
                button.Background = System.Windows.Media.Brushes.White;
        }

        private void reset(object sender, RoutedEventArgs e)
        {
            foreach (KeyValuePair<Button, List<Button>> key in matrix)
            {
                key.Key.Background = System.Windows.Media.Brushes.White;
                for (int i = 0; i < key.Value.Count; i++)
                    key.Value.ElementAt(i).Background = System.Windows.Media.Brushes.White;
            }
        }
    }
}
