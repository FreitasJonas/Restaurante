using Restaurante.modelos;
using System.Collections.Generic;

namespace Restaurante.access
{
    public interface IDao
    {
        Usuario ValidaUsuario(string Login, string Senha);
        List<Porcao> ListarPorcoes();
        Porcao PegaPorcao(int porcaoId);
        int AtualizaPorcao(Porcao porcao);
        void InserePorcao(Porcao porcao);
        void InsereRefeicao(Refeicao refeicao);
    }
}
