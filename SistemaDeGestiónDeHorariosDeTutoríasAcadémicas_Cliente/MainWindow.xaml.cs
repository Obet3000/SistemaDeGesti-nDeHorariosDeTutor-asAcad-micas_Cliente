using SistemaDeGestiónDeHorariosDeTutoríasAcadémicas_Cliente;
using System.Windows;
using System.Windows.Controls;

namespace SistemaDeGestionDeHorariosDeTutoriasAcademicas_Cliente
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MostrarPagina(new IniciarSesion());
        }

        public void MostrarPagina(Page pagina)
        {
            MainFrame.Navigate(pagina);
        }
    }
}
