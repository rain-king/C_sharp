string pangram = "The quick brown fox jumps over the lazy dog";

string[] arrayOfStrings = pangram.Split(" ");

string[] reversedWords = new string[arrayOfStrings.Length];

for (int i = 0; i < arrayOfStrings.Length; i++)
{
    char[] word = arrayOfStrings[i].ToCharArray();
    Array.Reverse(word);
    reversedWords[i] = new string(word);
}

Console.WriteLine(string.Join(" ", reversedWords));