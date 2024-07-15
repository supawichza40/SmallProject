using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomPasswordGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool expectedUppercase;
            bool expectedLowercase;
            bool expectedNumber;
            bool expectedSpecialCharacter;
            int expectedLength;

            Console.WriteLine("Enter the length of the password: ");
            expectedLength = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Do you want to include uppercase characters? (Y/N): ");
            expectedUppercase = Console.ReadLine().ToUpper() == "Y";
            Console.WriteLine("Do you want to include lowercase characters? (Y/N): ");
            expectedLowercase = Console.ReadLine().ToUpper() == "Y";
            Console.WriteLine("Do you want to include numbers? (Y/N): ");
            expectedNumber = Console.ReadLine().ToUpper() == "Y";
            Console.WriteLine("Do you want to include special characters? (Y/N): ");
            expectedSpecialCharacter = Console.ReadLine().ToUpper() == "Y";

            PasswordGenerator passwordGenerator = new PasswordGenerator(expectedLength, expectedUppercase, expectedLowercase, expectedNumber, expectedSpecialCharacter);
            Console.WriteLine($"Generated password: {passwordGenerator.GeneratePassword()}");

            // Improved passwordGenerator
            ImprovedPasswordGenerator passwordGenerator2 = new ImprovedPasswordGenerator(expectedLength, expectedUppercase, expectedLowercase, expectedNumber, expectedSpecialCharacter);
            Console.WriteLine($"Generated password: {passwordGenerator2.GeneratePassword()}");

        }
    }
}
