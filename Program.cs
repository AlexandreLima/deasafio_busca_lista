using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console.Net
{
    class Program
    {
        static void Main(string[] args)
        {

            CicloConsole c = new CicloConsole();
            c.IniciarFluxo();
        }

        class CicloConsole
        {
            public bool ItensInseridosCorretamente = false;
            decimal[] decimais;
            decimal valorBuscaDecimal = 0;

            public void IniciarFluxo()
            {
                while (!this.ItensInseridosCorretamente)
                {
                    this.IniciarCapturaValores();
                }

                this.EfetuarConta();
            }

            public void IniciarCapturaValores()
            {
                System.Console.WriteLine("Entre com os item a ser localizado");
                var valorBusca = System.Console.ReadLine();

                if (!decimal.TryParse(valorBusca, out valorBuscaDecimal))
                {
                    System.Console.WriteLine("Coloque um numero para a busca");
                    return;
                }

                System.Console.WriteLine("Entre com a lista de numeros");
                var valorLista = System.Console.ReadLine();
                string[] splitLista = null;

                try
                {
                    splitLista = valorLista.Split(',');
                    decimais = new decimal[splitLista.Length];

                    int contador = 0;

                    Array.ForEach(splitLista, x =>
                    {
                        decimais[contador] = decimal.Parse(splitLista[contador]);
                        contador++;
                    });
                }
                catch (Exception)
                {
                    System.Console.WriteLine("Entre com a lista de itens decimais corretamente");
                    return;
                }

                this.ItensInseridosCorretamente = true;

            }

            public void EfetuarConta()
            {
                if (Array.BinarySearch<decimal>(this.decimais, valorBuscaDecimal) < 0)
                {
                    System.Console.WriteLine("Não");
                } else
                    System.Console.WriteLine("Sim");

                FecharPrograma();

            }

            public void FecharPrograma()
            {
                string resultado;
                do
                {
                    System.Console.WriteLine("Deseja reiniciar o Teste? [S/N]");
                    resultado = System.Console.ReadLine();
                } while (resultado.ToUpper() != "S" && resultado.ToUpper() != "N");

                if (resultado.ToUpper() == "S")
                {
                    this.ItensInseridosCorretamente = false;
                    IniciarFluxo();
                }
                  
            }
        }
    }
}
