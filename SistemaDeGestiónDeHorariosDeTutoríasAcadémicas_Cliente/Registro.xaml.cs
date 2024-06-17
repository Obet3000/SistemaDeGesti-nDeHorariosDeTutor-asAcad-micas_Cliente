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
    public partial class Registro : Page, IServicioRegistroCallback
    {
        private IServicioRegistro servicioRegistro;

        public Registro()
        {
            InitializeComponent();
            servicioRegistro = new ServicioRegistroClient(new InstanceContext(this));
        }

        public void RegistrarUsuario()
        {
            try
            {
                UsuarioDTO usuario = new UsuarioDTO();
                usuario.Contrasenia = HashContrasenia(PBContrasenia.Password);
                usuario.NombreUsuario = TBMatricula.Text;
                usuario.Nombre = TBNombre.Text;
                usuario.ApellidoPaterno = TBApellidoPaterno.Text;
                usuario.ApellidoMaterno = TBApellidoMaterno.Text;
                string email = TBEmail.Text;

                if (ValidarCorreoElectronico(email))
                {
                    usuario.Correo = email;
                    if (PBContrasenia.Password == PBConfirmacionContrasenia.Password && ValidarContraseniaSegura(PBContrasenia.Password))
                    {
                        servicioRegistro.EnviarCodigoDeValidacion(usuario.Correo, usuario.Correo);
                        VentanaIngresaCodigoDeValidacion ventanaIngresaCodigoDeValidacion = new VentanaIngresaCodigoDeValidacion();
                        ventanaIngresaCodigoDeValidacion.ShowDialog();
                        if (ventanaIngresaCodigoDeValidacion.CodigoValidacion != -1)
                        {
                            servicioRegistro.ValidarCodigo(usuario, ventanaIngresaCodigoDeValidacion.CodigoValidacion);
                        }
                    }
                    else
                    {
                        MessageBox.Show("La contraseña debe tener una longitud mínima de 8 caracteres, incluir al menos una mayúscula, 1 minúscula y 1 signo");
                    }
                }
                else
                {
                    MessageBox.Show("El correo ingresado no es válido");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar al usuario: {ex.Message}");
            }
        }

        private bool ValidarContraseniaSegura(string contrasenia)
        {
            return Regex.IsMatch(contrasenia, @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*\W).{8,}$");
        }

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
        }

        private string HashContrasenia(string contrasenia)
        {
            using (System.Security.Cryptography.SHA256 sha256Hash = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(System.Text.Encoding.UTF8.GetBytes(contrasenia));
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
