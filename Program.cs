
using System.Data;
using System.Security.AccessControl;

string mensagemDeBoasVindas = "Bem vindes ao MomoBooks\n";
string amorzinho1 = "Rafael";
string amorzinho2 = "Giovanna";
//List <string> listaDeLivros = new List<string>() { "Mitos do individualismo", "A metamorfose","Amanhã, Amanhã e outro Amanhã"};
//List <string> listaDeAutores = new List<string>();
Dictionary<string,List<int>> livrosInseridos = new Dictionary<string, List<int>>();
livrosInseridos.Add("Mitos do invidualismo",new List<int> { 7 } );
livrosInseridos.Add("A Metamorfose", new List<int> { });

void ExibirLogo()
{
    Console.WriteLine(@"
███╗░░░███╗░█████╗░███╗░░░███╗░█████╗░██████╗░░█████╗░░█████╗░██╗░░██╗░██████╗
████╗░████║██╔══██╗████╗░████║██╔══██╗██╔══██╗██╔══██╗██╔══██╗██║░██╔╝██╔════╝
██╔████╔██║██║░░██║██╔████╔██║██║░░██║██████╦╝██║░░██║██║░░██║█████═╝░╚█████╗░
██║╚██╔╝██║██║░░██║██║╚██╔╝██║██║░░██║██╔══██╗██║░░██║██║░░██║██╔═██╗░░╚═══██╗
██║░╚═╝░██║╚█████╔╝██║░╚═╝░██║╚█████╔╝██████╦╝╚█████╔╝╚█████╔╝██║░╚██╗██████╔╝
╚═╝░░░░░╚═╝░╚════╝░╚═╝░░░░░╚═╝░╚════╝░╚═════╝░░╚════╝░░╚════╝░╚═╝░░╚═╝╚═════╝░");
    Console.WriteLine(mensagemDeBoasVindas);
};


void ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("Tecle 1 para se identificar");
    Console.WriteLine("Tecle 2 para cadastrar um livro");
    Console.WriteLine("Tecle 3 para consultar um livro");
    Console.WriteLine("Tecle 4 para Avaliar um livro");
    Console.WriteLine("Tecle 5 para consultar a avaliação de um livro");
    Console.WriteLine("Tecle -1 para sair");
    Console.Write("\nDigite a opção desejada: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);


    switch (opcaoEscolhidaNumerica)
    {
        case 1:
            RegistrarUsuario();
            break;

        case 2:
            RegistrarLivro();
            break;

        case 3:
            ConsultarLivro();
            break;

        case 4:
            AvaliarLivro();
            break;


        case 5:
            ConsultarNota();
            break;

        case -1:
            Console.WriteLine("Tchau tchau :)");
            break;

        default:
            Console.WriteLine("A opção escolhida não é válida");
            Thread.Sleep(5000);
            Console.Clear();
            ExibirOpcoesDoMenu();
            break;

    }

}
void RegistrarUsuario()

{
    Console.Clear();
    ExibirCabecalho("Favor informar o amorzinho:");
    string nomeDoUsuario = Console.ReadLine()!;
    if (nomeDoUsuario == amorzinho1 || nomeDoUsuario == amorzinho2)

    {
        Console.Clear();
        Console.WriteLine($"Olá, {nomeDoUsuario}, você pode registrar ou avaliar um livro!");
        Thread.Sleep(5000);
        Console.Clear();
        ExibirOpcoesDoMenu();

    }

    else
    {
        Console.Clear();
        Console.WriteLine($"Poxa, {nomeDoUsuario}, você não tem acesso ao Momobooks!");
        Thread.Sleep(5000);
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
}

    void RegistrarLivro()
    {
        Console.Clear();
        ExibirCabecalho("Digite o nome do livro:");
        string nomeDoLivro = Console.ReadLine()!;
        livrosInseridos.Add(nomeDoLivro,new List<int>());
       //Console.Write("\nFavor informar o nome do autor: ");
        //string nomeDoAutor = Console.ReadLine()!;
        //listaDeAutores.Add(nomeDoAutor);
        Console.Clear() ;
        Console.WriteLine($"Parabéns, o livro {nomeDoLivro} foi cadastrado com sucesso");
        Thread.Sleep(5000);
        Console.Clear();
        ExibirOpcoesDoMenu();
    }

    void ConsultarLivro()
    {
    Console.Clear();
    ExibirCabecalho("Exibindo os livros Cadastrados:\n");
    foreach (string livro in  livrosInseridos.Keys)
    {
        Console.WriteLine($"Livro: {livro}");
    }
    Console.WriteLine("\nDigite qualquer tecla para voltar ao menu: ");

    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();

    }

void ExibirCabecalho(string titulo)
{
    int quantidadeDeLetras = titulo.Length;
    string asterisco = string.Empty.PadLeft(quantidadeDeLetras,'*');
    Console.WriteLine(asterisco);
    Console.WriteLine(titulo);
    Console.WriteLine(asterisco + "\n");
}

void AvaliarLivro()
{
    Console.Clear();
    ExibirCabecalho("Avalie o livro");
    Console.Write("Digite o nome do livro que quer analisar: ");
    string nomeDoLivro = Console.ReadLine()!;
    if (livrosInseridos.ContainsKey(nomeDoLivro))
    {
        Console.Write($"O livro {nomeDoLivro} merece qual nota?:");
        int nota = int.Parse(Console.ReadLine()!);
        livrosInseridos[nomeDoLivro].Add(nota);
        Console.WriteLine($"\nA nota {nota} para o livro {nomeDoLivro} foi registrada com sucesso\n");
        Thread.Sleep(3000);
        Console.Clear();
        ExibirOpcoesDoMenu();


    }
    else
    {
     Console.WriteLine($"O Livro {nomeDoLivro} não foi encontrado.");
     Console.WriteLine("Digite qualquer tecla para voltar ao Menu");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();

    }
}

void ConsultarNota()
{
    Console.Clear();
    ExibirCabecalho("Veja a média do livro");
    Console.Write("Digite o nome do livro que quer consultar: ");
    string nomeDoLivro = Console.ReadLine()!;
    if (livrosInseridos.ContainsKey(nomeDoLivro))
        {
        List<int> notasDosLivros = livrosInseridos[nomeDoLivro];
        Console.WriteLine($"\nA média do livro {nomeDoLivro} é {notasDosLivros.Average()}.");
        }
    else
    {
        Console.WriteLine($"O livro {nomeDoLivro} não está cadastrado.");
        Console.WriteLine("Digite qualquer tecla para voltar ao Menu");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();

    }

    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();


}

ExibirOpcoesDoMenu();



    









