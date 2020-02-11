using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.modelos
{
    public class Refeicao
    {
        public int? RefeicaoId { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public int[] Porcoes { get; set; }

        public Refeicao()
        {
            Porcoes = new int[5];
        }
    }
}
