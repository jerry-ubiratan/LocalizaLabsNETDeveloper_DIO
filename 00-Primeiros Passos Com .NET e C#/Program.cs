using System;
using System.Threading;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {   
            Aluno[] alunos = new Aluno[5];
            string selecao = menuPrincipal(); 
            int indice;

            while (selecao != "X"){
                switch (selecao){
                    case "1":
                        indice = 0;
                        foreach (var a in alunos)
                        { 
                            if (string.IsNullOrEmpty(a.Nome))
                            {
                                alunos[indice].Nome = novoAlunoNome();
                                alunos[indice].Nota = novoAlunoNota();
                                break;
                            }
                            indice++;   
                        }
                        if (indice >= alunos.Length){
                            Console.WriteLine("Não é possivel incluir novos Alunos..");
                            Thread.Sleep(5000);
                        }
                            
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Lista de Alunos..");
                        foreach (var a in alunos)
                        { 
                            if (!string.IsNullOrEmpty(a.Nome))
                            {
                                Console.WriteLine($"Aluno = {a.Nome}, nota = {a.Nota} ");    
                            }
                        }
                        Console.WriteLine("");
                        Console.WriteLine("Tecle qualquer tecla para continuar ...");
                        Console.ReadLine();
                        break;
                    case "3":
                        Console.Clear();
                        decimal somaDasNotas = 0;
                        indice = 0;
                        foreach (var a in alunos)
                        { 
                            if (!string.IsNullOrEmpty(a.Nome))
                            {
                                somaDasNotas+= a.Nota;
                                indice++;
                            }
                        }
                        decimal mediaGeral = indice != 0?somaDasNotas/indice:0;
                        Console.WriteLine($"Soma de todas as Notas = ({somaDasNotas})");    
                        Console.WriteLine($"Quantidade de alunos com Nota = ({indice})");    
                        Console.WriteLine($"A média geral das notas é = ({mediaGeral}) - Conceito geral ({getConceito(mediaGeral)})");    
                        Console.WriteLine("");
                        Console.WriteLine("Tecle qualquer tecla para continuar ...");
                        Console.ReadLine();
                        break;
                    case "X":
                        //TODO
                        continue;
                }
                selecao = menuPrincipal(); 
            }
        }
        private static string menuPrincipal(){
            Console.Clear();
            Console.WriteLine("Informe a opção desejada:");    
            Console.WriteLine("1-Inserir novo aluno");    
            Console.WriteLine("2-Listar alunos");    
            Console.WriteLine("3-Calcular média Geral");    
            Console.WriteLine("X-Sair");    
            Console.WriteLine("");    
            Console.Write("Opção->");
            string selecao = Console.ReadLine();

            return selecao.ToUpper();
        }
        private static string novoAlunoNome(){
            Console.Clear();
            Console.WriteLine("Informe os dados do aluno:");    
            Console.Write("Digite o Nome=>");
            return Console.ReadLine();
        }
        private static Decimal novoAlunoNota(){
            decimal nota;
            while(true){
                Console.Write("Digite um valor decimal para a Nota=>");
                if(decimal.TryParse(Console.ReadLine(), out nota)){
                    break;
                }else{
                    continue;
                }        
            }
            return nota;
        }
    private static Conceito getConceito(decimal nota){
        Conceito conceito ;
    if (nota < 2){
        conceito = Conceito.E;
    }
    else if (nota < 4){
        conceito = Conceito.D;
    }
    else if (nota < 6){
        conceito = Conceito.C;
    }
    else if (nota < 8 ){
        conceito = Conceito.B;
    }else{
        conceito = Conceito.A;
    } 
    return conceito;
}



    }
}
