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
using DAL;
using BLL;
namespace Registro
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        InscripcionBLL ibll = new InscripcionBLL();
        public MainWindow()
        {
            InitializeComponent();
            cmbRecorrido.ItemsSource = Enum.GetValues(typeof(Recorrido));
            //cmbClasificacion.SelectedIndex = 3;
            cmbCategoria.ItemsSource = Enum.GetValues(typeof(Categoria));
            DateTime Hoy = DateTime.Today;
            DpFecha.SelectedDate = Hoy;
        }
        int iK2 = 1;
        int iK4 = 1;
        int iK8 = 1;
        private void BtnInscribir_Click(object sender, RoutedEventArgs e)
        {
            Inscripcion nueva = new Inscripcion();
            nueva.Recorrido = (Recorrido)cmbRecorrido.SelectedValue;
            nueva.Categoria = (Categoria)cmbCategoria.SelectedValue;
            double valor = 0;
            double desc = 0;
            string id = "";
            string identificador = "";
            string s = "";
            if (cmbRecorrido.SelectedValue.ToString() == "K2")
            { 
                s = iK2.ToString().PadLeft(2, '0'); 
                valor = 10000;
                id = "K2";
                iK2++;
            }
            else if (cmbRecorrido.SelectedValue.ToString() == "K4")
            {
                valor = 15000;
                id = "K4";
                s = iK4.ToString().PadLeft(2, '0');
                iK4++;
            }
            else
            {
                valor = 20000;
                id = "K8";
                s = iK8.ToString().PadLeft(2, '0');
                iK8++;
            }
            if (cmbCategoria.SelectedValue.ToString() == "infantil")
            {
                desc = 0.25;
            }
            else if (cmbCategoria.SelectedValue.ToString() == "amateur")
            {
                desc = 0.50;
            }
            else
            {
                desc = 1;
            }
            valor = valor * desc;
            nueva.Valor = valor;
            identificador = id + "-" + s;
            nueva.Identificador = identificador;
            nueva.FechaInscripcion = (DateTime)DpFecha.SelectedDate;
            if (txtNombre.Text.Length < 1)
            {
                MessageBox.Show("Error, El nombre no puede estar Vacio");
            }
            else
            {
            nueva.Nombre = txtNombre.Text.Trim();
            }

            if (Enumerable.Range(0,99).Contains(int.Parse(txtEdad.Text)))
            {
                nueva.Edad = int.Parse(txtEdad.Text);
            }
            else
            {
                MessageBox.Show("Error, la edad debe ser entre 0 y 99");
            }
            if (txtEmail.Text.Length < 1)
            {
                MessageBox.Show("Error, El email no puede estar Vacio");
            }
            else
            {
                nueva.Email = txtEmail.Text.Trim();
            }
                ibll.Agregar(nueva);
            lbIns.ItemsSource = null;
            lbIns.ItemsSource = ibll.GetAll();
            //MessageBox.Show(valor.ToString());

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
