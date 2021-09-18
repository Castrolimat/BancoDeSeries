using System;

namespace primeiroProjeto
{
    class Program
    {
        static serieRepositorio repositorio = new serieRepositorio();
        static void Main(string[] args)
        {

           string opcaoUsuario = obterOpcaoUsuario();

           while (opcaoUsuario.ToUpper() !="X")
           {
               switch (opcaoUsuario)
               {
                    case "1":
                        listarSeries();
                        break;
                    case "2":
                        inserirSerie();
                        break;
                    case "3":
                        atualizarSerie();
                        break;
                    case "4":
                        excluirSerie();
                        break;
                    case "5":
                        visualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                   default:
                        throw new ArgumentOutOfRangeException();
               }
               opcaoUsuario = obterOpcaoUsuario();
           }



        }
    

    private static void excluirSerie()
    {
        Console.Write("Digite o id da série: ");
        int indiceSerie = int.Parse(Console.ReadLine());
        
        repositorio.exclui(indiceSerie);
    }

    private static void visualizarSerie()
    {
        Console.Write("Digite o id da série: ");
        int indiceSerie = int.Parse(Console.ReadLine());

        var serie = repositorio.retornaPorId(indiceSerie);

        Console.WriteLine(serie);
    }

    private static void atualizarSerie()
    {
        Console.Write("Digite o id da série que deseja atualizar: ");
        int indiceSerie = int.Parse(Console.ReadLine());

        foreach(int i in Enum.GetValues(typeof(genero)))
        {
            Console.WriteLine("{0}-{1}", i,Enum.GetName(typeof(genero),i));
        }

        Console.Write("Digite o genêro entre as opções acima: ");
        int entradaGenero = int.Parse(Console.ReadLine());

        Console.Write("Digite o nome da série: ");
        string entradaTitulo = Console.ReadLine();

        Console.Write("Digite o ano de inicio da série: ");
        int entradaAno =  int.Parse(Console.ReadLine());

        Console.Write("Digite a descrição da série: ");
        string entradaDescricao = Console.ReadLine();

        serie atualizaSerie = new serie (id: indiceSerie,
                                         genero: (genero)           entradaGenero,
                                          titulo: entradaTitulo,
                                          ano: entradaAno,
                                          descricao: entradaDescricao );
        
        repositorio.atualiza(indiceSerie,atualizaSerie);
    }
       


    private static void listarSeries()
    {
        Console.WriteLine("Listar séries");

        var lista = repositorio.lista();

        if(lista.Count == 0)
        {
            Console.WriteLine("Desculpe, não há nenhuma série cadastrada.");
            return;
        }
        
        foreach (var serie in lista)
        {
            var excluido = serie.retornaExcluido();


            Console.WriteLine("#ID {0}: - {1} - {2}", serie.retornaId(),serie.retornaTitulo(),(excluido ? "Excluido" : ""));
        }
    }

    private static void inserirSerie()
    {
        Console.WriteLine("Inserir nova série");

        foreach (int i in Enum.GetValues(typeof(genero)))
        {
            Console.WriteLine("{0} - {1}",i,Enum.GetName(typeof(genero),i));
        }

        Console.WriteLine("Escolha o gênero da série: ");
        int entradaGenero = int.Parse(Console.ReadLine());

        Console.WriteLine("Digite o nome da série: ");
        string entradaTitulo = Console.ReadLine();

        Console.WriteLine("Digite o Ano de inicio da Série: ");
        int entradaAno = int.Parse(Console.ReadLine());

        Console.WriteLine("Digite a descrição da série: ");
        string entradaDescricao = Console.ReadLine();

        serie novaSerie = new serie (id: repositorio.proximoId(),
                                    genero: (genero)entradaGenero,
                                    titulo: entradaTitulo,
                                    ano: entradaAno,
                                    descricao: entradaDescricao);

        repositorio.insere(novaSerie);
    }
    private static string obterOpcaoUsuario()
    {
        Console.WriteLine();
        Console.WriteLine("Seja bem vindo ao Banco de Séries!");
        Console.WriteLine("Informe a opção desejada: ");

        Console.WriteLine("1- Listar séries");
        Console.WriteLine("2- Inserir nova série");
        Console.WriteLine("3- Atualizar série");
        Console.WriteLine("4- Excluir série");
        Console.WriteLine("5- Visualizar série");
        Console.WriteLine("C- Limpar Tela");
        Console.WriteLine("X -Sair");

        string OpcaoUsuario = Console.ReadLine().ToUpper();
        Console.WriteLine();
        return OpcaoUsuario;
    }
    
    
    }
}
