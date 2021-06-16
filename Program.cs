using System;
using System.Globalization;
using LogicaPagamentosJuros.Entities;
using LogicaPagamentosJuros.Services;


namespace LogicaPagamentosJuros
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter contract data");
                Console.Write("Number: ");
                int contractNumber = int.Parse(Console.ReadLine());
                Console.Write("Date (dd/MM/yyyy): ");
                DateTime contractDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                Console.Write("Contract value: ");
                double contractValue = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Enter number of installments: ");
                int months = int.Parse(Console.ReadLine());


                Contrato myContract = new Contrato(contractNumber, contractDate, contractValue);

                ContratoDeService contractService = new ContratoDeService(new ParcelService());
                contractService.ProcessContract(myContract, months);

                Console.WriteLine("Installments:");
                foreach (Parcelas installment in myContract.Parcelas)
                {
                    Console.WriteLine(installment);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
