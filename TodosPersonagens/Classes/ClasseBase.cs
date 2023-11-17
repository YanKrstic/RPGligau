using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;

namespace PPGligau.TodosPersonagens.Classes
{
    internal class ClasseBase //: IComparable<ClasseBase>
    {
        // variaveis da classe 

        public int vida; // vida ne
        public int vidaMax; // vida maxima que o player tera (nao passara dela quando ele se curar), ela vai aumentar quando o player comprar um upgrade
        public int danon; // dano normal
        public int danoc; // dano critico
        public int regenMin; // regeneracao minima
        public int regenMax; // regeneracao maxima                     
        public int chanceDano; // chance que o dano critico sera escolhido  
        public int id = 0; // gambiarra pra saber de que classe o per é


        public int ValorAtaque()
        {
            Random r = new Random();
            int a = r.Next(1, chanceDano+1);

            if (a == 1) { return danoc; }

            else { return danon; }
        }
        public int ValorRegeneracao()
        {
            Random ra = new Random();
            int regen = ra.Next(regenMin, regenMax);
            return regen;
        }
        public void ReceberAtaque(int atk)
        {
            if (vida - atk <= 0)
            {
                vida = 0;
            }
            else
            {
                vida = vida - atk;
            }
            
        }
        public ClasseBase(int vida,int vidaMax, int danon, int danoc,int regenMin,int regenMax, int chanceDano ,int id)
        {
            this.vida = vida;
            this.vidaMax = vidaMax;
            this.danon = danon;
            this.danoc = danoc;
            this.chanceDano = chanceDano;
            this.regenMin = regenMin;
            this.regenMax = regenMax;
            this.id = id;

        }

        public ClasseBase() { }

        /*public T CompareTo<T>(ClasseBase other, T objComp)
        {
            if (!(other is ClasseBase))
            {
                throw new ArgumentException("aa");
            }
            return objComp.CompareTo(other.objComp);
        }
        */

    }
}
