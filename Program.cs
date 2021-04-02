using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string OpcaoUsuario = ObterOpcaoUsuario();
            while(OpcaoUsuario != "X") 
            {
                switch(OpcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentException();
                }

                OpcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static void VisualizarSerie() 
        {
            Console.WriteLine("Digite o id da série que deseja visualizar:");
            int opcaoId = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(opcaoId);

            Console.WriteLine(serie);
        }
        
        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o ID da série que deseja excluir: ");
            int id = int.Parse(Console.ReadLine());
            Serie serie = repositorio.RetornaPorId(id);
            Console.WriteLine("Deseja mesmo excluir a série {0}, ID: {1}?", serie.RetornaTitulo(), serie.RetornaId().ToString());
            Console.WriteLine("1 - Não");
            Console.WriteLine("2 - Sim");
            int opcao = int.Parse(Console.ReadLine());

            switch(opcao) 
            {
                case 1:
                    Console.WriteLine("Série não excluída.");
                    break;
                case 2:
                    repositorio.Exclui(id);
                    Console.WriteLine("Série excluída.");
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o ID da série que deseja atualizar: ");
            int opcaoId = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genero))) 
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de inicio da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie
            (
                id: opcaoId,
                genero: (Genero)entradaGenero,
                nome: entradaTitulo,
                ano: entradaAno,
                descricao: entradaDescricao
            );

            repositorio.Atualiza(opcaoId, atualizaSerie);
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");

            foreach(int i in Enum.GetValues(typeof(Genero))) 
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de inicio da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie
            (
                id: repositorio.ProximoId(),
                genero: (Genero)entradaGenero,
                nome: entradaTitulo,
                ano: entradaAno,
                descricao: entradaDescricao
            );

            repositorio.Insere(novaSerie);
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listando séries:");

            var lista = repositorio.Lista();

            if(lista.Count == 0) 
            { 
                Console.WriteLine("Lista sem cadastros!"); 
                Console.WriteLine(); 
            }
            
            foreach(var serie in lista)
            {
                var excluido = serie.RetornaExcluido();
                Console.WriteLine("ID: " + serie.RetornaId());
                Console.WriteLine("Título: " + serie.RetornaTitulo());
                Console.WriteLine("Excluido: " + (excluido ? "*Excluído*" : ""));
                Console.WriteLine();
            }
        }

        static string ObterOpcaoUsuario() 
        {
            Console.WriteLine("Informe a opção:");
            Console.WriteLine();
            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            string resposta = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return resposta;
        }
    
    }
}
