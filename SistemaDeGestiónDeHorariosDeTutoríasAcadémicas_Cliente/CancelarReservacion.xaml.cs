using SistemaDeGestiónDeHorariosDeTutoríasAcadémicas_Cliente;
using System;
using System.Windows;
using System.Windows.Controls;
using SistemaDeGestionDeHorariosDeTutoriasAcademicas_Cliente.ServicioCancelar;
using System.ServiceModel;
using System.Collections.Generic;

namespace SistemaDeGestionDeHorariosDeTutoriasAcademicas_Cliente
{
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
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

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
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una reservación.");
            }
        }

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
            Dispatcher.Invoke(() =>
            {
                MessageBox.Show($"Reservación cancelada: {motivo}");
            });
        }

        public void NotificarTodasReservacionesCanceladas(string nombreUsuario, string motivo)
        {
            Dispatcher.Invoke(() =>
            {
                MessageBox.Show($"Todas las reservaciones para {nombreUsuario} han sido canceladas: {motivo}");
            });
        }

        public void NotificarError(string mensaje)
        {
            Dispatcher.Invoke(() =>
            {
                MessageBox.Show($"Error: {mensaje}");
            });
        }

        public void NotificarReservaciones(ReservacionDTO[] reservaciones)
        {
            Dispatcher.Invoke(() =>
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
            });
        }
    }
}
