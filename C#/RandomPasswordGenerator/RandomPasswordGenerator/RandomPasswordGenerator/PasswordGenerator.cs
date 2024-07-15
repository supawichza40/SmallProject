using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomPasswordGenerator
{
    internal class PasswordGenerator
    {
        // We will make an assumption that we will limit the list of characters to be used in the password.
        // Better option is to use HaskSet, and access it by index, but for simplicity we will use List.

        // Improvement we can have a characterPool instead of 4 List<char>, and if any of the flag is enabled, we will add those into the pool.

        public PasswordGenerator(int expectedLength, bool expectedUppercase, bool expectedLowercase, bool expectedNumber, bool expectedSpecialCharacter)
        {
            rand = new Random();

            userPassword = "";
            userExpectedLength = expectedLength;
            userExpectedUppercase = expectedUppercase;
            userExpectedLowercase = expectedLowercase;
            userExpectedNumber = expectedNumber;
            userExpectedSpecialCharacter = expectedSpecialCharacter;

            GenerateLowerCaseCharacters();
            GenerateUpperCaseCharacters();
            GenerateNumbers();

        }

        public Random rand { get; set; }
        // Lowercase list
        List<char> lowerCaseCharacters = new List<char>();
        // Uppercase list
        List<char> upperCaseCharacters = new List<char>();
        // number list
        List<char> numbers = new List<char>();
        //special characterlist
        string specialCharacters = "!@#$%^&*()_+";
        // store password
        private String userPassword { get; set; }

        // User expected length
        private int userExpectedLength { get; set; }

        // User expected uppercase
        private bool userExpectedUppercase { get; set; }

        // User expected lowercase
        private bool userExpectedLowercase { get; set; }

        // User expected number
        private bool userExpectedNumber { get; set; }

        // User expected special character
        private bool userExpectedSpecialCharacter { get; set; }

        private void GenerateNumbers()
        {
            // Generate numbers
            for (char c = '0'; c <= '9'; c++)
            {
                numbers.Add(c);
            }
            Console.WriteLine($"Number valid character: {String.Join(",",numbers)}");
        }

        private void GenerateUpperCaseCharacters()
        {
            // Generate uppercase characters
            for (char c = 'A'; c <= 'Z'; c++)
            {
                upperCaseCharacters.Add(c);
            }
            // Print upper case

            Console.WriteLine($"Upper case valid character: {String.Join(",",upperCaseCharacters)}");
        }

        private void GenerateLowerCaseCharacters()
        {
            // Generate lowercase characters
            for (char c = 'a'; c <= 'z'; c++)
            {
                lowerCaseCharacters.Add(c);
            }
            Console.WriteLine($"Lower Case valid character: {String.Join(",",lowerCaseCharacters)}");
        }
        // Generate Password
        public string GeneratePassword()
        {
            while (userPassword.Length< userExpectedLength)
            {
                
                int randomNumber = rand.Next(0,3+1);
                switch (randomNumber)
                {
                    case 0:
                        if (userExpectedLowercase)
                        {
                            userPassword += lowerCaseCharacters[rand.Next(0, lowerCaseCharacters.Count)];
                        }
                        break;
                    case 1:
                        if (userExpectedUppercase)
                        {
                            userPassword += upperCaseCharacters[rand.Next(0, upperCaseCharacters.Count)];
                        }
                        break;
                    case 2:
                        if (userExpectedNumber)
                        {
                            userPassword += numbers[rand.Next(0, numbers.Count)];
                        }
                        break;

                    case 3:
                        if (userExpectedSpecialCharacter)
                        {
                            userPassword += specialCharacters[rand.Next(0, specialCharacters.Length)];
                        }
                        break;
                    default:
                        break;
                }
            }
            return userPassword ;
        }
    }
}
