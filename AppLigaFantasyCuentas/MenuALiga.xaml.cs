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
using System.Data;
using System.Data.SQLite;
using System.Configuration;
using System.Data.SqlClient;

namespace AppLigaFantasyCuentas
{
    public partial class MenuALiga : Window
    {
        private SQLiteConnection miConexionSql;
        private String nombreLiga;
        private int numeroUsuarios;
        private decimal dineroPrincipal;

        public MenuALiga()
        {
            InitializeComponent();

            ConexionBD vConexion = new ConexionBD();
            miConexionSql = vConexion.ObtenerConexion();
        }

        //Botón Siguiente
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            nombreLiga = nombreLigaText.Text;
            numeroUsuarios = int.Parse(numeroUsuariosText.Text);

            string[] nombresUsuarios = new string[numeroUsuarios];

            for(int i=0; i<numeroUsuarios; i++)
            {
                MenuAUsuario ventanaUsuario = new MenuAUsuario();
                ventanaUsuario.ShowDialog();
                nombresUsuarios[i] = ventanaUsuario.ConseguirNombreU(); //Almacenar nombres usuario
            }

            //Insertar Liga
            string consulta = "INSERT INTO LIGAS (Nombre) VALUES (@Nombre)";
            SQLiteCommand miSqlCommand = new SQLiteCommand(consulta, miConexionSql);
            miConexionSql.Open();

            miSqlCommand.Parameters.AddWithValue("@Nombre", nombreLiga);

            miSqlCommand.ExecuteNonQuery();

            //Selecionar id de la Liga insertada anteriormente
            string consulta2 = "SELECT Id FROM LIGAS WHERE Nombre = @Nombre";
            SQLiteCommand miSqlCommand2 = new SQLiteCommand(consulta2, miConexionSql);

            miSqlCommand2.Parameters.AddWithValue("@Nombre", nombreLiga);

            DataTable idLiga = new DataTable();
            SQLiteDataAdapter miAdaptadorSql = new SQLiteDataAdapter(miSqlCommand2);
            miAdaptadorSql.Fill(idLiga); //Almacenamos ese id

            //Insertar todos los nombres pertenecientes a la Liga creada
            string consulta3 = "INSERT INTO USUARIOS (Nombre, IdLiga) VALUES (@Nombre, @IdLiga)";
            SQLiteCommand miSqlCommand3 = new SQLiteCommand(consulta3, miConexionSql);

            for (int i=0; i<numeroUsuarios; i++)
            {
                miSqlCommand3.Parameters.AddWithValue("@Nombre", nombresUsuarios[i]);
                miSqlCommand3.Parameters.AddWithValue("@IdLiga", Convert.ToInt32(idLiga.Rows[0]["Id"]));

                miSqlCommand3.ExecuteNonQuery();
            }

            MessageBox.Show("Liga creada correctamente!!");

            DineroInicial ventanaDinero = new DineroInicial();
            ventanaDinero.ShowDialog();
            dineroPrincipal = ventanaDinero.PedirDinero();

            string consulta4 = "UPDATE USUARIOS SET Dinero = @Dinero WHERE IdLiga = @IdLiga";
            SQLiteCommand miSqlCommand4 = new SQLiteCommand(consulta4, miConexionSql);

            miSqlCommand4.Parameters.AddWithValue("@IdLiga", Convert.ToInt32(idLiga.Rows[0]["Id"]));
            miSqlCommand4.Parameters.AddWithValue("@Dinero", dineroPrincipal);

            miSqlCommand4.ExecuteNonQuery();

            miConexionSql.Close(); //Cerramos conexion
            Close(); //cerramos la ventana

            

        }
    }
}
