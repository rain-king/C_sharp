using System.Runtime.InteropServices;

Console.WriteLine("Enter an integer between 5 and 10: ");
string? input = Console.ReadLine();
int inputNumber;
bool validInput = int.TryParse(input, out inputNumber);

while (inputNumber < 5 || inputNumber > 10 || !validInput) {
    if (!validInput)
        Console.WriteLine("You entered an invalid number, please try again.");
    else
        Console.WriteLine($"You entered {inputNumber}. Please enter a number between 5 and 10.");
    input = Console.ReadLine();
    validInput = int.TryParse(input, out inputNumber);
}

Console.WriteLine($"Your input ({input}) has been accepted.");