using Restaurante.modelos;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Restaurante.web.Models
{
    public class PorcaoModel
    {
        [HiddenInput]
        public int PorcaoId { get; set; }

        [Display(Name = "Porção")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [DataType(DataType.Text)]
        public string Nome { get; set; }

        [Display(Name = "Peso")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public double Peso { get; set; }

        [Display(Name = "Valor")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [DataType(DataType.Currency)]
        public double Valor { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Descricao { get; set; }

        [Display(Name = "Imagem")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Imagem { get; set; }

        [Display(Name = "Cadastro")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [HiddenInput]
        public DateTime Cadastro { get; set; }

        public static PorcaoModel MapearParaModel(Porcao porcao)
        {
            var model = new PorcaoModel();

            model.PorcaoId = porcao.PorcaoId;
            model.Nome = porcao.Nome;
            model.Peso = porcao.Peso;
            model.Valor = porcao.Valor;
            model.Descricao = porcao.Descricao;
            model.Imagem = porcao.Imagem;
            model.Cadastro = porcao.Cadastro;

            return model;
        }

        public Porcao MapearParaObjeto(PorcaoModel porcaoModel)
        {
            var model = new Porcao();

            model.PorcaoId = porcaoModel.PorcaoId;
            model.Nome = porcaoModel.Nome;
            model.Peso = porcaoModel.Peso;
            model.Valor = porcaoModel.Valor;
            model.Descricao = porcaoModel.Descricao;
            model.Imagem = porcaoModel.Imagem;
            model.Cadastro = porcaoModel.Cadastro;

            return model;
        }
    }
}