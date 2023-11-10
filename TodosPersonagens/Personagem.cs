using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPGligau.TodosPersonagens.Classes;


namespace PPGligau.TodosPersonagens
{
    internal class Personagem
    {
        public string nome = "vazio";
        public long denero;
        public int nivel;
        public ClasseBase classe;
        public List<Itens> iventario = new List<Itens>();


        public Personagem(string nome, int denero, ClasseBase classe, int nivel,List<Itens> iventario)
        {
            this.nome = nome;
            this.denero = denero;
            this.classe = classe;
            this.nivel = nivel;
            this.iventario = iventario;
        }
        public Personagem() { }

        public override string ToString()
        {
            return $"Nome: {nome},Vida: {classe.vida}, Dano[{classe.danon} - {classe.danoc},Chance: {classe.chanceDano}, id: {classe.id}],Denero: {denero}, Nivél: {nivel}";
        }
        // Equals e HashCode
        public override bool Equals(object? obj)
        {
            if (!(obj is Personagem))
            {

                return false;
            }
            Personagem other = obj as Personagem;
            return classe.vida.Equals(other.classe.vida);
        }
        public override int GetHashCode()
        {
            return classe.vida.GetHashCode();
        }


    }
}
