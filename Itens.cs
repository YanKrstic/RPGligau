using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPGligau.enums;

namespace PPGligau
{
    internal class Itens
    {
        public string nome;
        public ItensRaridade raridade { get; set; }
        public ItensFuncao funcao { get; set; }

        public Itens(string nome, ItensRaridade raridade, ItensFuncao funcao)
        {
            this.nome = nome;
            this.raridade = raridade;
            this.funcao = funcao;
        }
        public override string ToString()
        {
            return $"{nome}:{raridade}:{funcao}";
        }
    }
}
