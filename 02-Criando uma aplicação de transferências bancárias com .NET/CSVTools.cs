
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.VisualBasic.FileIO;

namespace ContaBancaria
{
    public static class CVSTools
    {
        public static void ExportCSV<T>(List<T> listDados)
        {
            var sb = new StringBuilder();
            var cvsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CONTAS.csv");
            var header = "";
            var info = typeof(T).GetProperties();
            
            if (File.Exists(cvsPath))
            {
                File.Delete(cvsPath);
            }

            var file = File.Create(cvsPath);
            file.Close();

            foreach (var prop in typeof(T).GetProperties())
            {
                header += prop.Name + ";";
            }
            header = header.Substring(0, header.Length - 2);
            sb.AppendLine(header);
            TextWriter sw = new StreamWriter(cvsPath, true);
            sw.Write(sb.ToString());

            foreach (var obj in listDados)
            {
                sb = new StringBuilder();
                var line = "";
                foreach (var prop in info)
                {
                    line += prop.GetValue(obj, null) + ";";
                }
                line = line.Substring(0, line.Length - 1);
                sb.AppendLine(line);
                sw.Write(sb.ToString());
            }
            sw.Close();

        }

        public static  List<Conta> loadCSV(){
            var cvsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CONTAS.csv");
            List<Conta> dados = new List<Conta>();
            using (TextFieldParser parser = new TextFieldParser(cvsPath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(";");
                while (!parser.EndOfData)
                {   
                    try
                    {
                        string[] fields = parser.ReadFields();
                        TipoConta tp = fields[1] == "PESSOA_FISICA"? TipoConta.PESSOA_FISICA:TipoConta.PESSOA_JURIDICA;
                        dados.Add (new Conta(fields[0], tp, int.Parse(fields[2]), double.Parse(fields[3]), double.Parse(fields[4])));
                    }
                    catch (System.Exception){}
                }
            }
            return dados;   
        }
    }
}