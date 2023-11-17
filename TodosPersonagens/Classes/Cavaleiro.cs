using System;
using System.Collections.Generic;

namespace PPGligau.TodosPersonagens.Classes
{
    internal class Cavaleiro : ClasseBase
    {
        public Cavaleiro(

           int vida = 150,
           int vidaMax = 150,
           int id = 1,
           int danon = 10,
           int danoc = 30,
           int regenMin = 15,
           int regenMax = 30,
           int chanceDano = 1
          
           ) : base(vida,vidaMax, danon, danoc,regenMin,regenMax, chanceDano, id) { }
        public Cavaleiro() { }

        public override void FuncCavaleiro1()
        {
            Console.WriteLine("foiii");
        }


    }
}
