using System;
using System.Collections.Generic;

class OldPhonePad
{
    
    static Dictionary<char, string> keys = new Dictionary<char, string>()
    {
        {'2', "ABC"},
        {'3', "DEF"},
        {'4', "GHI"},
        {'5', "JKL"},
        {'6', "MNO"},
        {'7', "PQRS"},
        {'8', "TUV"},
        {'9', "WXYZ"},
        {'0', " "}
    };

    
    static string ProcessInput(string input)
    {
        if (!input.EndsWith("#"))
        {
            Console.WriteLine("Invalid input. Please end the input with '#'.");
            return null;
        }

        input = input.TrimEnd('#');
        string result = string.Empty;

        for (int i = 0; i < input.Length; i++)
        {
            char currentChar = input[i];

            if (currentChar == '*')
            {
                
                if (result.Length > 0)
                    result = result.Remove(result.Length - 1);
            }
            else if (keys.ContainsKey(currentChar))
            {
                
                int count = 1;
                while (i + 1 < input.Length && input[i] == input[i + 1])
                {
                    count++;
                    i++;
                }

                
                string possibleChars = keys[currentChar];
                int index = (count - 1) % possibleChars.Length;
                result += possibleChars[index];
            }
        }

        return result;
    }

    
    static void Main(string[] args)
    {
        bool continueInput = true;

        while (continueInput)
        {
            Console.WriteLine("Please enter the sequence of numbers (end with '#'): ");
            string userInput = Console.ReadLine();

            string output = ProcessInput(userInput);
            if (output != null)
            {
                Console.WriteLine($"Output: {output}");
            }

            
            Console.WriteLine("Would you like to input another sequence? (yes/no): ");
            string tryAgain = Console.ReadLine().Trim().ToLower();

            if (tryAgain != "yes")
            {
                continueInput = false;
                Console.WriteLine("Thank you for using the Old Phone Pad! Goodbye.");
            }
        }
    }
}
