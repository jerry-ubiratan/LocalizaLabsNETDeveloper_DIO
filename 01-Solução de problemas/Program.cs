using System;

namespace sol
{
    class Program
    {
        static void Main(string[] args)
        {
            string opcao; 
            do {
                opcao = menu();
                switch (opcao)
                {
                    case "1":
                        calcConsulmoMedio();  
                        break;                    
                    case "2":
                        ListarCodigoDDD();                            
                        break;
                    case "3":
                        ProcessaNotasMoedas();
                        break;
                } ;

            }while (opcao != "X");


        }

        private static string menu()
        {
            Console.Clear();
            Console.WriteLine("Solução de Problemas em C#");
            Console.WriteLine("");
            Console.WriteLine("1 - Calculo de Consumo Médio");
            Console.WriteLine("2 - Listar Cidades e DDD");
            Console.WriteLine("3 - Notas e Moédas de um Valor");
            Console.WriteLine("X - Sair do Desafio");
            Console.WriteLine("");
            Console.Write("Digiter sua opção=> ");
            return Console.ReadLine().ToUpper();
                
        }

        // Calculo de Consumo médio 
        private static void calcConsulmoMedio()
        {
            Console.Clear();
            Console.WriteLine("Solução de Problemas em C# - Calculo de Consumo Médio ");
            Console.WriteLine();

            int distancia;
            double combustivelGasto, consumoMedio;

            Console.Write("Digite a Distancia => ");
            distancia = Convert.ToInt32(Console.ReadLine());
            Console.Write("Digite a quantidade de combustivel => ");
            combustivelGasto = Convert.ToDouble(Console.ReadLine());

            consumoMedio = distancia / combustivelGasto; 

            Console.WriteLine("O consumo médio é : {0:0.000} km/l", consumoMedio);
            Console.WriteLine();

            Console.Write("Digite qualquer tecla para continuar => ");
            Console.ReadLine();
        }



        private static void ListarCodigoDDD(){

            Console.Clear();
            Console.WriteLine("Solução de Problemas em C# - Consulta Cidade pelo DDD");
            Console.WriteLine();
            Console.Write("Digite o DDD => ");

            int ddd = Convert.ToInt32(Console.ReadLine());

            switch (ddd)
            {
                case 61:
                    Console.WriteLine("{0} - Brasilia", ddd);
                    break;
                case 71:                          
                    Console.WriteLine("{0} - Salvador", ddd);
                    break;
                case 11:
                    Console.WriteLine("{0} - Sao Paulo", ddd);
                    break;
                case 21:
                    Console.WriteLine("{0} - Rio de Janeiro", ddd);
                    break;
                case 32:
                    Console.WriteLine("{0} - Juiz de Fora", ddd);
                    break;
                case 19:
                    Console.WriteLine("{0} - Campinas", ddd);
                    break;
                case 27:
                    Console.WriteLine("{0} - Vitoria", ddd);
                    break;
                case 31:
                    Console.WriteLine("{0} - Belo Horizonte", ddd);
                    break;
                default:
                    Console.WriteLine("{0} - DDD nao cadastrado", ddd);
                    break;
            }

            Console.WriteLine();
            Console.Write("Digite qualquer tecla para continuar => ");
            Console.ReadLine();

        }


        private static void ProcessaNotasMoedas() { 

            Console.Clear();
            Console.WriteLine(" Solução de Problemas em C# - Contagem de Notas e Moedas");
            Console.WriteLine();
            Console.Write("Digite um valor => ");

            double valor;
            int inteiro;
            decimal auxMoedas;
            int[] vlNotas = { 100, 50, 20, 10, 5, 2 };
            decimal[] vlMoedas = { 0.50m, 0.25m, 0.10m, 0.05m, 0.01m };

            try
            {
                valor = Convert.ToDouble(Console.ReadLine());
                inteiro = (int)valor;
                valor *= 100;
                auxMoedas = (decimal)((valor % 100) / 100);


                Console.WriteLine("NOTAS:");
                foreach (int vlNota in vlNotas)
                {
                    Console.WriteLine("{0} nota(s) de R$ {1},00", inteiro / vlNota, vlNota);
                    inteiro %= vlNota;
                }

                Console.WriteLine("MOEDAS:");
                Console.WriteLine("{0} moeda(s) de R$ 1,00", inteiro / 1);
                foreach (var vlMoeda in vlMoedas)
                {
                    Console.WriteLine("{0} moeda(s) de R$ {1}", (int)(auxMoedas / vlMoeda), vlMoeda);
                    auxMoedas -= ((int)(auxMoedas / vlMoeda)) * vlMoeda;
                }
                Console.WriteLine();
           
            }
            catch (System.Exception)
            {
                Console.WriteLine("Na proxima tentativa digite um valor válido ....  ");
            }
            Console.Write("Digite qualquer tecla para continuar => ");

            Console.ReadLine();
    }


    }

}
