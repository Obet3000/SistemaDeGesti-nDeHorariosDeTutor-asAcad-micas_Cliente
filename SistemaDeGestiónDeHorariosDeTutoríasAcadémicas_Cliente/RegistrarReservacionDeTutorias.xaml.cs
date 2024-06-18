using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Windows;
using System.Windows.Controls;
using SistemaDeGestionDeHorariosDeTutoriasAcademicas_Cliente.ServicioReservacion;

namespace SistemaDeGestionDeHorariosDeTutoriasAcademicas_Cliente
{
    /**
     * Página para registrar reservaciones de tutorías académicas.
     * Modificado por: Obet Jair Hernandez Gonzalez
     * Fecha de modificación: 18-06-2024
     */
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
                MessageBox.Show($"Hubo un error al intentar cargar los turnos disponibles: {ex.Message}");
            }
        }

        public void NotificarTurnosDisponibles(TurnoDTO[] turnos)
        {
            try
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hubo un error al procesar los turnos disponibles: {ex.Message}");
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

                if (ValidarCampos(horarioSeleccionado, asunto))
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
            catch (Exception ex)
            {
                MessageBox.Show($"Hubo un error al guardar la reservación: {ex.Message}");
            }
        }

        public void NotificarReservacionRegistrada(ReservacionDTO reservacion)
        {
            try
            {
                MessageBox.Show("Reservación guardada exitosamente.");
                this.NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hubo un error al procesar la confirmación de la reservación: {ex.Message}");
            }
        }

        public void NotificarError(string mensaje)
        {
            try
            {
                MessageBox.Show($"Error: {mensaje}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al mostrar el mensaje de error: {ex.Message}");
            }
        }

        
        private void Regresar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar regresar: {ex.Message}");
            }
        }

        
        private int GenerarNumeroDeTurno()
        {
            return new Random().Next(1, 1000);
        }

       
        private bool ValidarCampos(string horarioSeleccionado, string asunto)
        {
            if (string.IsNullOrWhiteSpace(horarioSeleccionado))
            {
                MessageBox.Show("Por favor, seleccione un horario.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(asunto))
            {
                MessageBox.Show("Por favor, ingrese un asunto.");
                return false;
            }

            return true;
        }
    }
}
