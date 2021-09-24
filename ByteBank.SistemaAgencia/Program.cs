using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ByteBank.Modelos;
using ByteBank.Modelos.Funcionarios;
using Humanizer;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {

            //TesteHumanize();
            //TesteExtratorValorDeArgumentosURL();
            //TesteString();
            //TesteRegex();
            //SomarNumeros(new int[] { 1, 2, 3, 4, 5 });
            //TestaArrayInt();
            //TestaArrayDeContaCorrente();
            //TestaListaDeContaCorrente();
            //TestaListaDeObject();
            TestaListaGenerica();

            Console.ReadLine();
        }

        static void TesteExtratorValorDeArgumentosURL()
        {           
            string url = "pagina?moedaOrigem=real&moedaDestino=dolar";
            ExtratorValorDeArgumentosURL extrator = new ExtratorValorDeArgumentosURL(url);

            Console.WriteLine("moedaOrigem: " + extrator.GetValor("moedaOrigem"));
            Console.WriteLine("moedaDestino: " + extrator.GetValor("moedaDestino"));
        }

        static void TesteHumanize()
        {
            DateTime dataFimPagamento = new DateTime(2018, 6, 20);
            DateTime dataCorrente = DateTime.Now;

            TimeSpan diferenca = TimeSpan.FromMinutes(40); //dataFimPagamento - dataCorrente;

            string mensagem = "Vencimento em " + TimeSpanHumanizeExtensions.Humanize(diferenca);

            Console.WriteLine(mensagem);
        }

        static void TesteString()
        {

            Console.WriteLine("Testando ToLower");
            string mensagemOrigem = "PALAVRA";
            string termoBusca = "ra";

            Console.WriteLine(mensagemOrigem.ToLower());


            Console.WriteLine("Testando Replace");
            termoBusca = termoBusca.Replace('r', 'R');
            Console.WriteLine(termoBusca);

            termoBusca = termoBusca.Replace('a', 'A');
            Console.WriteLine(termoBusca);

            Console.WriteLine(mensagemOrigem.IndexOf(termoBusca));


            Console.WriteLine("Testando o método Remove");
            string testeRemocao = "primeiraParte&123456789";
            int indiceEComercial = testeRemocao.IndexOf('&');
            Console.WriteLine(testeRemocao.Remove(indiceEComercial, 4));
            Console.ReadLine();



            Console.WriteLine("Testando o IsNullOrEmpty");
            string textoVazio = "";
            string textoNulo = null;
            string textoQualquer = "kjhfsdjhgsdfjksdf";
            Console.WriteLine(String.IsNullOrEmpty(textoVazio));
            Console.WriteLine(String.IsNullOrEmpty(textoNulo));
            Console.WriteLine(String.IsNullOrEmpty(textoQualquer));

        }

        static void TesteRegex()
        {
            // Olá, meu nome é Guilherme e você pode entrar em contato comigo
            // através do número 8457-4456!

            // Meu nome é Guilherme, me ligue em 4784-4546

            //  "[0123456789][0123456789][0123456789][0123456789][-][0123456789][0123456789][0123456789][0123456789]";
            //  "[0-9][0-9][0-9][0-9][-][0-9][0-9][0-9][0-9]";
            //  "[0-9]{4,5}[-][0-9]{4}";
            //  "[0-9]{4,5}[-]{0,1}[0-9]{4}";
            //  "[0-9]{4,5}-{0,1}[0-9]{4}";
            string padrao = "[0-9]{4,5}-?[0-9]{4}";

            // 879.546.120-20
            // 879546120-20

            string textoDeTeste = "idyufdgfugfjksdhf 99871-5456 sdjkfgsdjgsjgh sfsdjgsdjghsdfj";

            Match resultado = Regex.Match(textoDeTeste, padrao);

            Console.WriteLine(resultado.Value);
        }
        static void SomarNumeros(int[] numeros)
        {
            for (int i = 0; i < numeros.Length -1; i += 2)
    {
                int primeiroNumero = numeros[i];
                int segundoNumero = numeros[i + 1];

                int soma = primeiroNumero + segundoNumero;

                Console.WriteLine($"{primeiroNumero}+{segundoNumero} = {soma}");
            }
        }

        static void TestaListaGenerica()
        {
            Lista<int> idades = new Lista<int>();

            idades.Adicionar(5);
            idades.AdicionarVarios(1, 5, 78);

            for (int i = 0; i < idades.Tamanho; i++)
            {
                int idade = idades[i];
                Console.WriteLine($"Idade no indice {i}: {idade}");
            }
        }

        static void TestaListaDeObject()
        {
            ListaDeObject listaDeIdades = new ListaDeObject();

            listaDeIdades.Adicionar(10);
            listaDeIdades.Adicionar(5);
            listaDeIdades.Adicionar(4);
            //listaDeIdades.Adicionar("um texto qualquer");
            listaDeIdades.AdicionarVarios(16, 23, 60);

            for (int i = 0; i < listaDeIdades.Tamanho; i++)
            {
                int idade = (int)listaDeIdades[i];
                Console.WriteLine($"Idade no indice {i}: {idade}");
            }
        }

        static void TestaListaDeContaCorrente()
        {
            //ListaDeContaCorrente lista = new ListaDeContaCorrente();
            ListaDeContaCorrente lista = new ListaDeContaCorrente();

            ContaCorrente contaDoGui = new ContaCorrente(11111, 1111111);

            ContaCorrente[] contas = new ContaCorrente[]
            {
                contaDoGui,
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679754)
            };

            lista.AdicionarVarios(contas);

            lista.AdicionarVarios(
                contaDoGui,
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679787)
            );

            for (int i = 0; i < lista.Tamanho; i++)
            {
                ContaCorrente itemAtual = lista[i];
                Console.WriteLine($"Item na posição {i} = Conta {itemAtual.Numero}/{itemAtual.Agencia}");
            }
        }

        static void TestaArrayDeContaCorrente()
        {
            ContaCorrente[] contas = new ContaCorrente[]
                {
                    new ContaCorrente(874, 5679787),
                    new ContaCorrente(874, 4456668),
                    new ContaCorrente(874, 7781438)
                };

            for (int indice = 0; indice < contas.Length; indice++)
            {
                ContaCorrente contaAtual = contas[indice];
                Console.WriteLine($"Conta {indice} {contaAtual.Numero}");
            }
        }

        static void TestaArrayInt()
        {
            // ARRAY de inteiros, com 5 posições!
            int[] idades = null;
            idades = new int[3];

            idades[0] = 15;
            idades[1] = 28;
            idades[2] = 35;
            //idades[3] = 50;
            //idades[4] = 28;
            //idades[5] = 60;

            Console.WriteLine(idades.Length);

            int acumulador = 0;
            for (int indice = 0; indice < idades.Length; indice++)
            {
                int idade = idades[indice];

                Console.WriteLine($"Acessando o array idades no índice {indice}");
                Console.WriteLine($"Valor de idades[{indice}] = {idade}");

                acumulador += idade;
            }

            int media = acumulador / idades.Length;
            Console.WriteLine($"Média de idades = {media}");
        }
    }
}
