using System;
using System.Windows;
using System.Windows.Controls;
using System.ServiceModel;
using SistemaDeGestionDeHorariosDeTutoriasAcademicas_Cliente.ServicioCalificacion;
using System.Collections.Generic;

namespace SistemaDeGestionDeHorariosDeTutoriasAcademicas_Cliente
{
    public partial class CalificarTutoriaAcademica : Page, ICalificacionServicioCallback
    {
        private CalificacionServicioClient _servicio;

        public CalificarTutoriaAcademica()
        {
            InitializeComponent();
            var context = new InstanceContext(this);
            _servicio = new CalificacionServicioClient(context);
            ActualizarFechaTutoria(new DateTime(2024, 5, 27));
        }

        private void Regresar_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            string comentario = ComentarioTextBox.Text;
            if (int.TryParse(CalificacionTextBox.Text, out int calificacion))
            { 
                _servicio.CalificarTutoria(comentario, calificacion, UsuarioSingleton.ObtenerInstancia().IdUsuario);
            }
            else
            {
                MessageBox.Show("Por favor, ingrese una calificación válida.");
            }
        }

       

        private void ActualizarFechaTutoria(DateTime fecha)
        {
            FechaTutoriaTextBlock.Text = fecha.ToString("dd/MM/yyyy");
        }


        public void NotificarCalificacionRegistrada(string mensaje)
        {
            
                MessageBox.Show(mensaje);
                NavigationService.GoBack();
           
        }

        public void NotificarCalificaciones(List<TutoriaAcademicaDTO> calificaciones)
        {
            throw new NotImplementedException();
        }

        public void NotificarCalificaciones(TutoriaAcademicaDTO[] calificaciones)
        {
            throw new NotImplementedException();
        }

        public void NotificarError(string mensaje)
        {
            
                MessageBox.Show($"Error: {mensaje}");
           
        }
    }
}
