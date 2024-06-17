public class UsuarioSingleton
{
    private static UsuarioSingleton _usuario;

    public int IdUsuario { get; set; }
    public string Correo { get; set; }
    public bool EstadoUsuario { get; set; }
    public string NombreUsuario { get; set; }
    public string Rol {  get; set; }
    private UsuarioSingleton() { }

    public static UsuarioSingleton ObtenerInstancia()
    {
        if (_usuario == null)
        {
            _usuario = new UsuarioSingleton();
        }
        return _usuario;
    }
}
