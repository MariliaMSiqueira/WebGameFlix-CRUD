using System;


namespace DesafioDIO
{
    class Program
    {
        static GameRepositorio repositorio = new GameRepositorio();
        static void Main(string[] args)
        {
           string opcaoUsuario = ObterOpcaoUsuario();
           while (opcaoUsuario.ToUpper() != "X") {
               switch (opcaoUsuario) {
                   case "1":
                   ListarGames();
                   break;

                   case "2":
                   InserirGame();
                   break;

                   case "3":
                  AtualizarGame();
                   break;

                   case "4":
                   ExcluirGame();
                   break;

                   case "5":
                   VisualizarGame();
                   break;

                   case "C":
                   Console.Clear();
                   break;
                   
                   default:
                        throw new ArgumentOutOfRangeException(); }

                    opcaoUsuario = ObterOpcaoUsuario();
               
           }
        }

        private static void VisualizarGame()
        {
            Console.Write("Digite o ID do jogo: ");
            int indiceGame = int.Parse(Console.ReadLine());

            var game = repositorio.RetornaPorId(indiceGame);

            Console.WriteLine(game);
        }

            private static void ExcluirGame()
            {
                Console.Write("Digite o ID do jogo: ");
                
                int indiceGame = int.Parse(Console.ReadLine());

                repositorio.Exclui(indiceGame);
            }
           private static void AtualizarGame()
           {
               Console.Write("Digite o ID do jogo: ");
               int indiceGame = int.Parse(Console.ReadLine());

               foreach (int i in Enum.GetValues(typeof(Genero)))
               {
                   Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
               }

                Console.WriteLine();

               Console.Write("Digite o gênero entre as opções acima: ");
               int entradaGenero = int.Parse(Console.ReadLine());

               foreach (int i in Enum.GetValues(typeof(Plataforma)))
               {
                   Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Plataforma), i));
               }
               
               Console.WriteLine();

               Console.Write("Digite a plataforma entre as opções acima: ");
               int entradaPlataforma = int.Parse(Console.ReadLine());

                Console.WriteLine();

               Console.Write("Digite o nome do jogo: ");
               string entradaNome = Console.ReadLine();

               Console.WriteLine();

               Console.Write("Digite a data de lançamento (dd/mm/aaaa): ");
               DateTime entradaAno = DateTime.Parse(Console.ReadLine());

               Console.WriteLine();

               Console.Write("Digite a descrição do jogo: ");
               string entradaDescricao = Console.ReadLine();

               Console.WriteLine();

               Console.Write("Digite o estúdio responsável pelo jogo: ");
               string entradaEstudio = Console.ReadLine();

               Games atualizaGame = new Games(id: indiceGame,
                                              genero: (Genero)entradaGenero,
                                              nome: entradaNome,
                                              data_lancamento: entradaAno,
                                              descricao: entradaDescricao,
                                              plataforma: (Plataforma)entradaPlataforma,
                                              estudio: entradaEstudio);
                repositorio.Atualiza(indiceGame, atualizaGame);

           }
           private static void ListarGames() {
               Console.WriteLine("Listar jogos");

               var lista = repositorio.Lista();

               if (lista.Count == 0){
                   Console.WriteLine("Nenhum jogo cadastrado.");
               }

               foreach (var game in lista) {
                
                   var excluido = game.retornaExcluido();
                   Console.WriteLine("#ID {0}: - {1} {2}", game.retornaId(), game.retornaNome(), (excluido ? "*Excluído/Indisponível*" : ""));
               }
           }

           private static void InserirGame(){
               Console.WriteLine("Inserir novo jogo.");

               foreach (int i in Enum.GetValues(typeof(Genero)))
               {
                   Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
               }

                 Console.WriteLine();

                Console.Write("Digite o gênero entre as opções acima: ");
                int entradaGenero = int.Parse(Console.ReadLine());

                foreach (int i in Enum.GetValues(typeof(Plataforma)))
                {
                    Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Plataforma), i));
                }

                 Console.WriteLine();

                Console.Write("Digite a plataforma entre as opções acima: ");
                int entradaPlataforma = int.Parse(Console.ReadLine());

                Console.WriteLine();

                Console.Write("Digite o nome do jogo: ");
                string entradaNome = Console.ReadLine();

                 Console.WriteLine();

                Console.Write("Digite a data de lançamento (dd/mm/aaaa): ");
                DateTime entradaAno = DateTime.Parse(Console.ReadLine());

                 Console.WriteLine();

                Console.Write("Digite a descrição do jogo: ");
                string entradaDescricao = Console.ReadLine();

                 Console.WriteLine();

                Console.Write("Digite o estúdio responsável pelo jogo: ");
                string entradaEstudio = Console.ReadLine();

                Games novoGame = new Games(id: repositorio.ProximoId(),
                                            genero: (Genero)entradaGenero,
                                            nome: entradaNome,
                                            data_lancamento: entradaAno,
                                            descricao: entradaDescricao,
                                            estudio: entradaEstudio,
                                            plataforma:(Plataforma) entradaPlataforma);

                repositorio.Insere(novoGame);
           }
        
        private static string ObterOpcaoUsuario() {
            Console.WriteLine();
            Console.WriteLine("Bem vindo ao WebGameFlix!");
            Console.WriteLine();
            Console.WriteLine("Prazer imenso em proporcionar a solução certa para o seu problema!");
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1 - Listar jogos disponíveis.");
            Console.WriteLine("2 - Inserir um novo jogo.");
            Console.WriteLine("3 - Atualizar jogo.");
            Console.WriteLine("4 - Excluir um jogo.");
            Console.WriteLine("5 - Visualizar um jogo específico.");
            Console.WriteLine("C - Limpar Tela.");
            Console.WriteLine("X - Sair");
            Console.WriteLine();
            

        string opcaoUsuario = Console.ReadLine().ToUpper();
        Console.WriteLine();
        return opcaoUsuario;
        }
    }
}
