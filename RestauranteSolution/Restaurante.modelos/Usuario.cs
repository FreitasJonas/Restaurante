using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.modelos
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string UsuarioNome { get; set; }
        public string UsuarioLogin { get; set; }
        public int UsuarioPerfil { get; set; }

        public string UsuarioSenha { get; set; }
        public string UsuarioEmail { get; set; }
        public string UsuarioTelefone { get; set; }
        public DateTime UsuarioCadastro { get; set; }
        public DateTime UsuarioUltimoAcesso { get; set; }
    }
}
