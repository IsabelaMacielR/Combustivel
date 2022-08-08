using System;

namespace Combustivel.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public string Placa { get; set; }
        public string Chassi { get; set; }
        public string Ano { get; set; }
        public string Cor { get; set; }
        public string Horimetro { get; set; }
        public string Km { get; set; }
        public string Combustivel { get; set; }
        public string Secretaria { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Vencimento { get; set; }
        public string Categoria { get; set; }
        public string Tipo { get; set; }
        public string Veiculo { get; internal set; }
    }
}