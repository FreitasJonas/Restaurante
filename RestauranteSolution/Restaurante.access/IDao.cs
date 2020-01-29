using Restaurante.modelos;

namespace Restaurante.access
{
    public interface IDao
    {
        Usuario ValidaUsuario(string Login, string Senha);
    }
}
