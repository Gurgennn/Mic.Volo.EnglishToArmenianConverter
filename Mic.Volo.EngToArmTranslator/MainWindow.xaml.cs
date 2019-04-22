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
using System.Globalization;

namespace Mic.Volo.EngToArmTranslator
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

        private string ConvertText(string input)
        {
            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add("a", "ա");
            map.Add("b", "բ");
            map.Add("g", "գ");
            map.Add("d", "դ");
            map.Add("e", "ե");
            map.Add("z", "զ");
            map.Add("@", "ը");
            map.Add("th", "թ");
            map.Add("i", "ի");
            map.Add("l", "լ");
            map.Add("kh", "խ");
            map.Add("ts", "ծ");
            map.Add("k", "կ");
            map.Add("h", "հ");
            map.Add("dz", "ձ");
            map.Add("gh", "ղ");
            map.Add("tsh", "ճ");
            map.Add("m", "մ");
            map.Add("y", "յ");
            map.Add("n", "ն");
            map.Add("sh", "շ");
            map.Add("o", "ո");
            map.Add("ch", "չ");
            map.Add("p", "պ");
            map.Add("j", "ջ");
            map.Add("s", "ս");
            map.Add("v", "վ");
            map.Add("t", "տ");
            map.Add("r", "ր");
            map.Add("c", "ց");
            map.Add("u", "ու");
            map.Add("ph", "փ");
            map.Add("q", "ք");
            map.Add("ev", "և");
            map.Add("f", "ֆ");
            map.Add("vo", "ո");
            map.Add(" ", " ");
            map.Add(":", ":");
            map.Add(",", ",");


            string output = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                if (input.Length > 0 && input[i] == 'z' && input[i - 1] == 'd')
                {
                    output = output.Substring(0, i - 1);
                    output += map["dz"];
                }
                else if (input.Length > 0 && input[i] == 'o' && input[i - 1] == 'v')
                {
                    output = output.Substring(0, i - 1);
                    output += map["vo"];
                }
                else if (input.Length > 0 && input[i] == 'h' && input[i - 1] == 'c')
                {
                    output = output.Substring(0, i - 1);
                    output += map["ch"];
                }
                else
                {
                    if (map.ContainsKey(input[i].ToString()))
                    {
                        output += map[txtInput.Text[i].ToString()];
                    }
                    else
                    {
                        output += input[i];
                    }
                }
            }

            return output;
        }

        private void TxtInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            string output = ConvertText(txtInput.Text);

            txtOutput.Text = output;
        }
    }
}
