using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioPOO.Models
{
    public abstract class Smartphone
    {
        // TODO: Implementar as propriedades faltantes de acordo com o diagrama
        public string Numero { get; set; }
        protected string Modelo;
        protected string Imei;
        protected int Memoria;
        public int MemoriaAtual;
        protected double Bateria = 0.5;
        public List<string> ListaDeAplicativos = new List<string>();
        public List<string> ListaAtualizada = new List<string>();
        public string FormatoHora;
        public int CondicaoHora = 1;

        public Smartphone(string numero, string modelo, string imei, int memoria)
        {
            // TODO: Passar os parâmetros do construtor para as propriedades
            Numero = numero;
            Modelo = modelo;
            Imei = imei;
            Memoria = memoria;
            MemoriaAtual = Memoria;
        }

        public void Menu()
        {
            bool menu = true;
            while (menu)
            {
                Console.Clear();
                if (Bateria <= 0.1)
                {
                    Console.WriteLine("Atenção!!! A bateria está descarregando, por favor, recarregue seu Smartphone");
                }

                if (Bateria == 0)
                {
                    Console.WriteLine("A bateria acabou");
                    break;
                }

                if (CondicaoHora == 1)
                {
                    FormatoHora = DataHoraAtual(true);
                }
                else
                {
                    FormatoHora = DataHoraAtual(false);
                }
                Console.WriteLine(
                   $"{FormatoHora} {Bateria.ToString("P0")}\n" + //bateria %
                   "1- Loja de Aplicativos\n" + //add, deletar
                   "2- Aplicativos Instalados\n" +//listar ----> ordenar apps por ordem alpha
                   "3- Efetuar Chamada\n" +//formato de hora e informações do celular
                   "4- Receber Chamada\n" +
                   "5- Calculadora\n" +
                   "6- Configurações\n" +
                   "7- Desligar"
                   );

                switch (Console.ReadLine())
                {
                    case "1":
                        SubMenuLojaAplicativos();
                        break;

                    case "2":
                        SubMenuAplicativos();
                        break;

                    case "3":
                        EfetuarChamada();
                        break;

                    case "4":
                        ReceberChamada();
                        break;

                    case "5":
                        Calculadora();
                        break;

                    case "6":
                        SubMenuConfiguracoes();
                        break;

                    case "7":
                        menu = false;
                        break;

                    default:
                        Console.WriteLine("Opção inválida, Tente novamente");
                        break;
                }
                Console.WriteLine("Pressione uma tecla para continuar");
                Console.ReadKey();
            }
            DesligarCelular();
        }

        public void SubMenuLojaAplicativos()
        {
            bool subMenu = true;
            while (subMenu)
            {
                if (CondicaoHora == 1)
                {
                    FormatoHora = DataHoraAtual(true);
                }
                else
                {
                    FormatoHora = DataHoraAtual(false);
                }
                Console.Clear();
                Console.WriteLine(
                   $"{FormatoHora} {Bateria.ToString("P0")}\n" +
                   "1- Instalar Aplicativo\n" +
                   "2- Deletar Aplicativo\n" +
                   "3- <-- Voltar"
                   );

                switch (Console.ReadLine())
                {
                    case "1":
                        InstalarAplicativo();
                        break;

                    case "2":
                        DeletarAplicativo();
                        break;

                    case "3":
                        subMenu = false;
                        break;

                    default:
                        Console.WriteLine("Opção inválida, Tente novamente");
                        break;
                }
                Console.WriteLine("Pressione uma tecla para continuar");
                Console.ReadKey();
            }
        }

        public void SubMenuAplicativos()
        {
            bool subMenu = true;
            while (subMenu)
            {
                if (CondicaoHora == 1)
                {
                    FormatoHora = DataHoraAtual(true);
                }
                else
                {
                    FormatoHora = DataHoraAtual(false);
                }
                Console.Clear();
                Console.WriteLine($"{FormatoHora} {Bateria.ToString("P0")}");
                Console.WriteLine(
                   $"{ListarAplicativos()}" +
                   "1- Ordenar Aplicativos em Ordem Alfabética\n" +
                   "2- Ordenação padrão\n" +
                   "3- <-- Voltar"
                   );

                switch (Console.ReadLine())
                {
                    case "1":
                        OrdenarAplicativos();
                        break;

                    case "2":
                        OrdenacaoPadrao();
                        break;

                    case "3":
                        subMenu = false;
                        break;

                    default:
                        Console.WriteLine("Opção inválida, Tente novamente");
                        break;
                }
                Console.WriteLine("Pressione uma tecla para continuar");
                Console.ReadKey();
            }
        }

        public void SubMenuConfiguracoes()
        {
            bool subMenu = true;
            while (subMenu)
            {
                if (CondicaoHora == 1)
                {
                    FormatoHora = DataHoraAtual(true);
                }
                else
                {
                    FormatoHora = DataHoraAtual(false);
                }
                Console.Clear();
                Console.WriteLine(
                    $"{FormatoHora} {Bateria.ToString("P0")}\n" +
                    "1- Informações do Smartphone\n" +
                    "2- Configurações de Data e Hora\n" +
                    "3- <-- Voltar"
                );

                switch (Console.ReadLine())
                {
                    case "1":
                        InformacoesSmartphone();
                        break;

                    case "2":
                        FormatoDataHora();
                        break;

                    case "3":
                        subMenu = false;
                        break;

                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
                Console.WriteLine("Pressione uma tecla para continuar");
                Console.ReadKey();
            }
        }

        public abstract void InstalarAplicativo();

        public abstract void DeletarAplicativo();

        public abstract string ListarAplicativos();

        public abstract void AtualizarLista();

        public abstract void OrdenarAplicativos();

        public abstract void OrdenacaoPadrao();

        public abstract void EfetuarChamada();

        public abstract void ReceberChamada();

        public abstract void Calculadora();

        public abstract void InformacoesSmartphone();

        public abstract string DataHoraAtual(bool formato);

        public abstract void FormatoDataHora();

        public void DesligarCelular()
        {
            Console.WriteLine("Desligando...");

            Thread.Sleep(2000);

            Console.WriteLine("Desligou.");
        }
    }
}