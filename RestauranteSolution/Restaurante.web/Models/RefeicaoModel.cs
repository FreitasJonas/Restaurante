using Restaurante.modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurante.web.Models
{
    public class RefeicaoModel
    {
        public int? RefeicaoId { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public int[] Porcoes { get; set; }

        public List<Porcao> _Porcoes { get; set; }

        public RefeicaoModel()
        {
            Porcoes = new int[5];
        }

        public static RefeicaoModel MapearParaModel(Refeicao refeicao)
        {
            var model = new RefeicaoModel();

            model.RefeicaoId = refeicao.RefeicaoId;
            model.Nome = refeicao.Nome;
            model.Descricao = refeicao.Descricao;
            model.Porcoes = refeicao.Porcoes;

            return model;
        }

        public Refeicao MapearParaObjeto(RefeicaoModel refeicaoModel)
        {
            var model = new Refeicao();

            model.RefeicaoId = refeicaoModel.RefeicaoId;
            model.Nome = refeicaoModel.Nome;
            model.Descricao = refeicaoModel.Descricao;
            model.Porcoes = refeicaoModel.Porcoes;

            return model;
        }
    }
}