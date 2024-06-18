using System;
using System.ServiceModel;
using System.Text.RegularExpressions;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using SistemaDeGestiónDeHorariosDeTutoríasAcadémicas_Cliente;
using SistemaDeGestionDeHorariosDeTutoriasAcademicas_Cliente.ServicioRegistro;

namespace SistemaDeGestionDeHorariosDeTutoriasAcademicas_Cliente
{
    /**
     * Esta clase gestiona la validación de datos y el envío de códigos de validación para el registro de usuarios.
     * Modificado por: Obet Jair Hernandez Gonzalez
     * Fecha de modificación: 18-06-2024
     */
    public partial class Registro : Page, IServicioRegistroCallback
    {
        private IServicioRegistro _servicioRegistro;

        public Registro()
        {
            InitializeComponent();
            _servicioRegistro = new ServicioRegistroClient(new InstanceContext(this));
        }

        
        public void RegistrarUsuario()
        {
            try
            {
                UsuarioDTO usuario = new UsuarioDTO
                {
                    Contrasenia = HashContrasenia(PBContrasenia.Password),
                    NombreUsuario = TBMatricula.Text,
                    Nombre = TBNombre.Text,
                    ApellidoPaterno = TBApellidoPaterno.Text,
                    ApellidoMaterno = TBApellidoMaterno.Text,
                    Correo = TBEmail.Text
                };

                if (ValidarCorreoElectronico(usuario.Correo))
                {
                    if (PBContrasenia.Password == PBConfirmacionContrasenia.Password && ValidarContraseniaSegura(PBContrasenia.Password))
                    {
                        _servicioRegistro.EnviarCodigoDeValidacion(usuario.Correo, usuario.Correo);
                        VentanaIngresaCodigoDeValidacion ventanaIngresaCodigoDeValidacion = new VentanaIngresaCodigoDeValidacion();
                        ventanaIngresaCodigoDeValidacion.ShowDialog();

                        if (ventanaIngresaCodigoDeValidacion.CodigoValidacion != -1)
                        {
                            _servicioRegistro.ValidarCodigo(usuario, ventanaIngresaCodigoDeValidacion.CodigoValidacion);
                        }
                    }
                    else
                    {
                        MessageBox.Show("La contraseña debe tener una longitud mínima de 8 caracteres, incluir al menos una mayúscula, 1 minúscula y 1 signo.");
                    }
                }
                else
                {
                    MessageBox.Show("El correo ingresado no es válido.");
                }
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
                MessageBox.Show($"Error al registrar al usuario: {ex.Message}");
            }
        }

        // Valida que la contraseña sea segura según las reglas especificadas.
        private bool ValidarContraseniaSegura(string contrasenia)
        {
            return Regex.IsMatch(contrasenia, @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*\W).{8,}$");
        }

        // Valida que el correo electrónico tenga un formato correcto.
        private bool ValidarCorreoElectronico(string email)
        {
            string patronCorreo = @"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$";
            return Regex.IsMatch(email, patronCorreo);
        }

        private void ButtonVolver_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.MostrarPagina(new IniciarSesion());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RegistrarUsuario();
        }

        public void RecibirRespuesta(string codigo)
        {
            if (codigo == "El código es válido")
            {
                MessageBox.Show(codigo);
                var mainWindow = (MainWindow)Window.GetWindow(this);
                mainWindow.MostrarPagina(new IniciarSesion());
            }
            else
            {
                MessageBox.Show("El código de validación es incorrecto o ha expirado.");
            }
        }

        private string HashContrasenia(string contrasenia)
        {
            using (System.Security.Cryptography.SHA256 sha256Hash = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(contrasenia));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
