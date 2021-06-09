using System;
using System.Threading;
using System.Collections.Generic;

namespace ContaBancaria
{
    class Program
    {
        static List<Conta> ContasDB = new List<Conta>();
        static void Main(string[] args)
        {
            string opcao;
            do
            {
                opcao = Menu();
                switch (opcao)
                {
                    case "1":
                        ListarCorrentistas();
                        break;
                    case "2":
                        IncluirCorrentista();
                        break;
                    case "3":
                        Transacao(tipoTRX.DEPOSITO);
                        break;
                    case "4":
                        Transacao(tipoTRX.SAQUE);
                        break;
                    case "5":
                        Transacao(tipoTRX.TRANSFERENCIA);
                        break;
                    case "A":
                        switch (Administracao()){
                            case "G":
                                CVSTools.ExportCSV(ContasDB);
                                break;
                            case "C":
                                ContasDB = CVSTools.loadCSV();
                                break;
                        }
                        break;
                }

                
            } while (opcao != "X");
        
        }

        private static string Menu()
        {
            Console.Clear();
            Console.WriteLine("BANCO DIO - APP de Transferência Bancária");
            Console.WriteLine();
            Console.WriteLine( "1-Lista de Correntistas");
            Console.WriteLine( "2-Incluir Novo Cliente");
            Console.WriteLine( "3-Depositar");
            Console.WriteLine( "4-Sacar");
            Console.WriteLine( "5-Transferir");
            Console.WriteLine( "----------------------------------------");
            Console.WriteLine( "A-ADM");
            Console.WriteLine( "----------------------------------------");
            Console.WriteLine( "X-Sair do APP");
            Console.WriteLine();
            Console.Write( "Digite a opção => ");
            return Console.ReadLine().ToUpper();
        }

        private static string Administracao()
        {
            Console.Clear();
            Console.WriteLine("BANCO DIO - APP de Transferência Bancária");
            Console.WriteLine("ADMINISTRAÇÃO");
            Console.WriteLine();
            Console.WriteLine( "G-Salvar dados.");
            Console.WriteLine( "C-Carregar dados.");
            Console.WriteLine( "Digite qualquer tecla para Voltar ao Menu Principal.");
            Console.WriteLine();
            Console.Write( "Digite a opção => ");
            return Console.ReadLine().ToUpper();
        }

        private static void IncluirCorrentista()
        {
            string inputNome = "";
            string inputTipo = "";
            string inputSaldo = "";
            string inputLimite = "";
            Conta newConta = new Conta();
            do{
                Console.Clear();
                Console.WriteLine("BANCO DIO - APP de Transferência Bancária");
                Console.WriteLine();
                Console.WriteLine("CARASTRO DE CORRENTISTA");
                Console.WriteLine();

                try
                {
                    Console.WriteLine("Digite o Nome => {0}", inputNome);
                    inputNome = String.IsNullOrEmpty(inputNome)?Console.ReadLine():inputNome;
                    newConta.Nome = inputNome;
                    Console.WriteLine("Digite o Tipo de Conta 0-Pessoa Fisica ou 1-Pessoa Juridica => {0}", inputTipo);
                    inputTipo = String.IsNullOrEmpty(inputTipo)?Console.ReadLine():inputTipo;
                    if ((int.Parse(inputTipo) != (int)TipoConta.PESSOA_FISICA) && (int.Parse(inputTipo) != (int) TipoConta.PESSOA_JURIDICA)){
                         throw new Exception();
                    }  
                    newConta.ContaTipo = (TipoConta)int.Parse(inputTipo);
                    
                    Console.WriteLine("Digite o Saldo Inicial => {0}", inputSaldo );
                    inputSaldo = String.IsNullOrEmpty(inputSaldo)?Console.ReadLine():inputSaldo;
                    newConta.Saldo = Double.Parse(inputSaldo); 

                    Console.WriteLine("Digite o Limite de Crédito => {0}", inputLimite);
                    inputLimite	= String.IsNullOrEmpty(inputLimite)?Console.ReadLine():inputLimite;
                    newConta.Limite = Double.Parse(inputLimite); 
                    newConta.NumeroConta = ContasDB.Count;
                    ContasDB.Add(newConta);

                    Console.WriteLine();
                    Console.Write("Correntista Cadastrado, digite qualquer tecla para continuar..");
                    Console.ReadLine();
                    break;
                }
                catch (System.Exception)
                {
                    Console.WriteLine("Parâmetros invalidos ...");
                    Console.WriteLine("Tecle <X> par abandonar o fornulario ou <ENTER> para continuar ...");
                    if (Console.ReadLine().ToUpper() == "X"){
                        break;
                    }
                } 

            }while(true);
        }

        private static void ListarCorrentistas()
        {
            Console.Clear();
            Console.WriteLine("BANCO DIO - APP de Transferência Bancária");
            Console.WriteLine();
            Correntistas();    
            Console.WriteLine();
            Console.Write("Digite qualquer tecla para continuar ...");
            Console.ReadLine();
        }

        private static void Correntistas()
        {
            Console.WriteLine("LISTA DE CORRENTISTAS");
            if (ContasDB.Count > 0){
                Console.WriteLine();
                Console.WriteLine(String.Empty.PadLeft(73,'-') );
                Console.WriteLine("CONTA|{0}|TIPO|{1,15}|{2,15}", ("NOME").PadRight(30), "SALDO", "LIMITE" );
                Console.WriteLine(String.Empty.PadLeft(73,'-') );
                foreach (Conta cta in ContasDB)
                {
                    Console.WriteLine(cta.ToString());
                }            
            }else{
                Console.WriteLine("Não há correntistas cadastrados ....");
            }        
        }

        private static void Transacao(tipoTRX trx)
        {
            string[] transacao = {"DEPOSITO", "SAQUE", "TRANSFERENCIA"};
            Console.Clear();
            Console.WriteLine("BANCO DIO - APP de Transferência Bancária");

            Console.WriteLine(transacao[(int)trx]);
            Console.WriteLine();
            Correntistas();
            if (ContasDB.Count> 0){
                try
                {
                    Console.WriteLine("Informe o numero da Conta Origem => ");
                    int inputOrigem = int.Parse(Console.ReadLine());

                    string msg;
                    if (trx == tipoTRX.DEPOSITO){
                        Console.WriteLine("Digite o Valor => ");
                        msg = ContasDB[inputOrigem].Depositar(Double.Parse(Console.ReadLine())); 
                    }else if(trx == tipoTRX.SAQUE) {
                        Console.WriteLine("Digite o Valor => ");
                        msg = ContasDB[inputOrigem].Sacar(Double.Parse(Console.ReadLine())); 
                    }else{
                        Console.WriteLine("Informe o numero da Conta Destino => ");
                        int inputDestino = int.Parse(Console.ReadLine());
                        Console.WriteLine("Digite o Valor => ");
                        msg = ContasDB[inputOrigem].Transferir(Double.Parse(Console.ReadLine()),ContasDB[inputDestino]); 
                    }
                    Console.WriteLine();
                    Console.WriteLine(msg);

                    Console.Write("Digite qualquer tecla para continuar ...");
                    Console.ReadLine();
                }                
                catch (Exception)
                {
                    Console.Write("Dados invalidos, tente novamente...");
                    Thread.Sleep(5000);
                }

            }

        }
   
    }
}
