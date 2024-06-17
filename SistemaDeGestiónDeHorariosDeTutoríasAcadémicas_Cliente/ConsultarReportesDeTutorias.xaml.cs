using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.ServiceModel;
using SistemaDeGestionDeHorariosDeTutoriasAcademicas_Cliente.ServicioReporte;

namespace SistemaDeGestionDeHorariosDeTutoriasAcademicas_Cliente
{
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

        private void CargarSesiones()
        {
            try
            {
                _servicio.ObtenerReportesDeTutorias();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las sesiones de tutoría: {ex.Message}");
                this.NavigationService.GoBack();
            }
        }

        public void RecibirReportesDeTutorias(ReporteTutoriaDTO[] reportes)
        {
            Dispatcher.Invoke(() =>
            {
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
            });
        }

        private void SesionesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SesionesComboBox.SelectedItem != null)
            {
                var reporte = (SesionesComboBox.SelectedItem as ComboBoxItem).Tag as ReporteTutoriaDTO;
                SesionSeleccionadaTextBlock.Text = "Sesión seleccionada: " + reporte.FechaTutoria.ToString("dd/MM/yyyy");
                CargarDatosSesion(reporte);
            }
        }

        private void CargarDatosSesion(ReporteTutoriaDTO reporte)
        {
            TutoradosAtendidosTextBlock.Text = reporte.NumeroTutoradosAtendidos.ToString();
            TiempoPromedioTextBlock.Text = TimeSpan.FromMinutes(reporte.TiempoPromedioTutorias).ToString(@"hh\:mm");
            AsuntosAtendidosTextBlock.Text = reporte.AsuntosTratados.ToString();
            AsuntosNoAtendidosTextBlock.Text = reporte.NumeroAsuntosNoAtendidos.ToString();
        }

        private void Regresar_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        public void NotificarError(string mensaje)
        {
            Dispatcher.Invoke(() =>
            {
                MessageBox.Show($"Error: {mensaje}");
                this.NavigationService.GoBack();
                });
        }
    }
}
