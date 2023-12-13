namespace DesafioPOO.Models
{
    public abstract class Smartphone
    {
        // TODO: Implementar as propriedades faltantes de acordo com o diagrama
        public string Numero { get; set; }
        private string Modelo;
        private string Imei;
        private int Memoria;

        public Smartphone(string numero, string modelo, string imei, int memoria)
        {
            // TODO: Passar os parâmetros do construtor para as propriedades
            Numero = numero;
            Modelo = modelo;
            Imei = imei;
            Memoria = memoria;
        }

        public void Ligar()
        {
            Console.WriteLine("Ligando...");
        }

        public void ReceberLigacao()
        {
            Console.WriteLine("Recebendo ligação...");
        }

        public void ConfiguracoesDoCelular()
        {
            Console.WriteLine($"Seu celular por possui as seguintes configurações:" + 
             $"\n Modelo:{Modelo} \n IMEI:{Imei} \n Memória:{Memoria}Gb");
        }

        public abstract void InstalarAplicativo(string nomeApp);
    }
}