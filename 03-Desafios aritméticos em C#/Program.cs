using System;

namespace Aritmeticos
{
    class Program
    {
        static void Main(string[] args)
        {
            string opcao;
            do
            {
                opcao = menu();
                switch (opcao)
                {
                    case "1":
                        calcMedia();
                        break;
                    case "2":
                        CrescimentoPopulacional();
                        break;
                    case "3":
                        Bazinga();
                        break;
                    case "4":
                        TempoEvento();
                        break;
                    case "5":
                        Piralandia();
                        break;
                };

            } while (opcao != "X");


        }

        private static string menu()
        {
            Console.Clear();
            Console.WriteLine("Desafios aritméticos em C#");
            Console.WriteLine("");
            Console.WriteLine("1 - Cálculo de Média");
            Console.WriteLine("2 - Crescimento Populacional");
            Console.WriteLine("3 - Bazinga!!");
            Console.WriteLine("4 - Tempo de um Evento");
            Console.WriteLine("5 - Comunicação em Piralândia");
            Console.WriteLine("X - Sair do Desafio");
            Console.WriteLine("");
            Console.Write("Digiter sua opção=> ");
            return Console.ReadLine().ToUpper();

        }

        // Calculo de Consumo médio 
        private static void calcMedia()
        {
            Console.Clear();
            Console.WriteLine("Desafios aritméticos em C# - Cálculo de Média ");
            Console.WriteLine();

            double a, b, mediaP;
            try
            {
                Console.Write("Digite a primeira nota => ");
                a = Convert.ToDouble(Console.ReadLine());
                Console.Write("Digite a segunda nota => ");
                b = Convert.ToDouble(Console.ReadLine());

                //complete com as variaveis
                mediaP = ((a * 3.5) + (b * 7.5)) / (3.5 + 7.5);

                Console.WriteLine("MÉDIA = {0}", mediaP.ToString("0.00000"));
                Console.WriteLine();
            }
            catch (System.Exception)
            {
                Console.WriteLine("Parâmetros inválidos ....");
                Console.WriteLine();
            }

            Console.Write("Digite qualquer tecla para continuar => ");
            Console.ReadLine();
        }

        private static void CrescimentoPopulacional()
        {

            double[] arrayList = new double[4];
            int pa, pb;
            double cpa, cpb;
            int anos;
            int t = 0;

            Console.Clear();
            Console.WriteLine("Desafios aritméticos em C# - Crescimento Populacional ");
            Console.WriteLine();

            Console.Write("Digite o número de testes que pretende realizar =>");
            try
            {
                t = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Parâmetros > PA-População A , PB-População B, G1-Percentual de crescimento A e G2-Percentual de crescimento B ");
                Console.WriteLine("Exemplo de entrada: PA PB G1 G2");
                Console.WriteLine("100 150 1,0 0");
                Console.WriteLine();
            }
            catch (System.Exception)
            {
                Console.WriteLine("Parâmetros inválidos ....");
            }

            for (int i = 0; i < t; i++)
            {
                try
                {
                    anos = 0;
                    Console.Write("Digite os dados => ");

                    string[] valores = Console.ReadLine().Split();
                    pa = int.Parse(valores[0]);
                    pb = int.Parse(valores[1]);

                    //declare as variaveis corretamente
                    cpa = double.Parse(valores[2]) / 100;
                    cpb = double.Parse(valores[3]) / 100;

                    while (pa <= pb)
                    {
                        //complete o while
                        pa += (int)(pa * cpa);
                        pb += (int)(pb * cpb);
                        anos++;

                        if (anos > 100)
                        {
                            Console.WriteLine("Mais de 1 seculo.");
                            break;
                        }
                    }

                    if (anos <= 100)
                    {
                        Console.WriteLine($"{anos} anos.");
                    }

                }
                catch (System.Exception)
                {
                    Console.WriteLine("Parâmetros inválidos ....");
                    Console.Write("Digite qualquer tecla para continuar => ");
                    Console.ReadLine();
                }
            }

            Console.WriteLine();
            Console.Write("Digite qualquer tecla para continuar => ");
            Console.ReadLine();

        }


