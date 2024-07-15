using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomPasswordGenerator
{
    internal class ImprovedPasswordGenerator
    {
        private readonly Random rand = new Random(); // when we initialise random in quick succession, it initialised with the same seed value due to the system clock.
        private readonly List<char> characterPool = new List<char>();
        private readonly int passwordLength;
        private readonly string specialCharacters = "!@#$%^&*()_+";
        public ImprovedPasswordGenerator(int length, bool includeUppercase, bool includeLowercase, bool includeNumbers, bool includeSpecial)
        {
            this.passwordLength = length;
            if (includeUppercase) GenerateCharacterPool('A', 'Z');
            if (includeLowercase) GenerateCharacterPool('a', 'z');
            if (includeNumbers) GenerateCharacterPool('0', '9');
            if (includeSpecial)
            {
                foreach (var c in specialCharacters)
                {
                    characterPool.Add(c);
                }
            }
            Console.WriteLine($"Valid characters: {String.Join(",", characterPool)}");


        }
        public void GenerateCharacterPool(char mixChar, char maxChar)
        {
            for (char c = mixChar; c <= maxChar; c++)
            {
                characterPool.Add(c);
            }
        }
        public string GeneratePassword()
        {
            string password = "";
            for (int i = 0; i < passwordLength; i++)
            {
                password += characterPool[rand.Next(0, characterPool.Count)];
            }
            return password;
        }
    }
}
