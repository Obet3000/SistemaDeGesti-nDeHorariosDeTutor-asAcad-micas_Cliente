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
        private DispatcherTimer temporizador;
        private TimeSpan tiempoTranscurrido;
        private List<ReservacionDTO> estudiantes;
        private ReservacionDTO estudianteActual;

        public ConsultarListaDeEstudiantes()
        {
            InitializeComponent();
            var contexto = new InstanceContext(this);
            _servicio = new ConsultaServicioClient(contexto);
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
                    BotonIniciarContador.Visibility = Visibility.Visible;
                    BotonDetenerContador.Visibility = Visibility.Visible;
                    break;
                default:
                    BotonIniciarContador.Visibility = Visibility.Collapsed;
                    BotonDetenerContador.Visibility = Visibility.Collapsed;
                    break;
            }

            BotonRegresar.Visibility = Visibility.Visible;
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
                DataGridEstudiantes.ItemsSource = estudiantes;
                DataGridEstudiantes.SelectedItem = estudiantes.FirstOrDefault();
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
            temporizador = new DispatcherTimer();
            temporizador.Interval = TimeSpan.FromSeconds(1);
            temporizador.Tick += Temporizador_Tick;
        }

        // Maneja el evento Tick del temporizador para actualizar el tiempo transcurrido.
        private void Temporizador_Tick(object sender, EventArgs e)
        {
            tiempoTranscurrido = tiempoTranscurrido.Add(TimeSpan.FromSeconds(1));
            ActualizarTiempoTranscurrido();
        }

        // Actualiza el texto del tiempo transcurrido en la interfaz de usuario.
        private void ActualizarTiempoTranscurrido()
        {
            TextoTiempoTranscurrido.Text = "Tiempo transcurrido: " + tiempoTranscurrido.ToString(@"mm\:ss");
        }

        private void BotonRegresar_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        // Maneja el evento de clic para detener el temporizador y actualizar la duración de la tutoría.
        private void BotonDetenerContador_Click(object sender, RoutedEventArgs e)
        {
            temporizador.Stop();
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
        private void BotonIniciarContador_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridEstudiantes.SelectedItem != null)
            {
                estudianteActual = (ReservacionDTO)DataGridEstudiantes.SelectedItem;
                tiempoTranscurrido = TimeSpan.Zero;
                temporizador.Start();
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
            if (DataGridEstudiantes.SelectedItem != null)
            {
                estudianteActual = (ReservacionDTO)DataGridEstudiantes.SelectedItem;
                TextoTutoradoAtendido.Text = "Tutorado atendido: " + estudianteActual.Tutorado.UsuarioTutorado.Nombre;
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

        private void DataGridEstudiantes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ActualizarTutoradoAtendido();
        }
    }
}
