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
using System.Windows.Shapes;

namespace AppLigaFantasyCuentas
{
    public partial class MenuAUsuario : Window
    {
        private String nombre;
        public MenuAUsuario()
        {
            InitializeComponent();
        }

        public string ConseguirNombreU()
        {
            return nombre;
        }

        //Boton Añadir
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            nombre = nombreUsuario.Text;

            Close();
        }
    }
}
