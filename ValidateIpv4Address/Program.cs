static bool HasFourIntegers(string address)
{
    string[] addressArray = address.Split(".", StringSplitOptions.RemoveEmptyEntries);

    bool hasFourStrings = addressArray.Length == 4;
    
    bool hasOnlyIntegers = true;
    for (int i = 0; i < addressArray.Length; i++)
    {
        hasOnlyIntegers &= int.TryParse(addressArray[i], out _);
    }

    return hasFourStrings && hasOnlyIntegers;
}

static bool NoLeadingZeroes(string address)
{
    string[] addressArray = address.Split(".");
    bool NoLeadingZeroes = true;

    foreach (string str in addressArray)
    {
        NoLeadingZeroes &= !(str.StartsWith('0') && str.Length > 1);
    }

    return NoLeadingZeroes;
}

static bool InRange(string address)
{
    string[] addressArray = address.Split(".");
    bool allInRange = true;

    foreach (string str in addressArray)
    {
        int number = Convert.ToInt32(str);
        allInRange &= number >= 0 && number < 256;
    }

    return allInRange;
}

string[] ipv4Input = {"107.31.1.5", "255.0.0.255", "555..0.555", "255...255"};

foreach (string address in ipv4Input)
{
    if (HasFourIntegers(address) && NoLeadingZeroes(address) && InRange(address))
        Console.WriteLine($"{address} is a valid ipv4 address.");
    else
        Console.WriteLine($"{address} is an invalid ipv4 address.");
}