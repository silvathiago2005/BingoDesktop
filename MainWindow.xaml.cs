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

namespace BingoGame
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        int primeiro = 0;
        List<int> numerosParaSortear = new List<int>();
        List<int> numerosSorteados = new List<int>();
        private Button[] botoes;

        public MainWindow()
        {
            InitializeComponent();
            bingo.IsEnabled = false;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            botoes = new Button[] { button1, button2, button3, button4, button5, button6, button7, button8, button9, button10, button11, button12, button13, button14,
                                    button15, button16, button17, button18, button19, button20, button21, button22, button23, button24, button25, button26, button27,
                                    button28, button29, button30, button31, button32, button33, button34, button35, button36, button37, button38, button39, button40,
                                    button41, button42, button43, button44, button45, button46, button47, button48, button49, button50, button51, button52, button53,
                                    button54, button55, button56, button57, button58, button59, button60, button61, button62, button63, button64, button65, button66,
                                    button67, button68, button69, button70, button71, button72, button73, button74, button75
                                    };
            if (primeiro == 0)
            {
                List<int> retorno = PreencherNumeros();
                retorno.Remove(0);
                numerosParaSortear = retorno;
                primeiro++;
                bingo.IsEnabled = true;
            }

            Random rand = new Random(DateTime.Now.Millisecond);
            int resultado = numerosParaSortear[rand.Next(numerosParaSortear.Count)];
            numerosSorteados.Add(resultado);
            numerosParaSortear.Remove(resultado);
            

            if (resultado != 0)
            {
                botoes[resultado - 1].Background = Brushes.Red;

                if (resultado < 16)
                {
                    MessageBox.Show($"B " + resultado);
                }
                else if (resultado > 16 && resultado < 31)
                {
                    MessageBox.Show($"I " + resultado);
                }
                else if (resultado > 31 && resultado < 46)
                {
                    MessageBox.Show($"N " + resultado);
                }
                else if (resultado > 46 && resultado < 61)
                {
                    MessageBox.Show($"G " + resultado);
                }
                else
                {
                    MessageBox.Show($"O " + resultado);
                }
            }
        }

        public List<int> PreencherNumeros()
        {
            List<int> numerosParaSortear = new List<int>();

            for (int i = 0; i < 76; i++)
            {
                numerosParaSortear.Add(i);
            }

            return numerosParaSortear;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var numerosFaltantes in numerosParaSortear)
            {
                MessageBox.Show(numerosFaltantes.ToString());
            }

            foreach (var numerosALimpar in numerosSorteados)
            {
                botoes[numerosALimpar-1].Background = Brushes.LightGray;
            }

            numerosParaSortear.Clear();
            numerosSorteados.Clear();

            bingo.IsEnabled = false;
        }
    }
}
