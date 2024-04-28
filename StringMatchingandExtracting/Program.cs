string message = "(What if) there are (more than) one (set of parentheses)?";
int openingPosition = 0;

while (true)
{
    openingPosition = message.IndexOf('(', openingPosition);
    if (openingPosition == -1) break;

    openingPosition += 1;
    int closingPosition = message.IndexOf(')', openingPosition);
    int length = closingPosition - openingPosition;
    Console.WriteLine(message.Substring(openingPosition, length));
}