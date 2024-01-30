using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DesafioPOO.Models
{
    // TODO: Herdar da classe "Smartphone"
    public class Nokia : Smartphone
    {
        public Nokia(string numero, string modelo, string imei, int memoria) : base(numero, modelo, imei, memoria)
        {

        }
      
        public override void AtualizarLista()
        {
            ListaAtualizada = new List<string>(ListaDeAplicativos);
        }

        // TODO: Sobrescrever o método "InstalarAplicativo"
        public override void InstalarAplicativo()
        {
            bool loopApp = true;
            while (loopApp)
            {
                if (MemoriaAtual < 50)
                {
                    Console.WriteLine("O Smartphone não possui memória suficiente, por favor desinstale algum aplicativo para liberar espaço");
                    loopApp = false;
                }
                else
                {
                    Console.WriteLine("Digite o nome do Aplicativo que seja instalar:");
                    string aplicativo = Console.ReadLine();

                    if (ListaDeAplicativos.Any(x => x.ToUpper() == aplicativo.ToUpper()))
                    {
                        Console.WriteLine($"O aplicativo: '{aplicativo}' já está instalado no seu SmartPhone");
                    }
                    else
                    {
                        ListaDeAplicativos.Add(aplicativo);
                        Console.WriteLine($"{aplicativo} foi instalado");
                        AtualizarLista();
                        Bateria -= 0.01;
                        MemoriaAtual -= 50;
                        loopApp = false;
                    }
                }
            }
        }

        public override void DeletarAplicativo()
        {
            ListarAplicativos();

            bool loopApp = true;
            while (loopApp)
            {
                if (ListaDeAplicativos.Any())
                {
                    Console.WriteLine(
                        "***********************************************\n" +
                        "1- Digite o nome do Aplicativo que seja deletar.\n" +
                        "2- <-- Voltar."
                        );
                    switch (Console.ReadLine())
                    {
                        case "1":
                            Console.WriteLine("Digite o nome do App");
                            string aplicativo = Console.ReadLine();

                            // Verifica se o aplicativo está instalado
                            if (ListaDeAplicativos.Any(x => x.ToUpper() == aplicativo.ToUpper()))
                            {
                                ListaDeAplicativos.Remove(aplicativo);
                                Console.WriteLine($"{aplicativo} foi removido");
                                AtualizarLista();
                                Bateria -= 0.01;
                                MemoriaAtual += 50;
                                loopApp = false;
                            }

                            else
                            {
                                Console.WriteLine($"{aplicativo} não está instalado no seu SmartPhone.\n");

                                bool loopDelete2 = true;
                                while (loopDelete2)
                                {
                                    Console.WriteLine(
                                        "1- Tentar novamente.\n" +
                                        "2- <-- Voltar");
                                    switch (Console.ReadLine())
                                    {
                                        case "1":
                                            loopDelete2 = false;
                                            break;

                                        case "2":
                                            loopApp = false;
                                            loopDelete2 = false;
                                            break;

                                        default:
                                            Console.WriteLine("Opção inválida, Tente novamente");
                                            break;
                                    }
                                }

                            }
                            break;

                        case "2":
                            loopApp = false;
                            break;

                        default:
                            Console.WriteLine("Opção inválida, Tente novamente");
                            break;
                    }

                }
                else
                {
                    Console.WriteLine("Tente istalar aplicativos.");
                    loopApp = false;
                }
            }
        }

        public override string ListarAplicativos()
        {
            if (ListaDeAplicativos.Any())
            {
                Console.WriteLine("Aplicativos:");
                for(int contador = 1; contador < ListaDeAplicativos.Count; contador++)
                {
                    Console.WriteLine($"{contador} - {ListaDeAplicativos[contador]}");
                }
            }
            else
            {
                Console.WriteLine("Não há aplicativos instalados.");
            }
            return "";
        }

        public override void OrdenarAplicativos()
        {
            //List<string> aplicativosEmOrdemAlfa = new List<string>();

            if (ListaDeAplicativos.Any())
            {
                //aplicativosEmOrdemAlfa = ListaDeAplicativos.OrderBy(item => item).ToList();
                ListaDeAplicativos.Sort();
                Bateria -= 0.01;
            }

            else
            {
                Console.WriteLine("Não há aplicativos instalados.");
            }
        }

        public override void OrdenacaoPadrao()
        {
            if (ListaAtualizada.Any())
            {
                ListaDeAplicativos = new List<string>(ListaAtualizada);
                Bateria -= 0.01;
            }

            else
            {
                Console.WriteLine("Não há aplicativos instalados.");
            }
        }

        public override void EfetuarChamada()
        {
            Console.WriteLine("Para qual número deseja ligar");

            string numeroDiscado;
            long numeroDiscadoValido;

            while (true)
            {
                numeroDiscado = Console.ReadLine();

                // Tentando converter a string em um numero válido
                if (long.TryParse(numeroDiscado, out numeroDiscadoValido))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Por favor, digite apenas números. Tente novamente:");
                }
            }

            Bateria -= 0.1;
            Console.WriteLine($"Ligando para {numeroDiscadoValido} ...");
        }

        public override void ReceberChamada()
        {
            Stopwatch tempoEmChamada = new Stopwatch();

            Console.WriteLine(
            "Recebendo Ligação...\n" +
            "1- Aceitar Chamada\n" +
            "2- Recusar Chamada");

            string opcaoChamada = Console.ReadLine();

            while (opcaoChamada != "2")
            {
                if (opcaoChamada == "1")
                {
                    Bateria -= 0.1;
                    Console.WriteLine("Chamada em andamento...");
                    tempoEmChamada.Start();

                    Console.WriteLine("2- Encerrar Chamada");
                    opcaoChamada = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Opção inválida. Digite 1 para Aceitar Chamada ou 2 para Recusar Chamada:");
                    opcaoChamada = Console.ReadLine();
                }
            }
            //Para a chamada
            tempoEmChamada.Stop();

            //Duracao da chamada
            TimeSpan duracaoDaChamada = tempoEmChamada.Elapsed;

            Console.WriteLine($"Duração da Chamada: {duracaoDaChamada.Hours:D2}:{duracaoDaChamada.Minutes:D2}:{duracaoDaChamada.Seconds:D2}");
        }

        public override void Calculadora()
        {
            void Soma()
            {
                Console.Write("Digite o primeiro número: ");//poderia ser feito com IsNaN
                double numero1;
                while (!double.TryParse(Console.ReadLine(), out numero1))
                {
                    Console.WriteLine("Entrada inválida. Digite um número.");
                    Console.Write("Digite o primeiro número: ");
                }

                Console.Write("Digite o segundo número: ");
                double numero2;
                while (!double.TryParse(Console.ReadLine(), out numero2))
                {
                    Console.WriteLine("Entrada inválida. Digite um número.");
                    Console.Write("Digite o segundo número: ");
                }

                Console.WriteLine($"Resultado: {numero1 + numero2}");
                Bateria -= 0.01;
            }

            void Subtracao()
            {
                Console.Write("Digite o primeiro número: ");
                double numero1;
                while (!double.TryParse(Console.ReadLine(), out numero1))
                {
                    Console.WriteLine("Entrada inválida. Digite um número.");
                    Console.Write("Digite o primeiro número: ");
                }

                Console.Write("Digite o segundo número: ");
                double numero2;
                while (!double.TryParse(Console.ReadLine(), out numero2))
                {
                    Console.WriteLine("Entrada inválida. Digite um número.");
                    Console.Write("Digite o segundo número: ");
                }

                Console.WriteLine($"Resultado: {numero1 - numero2}");
                Bateria -= 0.01;
            }

            void Multiplicacao()
            {
                Console.Write("Digite o primeiro número: ");
                double numero1;
                while (!double.TryParse(Console.ReadLine(), out numero1))
                {
                    Console.WriteLine("Entrada inválida. Digite um número.");
                    Console.Write("Digite o primeiro número: ");
                }

                Console.Write("Digite o segundo número: ");
                double numero2;
                while (!double.TryParse(Console.ReadLine(), out numero2))
                {
                    Console.WriteLine("Entrada inválida. Digite um número.");
                    Console.Write("Digite o segundo número: ");
                }

                Console.WriteLine($"Resultado: {numero1 * numero2}");
                Bateria -= 0.01;
            }

            void Divisao()
            {
                bool loopDivisao = true;

                while (loopDivisao)
                {
                    try
                    {
                        Console.Write("Digite o numerador: ");
                        double numerador;
                        while (!double.TryParse(Console.ReadLine(), out numerador))
                        {
                            Console.WriteLine("Entrada inválida. Digite um número.");
                            Console.Write("Digite o numerador: ");
                        }

                        Console.Write("Digite o denominador: ");
                        double denominador;
                        while (!double.TryParse(Console.ReadLine(), out denominador))
                        {
                            Console.WriteLine("Entrada inválida. Digite um número.");
                            Console.Write("Digite o denominador: ");
                        }

                        if (denominador == 0)
                        {
                            throw new DivideByZeroException("Erro: A divisão por 0 é indefinida.");
                        }
                        else
                        {
                            Bateria -= 0.01;
                            Console.WriteLine($"Resultado: {(numerador / denominador).ToString("F2")}");
                            loopDivisao = false; // Encerrar o loop
                        }
                    }
                    catch (DivideByZeroException excecao)
                    {
                        Console.WriteLine(excecao);
                        bool loopCatch = true;
                        while (loopCatch)
                        {
                            Console.WriteLine(
                                "1- Tentar Novamente\n" +
                                "2- <-- Voltar");

                            switch (Console.ReadLine())
                            {
                                case "1":
                                    loopCatch = false;
                                    break;

                                case "2":
                                    loopCatch = false;
                                    loopDivisao = false;
                                    break;

                                default:
                                    Console.WriteLine("Opção inválida, Tente novamente");
                                    break;
                            }
                            Console.WriteLine("Pressione uma tecla para continuar");
                            Console.ReadKey();
                        }
                    }
                }
            }

            void Seno()
            {
                Console.Write("Digite o ângulo em graus: ");
                double angulo;
                while (!double.TryParse(Console.ReadLine(), out angulo))
                {
                    Console.WriteLine("Entrada inválida. Digite um número.");
                    Console.Write("Digite o ângulo em graus: ");
                }

                Console.WriteLine($"Resultado: {Math.Sin(Math.PI * angulo / 180.0).ToString("F3")}");
                Bateria -= 0.01;
            }

            void Cosseno()
            {
                Console.Write("Digite o ângulo em graus: ");
                double angulo;
                while (!double.TryParse(Console.ReadLine(), out angulo))
                {
                    Console.WriteLine("Entrada inválida. Digite um número.");
                    Console.Write("Digite o ângulo em graus: ");
                }

                Console.WriteLine($"Resultado: {Math.Cos(Math.PI * angulo / 180.0).ToString("F3")}");
                Bateria -= 0.01;
            }

            void Tangente()
            {
                bool loopTangente = true;

                while (loopTangente)
                {
                    try
                    {
                        Console.Write("Digite o ângulo em graus: ");
                        double angulo;
                        while (!double.TryParse(Console.ReadLine(), out angulo))
                        {
                            Console.WriteLine("Entrada inválida. Digite um número.");
                            Console.Write("Digite o ângulo em graus: ");
                        }

                        if (angulo == 90)
                        {
                            throw new Exception("Erro: A tangente de 90° é indefinida.");
                        }
                        else
                        {
                            Bateria -= 0.01;
                            Console.WriteLine($"Resultado: {Math.Tan(Math.PI * angulo / 180.0).ToString("F3")}");
                            loopTangente = false; // Encerrar o loop
                        }
                    }
                    catch (Exception excecao)
                    {
                        Console.WriteLine(excecao);
                        bool loopCatch = true;
                        while (loopCatch)
                        {
                            Console.WriteLine(
                                "1- Tentar Novamente\n" +
                                "2- <-- Voltar");

                            switch (Console.ReadLine())
                            {
                                case "1":
                                    loopCatch = false;
                                    break;

                                case "2":
                                    loopCatch = false;
                                    loopTangente = false;
                                    break;

                                default:
                                    Console.WriteLine("Opção inválida, Tente novamente");
                                    break;
                            }
                            Console.WriteLine("Pressione uma tecla para continuar");
                            Console.ReadKey();
                        }
                    }
                }
            }

            void RaizQuadrada()
            {
                Console.Write("Digite o número: ");
                double numero;
                while (!double.TryParse(Console.ReadLine(), out numero) || numero < 0)
                {
                    Console.WriteLine("Entrada inválida. Digite um número não-negativo.");
                    Console.Write("Digite o número: ");
                }

                Console.WriteLine($"Resultado: {Math.Sqrt(numero).ToString("F3")}");
                Bateria -= 0.01;
            }

            bool loopCalculadora = true;

            while (loopCalculadora)
            {
                Console.Clear();
                if (Bateria <= 0.1)
                {
                    Console.WriteLine("Atenção!!! A bateria está descarregando, por favor, recarregue seu Smartphone");
                }

                if (Bateria <= 0)
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
                    $"{FormatoHora} {Bateria.ToString("P0")}\n" +
                    "Escolha uma operação:\n" +
                    "1- Soma\n" +
                    "2- Subtração\n" +
                    "3- Multiplicação\n" +
                    "4- Divisão\n" +
                    "5- Seno\n" +
                    "6- Cosseno\n" +
                    "7- Tangente\n" +
                    "8- Raiz Quadrada\n" +
                    "9- <-- Voltar"
                );

                switch (Console.ReadLine())
                {
                    case "1":
                        Soma();
                        break;

                    case "2":
                        Subtracao();
                        break;

                    case "3":
                        Multiplicacao();
                        break;

                    case "4":
                        Divisao();
                        break;

                    case "5":
                        Seno();
                        break;

                    case "6":
                        Cosseno();
                        break;

                    case "7":
                        Tangente();
                        break;

                    case "8":
                        RaizQuadrada();
                        break;

                    case "9":
                        loopCalculadora = false;
                        break;

                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
                Console.WriteLine("Pressione uma tecla para continuar");
                Console.ReadKey();
            }
        }

        public override void InformacoesSmartphone()
        {
            Console.WriteLine(
                $"Modelo:{Modelo}\n" +
                $"Memória Padrão:{Memoria}Gb\n" +
                $"Memória Atual:{MemoriaAtual}Gb\n" +
                $"Número:{Numero}\n" +
                $"IMEI:{Imei}\n"
                );
        }

        public override string DataHoraAtual(bool formato)
        {
            DateTime dataHoraAtual = DateTime.Now;
            bool horaFormato = formato;
            if (horaFormato)
            {
                dataHoraAtual = DateTime.Now;
                return dataHoraAtual.ToString("HH:mm " + "dd/MM/yyyy");
            }
            else
            {
                dataHoraAtual = DateTime.Now;
                return dataHoraAtual.ToString("hh:mm tt" + " dd/MM/yyyy");
            }

        }

        public override void FormatoDataHora()
        {
            bool loopDataHora = true;
            while (loopDataHora)
            {
                Console.Clear();
                if (Bateria <= 0.1)
                {
                    Console.WriteLine("Atenção!!! A bateria está descarregando, por favor, recarregue seu Smartphone");
                }

                if (Bateria <= 0)
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
                    $"{FormatoHora} {Bateria.ToString("P0")}\n" +
                    "Defina a exibição da Hora do seu Smartphone\n" +
                    "1- Formato 24h\n" +
                    "2- Formato 12h\n" +
                    "3- <-- Voltar"
                );

                switch (Console.ReadLine())
                {
                    case "1":
                        CondicaoHora = 1;
                        Bateria -= 0.01;
                        break;

                    case "2":
                        CondicaoHora = 0;
                        Bateria -= 0.01;
                        break;

                    case "3":
                        loopDataHora = false;
                        break;

                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
                Console.WriteLine("Pressione uma tecla para continuar");
                Console.ReadKey();
            }

        }   
    }
}