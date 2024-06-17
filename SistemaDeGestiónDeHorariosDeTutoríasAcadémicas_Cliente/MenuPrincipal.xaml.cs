using SistemaDeGestiónDeHorariosDeTutoríasAcadémicas_Cliente;
using System;
using System.Windows;
using System.Windows.Controls;

namespace SistemaDeGestionDeHorariosDeTutoriasAcademicas_Cliente
{
    public partial class MenuPrincipal : Page
    {
        public MenuPrincipal()
        {
            InitializeComponent();
            ConfigurarMenu();
        }

        private void Salir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        
        private void ConsultarListaEstudiantes_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ConsultarListaDeEstudiantes());
        }

        private void RegistrarReservacion_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new RegistrarReservacionDeTutorias());
        }

        private void CalificarSesion_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CalificarTutoriaAcademica());
        }

        private void CancelarReservacion_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CancelarReservacion());
        }

        private void RegistrarSesion_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new RegistrarSesionTutoria());
        }

        private void ConsultarReportes_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ConsultarReportes());
        }

        private void ConfigurarMenu()
        {
            var usuario = UsuarioSingleton.ObtenerInstancia();
            ConsultarListaEstudiantesButton.Visibility = Visibility.Collapsed;
            RegistrarReservacionButton.Visibility = Visibility.Collapsed;
            CalificarSesionButton.Visibility = Visibility.Collapsed;
            CancelarReservacionButton.Visibility = Visibility.Collapsed;
            RegistrarSesionButton.Visibility = Visibility.Collapsed;
            ConsultarReportesButton.Visibility = Visibility.Collapsed;

            switch (usuario.Rol)
            {
                case "Tutorado":
                    RegistrarReservacionButton.Visibility = Visibility.Visible;
                    CalificarSesionButton.Visibility = Visibility.Visible;
                    CancelarReservacionButton.Visibility = Visibility.Visible;
                    ConsultarListaEstudiantesButton.Visibility = Visibility.Visible;
                    break;

                case "Tutor":
                    CancelarReservacionButton.Visibility = Visibility.Visible;
                    ConsultarListaEstudiantesButton.Visibility = Visibility.Visible;
                    break;

                case "Administrador":
                    CancelarReservacionButton.Visibility = Visibility.Visible;
                    RegistrarSesionButton.Visibility = Visibility.Visible;
                    ConsultarReportesButton.Visibility = Visibility.Visible;
                    break;

                default:
                    MessageBox.Show("Rol de usuario no reconocido.");
                    break;
            }
        }
    }
}
