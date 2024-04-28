var heroHealth = 10;
var monsterHealth = 10;
Random dice = new();

do {
    int attack = dice.Next(1, 11);
    monsterHealth -= attack;
    Console.WriteLine($"Monster lost {attack} health and now has {monsterHealth} health.");
    if (monsterHealth <= 0) 
        break;
    attack = dice.Next(1, 11);
    heroHealth -= attack;
    Console.WriteLine($"Hero lost {attack} health and now has {heroHealth} health.");
} while (heroHealth > 0 && monsterHealth > 0);

if (heroHealth > 0)
    Console.WriteLine("Hero wins!");
else
    Console.WriteLine("Monster wins...");