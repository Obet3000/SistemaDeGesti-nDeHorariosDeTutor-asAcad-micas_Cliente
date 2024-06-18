using System.Linq;
using System.Windows;

namespace SistemaDeGestiónDeHorariosDeTutoríasAcadémicas_Cliente
{
    /**
     * Ventana para ingresar el código de validación.
     * Permite al usuario ingresar un código de validación de 6 caracteres numéricos.
     * Modificado por: Obet Jair Hernandez Gonzalez
     * Fecha de modificación: 18-06-2024
     */
    public partial class VentanaIngresaCodigoDeValidacion : Window
    {
        public int CodigoValidacion { get; private set; }

        public VentanaIngresaCodigoDeValidacion()
        {
            InitializeComponent();
            CodigoValidacion = -1;
        }

        private void BtnAceptar_Click(object sender, RoutedEventArgs e)
        {
            string codigoStr = TBCodigo.Text;

            if (EsCodigoValido(codigoStr))
            {
                if (int.TryParse(codigoStr, out int codigoParseado))
                {
                    CodigoValidacion = codigoParseado;
                    this.DialogResult = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al convertir el código a un número, inténtelo nuevamente.");
                }
            }
            else
            {
                MessageBox.Show("Ingrese un código válido de 6 caracteres numéricos.");
            }
        }

        private bool EsCodigoValido(string codigo)
        {
            return !string.IsNullOrEmpty(codigo) && codigo.Length == 6 && codigo.All(char.IsDigit);
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            CodigoValidacion = -1;
            this.DialogResult = false;
            this.Close();
        }
    }
}