        private static void Bazinga()
        {
            int qtdTeste = 0;
            string[] cond = { "tesoura papel lagarto", "papel pedra spock", "pedra lagarto tesoura", "lagarto spock papel", "spock tesoura pedra" };
            string v1 = "", v2 = "";
            string bazinga = "papel, pedra, tesoura, lagarto, spock";

            Console.Clear();
            Console.WriteLine("Desafios aritméticos em C# - Bazinga!! ");
            Console.WriteLine();

            Console.Write("Digite o número de jogadas que pretende realizar =>");
            try
            {
                qtdTeste = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Digite as escolhas de Sheldon e de Raj");
                Console.WriteLine($"Parâmetros possíveis ({bazinga}) ");
                Console.WriteLine("Exemplo de entrada: lagarto pedra");
                Console.WriteLine();
            }
            catch (System.Exception)
            {
                Console.WriteLine("Parâmetros inválidos ....");
            }

            for (int i = 1; i <= qtdTeste; i++) //insira a variavel correta
            {
                bool leftWin = false;
                Console.Write("Digite as escolhas => ");
                try
                {
                    string[] valores = Console.ReadLine().ToLower().Split();
                    v1 = valores[0];
                    v2 = valores[1];
                }
                catch (System.Exception) { }

                if (!bazinga.Contains(v1) || !bazinga.Contains(v2))
                {
                    Console.WriteLine($"Parâmetros inválidos escolha bazinga ({bazinga})");
                    continue;
                }

                if (v1 == v2)
                {
                    Console.WriteLine("Caso #{0}: De novo!", i);
                    continue;
                }

                foreach (var c in cond)
                {
                    string[] cd = c.Split();
                    int pV1 = Array.IndexOf(cd, v1);
                    int pV2 = Array.IndexOf(cd, v2);
                    if (pV1 == 0)
                    {
                        if (pV2 != -1)
                        {
                            leftWin = true;
                        }
                        break;
                    }
                }

                if (leftWin)
                {
                    Console.WriteLine("Caso #{0}: Bazinga!", i);
                }
                else
                {
                    Console.WriteLine("Caso #{0}: Raj trapaceou!", i);
                }
            }

            Console.WriteLine("Digite qualquer tecla para continuar => ");
            Console.ReadLine();
        }

        private static void TempoEvento()
        {

            Console.Clear();
            Console.WriteLine("Desafios aritméticos em C# - Bazinga!! ");
            Console.WriteLine();

            int diaInicio, diaTermino, horaMomentoInicio, minutoMomentoInicio, segundoMomentoInicio;
            int horaMomentoTermino, minutoMomentoTermino, segundoMomentoTerminio;

            try
            {

                Console.Write("Digite o dia de inicio (exemplo Dia 2) => ");
                string[] dadosInicio = Console.ReadLine().Split();
                diaInicio = Convert.ToInt32(dadosInicio[1]);

                Console.Write("Digite a hora de inicio (exemplo HH:MM:SS ) => ");
                string[] dadosMomentoInicio = Console.ReadLine().Split(":");
                horaMomentoInicio = Convert.ToInt32(dadosMomentoInicio[0]);
                minutoMomentoInicio = Convert.ToInt32(dadosMomentoInicio[1]);
                segundoMomentoInicio = Convert.ToInt32(dadosMomentoInicio[2]);

                Console.Write("Digite o dia que termina (exemplo Dia 5) => ");
                string[] dadosTermino = Console.ReadLine().Split();
                diaTermino = Convert.ToInt32(dadosTermino[1]);

                Console.Write("Digite a hora que termina (exemplo HH:MM:SS ) => ");
                string[] dadosMomentoTermino = Console.ReadLine().Split(":");
                horaMomentoTermino = Convert.ToInt32(dadosMomentoTermino[0]);
                minutoMomentoTermino = Convert.ToInt32(dadosMomentoTermino[1]);
                segundoMomentoTerminio = Convert.ToInt32(dadosMomentoTermino[2]);

                DateTime datainicio = new DateTime(DateTime.Today.Year, DateTime.Today.Month, diaInicio, horaMomentoInicio, minutoMomentoInicio, segundoMomentoInicio);
                DateTime datafinal = new DateTime(DateTime.Today.Year, DateTime.Today.Month, diaTermino, horaMomentoTermino, minutoMomentoTermino, segundoMomentoTerminio);

                TimeSpan dados = datafinal - datainicio;

                Console.WriteLine();
                Console.WriteLine("Duração do evento :");
                Console.WriteLine("{0} dia(s)", dados.Days);
                Console.WriteLine("{0} hora(s)", dados.Hours);
                Console.WriteLine("{0} minuto(s)", dados.Minutes);
                Console.WriteLine("{0} segundo(s)", dados.Seconds);
                Console.WriteLine();

            }
            catch (System.Exception)
            {
                Console.WriteLine("Parâmetros inválidos ....");
            }

            Console.WriteLine("Digite qualquer tecla para continuar => ");
            Console.ReadLine();

        }

        private static void Piralandia()
        {

            Console.Clear();
            Console.WriteLine("Desafios aritméticos em C# - Comunicação em Piralândia ");
            Console.WriteLine();

            try
            {
                Console.Write("Digite um número => ");
                string n = Console.ReadLine();
                //continue a solução
                char[] arr = n.ToCharArray();
                Array.Reverse(arr);

                string v = new string(arr);
                Console.WriteLine(v);
            }
            catch (System.Exception)
            {
                Console.WriteLine("Parâmetros inválidos ....");
            }

            Console.WriteLine("Digite qualquer tecla para continuar => ");
            Console.ReadLine();

        }

    }

}
