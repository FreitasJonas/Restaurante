using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.modelos
{
    public class Porcao
    {
        public int PorcaoId { get; set; }

        public string Nome { get; set; }

        public double Peso { get; set; }

        public double Valor { get; set; }

        public string Descricao { get; set; }

        public string Imagem { get; set; }

        public DateTime Cadastro { get; set; }
    }
}
