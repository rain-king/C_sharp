Random dice = new Random(5);

int roll1 = dice.Next(1, 7);
int roll2 = dice.Next(1, 7);
int roll3 = dice.Next(1, 7);

int total = roll1 + roll2 + roll3;

Console.WriteLine($"Dice roll: {roll1} + {roll2} + {roll3} = {total}");

// EXERCISE FOR LATER, what is the probability of rolling doubles?
bool rolledDoubles = roll1 == roll2 || roll2 == roll3 || roll3 == roll1;
bool rolledTriples = roll1 == roll2 && roll2 == roll3;

if (rolledDoubles && !rolledTriples) {
    Console.WriteLine("You rolled doubles! +2 bonus to total!");
    total += 2;
}

if (rolledTriples) {
    Console.WriteLine("You rolled triples! +6 bonus to total!");
    total += 6;
}

if (total >= 15) {
    Console.WriteLine("You win!");
} else {
    Console.WriteLine("Sorry, you lose.");
}