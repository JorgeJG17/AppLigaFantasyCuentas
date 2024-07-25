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

namespace AppLigaFantasyCuentas
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        //Botón crear liga
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MenuALiga VentanaLiga = new MenuALiga();
            VentanaLiga.ShowDialog();
        }

        //Botón gestioar la liga
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //vamos por aqui, tenemos que crear una ventana donde podamos gestionar la liga, salgan todos los jugadores y su deinero,
            //y al principio salga las ligas
        }
    }
}
