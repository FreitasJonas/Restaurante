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

        [Display(Name = "Porção")]
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

        [Display(Name = "Imagem")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [HiddenInput]
        public DateTime Cadastro { get; set; }
    }
}