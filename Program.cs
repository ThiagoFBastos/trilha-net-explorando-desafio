using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

Suite CriaSuite()
{
    Console.Write("Tipo suite: ");
    string tipoSuite = Console.ReadLine();

    Console.Write("Capacidade: ");
    int capacidade = int.Parse(Console.ReadLine());

    Console.Write("Valor da diária: ");
    decimal valorDiaria = decimal.Parse(Console.ReadLine());

    return new Suite(tipoSuite, capacidade, valorDiaria);
}

List<Pessoa> CriaListaDePessoas()
{
    List<Pessoa> pessoas = new List<Pessoa>();

    Console.Write("Quantidade de pessoas: ");
    int quantidade = int.Parse(Console.ReadLine());

    for(int i = 0; i < quantidade; ++i)
    {
        Console.Write("Nome: ");
        string nome = Console.ReadLine();

        Console.Write("Sobrenome: ");
        string sobrenome = Console.ReadLine();

        if(sobrenome.Length > 0)
            pessoas.Add(new Pessoa(nome, sobrenome));
        else
            pessoas.Add(new Pessoa(nome));
    }

    return pessoas;
}

bool Menu()
{
    try
    {

        Console.Write("Digite [s/n] para terminar a execução: ");
        string entrada = Console.ReadLine();

        if(entrada.ToLower() == "s")
            return false;

        Console.WriteLine("Cadastre a suíte:");
        Suite suite = CriaSuite();

        Console.WriteLine("Cadastre os hóspedes:");
        var hospedes = CriaListaDePessoas();

        Console.Write("Dias reservados: ");
        int diasReservados = int.Parse(Console.ReadLine());

        Reserva reserva = new Reserva(diasReservados);

        reserva.CadastrarSuite(suite);
        reserva.CadastrarHospedes(hospedes);

        Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
        Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Um erro acabou de acontecer: {ex.Message}");
    }

    return true;
}

while(Menu());