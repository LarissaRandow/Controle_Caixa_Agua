using System.Windows;

namespace Controle_Caixa_Agua
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void result(object sender, RoutedEventArgs e)
        {
            string valve = "Válvula Fechada";
            string pump = "Bomba Desligada";

            bool _s1 = s1.IsChecked.GetValueOrDefault();
            bool _s2 = s2.IsChecked.GetValueOrDefault();

            //Verifica se o sensor do topo está ativo e fundo inativo
            if (_s1 && !_s2)
            {
                output.Content = "Erro";
                return;
            }
            //Se o sensor do fundo está inativo a vávula deverá ser aberta
            else if (!_s2)
                valve = "Válvula Aberta";

            bool _s3 = s3.IsChecked.GetValueOrDefault();
            bool _s4 = s4.IsChecked.GetValueOrDefault();

            //Verifica se o sensor do topo está ativo e fundo inativo
            if (_s3 && !_s4)
            {
                output.Content = "Erro";
                return;
            }
            //Se o sensor do fundo está inativo E a C1 estiver com água a bomba deverá ser ligada
            else if (_s2 && !_s4)
                pump = "Bomba Ligada";

            output.Content = $"{valve}\n\n{pump}";
        }
    }
}
