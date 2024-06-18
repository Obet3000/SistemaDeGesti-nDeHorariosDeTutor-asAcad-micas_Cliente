using System;
using System.ServiceModel;
using System.Windows;
using System.Windows.Controls;
using SistemaDeGestionDeHorariosDeTutoriasAcademicas_Cliente.ServicioSesionTutoria;

namespace SistemaDeGestionDeHorariosDeTutoriasAcademicas_Cliente
{
    /**
     * Página para registrar sesiones de tutoría.
     * Modificado por: Obet Jair Hernandez Gonzalez
     * Fecha de modificación: 18-06-2024
     */
    public partial class RegistrarSesionTutoria : Page, ISesionTutoriaServicioCallback
    {
        private SesionTutoriaServicioClient _servicio;

        public RegistrarSesionTutoria()
        {
            InitializeComponent();
            var context = new InstanceContext(this);
            _servicio = new SesionTutoriaServicioClient(context);
            CargarSesionesDelPeriodo();
        }

        private void CalendarControl_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CalendarControl.SelectedDate.HasValue)
            {
                FechaSeleccionadaTextBlock.Text = "Fecha seleccionada: " + CalendarControl.SelectedDate.Value.ToString("dd/MM/yyyy");
            }
        }

        private void Regresar_Click(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService != null)
            {
                this.NavigationService.GoBack();
            }
        }

        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            if (CalendarControl.SelectedDate.HasValue)
            {
                DateTime fechaSeleccionada = CalendarControl.SelectedDate.Value;
                int idPeriodo = ObtenerIdPeriodoActual();
                int numeroDeSesion = ObtenerNumeroDeSesion(idPeriodo);

                var sesion = new SesionDeTutoriaDTO
                {
                    FechaDeSesion = fechaSeleccionada,
                    IdPeriodo = idPeriodo,
                    NumeroDeSesion = numeroDeSesion
                };

                try
                {
                    _servicio.RegistrarSesionDeTutoria(sesion);
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
                    MessageBox.Show($"Error al registrar la sesión: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fecha.");
            }
        }

        public void NotificarSesionRegistrada(SesionDeTutoriaDTO sesion)
        {
            try
            {
                MessageBox.Show($"Sesión registrada exitosamente para la fecha: {sesion.FechaDeSesion.ToString("dd/MM/yyyy")}");
                this.NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar la confirmación de la sesión: {ex.Message}");
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

        private void CargarSesionesDelPeriodo()
        {
            try
            {
                int idPeriodo = ObtenerIdPeriodoActual();
                _servicio.ObtenerSesionesPorPeriodo(idPeriodo);
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
                MessageBox.Show($"Error al cargar las sesiones del periodo: {ex.Message}");
            }
        }

        public void NotificarSesionesPorPeriodo(SesionDeTutoriaDTO[] sesiones)
        {
            try
            {
                foreach (var sesion in sesiones)
                {
                    Console.WriteLine($"Sesión: {sesion.NumeroDeSesion}, Fecha: {sesion.FechaDeSesion.ToString("dd/MM/yyyy")}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar las sesiones obtenidas: {ex.Message}");
            }
        }

        
        private int ObtenerIdPeriodoActual()
        {
            return 1; 
        }

    
        private int ObtenerNumeroDeSesion(int idPeriodo)
        {
            
            return 1; 
        }
    }
}
