using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System;
namespace ControleProdutosQ3.Models
{
    //[indexer(nameof)]
    public class ProdutoModel
    {
        //[Index(nameof(CodigoDeBarras), IsUnique = true)]
        public int Id { get; set; }

        [RegularExpression(@"^[0-9]+$", ErrorMessage ="Este campo aceita somente numeros")]
        [Required]
        [StringLength(12, MinimumLength = 12,
            ErrorMessage= "Minimo de 12 Caracteres")]
        public string CodigoDeBarras { get; set; }

        //[RegularExpression(@"^[A-Z] + [a-zA-Z\s]*$")]
        public string Descricao { get; set; }

        //[Range(typeof(DateTime), minimum: "23/08/2023", maximum: "24/8/2024")]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        public DateTime? DataValidade { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DataDeRegistro { get; set; }
        [Range(1, 1000)]
        [Required(ErrorMessage = "Campo Obrigatório")]
 
        public int Quantidade { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Valor { get; set; }
     
        [MaybeNull]
        public string? NomeDaFoto { get; set; }
        [MaybeNull]

        public byte[]? Foto { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public bool Ativo { get; set; }
    }
}
