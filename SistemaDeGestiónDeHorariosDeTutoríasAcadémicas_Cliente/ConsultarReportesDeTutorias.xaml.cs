using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.ServiceModel;
using SistemaDeGestionDeHorariosDeTutoriasAcademicas_Cliente.ServicioReporte;

namespace SistemaDeGestionDeHorariosDeTutoriasAcademicas_Cliente
{
    /**
     * Página para consultar reportes de tutorías académicas.
     * Esta clase permite a los usuarios visualizar las sesiones de tutoría y sus detalles.
     * Modificado por: Obet Jair Hernandez Gonzalez
     * Fecha de modificación: 18-06-2024
     */
    public partial class ConsultarReportes : Page, IReporteServicioCallback
    {
        private ReporteServicioClient _servicio;

        public ConsultarReportes()
        {
            InitializeComponent();
            var context = new InstanceContext(this);
            _servicio = new ReporteServicioClient(context);
            CargarSesiones();
        }

        // Carga las sesiones de tutoría disponibles desde el servicio.
        private void CargarSesiones()
        {
            try
            {
                _servicio.ObtenerReportesDeTutorias();
            }
            catch (CommunicationException ex)
            {
                MessageBox.Show($"Error de comunicación: {ex.Message}");
                this.NavigationService.GoBack();
            }
            catch (TimeoutException ex)
            {
                MessageBox.Show($"Tiempo de espera agotado: {ex.Message}");
                this.NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado al cargar las sesiones de tutoría: {ex.Message}");
                this.NavigationService.GoBack();
            }
        }

        public void RecibirReportesDeTutorias(ReporteTutoriaDTO[] reportes)
        {
            if (reportes == null)
            {
                MessageBox.Show("Error: No se recibieron reportes de tutorías.");
                return;
            }

            SesionesComboBox.Items.Clear();
            foreach (var reporte in reportes)
            {
                SesionesComboBox.Items.Add(new ComboBoxItem { Content = reporte.FechaTutoria.ToString("dd/MM/yyyy"), Tag = reporte });
            }

            if (SesionesComboBox.Items.Count > 0)
            {
                SesionesComboBox.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("No hay sesiones de tutoría disponibles.");
                this.NavigationService.GoBack();
            }
        }

        // Maneja el evento de cambio de selección del ComboBox de sesiones.
        private void SesionesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SesionesComboBox.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione una sesión de la lista.");
                return;
            }

            var reporte = (SesionesComboBox.SelectedItem as ComboBoxItem)?.Tag as ReporteTutoriaDTO;
            if (reporte != null)
            {
                SesionSeleccionadaTextBlock.Text = "Sesión seleccionada: " + reporte.FechaTutoria.ToString("dd/MM/yyyy");
                CargarDatosSesion(reporte);
            }
            else
            {
                MessageBox.Show("Error: No se pudo cargar la información de la sesión seleccionada.");
            }
        }

        // Carga los datos de la sesión seleccionada en los elementos correspondientes de la interfaz de usuario.
        private void CargarDatosSesion(ReporteTutoriaDTO reporte)
        {
            TutoradosAtendidosTextBlock.Text = reporte.NumeroTutoradosAtendidos.ToString();
            AsuntosAtendidosTextBlock.Text = string.Join(", ", reporte.AsuntosTratados);
            AsuntosNoAtendidosTextBlock.Text = reporte.NumeroAsuntosNoAtendidos.ToString();
        }

        private void Regresar_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        public void NotificarError(string mensaje)
        {
            MessageBox.Show($"Error: {mensaje}");
            this.NavigationService.GoBack();
        }
    }
}
