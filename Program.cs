using System.Globalization;
using SALlIQUIDO2.Entities;
using SALlIQUIDO2.Entities.Enums;

namespace SALlIQUIDO2
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Digite o nome do departamento: ");
            string deptNome = Console.ReadLine();
            Console.WriteLine("Insira os dados do trabalhador:");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Nível: (Junior/MidLevel/Senior): ");
            NivelTrabalhador nivel = Enum.Parse<NivelTrabalhador>(Console.ReadLine());
            Console.Write("Salário Base: ");
            double salarioBase = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Departamento dept = new Departamento(deptNome);
            Trabalhador trabalhador = new Trabalhador(nome, nivel, salarioBase, dept);

            Console.Write("Quantos contratos de trabalho? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Insira os dados do #{i}° contrato");
                Console.Write($"Data (Dia/Mês/Ano): ");
                DateTime data = DateTime.Parse(Console.ReadLine());
                Console.Write("Valor por hora: ");
                double valorPorHora = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duração (horas): ");
                int horas = int.Parse(Console.ReadLine());
                ContratoPorHora contrato = new ContratoPorHora(data, valorPorHora, horas);
                trabalhador.AdicionarContrato(contrato);
            }

            Console.WriteLine();
            Console.Write($"Insira o mês e ano para calcular a renda (Mês/Ano): ");
            string mesAno = Console.ReadLine();
            int mes = int.Parse(mesAno.Substring(0, 2));
            int ano = int.Parse(mesAno.Substring(3));
            Console.WriteLine($"Nome: {trabalhador.Nome} ");
            Console.WriteLine($"Departamento: {trabalhador.Departamento.Nome} ");
            Console.WriteLine("Renda do (Mês/Ano) " + mesAno + ": " + trabalhador.Renda(ano, mes).ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}