using System;
using System.ServiceModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using SistemaDeGestionDeHorariosDeTutoriasAcademicas_Cliente.ServicioAutentificacion;

namespace SistemaDeGestionDeHorariosDeTutoriasAcademicas_Cliente
{
    /**
     * Página para iniciar sesión en el sistema de gestión de horarios de tutorías académicas.
     * Modificado por: Obet Jair Hernandez Gonzalez
     * Fecha de modificación: 18-06-2024
     */
    public partial class IniciarSesion : Page, IAutentificacionServicioCallback
    {
        private IAutentificacionServicio _servicio;
        private InstanceContext context;

        public IniciarSesion()
        {
            InitializeComponent();
            context = new InstanceContext(this);
        }

        
        public void RespuestaAutentificacion(UsuarioDTO usuario)
        {
            if (usuario.Correo != null)
            {
                UsuarioSingleton.ObtenerInstancia().IdUsuario = usuario.IdUsuario;
                UsuarioSingleton.ObtenerInstancia().Correo = usuario.Correo;
                UsuarioSingleton.ObtenerInstancia().EstadoUsuario = true;
                UsuarioSingleton.ObtenerInstancia().NombreUsuario = usuario.NombreUsuario;
                UsuarioSingleton.ObtenerInstancia().Rol = usuario.Rol;

                if (usuario.Rol == null && usuario.Correo.EndsWith("@estudiantes.uv.mx"))
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        var mainWindow = (MainWindow)Window.GetWindow(this);
                        mainWindow.MostrarPagina(new SeleccionarTutor());
                    });
                }
                else
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        var mainWindow = (MainWindow)Window.GetWindow(this);
                        mainWindow.MostrarPagina(new MenuPrincipal());
                    });
                }
            }
            else
            {
                MessageBox.Show("El email o la contraseña es incorrecta.");
            }
        }

        
        private void IniciarSesion_Click(object sender, RoutedEventArgs e)
        {
            string usuario = UsuarioTextBox.Text;
            string contrasena = ContraseniaPasswordBox.Password;

            if (ValidarCampos(usuario, contrasena))
            {
                try
                {
                    _servicio = new AutentificacionServicioClient(context);
                    _servicio.AutentificacionUsuario(usuario, HashContrasena(contrasena));
                    _servicio = null;
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
                    MessageBox.Show($"Error inesperado: {ex.Message}");
                }
            }
        }

        
        private void Registrarse_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.MostrarPagina(new Registro());
        }

        
        private string HashContrasena(string contrasena)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(contrasena));
                var builder = new System.Text.StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        
         // Valida los campos de usuario y contraseña.
         
        private bool ValidarCampos(string usuario, string contrasena)
        {
            if (string.IsNullOrWhiteSpace(usuario))
            {
                MessageBox.Show("El campo de usuario no puede estar vacío.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(contrasena))
            {
                MessageBox.Show("El campo de contraseña no puede estar vacío.");
                return false;
            }

            if (!Regex.IsMatch(usuario, @"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$"))
            {
                MessageBox.Show("El correo ingresado no es válido.");
                return false;
            }

            if (contrasena.Length < 8)
            {
                MessageBox.Show("La contraseña debe tener al menos 8 caracteres.");
                return false;
            }

            return true;
        }

        public void NotificarActualizacionUsuario(bool exito, string mensaje)
        {
            throw new NotImplementedException();
        }

        public void RecibirTutores(UsuarioDTO[] tutores)
        {
            throw new NotImplementedException();
        }
    }
}
