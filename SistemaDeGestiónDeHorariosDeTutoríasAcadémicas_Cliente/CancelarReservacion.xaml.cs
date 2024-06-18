using SistemaDeGestiónDeHorariosDeTutoríasAcadémicas_Cliente;
using System;
using System.Windows;
using System.Windows.Controls;
using SistemaDeGestionDeHorariosDeTutoriasAcademicas_Cliente.ServicioCancelar;
using System.ServiceModel;
using System.Collections.Generic;

namespace SistemaDeGestionDeHorariosDeTutoriasAcademicas_Cliente
{
    /**
     * Página para cancelar reservaciones de tutoría académica.
     * Esta clase permite a los usuarios cancelar reservaciones individuales o todas sus reservaciones.
     * Modificado por: Obet Jair Hernandez Gonzalez
     * Fecha de modificación: 18-06-2024
     */
    public partial class CancelarReservacion : Page, ICancelarServicioCallback
    {
        private ICancelarServicio _servicio;
        private InstanceContext context;

        public CancelarReservacion()
        {
            InitializeComponent();
            context = new InstanceContext(this);
            _servicio = new CancelarServicioClient(context);
            ConfigurarBotones();
            CargarReservaciones();
        }

        // Configura la visibilidad de los botones según el rol del usuario.
        private void ConfigurarBotones()
        {
            var usuario = UsuarioSingleton.ObtenerInstancia();

            switch (usuario.Rol)
            {
                case "Tutorado":
                    CancelarReservacionButton.Visibility = Visibility.Visible;
                    break;
                case "Tutor":
                    CancelarReservacionButton.Visibility = Visibility.Visible;
                    CancelarTodasButton.Visibility = Visibility.Visible;
                    break;
            }
        }

        // Carga las reservaciones del usuario actual.
        private void CargarReservaciones()
        {
            try
            {
                var usuario = UsuarioSingleton.ObtenerInstancia();
                _servicio.ObtenerReservaciones(usuario.NombreUsuario, usuario.Rol == "Tutor");
            }
            catch (CommunicationException ex)
            {
                MessageBox.Show($"Error de comunicación: {ex.Message}");
            }
            catch (TimeoutException ex)
            {
                MessageBox.Show($"Tiempo de espera agotado: {ex.Message}");
            }
            catch (Exception)
            {
                MessageBox.Show("Error inesperado al cargar reservaciones. Por favor, inténtelo más tarde.");
            }
        }

        // Maneja el evento de clic para cancelar una reservación específica.
        private void CancelarReservacion_Click(object sender, RoutedEventArgs e)
        {
            if (HorarioComboBox.SelectedItem != null)
            {
                int idReservacion = (int)(HorarioComboBox.SelectedItem as ComboBoxItem).Tag;
                string motivo = AsuntoTextBox.Text;

                try
                {
                    _servicio.CancelarReservacion(idReservacion, motivo);
                }
                catch (CommunicationException ex)
                {
                    MessageBox.Show($"Error de comunicación: {ex.Message}");
                }
                catch (TimeoutException ex)
                {
                    MessageBox.Show($"Tiempo de espera agotado: {ex.Message}");
                }
                catch (Exception)
                {
                    MessageBox.Show("Error inesperado al cancelar la reservación. Por favor, inténtelo más tarde.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una reservación.");
            }
        }

        // Maneja el evento de clic para cancelar todas las reservaciones del usuario.
        private void CancelarTodas_Click(object sender, RoutedEventArgs e)
        {
            string motivo = AsuntoTextBox.Text;

            try
            {
                _servicio.CancelarTodasReservaciones(UsuarioSingleton.ObtenerInstancia().NombreUsuario, motivo);
            }
            catch (CommunicationException ex)
            {
                MessageBox.Show($"Error de comunicación: {ex.Message}");
            }
            catch (TimeoutException ex)
            {
                MessageBox.Show($"Tiempo de espera agotado: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void HorarioComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (HorarioComboBox.SelectedItem != null)
            {
                HorarioSeleccionadoTextBlock.Text = "Horario seleccionado: " + (HorarioComboBox.SelectedItem as ComboBoxItem).Content.ToString();
            }
        }

        private void Regresar_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        public void NotificarReservacionCancelada(int idReservacion, string motivo)
        {
            MessageBox.Show($"Reservación cancelada: {motivo}");
            CargarReservaciones();
        }

        public void NotificarTodasReservacionesCanceladas(string nombreUsuario, string motivo)
        {
            MessageBox.Show($"Todas las reservaciones para {nombreUsuario} han sido canceladas: {motivo}");
            CargarReservaciones();
        }

        public void NotificarError(string mensaje)
        {
            MessageBox.Show($"Error: {mensaje}");
        }

        public void NotificarReservaciones(ReservacionDTO[] reservaciones)
        {
            HorarioComboBox.Items.Clear();
            foreach (var reservacion in reservaciones)
            {
                var item = new ComboBoxItem
                {
                    Content = reservacion.Hora.ToString(),
                    Tag = reservacion.IdReservacion
                };
                HorarioComboBox.Items.Add(item);
            }
        }
    }
}
