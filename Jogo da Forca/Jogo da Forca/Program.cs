using System;
using System.Collections.Generic;

namespace Jogo_da_Forca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Lista de palavras
            List<string> palavras = new List<string>
{
    // Objetos
    "computador", "carro", "televisor", "celular", "óculos",
    
    // Esatados
    "california", "florida", "texas", "nova york", "ohio",
    
    // Países
    "brasil", "japão", "austrália", "canadá", "índia",
    
    // Animais
    "panda", "girafa", "lobo", "tucano", "ornitorrinco",
    
    // Filmes
    "matrix", "titanic", "star wars", "inception", "avatar",
    
    // Séries
    "breaking bad", "stranger things", "the simpsons", "game of thrones", "friends"
};

            // Lista de tamanhos
            List<int> tamanhos = new List<int> { 10, 4, 9, 7, 6, 9, 7, 5, 7, 10, 5, 5, 6, 9, 7, 6, 9, 7, 16, 13, 7, 15, 14, 5, 11 };

            // Lista de dicas
            List<string> dicas = new List<string>
{
    // Objetos
    "Tecnologia", "Meio de transporte", "Eletrônico", "Dispositivo móvel", "Acessório pessoal",
    
    // Estados
    "Estado da costa oeste", "Estado ensolarado", "Estado grande", "Estado com cidade famosa", "Estado no meio-oeste",
    
    // Países
    "País sul-americano", "País asiático", "País oceânico", "País norte-americano", "País asiático",
    
    // Animais
    "Urso preto e branco", "Animal de pescoço longo", "Carnívoro selvagem", "Pássaro colorido", "Mamífero aquático peculiar",
    
    // Filmes
    "Ficção científica", "Romance trágico", "Space opera", "Ação e ficção científica", "Ficção épica",
    
    // Séries
    "Professor que vira traficante", "Crianças enfrentando o sobrenatural", "Animação de comédia", "Guerra pelo trono", "Grupo de amigos em Nova York"
};


            bool Win = false;
            int attempts = 5;
            char Chosen_character = ' ';

            // Get random word
            Random random = new Random();
            int sizeList = palavras.Count;
            int indexRand = random.Next(0, sizeList);

            // Array for Guessed Word
            string chosenWord = palavras[indexRand];
            char[] guessedWord = new char[chosenWord.Length];

            for (int i = 0; i < guessedWord.Length; i++)
            {
                guessedWord[i] = '_';
            }

            do
            {
                Console.Clear();
                Console.WriteLine("***********************");
                Console.WriteLine("   Jogo da Forca");
                Console.WriteLine("***********************\n");

                if (attempts < 3)
                {
                    Console.WriteLine($"Tips: {dicas[indexRand]}\n");
                }

                // Display Guessed Word
                Console.Write("Word: ");
                for (int i = 0; i < guessedWord.Length; i++)
                {
                    Console.Write($"{guessedWord[i]} ");
                }

                Console.WriteLine("\n");
                Console.WriteLine($"Remaining attempts: {attempts}");
                Console.WriteLine($"Word size: {chosenWord.Length}\n");

                // Get one char
                Console.Write("Enter a letter: ");
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                char userInput = keyInfo.KeyChar;
                Chosen_character = userInput;

                // Update Guessed Word
                bool letterGuessed = false;

                for (int i = 0; i < chosenWord.Length; i++)
                {
                    if (chosenWord[i] == Chosen_character)
                    {
                        guessedWord[i] = Chosen_character;
                        letterGuessed = true;
                    }
                }

                if (!letterGuessed)
                {
                    Console.WriteLine("\nThis letter is not present in the word, try again\n");
                    attempts--;
                }

                // Convert array to string
                string wordCorrect = new string(guessedWord);
                if (wordCorrect == chosenWord)
                {
                    Console.Clear();
                    Console.WriteLine("***********************");
                    Console.WriteLine("   Jogo da Forca");
                    Console.WriteLine("***********************\n");

                    if (attempts < 3)
                    {
                        Console.WriteLine($"Tips: {dicas[indexRand]}\n");
                    }

                    // Display Guessed Word
                    Console.Write("Word: ");
                    for (int i = 0; i < guessedWord.Length; i++)
                    {
                        Console.Write($"{guessedWord[i]} ");
                    }

                    Console.WriteLine("\n");
                    Console.WriteLine($"Remaining attempts: {attempts}");
                    Console.WriteLine($"Word size: {chosenWord.Length}\n");

                    Console.WriteLine("Congratulations, you won!!!!!");
                    Console.ReadKey();
                    break;
                }

                if (attempts == -1)
                {
                    Console.WriteLine("\nOops..., failed attempts");
                    Console.WriteLine(chosenWord);
                    Console.ReadKey();
                    break;
                }

                Console.ReadKey();
            } while (!Win);
        }
    }
}
