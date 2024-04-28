Console.WriteLine("Enter your role name ('Administrator', 'Manager' or 'User')");
bool validEntry = false;
string? input;

do {
    input = Console.ReadLine();
    if (input != null && input != "")
    {
        string input_regularized = input.Trim().ToLower();
        if (input_regularized == "administrator" || input_regularized == "manager" ||
            input_regularized == "user")
            validEntry = true;
        else
            Console.WriteLine($"Your input ({input}) is invalid," +
                " try your role name ('Administrator', 'Manager' or 'User')");
    } else {
        Console.WriteLine("Empty line, no role assigned.");
        validEntry = true;
    }
} while (!validEntry);

Console.WriteLine($"Your input ({input}) has been accepted.");