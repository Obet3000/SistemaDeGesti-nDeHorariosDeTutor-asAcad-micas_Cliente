using System;
using System.ServiceModel;
using System.Windows;
using System.Windows.Controls;
using SistemaDeGestionDeHorariosDeTutoriasAcademicas_Cliente.ServicioRegistro;
using SistemaDeGestionDeHorariosDeTutoriasAcademicas_Cliente.ServicioSesionTutoria;
using System.Collections.Generic;

namespace SistemaDeGestionDeHorariosDeTutoriasAcademicas_Cliente
{
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

                var sesion = new SistemaDeGestionDeHorariosDeTutoriasAcademicas_Cliente.ServicioSesionTutoria.SesionDeTutoriaDTO
                {
                    FechaDeSesion = fechaSeleccionada,
                    IdPeriodo = idPeriodo,
                    NumeroDeSesion = numeroDeSesion
                };

                _servicio.RegistrarSesionDeTutoria(sesion);
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fecha.");
            }
        }

        public void NotificarSesionRegistrada(ServicioSesionTutoria.SesionDeTutoriaDTO sesion)
        {
            Dispatcher.Invoke(() =>
            {
                MessageBox.Show($"Sesión registrada exitosamente para la fecha: {sesion.FechaDeSesion.ToString("dd/MM/yyyy")}");
                this.NavigationService.GoBack();
            });
        }

        public void NotificarError(string mensaje)
        {
            Dispatcher.Invoke(() =>
            {
                MessageBox.Show($"Error: {mensaje}");
            });
        }

        private void CargarSesionesDelPeriodo()
        {
            try
            {
                int idPeriodo = ObtenerIdPeriodoActual();
                _servicio.ObtenerSesionesPorPeriodo(idPeriodo);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las sesiones del periodo: {ex.Message}");
            }
        }

        public void NotificarSesionesPorPeriodo(ServicioSesionTutoria.SesionDeTutoriaDTO[] sesiones)
        {
            Dispatcher.Invoke(() =>
            {
                // Manejar las sesiones obtenidas (por ejemplo, mostrarlas en una lista o usarlas de alguna manera)
                foreach (var sesion in sesiones)
                {
                    Console.WriteLine($"Sesión: {sesion.NumeroDeSesion}, Fecha: {sesion.FechaDeSesion.ToString("dd/MM/yyyy")}");
                }
            });
        }

        private int ObtenerIdPeriodoActual()
        {
            // Implementa la lógica para obtener el ID del periodo actual
            return 1; // Ejemplo
        }

        private int ObtenerNumeroDeSesion(int idPeriodo)
        {
            // Implementa la lógica para obtener el número de sesión para el periodo dado
            return 1; // Ejemplo
        }
    }
}
