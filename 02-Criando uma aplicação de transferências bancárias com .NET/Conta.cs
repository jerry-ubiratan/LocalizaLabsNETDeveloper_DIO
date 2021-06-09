using System;
namespace ContaBancaria
{
    public class Conta
    {
        private string nome;
        private TipoConta contaTipo;
        private int numeroConta;
        private double saldo;
        private double limite;
        
        public Conta (){
            this.nome = "";
            this.contaTipo = TipoConta.PESSOA_FISICA;
            this.numeroConta = 0;
            this.limite = 0;
            this.saldo = 0;
        }
        public Conta(string nome, TipoConta contaTipo, int numeroConta, double saldo, double limite)
        {
            this.nome = nome;
            this.contaTipo = contaTipo;
            this.numeroConta = numeroConta;
            this.saldo = saldo;
            this.limite = limite;
        }

        public string Nome { get => nome; set => nome = value; }
        public TipoConta ContaTipo { get => contaTipo; set => contaTipo = value; }
        public int NumeroConta { get => numeroConta; set => numeroConta = value; }
        public double Saldo { get => saldo; set => saldo = value; }
        public double Limite { get => limite; set => limite = value; }

        public string Depositar(double valor){
            Saldo += valor;
            return "Deposito realizado com sucesso ...";
        }
        public string Sacar(double valor){
            
            if ((Saldo+Limite)-valor>=0){
                Saldo -= valor;
                return "Saque realizado com sucesso ...";
            } else{
                return "Saldo insuficiente para realizar a operação...";
            }
        }
        public string Transferir(double valor, Conta recebedor){

            if ((Saldo+Limite)-valor>=0){
                Saldo -= valor;
                recebedor.Saldo += valor;
                return "Tranferência realizado com sucesso ...";
            } else{
                return "Saldo insuficiente para realizar a operação...";
            }
        }

        public override string ToString()
        {    
            string shortName = contaTipo.Equals(TipoConta.PESSOA_JURIDICA)?"PJ":"PF";
            string ret = $"{NumeroConta.ToString().PadLeft(5)}|{Nome.PadRight(30)}|";
            ret += $"{shortName.PadRight(4)}|{Saldo.ToString("N3").PadLeft(15)}";
            ret += $"|{Limite.ToString("N3").PadLeft(15)}";
            return ret;
        }
    }
}