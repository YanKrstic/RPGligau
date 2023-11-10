using System;
using System.IO;
using PPGligau;
using PPGligau.TodosPersonagens;
using PPGligau.TodosPersonagens.Classes;
using PPGligau.enums;


namespace RPGligau
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Personagem ini = new Personagem();
            ini.classe = new Arqueiro();

            Personagem per = new Personagem();

            //Personagem per2 = new Personagem();
            //per2.classe = new Cavaleiro();

            // verificando/criando as pastas

            string pastaDeTudo = @"C:\RPGligau_dados";

            if (!Directory.Exists(pastaDeTudo))
            {
                Directory.CreateDirectory(pastaDeTudo);
            }
            string pastaDePersonagens = @"C:\RPGligau_dados\Personagens";

            if (!Directory.Exists(pastaDePersonagens))
            {
                Directory.CreateDirectory(pastaDePersonagens);
            }

            void SalvarPersonagem(Personagem perso)
            {
                string inventarioSt = "";
                int cont = 0;
                foreach (Itens it in perso.iventario)
                {
                    if (cont == 0)
                    {
                        inventarioSt += $"{it.ToString()}";
                    }
                    else
                    {
                        inventarioSt += $";{it.ToString()}";
                    }
                    ++cont;
                }

                File.WriteAllText($"C:\\RPGligau_dados\\Personagens\\{perso.nome}.txt",
                    $"{perso.classe.id},{perso.classe.vida},{perso.classe.vidaMax},{perso.classe.danon},{perso.classe.danoc},{perso.classe.regenMin},{perso.classe.regenMax},{perso.classe.chanceDano},{perso.denero},{perso.nivel},{inventarioSt}");

            }
            void PrintInventario(Personagem p)
            {
                Console.WriteLine("iventario:");
                foreach (Itens it in p.iventario)
                {
                    Console.WriteLine(it.nome);
                }
            }

            // onde começa os inputs

            Console.WriteLine("Escolha seu personagem:");
            Console.WriteLine();

            string[] arquivos = Directory.GetFiles(pastaDePersonagens);
            int contark = 0;
            foreach (string ark in arquivos)
            {
                Console.WriteLine($"[{contark + 1}] - {ark.Replace(@"C:\RPGligau_dados\Personagens\", "").Replace(".txt", "")}");
                contark++;
            }

            Console.WriteLine($"[{contark + 1}] - Criar personagemm");
            int criarper = contark + 1;

            Console.Write("[R: ");
            int escolha = int.Parse(Console.ReadLine());
            Console.WriteLine();

            if (escolha != criarper)
            {
                // atribuindo os dados salvos
                string[] dados = File.ReadAllText(arquivos[escolha - 1]).Split(",");

                if (int.Parse(dados[0]) == 1)
                {
                    per.classe = new Cavaleiro();
                }
                if (int.Parse(dados[0]) == 2)
                {
                    per.classe = new Arqueiro();
                }

                per.nome = arquivos[escolha - 1].Replace(@"C:\RPGligau_dados\Personagens\", "").Replace(".txt", "");
                per.classe.vida = int.Parse(dados[1]);
                per.classe.vidaMax = int.Parse(dados[2]);
                per.classe.danoc = int.Parse(dados[3]);
                per.classe.danoc = int.Parse(dados[4]);
                per.classe.regenMin = int.Parse(dados[5]);
                per.classe.regenMax = int.Parse(dados[6]);
                per.classe.chanceDano = int.Parse(dados[7]);
                per.denero = long.Parse(dados[8]);
                per.nivel = int.Parse(dados[9]);
                // tratamento inventario

                string[] itensSt = dados[10].Split(";");

                foreach (string it in itensSt)
                {
                    string[] dadosIt = it.Split(":");

                    var raridade = ItensRaridade.raro;
                    switch (dadosIt[1])
                    {
                        case "lixo": raridade = ItensRaridade.lixo; break;
                        case "comum": raridade = ItensRaridade.comum; break;
                        case "raro": raridade = ItensRaridade.raro; break;
                        case "impossivel": raridade = ItensRaridade.impossivel; break;
                    }
                    var funcao = ItensFuncao.ataque;
                    switch ((string)dadosIt[2])
                    {
                        case "ataque": funcao = ItensFuncao.ataque; break;
                        case "defesa": funcao = ItensFuncao.defesa; break;
                        case "chanceAtaque": funcao = ItensFuncao.chanceAtaque; break;
                        case "chanceDefesa": funcao = ItensFuncao.chanceDefesa; break;

                    }
                    per.iventario.Add(new Itens(dadosIt[0], raridade, funcao));
                }


                Console.WriteLine();


            } //criando per
            else if (escolha == criarper)
            {

                // criar personagen 
                Console.WriteLine("Escolha sua classe:");

                while (true)
                {
                    int des = 0;

                    Console.WriteLine("[1] - Cavalheiro");
                    Console.WriteLine("[2] - Arqueiro");
                    Console.Write("[R: ");

                    try
                    {
                        des = int.Parse(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Nelhuma Classe corresponde a essa opção! ");
                        Console.WriteLine("Escolha sua classe novamente:");
                        continue;
                    }
                    switch (des)
                    {
                        case 1:
                            per.classe = new Cavaleiro();
                            break;
                        case 2:
                            per.classe = new Arqueiro();
                            break;
                        default:
                            Console.WriteLine();
                            Console.WriteLine("Nelhuma Classe corresponde a essa opção! ");
                            Console.WriteLine("Escolha sua classe novamente:");
                            continue;
                    }
                    break;

                }

                // nomeando o personagem 
                Console.WriteLine();
                Console.WriteLine($"Qual ser o nome do seu Personagen?");
                Console.Write("R:");
                per.nome = Console.ReadLine();
                Console.WriteLine();


                per.iventario.Add(new Itens("teste", ItensRaridade.raro, ItensFuncao.defesa));
                per.iventario.Add(new Itens("machado sla", ItensRaridade.lixo, ItensFuncao.defesa));
                per.iventario.Add(new Itens("teste2", ItensRaridade.impossivel, ItensFuncao.ataque));
                per.iventario.Add(new Itens("teste3", ItensRaridade.raro, ItensFuncao.chanceAtaque));

                Console.WriteLine();
            }
            //Console.Clear();
            // SalvarPersonagem(per)

            // testes
            Console.WriteLine(per.ToString());
            Console.WriteLine();

            PrintInventario(per);


            Console.WriteLine();
            Console.WriteLine(ini.classe.vida);
            Console.WriteLine(per.classe.ValorAtaque());

            GameplayFuncs.AtaqueDePara(per, ini);  
            Console.WriteLine(ini.classe.vida);

            Console.WriteLine();
            GameplayFuncs.Regenerar(ini);
            Console.WriteLine(ini.classe.vida);

            Console.WriteLine();
            Console.WriteLine(ini.classe.vida);
            Console.WriteLine(per.classe.ValorAtaque());

            Console.WriteLine("---");
            GameplayFuncs.Print(per, ini);
            Console.WriteLine("---");



            Console.ReadLine();
            SalvarPersonagem(per);


            

        }
        
    }

}