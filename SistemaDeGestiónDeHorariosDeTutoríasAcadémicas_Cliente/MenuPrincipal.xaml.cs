using SistemaDeGestiónDeHorariosDeTutoríasAcadémicas_Cliente;
using System;
using System.Windows;
using System.Windows.Controls;

namespace SistemaDeGestionDeHorariosDeTutoriasAcademicas_Cliente
{
    /**
     * Página del menú principal para el sistema de gestión de horarios de tutorías académicas.
     * Modificado por: Obet Jair Hernandez Gonzalez
     * Fecha de modificación: 18-06-2024
     */
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
            try
            {
                this.NavigationService.Navigate(new ConsultarListaDeEstudiantes());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al navegar a la página de consulta de lista de estudiantes: {ex.Message}");
            }
        }

      
        private void RegistrarReservacion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.NavigationService.Navigate(new RegistrarReservacionDeTutorias());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al navegar a la página de registro de reservación: {ex.Message}");
            }
        }

       
        private void CalificarSesion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.NavigationService.Navigate(new CalificarTutoriaAcademica());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al navegar a la página de calificación de sesión: {ex.Message}");
            }
        }

        
        private void CancelarReservacion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.NavigationService.Navigate(new CancelarReservacion());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al navegar a la página de cancelación de reservación: {ex.Message}");
            }
        }

        
        private void RegistrarSesion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.NavigationService.Navigate(new RegistrarSesionTutoria());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al navegar a la página de registro de sesión: {ex.Message}");
            }
        }

      
        private void ConsultarReportes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.NavigationService.Navigate(new ConsultarReportes());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al navegar a la página de consulta de reportes: {ex.Message}");
            }
        }

        
         // Configura la visibilidad de los botones del menú en función del rol del usuario.
         
        private void ConfigurarMenu()
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show($"Error al configurar el menú: {ex.Message}");
            }
        }
    }
}
