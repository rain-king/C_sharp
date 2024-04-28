string[] myStrings = new string[2] { "I like pizza. I like roast chicken. I like salad", "I like all three of the menu choices" };

foreach (string str in myStrings)
{
    string[] subStrings = str.Split('.');
    foreach(string subString in subStrings)
    {
        Console.WriteLine(subString.TrimStart());
    }
}