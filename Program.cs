using DesafioPOO.Models;

// TODO: Realizar os testes com as classes Nokia e Iphone
Console.WriteLine("Smartphone Nokia:");
Nokia nokia = new Nokia("123456", "Modelo 1", "ac547df", 128);
nokia.Ligar();
nokia.InstalarAplicativo("Gmail");
nokia.ConfiguracoesDoCelular();

Console.WriteLine("\n");

Console.WriteLine("Smartphone iPhone:");
Iphone iphone = new Iphone("145236", "Modelo 2", "yu856ew32", 256);
iphone.ReceberLigacao();
iphone.InstalarAplicativo("YouTube");
iphone.ConfiguracoesDoCelular();