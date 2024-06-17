using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Windows;
using System.Windows.Controls;
using SistemaDeGestionDeHorariosDeTutoriasAcademicas_Cliente.ServicioReservacion;

namespace SistemaDeGestionDeHorariosDeTutoriasAcademicas_Cliente
{
    public partial class RegistrarReservacionDeTutorias : Page, IReservacionServicioCallback
    {
        private IReservacionServicio _servicio;
        private InstanceContext context;
        private GestorDeTurnos _gestorDeTurnos;

        public RegistrarReservacionDeTutorias()
        {
            InitializeComponent();
            context = new InstanceContext(this);
            _servicio = new ReservacionServicioClient(context);
            _gestorDeTurnos = new GestorDeTurnos();

            CargarTurnosDisponibles();
        }

        private void CargarTurnosDisponibles()
        {
            try
            {
                string nombreUsuario = UsuarioSingleton.ObtenerInstancia().NombreUsuario;
                _servicio.ObtenerTurnosOcupados(nombreUsuario, UsuarioSingleton.ObtenerInstancia().IdUsuario);
            }
            catch
            {
                MessageBox.Show("Hubo un error al intentar cargar los turnos disponibles. Por favor, inténtelo nuevamente más tarde.");
            }
        }

        public void NotificarTurnosDisponibles(TurnoDTO[] turnos)
        {
            try
            {
                Dispatcher.Invoke(() =>
                {
                    var turnosGenerados = _gestorDeTurnos.GenerarTurnos();
                    _gestorDeTurnos.ActualizarTurnosConReservaciones(turnosGenerados, turnos);

                    HorarioComboBox.Items.Clear();
                    foreach (var turno in turnosGenerados)
                    {
                        if (turno.Disponible)
                        {
                            HorarioComboBox.Items.Add(new ComboBoxItem
                            {
                                Content = turno.Hora
                            });
                        }
                    }
                });
            }
            catch
            {
                MessageBox.Show("Hubo un error al procesar los turnos disponibles. Por favor, inténtelo nuevamente más tarde.");
            }
        }

        private void HorarioComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (HorarioComboBox.SelectedItem != null)
            {
                HorarioSeleccionadoTextBlock.Text = "Horario seleccionado: " + (HorarioComboBox.SelectedItem as ComboBoxItem).Content.ToString();
            }
        }

        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string horarioSeleccionado = (HorarioComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
                string asunto = AsuntoTextBox.Text;

                if (!string.IsNullOrWhiteSpace(horarioSeleccionado) && !string.IsNullOrWhiteSpace(asunto))
                {
                    var reservacion = new ReservacionDTO
                    {
                        NumeroDeTurno = GenerarNumeroDeTurno(),
                        Hora = TimeSpan.Parse(horarioSeleccionado),
                        Asunto = asunto,
                        EstadoAsunto = false,
                        EstadoReservacion = true,
                        IdTutoriaAcademica = null
                    };

                    _servicio.RegistrarReservacion(reservacion, UsuarioSingleton.ObtenerInstancia().IdUsuario);
                }
                else
                {
                    MessageBox.Show("Por favor, complete todos los campos.");
                }
            }
            catch
            {
                MessageBox.Show("Hubo un error al guardar la reservación. Por favor, inténtelo nuevamente más tarde.");
            }
        }

        public void NotificarReservacionRegistrada(ReservacionDTO reservacion)
        {
            try
            {
                Dispatcher.Invoke(() =>
                {
                    MessageBox.Show("Reservación guardada exitosamente.");
                    this.NavigationService.GoBack();
                });
            }
            catch
            {
                MessageBox.Show("Hubo un error al procesar la confirmación de la reservación. Por favor, inténtelo nuevamente más tarde.");
            }
        }

        public void NotificarError(string mensaje)
        {
            Dispatcher.Invoke(() =>
            {
                MessageBox.Show($"Error: {mensaje}");
            });
        }

        private void Regresar_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private int GenerarNumeroDeTurno()
        {
            return new Random().Next(1, 1000);
        }
    }
}
