
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
        {'0'," "}
    };
    static string OldPhonePadmethod(String input)
    {   
        if (input.EndsWith("#"))
        {
            string result = " ";
            char[] chars = input.TrimEnd('#').ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] == '*')
                {
                    if (result.Length > 0)
                    {
                        result = result.Remove(result.Length - 1);
                    }


                }
                else if (keys.ContainsKey(chars[i]))
                {
                    int count = 1;

                    while (i + 1 < chars.Length && chars[i] == chars[i + 1])
                    {
                        count++;
                        i++;
                    }

                    string possiblechar = keys[chars[i]];
                    int index = (count - 1) % chars.Length;
                    result += possiblechar[index];

                }


            }
            return result;
        }
    else
        {
            Console.WriteLine("Invaild Input. Please End with #");
            return null;
        }
    }

    static void Main (string[] args)
    {

        Console.WriteLine(OldPhonePadmethod("33#"));
        Console.WriteLine(OldPhonePadmethod("227 *#"));
        Console.WriteLine(OldPhonePadmethod("4433555 555666#"));
        Console.WriteLine(OldPhonePadmethod("8 88777444666*664#"));

    }

}


