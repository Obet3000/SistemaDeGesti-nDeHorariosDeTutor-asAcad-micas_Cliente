using SistemaDeGestiónDeHorariosDeTutoríasAcadémicas_Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using SistemaDeGestionDeHorariosDeTutoriasAcademicas_Cliente.ServicioConsulta;

namespace SistemaDeGestionDeHorariosDeTutoriasAcademicas_Cliente
{
    /**
     * Página para consultar la lista de estudiantes en cola para tutorías académicas.
     * Esta clase permite a los tutores iniciar y detener un temporizador para registrar la duración de las tutorías.
     * Modificado por: Obet Jair Hernandez Gonzalez
     * Fecha de modificación: 18-06-2024
     */
    public partial class ConsultarListaDeEstudiantes : Page, IConsultaServicioCallback
    {
        private ConsultaServicioClient _servicio;
        private DispatcherTimer timer;
        private TimeSpan tiempoTranscurrido;
        private List<ReservacionDTO> estudiantes;
        private ReservacionDTO estudianteActual;

        public ConsultarListaDeEstudiantes()
        {
            InitializeComponent();
            var context = new InstanceContext(this);
            _servicio = new ConsultaServicioClient(context);
            InicializarTemporizador();
            CargarDatos();
            ConfigurarBotones();
        }

        // Configura la visibilidad de los botones según el rol del usuario.
        private void ConfigurarBotones()
        {
            var usuario = UsuarioSingleton.ObtenerInstancia();

            switch (usuario.Rol)
            {
                case "Tutor":
                    IniciarContadorButton.Visibility = Visibility.Visible;
                    DetenerContadorButton.Visibility = Visibility.Visible;
                    break;
                default:
                    IniciarContadorButton.Visibility = Visibility.Collapsed;
                    DetenerContadorButton.Visibility = Visibility.Collapsed;
                    break;
            }

            RegresarButton.Visibility = Visibility.Visible;
        }

        // Carga las reservaciones en cola del tutor.
        private void CargarDatos()
        {
            try
            {
                int tutorId = UsuarioSingleton.ObtenerInstancia().IdUsuario;
                _servicio.ObtenerReservacionesEnColaAsync(tutorId);
            }
            catch (Exception)
            {
                MessageBox.Show("No hay conexión. Inténtelo más tarde.");
                NavigationService.GoBack();
            }
        }

        public void NotificarReservacionesEnCola(ReservacionDTO[] reservaciones)
        {
            estudiantes = reservaciones.ToList();

            if (estudiantes != null && estudiantes.Any())
            {
                EstudiantesDataGrid.ItemsSource = estudiantes;
                EstudiantesDataGrid.SelectedItem = estudiantes.FirstOrDefault();
                ActualizarTutoradoAtendido();
            }
            else
            {
                MessageBox.Show("No hay reservaciones disponibles.");
                NavigationService.GoBack();
            }
        }

        // Inicializa el temporizador para registrar la duración de las tutorías.
        private void InicializarTemporizador()
        {
            tiempoTranscurrido = TimeSpan.Zero;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
        }

        // Maneja el evento Tick del temporizador para actualizar el tiempo transcurrido.
        private void Timer_Tick(object sender, EventArgs e)
        {
            tiempoTranscurrido = tiempoTranscurrido.Add(TimeSpan.FromSeconds(1));
            ActualizarTiempoTranscurrido();
        }

        // Actualiza el texto del tiempo transcurrido en la interfaz de usuario.
        private void ActualizarTiempoTranscurrido()
        {
            TiempoTranscurridoTextBlock.Text = "Tiempo transcurrido: " + tiempoTranscurrido.ToString(@"mm\:ss");
        }

        private void Regresar_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        // Maneja el evento de clic para detener el temporizador y actualizar la duración de la tutoría.
        private void DetenerContador_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            if (estudianteActual != null)
            {
                estudianteActual.TutoriaAcademica.Duracion = tiempoTranscurrido;

                TutoriaAcademicaDTO tutoria = new TutoriaAcademicaDTO
                {
                    IdTutoriaAcademica = estudianteActual.TutoriaAcademica.IdTutoriaAcademica,
                    Duracion = estudianteActual.TutoriaAcademica.Duracion,
                    Usuario = new UsuarioDTO { Correo = estudianteActual.Tutorado.UsuarioTutorado.Correo }
                };
                _servicio.ActualizarTutoriaAcademica(tutoria);
            }
        }

        // Maneja el evento de clic para iniciar el temporizador para la tutoría seleccionada.
        private void IniciarContador_Click(object sender, RoutedEventArgs e)
        {
            if (EstudiantesDataGrid.SelectedItem != null)
            {
                estudianteActual = (ReservacionDTO)EstudiantesDataGrid.SelectedItem;
                tiempoTranscurrido = TimeSpan.Zero;
                timer.Start();
                MessageBox.Show($"Iniciando contador para {estudianteActual.Tutorado.UsuarioTutorado.Nombre}");
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un tutorado de la lista.");
            }
        }

        // Actualiza el texto del tutorado atendido en la interfaz de usuario.
        private void ActualizarTutoradoAtendido()
        {
            if (EstudiantesDataGrid.SelectedItem != null)
            {
                estudianteActual = (ReservacionDTO)EstudiantesDataGrid.SelectedItem;
                TutoradoAtendidoTextBlock.Text = "Tutorado atendido: " + estudianteActual.Tutorado.UsuarioTutorado.Nombre;
            }
        }

        public void NotificarTutoriaAcademicaActualizada(TutoriaAcademicaDTO tutoria)
        {
            MessageBox.Show($"Tutoria académica actualizada: {tutoria.Duracion}");
        }

        public void NotificarError(string mensaje)
        {
            MessageBox.Show($"Error: {mensaje}");
        }

        private void EstudiantesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ActualizarTutoradoAtendido();
        }
    }
}
