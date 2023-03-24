using Hotel.Models;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

//Neste LAB foi proposto um desafio para construir um sistema de hospedagem,
//que será usado para realizar uma reserva em um hotel.
//Você precisará usar a classe Pessoa, que representa o hóspede, a classe Suíte, e a classe Reserva, que fará um relacionamento entre ambos.
//Seu programa deverá calcular corretamente os valores dos métodos da classe Reserva, que precisará trazer a quantidade de hóspedes e o valor da diária concedendo um desconto de 10% para caso a reserva seja para um período maior que 10 dias.

List<Reserva> listaDeReserva = new List<Reserva>();
bool condicao = true;
int opcao = 0;

while (condicao)
{

    Console.WriteLine("Menu Hotel:");
    Console.WriteLine("1 - Fazer Reserva");
    Console.WriteLine("2 - Obter Quantidade de Hospedes");
    Console.WriteLine("3 - Consultar Reserva");
    Console.WriteLine("4 - Sair");

    try
    {
        opcao = Convert.ToInt32(Console.ReadLine());
    }
    catch (Exception ex)
    {
        Console.WriteLine($"erro: {ex.Message}");
    }

    switch (opcao)
    {
        case 1:
            Console.WriteLine("RESERVA:");
            Console.WriteLine();

            Console.WriteLine("Suite: ");
            Console.WriteLine();

            Console.WriteLine("ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Tipo da Suite: ");
            string tipoSuite = Console.ReadLine();

            Console.WriteLine("Capacidade: ");
            int capacidade = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Valor da Diaria: ");
            decimal valorDiaria = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Dias Reservados: ");
            int diasReservados = Convert.ToInt32(Console.ReadLine());

            Suite suite = new Suite(tipoSuite, capacidade, valorDiaria);



            var reserva = new Reserva(id, suite, diasReservados);

            try 
            { 
                listaDeReserva.Add(reserva); 
            }
            catch(Exception ex) 
            {
                throw new ArgumentException(ex.Message);
            }
            

            Console.WriteLine();
            Console.WriteLine("Hospedes:");
            Console.WriteLine();
            Console.WriteLine("Quantidade de hospedes para reserva: ");
            int quantidadeHospedes = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            for (int i = 0; i < quantidadeHospedes; i++)
            {

                Console.WriteLine("Nome: ");
                string nome = Console.ReadLine();
                Console.WriteLine("Sobrenome: ");
                string sobrenome = Console.ReadLine();
                Console.WriteLine();

                Pessoa hospede = new Pessoa(nome, sobrenome);
                reserva.AdicionarHospede(hospede);
            }

            
            var numeroHospedes = reserva.ObterQuantidadeHospedes();
            var valorTotal = reserva.CalcularValorTotalReserva();
            Console.WriteLine("numero de hospedes da reserva:");
            Console.WriteLine(numeroHospedes);

            Console.WriteLine("valor total da reserva:");
            Console.WriteLine(valorTotal);

            break;

        case 2:
            int k = listaDeReserva.Count;
            int totalHospedes = 0;
            for (int i = 0; i < k; i++)
            {

                totalHospedes += listaDeReserva[i].ObterQuantidadeHospedes();
            }
            Console.WriteLine(totalHospedes);
            break;

        case 3:
            foreach (var item in listaDeReserva)
            {
                Console.WriteLine(item);
            }
            break;

        case 4:
            Console.WriteLine("Finalizando programa!");
            condicao = false;
            break;

        default:
            Console.WriteLine("Opção invalida");
            break;

    }
}
