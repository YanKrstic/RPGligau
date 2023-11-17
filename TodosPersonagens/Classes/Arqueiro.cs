using System;
using System.Collections.Generic;

namespace PPGligau.TodosPersonagens.Classes
{
    internal class Arqueiro : ClasseBase
    {
        public Arqueiro(

           int vida = 90,
           int vidaMax = 90,
           int id = 2,
           int danon = 30,
           int danoc = 40,
           int regenMin = 10,
           int regenMax = 15,
           int chanceDano = 4

           ) : base(vida,vidaMax, danon, danoc,regenMin,regenMax, chanceDano, id) { }

        public Arqueiro() { }


    }
}
