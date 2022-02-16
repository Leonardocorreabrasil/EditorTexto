using System;
using System.IO;

namespace TextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("O que voce deseja fazer?");
            Console.WriteLine("1- abrir arquivo");
            Console.WriteLine("2 - criar novo arquivo");
            Console.WriteLine("0 - sair");
            var option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 0: System.Environment.Exit(0); break;
                case 1: Abrir(); break;
                case 2: Editar(); break;
                default: Menu(); break;
            }


        }
        static void Abrir()
        {
            Console.Clear();
            Console.WriteLine("qual o caminho do arquivo?");
            var path = Console.ReadLine();

            using (var file = new StreamReader(path))
            {
                var text = file.ReadToEnd();
                Console.WriteLine(text);
                Menu();
            }
        }

        static void Editar()
        {
            Console.Clear();
            Console.WriteLine("digite seu texto abaixo (ESC para sair)");
            Console.WriteLine("---------------");
            var text = "";

            do
            {
                text += Console.ReadLine();
                text += Environment.NewLine;
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);
            Salvar(text);
        }
        static void Salvar(string text)
        {
            Console.Clear();
            Console.WriteLine("qual o caminho para salvar o arquivo/;");
            var path = Console.ReadLine();

            using (var file = new StreamWriter(path))
            {
                file.Write(text);
            }

            Console.WriteLine($"arquivo {path} salvo com sucesso");
            Console.ReadLine();
            Menu();
        }
    }
}
