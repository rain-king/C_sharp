Random random = new Random();
int daysUntilExpiration = random.Next(12);
int discountPercentage = 0;

if (daysUntilExpiration <= 10) {
    if (daysUntilExpiration > 5) {
        Console.WriteLine("Your subscription will expire soon. Renew now!");
    } else {
        if (daysUntilExpiration >= 2) {
            discountPercentage = 10;
            Console.WriteLine($"Your subscription expires in {daysUntilExpiration} days.");
        } else if (daysUntilExpiration == 1) {
            discountPercentage = 20;
            Console.WriteLine("Your subscription expires within a day!");
        } else {
            Console.WriteLine("Your subscription has expired");
        }
    }
}

if (discountPercentage > 0)
    Console.WriteLine($"Renew now and save {discountPercentage}%.");