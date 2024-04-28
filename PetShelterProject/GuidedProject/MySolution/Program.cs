using Microsoft.Data.Analysis;

var dataFrame = DataFrame.LoadCsv("data/ourAnimals.csv");


// variables that support data entry
int maxPets = 8;
string? readResult;
string menuSelection;

do {
    Console.Clear();

    Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
    Console.WriteLine(" 1. List all of our current pet information");
    Console.WriteLine(" 2. Add a new animal friend to the ourAnimals array");
    Console.WriteLine(" 3. Ensure animal ages and physical descriptions are complete");
    Console.WriteLine(" 4. Ensure animal nicknames and personality descriptions are complete");
    Console.WriteLine(" 5. Edit an animal’s age");
    Console.WriteLine(" 6. Edit an animal’s personality description");
    Console.WriteLine(" 7. Display all cats with a specified characteristic");
    Console.WriteLine(" 8. Display all dogs with a specified characteristic");
    Console.WriteLine();
    Console.WriteLine("Enter your selection number (or type anything else to exit the program)");

    readResult = Console.ReadLine();
    if (readResult != null)
    {
        if (readResult == "")
            menuSelection = "exit";
        else
            menuSelection = readResult.ToLower();
    }
    else
    {
        menuSelection = "exit";
    }

    Console.WriteLine($"You selected menu option {menuSelection}.");
    // Console.WriteLine("Press the Enter key to continue");
    // Console.ReadLine();

    switch (menuSelection)
    {
        case "1":
            Console.Clear();
            Console.WriteLine(dataFrame);
            Console.WriteLine("Press the Enter key to go back to main menu");
            Console.ReadLine();
            break;

        case "2":
            Console.Clear();
            int petCount = 0;
            foreach (DataFrameRow row in dataFrame.Rows) {
                petCount += 1;
            }
            Console.WriteLine($"There are {petCount} out of {maxPets} pets in our shelter.");
            
            string? anotherPet = "y";
            while (anotherPet != "n" && petCount < maxPets)
            {
                petCount += 1;
                string animalSpecies = "";
                string animalID = "";
                string animalAge = "";
                string animalPhysicalDescription = "";
                string animalPersonalityDescription = "";
                string animalNickname = "";

                // get species
                do
                {
                    Console.WriteLine("What's the pet species (dog/cat)?");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                        animalSpecies = readResult.ToLower().Trim();
                } while (!(animalSpecies == "dog" || animalSpecies == "cat"));
                // set animalID
                animalID = animalSpecies == "dog" ? "d"+petCount.ToString()
                                                    : "c"+petCount.ToString();
                // get age or empty string
                bool isInteger = false;
                do
                {
                    Console.WriteLine("What's its age? (Write an integer or leave empty)");
                    readResult = Console.ReadLine();
                    isInteger = int.TryParse(readResult, out _);
                    if (readResult != null)
                        animalAge = readResult.Trim();
                } while (!(animalAge == "" || isInteger));
                // get physical description
                Console.WriteLine("Write a physical description or leave empty");
                readResult = Console.ReadLine();
                if (readResult != null)
                    animalPhysicalDescription = readResult.Trim();
                
                Console.WriteLine("Write a personality description or leave empty");
                readResult = Console.ReadLine();
                if (readResult != null)
                    animalPersonalityDescription = readResult.Trim();
                
                Console.WriteLine("Write a nickname or leave empty");
                readResult = Console.ReadLine();
                if (readResult != null)
                    animalNickname = readResult.Trim();
                // add data to dataFrame
                string[] newPet = {
                    animalID,
                    animalSpecies,
                    animalAge,
                    animalNickname,
                    animalPhysicalDescription,
                    animalPersonalityDescription
                };
                dataFrame.Append(newPet, inPlace: true);
                Console.WriteLine("Pet added.");

                Console.WriteLine("Do you want to add another pet? (y/n, default y)");
                anotherPet = Console.ReadLine();
            }

            Console.WriteLine("Press the Enter key to go back to main menu");
            Console.ReadLine();
            break;

        case "3":
            Console.Clear();
            foreach (DataFrameRow row in dataFrame.Rows)
            {
                if (row["age"] == null)
                {
                    string animalAge = "";
                    Console.WriteLine(row);
                    Console.WriteLine($"Pet with ID {row["id"]} lacks an age value.");
                    // get age or empty string
                    bool isInteger = false;
                    do
                    {
                        Console.WriteLine("What's its age? (Write an integer or leave empty)");
                        readResult = Console.ReadLine();
                        isInteger = int.TryParse(readResult, out _);
                        if (readResult != null)
                            animalAge = readResult.Trim();
                    } while (!(animalAge == "" || isInteger));
                    Single age;
                    if (Single.TryParse(animalAge, out age))
                        row["age"] = age;
                }

                if (row["physical_description"].ToString() == "")
                {
                    Console.WriteLine(row);
                    string animalPhysicalDescription = "";
                    Console.WriteLine($"Pet with ID {row["id"]} lacks a physical description. Enter one below:");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                        animalPhysicalDescription = readResult.Trim();
                    row["physical_description"] = animalPhysicalDescription;
                }
            }

            Console.WriteLine("Press the Enter key to go back to main menu");
            Console.ReadLine();
            break;

        case "4":
            Console.Clear();
            foreach (DataFrameRow row in dataFrame.Rows)
            {
                if (row["nickname"].Equals(""))
                {
                    string nickname = "";
                    Console.WriteLine(row);
                    Console.WriteLine($"Pet with ID {row["id"]} lacks a nickname. Enter one below.");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                        nickname = readResult.Trim();
                    row["nickname"] = nickname;
                }
                if (row["personality"].Equals(""))
                {
                    string personality = "";
                    Console.WriteLine(row);
                    Console.WriteLine($"Pet with ID {row["id"]} lacks a personality description. Enter one below.");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                        personality = readResult.Trim();
                    row["personality"] = personality;
                }
            }
            Console.WriteLine("Press the Enter key to go back to main menu");
            Console.ReadLine();
            break;

        case "5": {
            Console.Clear();
            Console.WriteLine(dataFrame);
            Console.WriteLine();
            
            string[] validIDs = new string[dataFrame.Rows.Count];
            int index = 0;
            foreach (DataFrameRow row in dataFrame.Rows)
            {
                validIDs[index] = row["id"].ToString();
                index++;
            }

            string id = "";
            bool validID = false;            
            while (!validID)
            {
                Console.WriteLine("What's the id of the pet you want to change its age?");
                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    id = readResult.Trim();
                    validID = validIDs.Contains(id);
                }
            }

            float newAge;
            Console.WriteLine("Enter a new age: ");
            readResult = Console.ReadLine();
            if (float.TryParse(readResult, out newAge) && int.TryParse(readResult, out _))
                foreach (DataFrameRow row in dataFrame.Rows)
                    if (row["id"].Equals(id))
                        row["age"] = newAge;
                
            Console.WriteLine("Press the Enter key to go back to main menu");
            Console.ReadLine();
            break;
        }
        case "6": {
            Console.Clear();
            Console.WriteLine(dataFrame);
            Console.WriteLine();
            
            string[] validIDs = new string[dataFrame.Rows.Count];
            int index = 0;
            foreach (DataFrameRow row in dataFrame.Rows)
            {
                validIDs[index] = row["id"].ToString();
                index++;
            }

            string id = "";
            bool validID = false;            
            while (!validID)
            {
                Console.WriteLine("What's the id of the pet you want to edit its personality entry?");
                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    id = readResult.Trim();
                    validID = validIDs.Contains(id);
                }
            }

            string newPersonality = "";
            Console.WriteLine("Enter a personality description: ");
            readResult = Console.ReadLine();
            if (readResult != null)
            {
                newPersonality = readResult.Trim();
                foreach (DataFrameRow row in dataFrame.Rows)
                    if (row["id"].Equals(id))
                        row["personality"] = newPersonality;
            }           
            Console.WriteLine("Press the Enter key to go back to main menu");
            Console.ReadLine();
            break;
        }
        case "7": {
            Console.Clear();
            Console.WriteLine("Write a physical description of the cat.");
            readResult = Console.ReadLine();
            string physicalDescription = "";
            if (readResult != null)
                physicalDescription = readResult;

            Console.WriteLine("Write a personality description of the cat.");
            readResult = Console.ReadLine();
            string personalityDescription = "";
            if (readResult != null)
                personalityDescription = readResult;

            string[] physicalTerms = physicalDescription.ToLower().Split(" ");
            string[] personalityTerms = personalityDescription.ToLower().Split(" ");
            
            Console.WriteLine("Matching cats: ");
            foreach (DataFrameRow row in dataFrame.Rows)
            {
                bool searchMatch = false;
                foreach(string term in physicalTerms)
                {
                    if (term != "")
                        searchMatch |=
                            row["physical_description"].ToString().Contains(term);
                }
                foreach(string term in personalityTerms)
                {
                    if (term != "")
                        searchMatch |=
                            row["personality"].ToString().Contains(term);
                }
                if (searchMatch && row["species"].Equals("cat"))
                {
                    foreach(var value in row.GetValues())
                    {
                        Console.Write(value);
                    }
                    Console.WriteLine();
                }
            }

            Console.WriteLine("Press the Enter key to go back to main menu");
            Console.ReadLine();
            break;
        }
        case "8": {
            Console.Clear();
            Console.WriteLine("Write a physical description of the dog.");
            readResult = Console.ReadLine();
            string physicalDescription = "";
            if (readResult != null)
                physicalDescription = readResult;

            Console.WriteLine("Write a personality description of the cat.");
            readResult = Console.ReadLine();
            string personalityDescription = "";
            if (readResult != null)
                personalityDescription = readResult;

            string[] physicalTerms = physicalDescription.ToLower().Split(" ");
            string[] personalityTerms = personalityDescription.ToLower().Split(" ");
            
            Console.WriteLine("Matching dogs: ");
            foreach (DataFrameRow row in dataFrame.Rows)
            {
                bool searchMatch = false;
                foreach(string term in physicalTerms)
                {
                    if (term != "")
                        searchMatch |=
                            row["physical_description"].ToString().Contains(term);
                }
                foreach(string term in personalityTerms)
                {
                    if (term != "")
                        searchMatch |=
                            row["personality"].ToString().Contains(term);
                }
                if (searchMatch && row["species"].Equals("dog"))
                {
                    foreach(var value in row.GetValues())
                    {
                        Console.Write(value);
                    }
                    Console.WriteLine();
                }
            }
            Console.WriteLine("Press the Enter key to go back to main menu");
            Console.ReadLine();
            break;
        }
        // case "9": // delete row
        //     string? idToDelete = Console.ReadLine();
        //     if (idToDelete != null)
        //         foreach (DataFrameRow row in dataFrame.Rows) {
        //             if (row['id'] == idToDelete)
        //                 row.Drop()
        //         }
        //     break;

        case "exit":
        default:
            readResult = "exit";
            break;
    }
    
} while (readResult != "exit");