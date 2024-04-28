using System.Runtime.CompilerServices;

string[] ShuffledArray(string[] array)
{
    Random random = new();
    int arrayLength = array.Length;
    string[] newArray = new string[arrayLength];
    for (int i = 0; i < arrayLength; i++)
        newArray[i] = array[i];
    
    for (int i = 0; i < arrayLength*2; i++)
    {
        // shuffle item[r1] with item[r2]
        int r1 = random.Next(arrayLength);
        int r2 = random.Next(arrayLength);

        var temp = newArray[r2];
        newArray[r2] = newArray[r1];
        newArray[r1] = temp;
    }
    
    return newArray;
}

// TODO: update to use List<strings> internally, would be more readable, memory efficient but slower
string[,] SplittedArray(string[] array, int numberOfGroups)
{
    // get number of items in each group
    // for groups - 1 first items round division
    int itemsForFirstGroups = Convert.ToInt32((decimal)array.GetLength(0) / numberOfGroups);
    // for last group, get the remaining items in the group
    int itemsForLastGroup = array.GetLength(0) - itemsForFirstGroups * (numberOfGroups - 1);
    // get `number_of_items` items for first `groups - 1` groups
    // get `remainder` items for last group

    string[,] groups = new string[numberOfGroups, Math.Max(itemsForFirstGroups, itemsForLastGroup)];

    // arrayIndex goes from 0 to (groups - 1)*number_of_items
    int arrayIndex = 0;
    for (int i = 0; i < numberOfGroups - 1; i++)
    {
        for (int j = 0; j < itemsForFirstGroups; j++)
        {
            groups[i, j] = array[arrayIndex];
            arrayIndex += 1;
        }
    }
    // arrayIndex goes from `(groups - 1)*number_of_items + 1` to `(groups - 1)*number_of_items + remainder = array.GetLength(0)`
    for (int j = 0; j < itemsForLastGroup; j++)
    {
        groups[numberOfGroups - 1, j] = array[arrayIndex];
        arrayIndex += 1;
    }

    return groups;
}

void DisplayGroups(string[] pettingZoo, int numberOfGroups)
{
    string[,] groups = SplittedArray(pettingZoo, numberOfGroups);
    for (int groupNumber = 0; groupNumber < groups.GetLength(0); groupNumber++)
    {
        Console.Write($"Group {groupNumber} sees animals: ");
        for (int animalNumber = 0; animalNumber < groups.GetLength(1); animalNumber++)
        {
            string? animal = groups[groupNumber, animalNumber];
            if (animal != null)
                Console.Write(animal + ", ");
        }
        Console.WriteLine();
    }
}


string[] pettingZoo =
{
    "alpacas", "capybaras", "chickens", "ducks", "emus", "geese",
    "goats", "iguanas", "kangaroos", "lemurs", "llamas", "macaws",
    "ostriches", "pigs", "ponies", "rabbits", "sheep", "tortoises",
    "lions"
};

// RandomizeAnimals();

Console.WriteLine("School A");
DisplayGroups(ShuffledArray(pettingZoo), 6);

Console.WriteLine("School B");
DisplayGroups(ShuffledArray(pettingZoo), 3);

Console.WriteLine("School C");
DisplayGroups(ShuffledArray(pettingZoo), 2);
