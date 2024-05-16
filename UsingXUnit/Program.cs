using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics.CodeAnalysis;

namespace UsingXUnit
{
    [ExcludeFromCodeCoverage]
    internal class Program
    {
        static void Main(string[] args)
        {

            int option;
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                //Agrego un console Logger
                builder.AddConsole();
            });

            //Creo un logger
            var logger = loggerFactory.CreateLogger<StringOperations>();


            do
            {
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("Select an action to use the app:");
                Console.WriteLine("1- Concat 2 strings.");
                Console.WriteLine("2- Reverse String.");
                Console.WriteLine("3- Take de string Length.");
                Console.WriteLine("4- Remove white spaces.");
                Console.WriteLine("5- Truncate String.");
                Console.WriteLine("6- Check if the word is a palindrome.");
                Console.WriteLine("7- Count Charcter concurrency.");
                Console.WriteLine("8- Pluralize a word.");
                Console.WriteLine("9- Express a quantity in words.");
                Console.WriteLine("10- Convert From Roman Number to Number.");
                Console.WriteLine("11- Read a Text File.");
                Console.WriteLine("12- Exit.");
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("");

                string inputChoose = Console.ReadLine();

                while (!int.TryParse(inputChoose, out option))
                {
                    Console.WriteLine("Enter a correct option: ");
                    inputChoose = Console.ReadLine();
                }


                StringOperations stringOperations = new StringOperations(logger);

                switch (option)
                {
                    case 1:
                        Console.WriteLine("Write a string:");
                        string input = Console.ReadLine();

                        Console.WriteLine("Write another string:");
                        string input2 = Console.ReadLine();
                        Console.WriteLine("");
                        Console.WriteLine(stringOperations.ConcatenateStrings(input, input2));
                        break;
                    case 2:
                        Console.WriteLine("Write a string:");
                        string inputToReverse = Console.ReadLine();

                        Console.WriteLine("");
                        Console.WriteLine(stringOperations.ReverseString(inputToReverse));
                        break;
                    case 3:
                        Console.WriteLine("Write a string:");
                        string inputLength = Console.ReadLine();

                        Console.WriteLine("");
                        Console.WriteLine(stringOperations.GetStringLength(inputLength));
                        break;
                    case 4:
                        Console.WriteLine("Write a String use white spaces:");
                        string inputWithSpaces = Console.ReadLine();

                        Console.WriteLine("");
                        Console.WriteLine(stringOperations.RemoveWhiteSpace(inputWithSpaces));
                        break;
                    case 5:
                        Console.WriteLine("Write a string:");
                        string inputTruncate = Console.ReadLine();

                        Console.WriteLine("Set max length.");
                        int maxLength = int.Parse(Console.ReadLine());

                        Console.WriteLine("");
                        Console.WriteLine(stringOperations.TruncateString(inputTruncate, maxLength));
                        break;
                    case 6:
                        Console.WriteLine("Write a string:");
                        string inputPalindrome = Console.ReadLine();

                        Console.WriteLine("");
                        Console.WriteLine(stringOperations.IsPalindrome(inputPalindrome));
                        break;
                    case 7:
                        Console.WriteLine("Write a string:");
                        string inputConcurrency = Console.ReadLine();

                        Console.WriteLine("Write a character:");
                        char charToFind = char.Parse(Console.ReadLine());

                        Console.WriteLine("");
                        Console.WriteLine(stringOperations.CountOccurrences(inputConcurrency, charToFind));
                        break;
                    case 8:
                        Console.WriteLine("Write a string: ");
                        string inputToPluralize = Console.ReadLine();

                        Console.WriteLine("");
                        Console.WriteLine(stringOperations.Pluralize(inputToPluralize));
                        break;
                    case 9:
                        Console.WriteLine("Write a word:");
                        string word = Console.ReadLine();

                        Console.WriteLine("Write a quantity:");
                        int quantity = int.Parse(Console.ReadLine());

                        Console.WriteLine("");
                        Console.WriteLine(stringOperations.QuantityInWords(word, quantity));
                        break;
                    case 10:
                        Console.WriteLine("Write a Roman Number:");
                        string romanNumber = Console.ReadLine();

                        Console.WriteLine("");
                        Console.WriteLine(stringOperations.FromRomanToNumber(romanNumber));
                        break;
                    case 11:
                        Console.WriteLine("");
                        IFileReaderConector fileReader = new FileReaderConector();
                        Console.WriteLine(stringOperations.ReadFile(fileReader, "information.txt"));
                        break;
                    default:
                        break;
                }
            } while (option != 12);

            Console.WriteLine("");
            Console.WriteLine("-----------------------------------------");
        }
    }
}
