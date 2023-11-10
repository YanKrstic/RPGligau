using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPGligau.TodosPersonagens;
using PPGligau.TodosPersonagens.Classes;
using PPGligau.enums;
using PPGligau;

namespace PPGligau
{
    internal class GameplayFuncs
    {
        public static void AtaqueDePara(Personagem per , Personagem ini)
        {
            ini.classe.ReceberAtaque(per.classe.ValorAtaque());
        }
        public static void Regenerar(Personagem per)
        {
            int regen = per.classe.ValorRegeneracao();
            if ((regen + per.classe.vida) >= per.classe.vidaMax) 
            {
                per.classe.vida = per.classe.vidaMax;
            }
            else
            {
                per.classe.vida += regen;
            }
        }
        public static void Print(Personagem per, Personagem ini)
        {
            Console.WriteLine($"{per.nome} vs {ini.nome}");
            Console.WriteLine(new string(' ',per.nome.Length + 2),"");
            Console.WriteLine($"            |           ");
            Console.WriteLine($"            |           ");
            Console.WriteLine($"");
            Console.WriteLine($"");
            Console.WriteLine($"");
        }
    }
}
