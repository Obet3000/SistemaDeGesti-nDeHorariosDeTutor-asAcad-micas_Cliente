using System;
using System.Windows;
using System.Windows.Controls;
using System.ServiceModel;
using SistemaDeGestionDeHorariosDeTutoriasAcademicas_Cliente.ServicioCalificacion;
using System.Collections.Generic;

namespace SistemaDeGestionDeHorariosDeTutoriasAcademicas_Cliente
{
    /**
     * Página para calificar tutorías académicas.
     * Esta clase permite a los usuarios calificar y comentar sobre sus sesiones de tutoría académica.
     * Modificado por: Obet Jair Hernandez Gonzalez
     * Fecha de modificación: 18-06-2024
     */
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
                if (calificacion >= 1 && calificacion <= 5)
                {
                    try
                    {
                        _servicio.CalificarTutoria(comentario, calificacion, UsuarioSingleton.ObtenerInstancia().IdUsuario);
                    }
                    catch (EndpointNotFoundException)
                    {
                        MessageBox.Show("Error al conectar con el servicio. Por favor, inténtelo más tarde.");
                    }
                    catch (CommunicationException)
                    {
                        MessageBox.Show("Error de comunicación. Por favor, inténtelo más tarde.");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ocurrió un error inesperado. Por favor, inténtelo más tarde.");
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, ingrese una calificación entre 1 y 5.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese una calificación válida.");
            }
        }

        /**
         * Actualiza la fecha de la tutoría mostrada en la interfaz.
         */
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
