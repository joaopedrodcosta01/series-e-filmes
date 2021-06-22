using System;

namespace Serie_e_Filme
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string OpcaoUsuario = ObterOpcaoUsuario();

            while(OpcaoUsuario.ToUpper() != "X")
            {
                switch(OpcaoUsuario)
                {
                    case "1":
                    ListarSF();
                    break;

                    case "2":
                    InserirSF();
                    break;

                    case "3":
                    AtualizarSF();
                    break;

                    case "4":
                    ExcluirSF();
                    break;

                    case "5":
                    VisualizarSF();
                    break;
                    case "C":
                    Console.Clear();
                    break;


                    default:
                    throw new ArgumentOutOfRangeException();
                }

                OpcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("------------------------");
            Console.WriteLine("|Series&Filmes a ordem!|");
            Console.WriteLine("------------------------");
            Console.WriteLine();

            Console.WriteLine("Informe a sua opção desejada:");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("1 - Listar Séries/Filmes");
            Console.WriteLine("2 - Adicionar uma nova Série/Filme");
            Console.WriteLine("3 - Atualizar Série/Filme");
            Console.WriteLine("4 - Excluir Série/Filme");
            Console.WriteLine("5 - Visualizar Série/Filme");
            Console.WriteLine("C - Limpar sua Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string OpcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return OpcaoUsuario;
        }



        private static void ListarSF()
        {
            Console.WriteLine("Listar Séries&Filmes");

            var Lista = repositorio.Lista();

            if(Lista.Count == 0)
            {
                Console.WriteLine("Nenhum(a) Série&Filme cadastrada. :-(");
                return;
            }

            foreach(var serie in Lista)
            {
                var excluido = serie.retornaExcluido();

                Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluido*" : ""));
            }
        } 

        private static void InserirSF()
        {
            Console.WriteLine("Inserir nova Série/Filme");

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            
            Console.Write("Digite se é Serie ou Filme: ");
            string SerieOuFilme = Console.ReadLine();
            
            Console.Write("Digite o titulo da Serie/Filme: ");
            string EntradaTitulo = Console.ReadLine();

            Console.Write("Qual o tempo da sua Serie/Filme? (Em minutos)");
            float Tempo = float.Parse(Console.ReadLine());

            Console.Write("Digite o ano de Inicio: ");
            int EntradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        SerieOuFilme: SerieOuFilme,
                                        Tempo: Tempo,
                                        titulo: EntradaTitulo,
                                        ano: EntradaAno,
                                        descricao: entradaDescricao);
            repositorio.Insere(novaSerie);
        }

        private static void AtualizarSF()
        {
            Console.Write("Digite o ID da Série/Filme: ");
            int indiceSF = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("É uma série ou um filme? ");
            string SerieOuFilme = Console.ReadLine();

            Console.Write("Digite o Título da Serie/Filme: ");
            string EntradaTitulo = Console.ReadLine();

            Console.Write("Qual o tempo da sua Serie/Filme? (Em minutos)");
            float Tempo = float.Parse(Console.ReadLine());

            Console.Write("Digite o ano de inicio: ");
            int EntradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSF = new Serie(
                                            id: indiceSF,
                                            genero: (Genero) entradaGenero,
                                            SerieOuFilme: SerieOuFilme, 
                                            titulo: EntradaTitulo,
                                            Tempo: Tempo,
                                            ano: EntradaAno,
                                            descricao: entradaDescricao);

            repositorio.Atualiza(indiceSF, atualizaSF);

        }

        private static void ExcluirSF()
        {
            Console.Write("Digite o ID da Série/Filme: ");
            int indiceSF = int.Parse(Console.ReadLine());

            Console.WriteLine("Você tem certeza que deseja excluir?");
            Console.WriteLine("1 - Sim");
            Console.WriteLine("2 - Não");

            int opcao = int.Parse(Console.ReadLine());
            switch(opcao)
            {
                case 1:
                repositorio.Exclui(indiceSF);
                break;
            }

           
        }

        private static void VisualizarSF()
        {
            Console.Write("Digite o ID: ");
            int indiceSF = int.Parse(Console.ReadLine());
        
            var serie = repositorio.retornaPorId(indiceSF);

            Console.WriteLine(serie);
        }
    }
}
