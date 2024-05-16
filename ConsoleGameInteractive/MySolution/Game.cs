using System.Runtime.InteropServices;

namespace MyGame;

public class Game
{
    private int Mod(int x, int m) => (x%m + m)%m;
    private Random random = new Random();

    // Console position of the player
    private int playerX = 0;
    private int playerY = 0;

    // Console position of the food
    private int foodX = 0;
    private int foodY = 0;

    // Available player and food strings
    private readonly string[] states = {"('-')", "(^-^)", "(X_X)"};
    private readonly string[] foods = {"@@@@@", "$$$$$", "#####"};
    // Current player string displayed in the Console
    private string player = "";

    // Index of the current food
    private int food = 0;
    private int height = Console.WindowHeight - 1;
    private int width = Console.WindowWidth - 5;
    private bool fastMovement = false;
    public bool ExitOnNonDirectionalKey {get; set;} = false;
    public bool Wrap {get; set;} = true;
    public bool ShouldExit {get; set;} = false;
    public Game(bool exitOnNonDirectionalKey, bool wrap)
    {
        ExitOnNonDirectionalKey = exitOnNonDirectionalKey;
        Wrap = wrap;
    }
    public void Start()
    {
        Console.CursorVisible = false;
        player = states[0];

        Console.Clear();
        ShowFood();
        Console.SetCursorPosition(0, 0);
        Console.Write(player);

        while (!ShouldExit) 
        {
            if (TerminalResized())
            {
                Console.WriteLine("Terminal was resized. Program exiting.");
                ShouldExit = true;
                break;
            }
            Move(ExitOnNonDirectionalKey, fastMovement);
            if (ateFood())
            {
                ClearFoods();
                ChangePlayer();
                ShowFood();
            }
            PlayerEffect();
        }
    }
    
    public void End()
    {
        Console.CursorVisible = true;
        Console.WriteLine();
    }

    private void PlayerEffect()
    {
        switch(player)
        {
            case "(^-^)":
                fastMovement = true;
                break;
            case "(X_X)":
                FreezePlayer();
                break;
            default:
                fastMovement = false;
                break;
        }
    }

    private void ClearFoods()
    {
        Console.Clear();
        Console.SetCursorPosition(playerX, playerY);
        Console.Write(player);
    }

    // return true if player is overlapping on food
    private bool ateFood()
    {
        return Math.Abs(playerX - foodX) < player.Length
            && playerY == foodY;
    }

    // Returns true if the Terminal was resized 
    private bool TerminalResized() 
    {
        return height != Console.WindowHeight - 1 || width != Console.WindowWidth - 5;
    }

    // Displays random food at a random location
    private void ShowFood() 
    {
        // Update food to a random index
        food = random.Next(0, foods.Length);

        // Update food position to a random location
        foodX = random.Next(0, width - player.Length);
        foodY = random.Next(0, height - 1);

        // Display the food at the location
        Console.SetCursorPosition(foodX, foodY);
        Console.Write(foods[food]);
    }

    // Changes the player to match the food consumed
    private void ChangePlayer() 
    {
        player = states[food];
        Console.SetCursorPosition(playerX, playerY);
        Console.Write(player);
    }

    // Temporarily stops the player from moving
    private void FreezePlayer() 
    {
        System.Threading.Thread.Sleep(1000);
        player = states[0];
    }

    // Reads directional input from the Console and moves the player
    private void Move(bool exitOnNonDirectionalKey = false, bool fastMovement = false) 
    {
        int lastX = playerX;
        int lastY = playerY;
        
        switch (Console.ReadKey(true).Key) 
        {
            case ConsoleKey.UpArrow:
            case ConsoleKey.W:
                playerY--; 
                break;
            case ConsoleKey.DownArrow:
            case ConsoleKey.S:
                playerY++; 
                break;
            case ConsoleKey.LeftArrow:
            case ConsoleKey.A:
                if (fastMovement)
                    playerX -= 3;
                else
                    playerX--; 
                break;
            case ConsoleKey.RightArrow:
            case ConsoleKey.D:
                if (fastMovement)
                    playerX += 3;
                else
                    playerX++; 
                break;
            case ConsoleKey.Escape:     
                ShouldExit = true; 
                break;
            default:
                if (exitOnNonDirectionalKey)
                    ShouldExit = true;
                break;
        }

        // Clear the characters at the previous position
        Console.SetCursorPosition(lastX, lastY);
        for (int i = 0; i < player.Length; i++) 
        {
            Console.Write(" ");
        }

        // Wrap player position around the Terminal window
        if (Wrap)
        {
            playerX = Mod(playerX, width+1);
            playerY = Mod(playerY, height+1);
        }
        else
        {
            // Keep player position within the bounds of the Terminal window
            playerX = (playerX < 0) ? 0 : (playerX >= width ? width : playerX);
            playerY = (playerY < 0) ? 0 : (playerY >= height ? height : playerY);
        }

        // Draw the player at the new location
        Console.SetCursorPosition(playerX, playerY);
        Console.Write(player);
    }
}
