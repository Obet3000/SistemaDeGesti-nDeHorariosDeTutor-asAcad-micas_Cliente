using System.Windows;
using System.Windows.Controls;
using System.ServiceModel;
using SistemaDeGestionDeHorariosDeTutoriasAcademicas_Cliente.ServicioAutentificacion;
using System;

namespace SistemaDeGestionDeHorariosDeTutoriasAcademicas_Cliente
{
    /**
     * Esta clase gestiona la carga de tutores y la asignación de un tutor seleccionado al estudiante.
     * Modificado por: Obet Jair Hernandez Gonzalez
     * Fecha de modificación: 18-06-2024
     */
    public partial class SeleccionarTutor : Page, IAutentificacionServicioCallback
    {
        private IAutentificacionServicio _servicio;
        private InstanceContext _context;

        public SeleccionarTutor()
        {
            InitializeComponent();
            _context = new InstanceContext(this);
            _servicio = new AutentificacionServicioClient(_context);
            CargarTutores();
        }

        private void CargarTutores()
        {
            try
            {
                _servicio.ObtenerTutores();
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
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        public void RecibirTutores(UsuarioDTO[] tutores)
        {
            Dispatcher.Invoke(() =>
            {
                TutorComboBox.Items.Clear();
                foreach (var tutor in tutores)
                {
                    TutorComboBox.Items.Add(new ComboBoxItem
                    {
                        Content = tutor.NombreUsuario,
                        Tag = tutor.IdUsuario
                    });
                }
            });
        }


         
        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            if (TutorComboBox.SelectedItem != null)
            {
                var tutorSeleccionado = (ComboBoxItem)TutorComboBox.SelectedItem;
                int idTutor = (int)tutorSeleccionado.Tag;

                var usuario = UsuarioSingleton.ObtenerInstancia();
                var usuarioDTO = new UsuarioDTO
                {
                    IdUsuario = usuario.IdUsuario,
                    Correo = usuario.Correo,
                    NombreUsuario = usuario.NombreUsuario,
                    Rol = "Tutorado"
                };

                try
                {
                    _servicio.DefinirTutor(usuarioDTO, idTutor);
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
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un tutor.");
            }
        }

         // Notifica al usuario sobre la actualización del tutor y redirige al menú principal si es exitosa.
         
        public void NotificarActualizacionUsuario(bool exito, string mensaje)
        {
            Dispatcher.Invoke(() =>
            {
                MessageBox.Show(mensaje);
                if (exito)
                {
                    var mainWindow = (MainWindow)Window.GetWindow(this);
                    mainWindow.MostrarPagina(new MenuPrincipal());
                }
            });
        }

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        public void RespuestaAutentificacion(UsuarioDTO usuario)
        {
            throw new NotImplementedException();
        }
    }
}
