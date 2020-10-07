using UnityEngine;
using UnityEngine.UI;


public class Hacker : MonoBehaviour
{
    string[] level1Passwords = { "facebook", "privacy", "content", "profile", "repost"};
    string[] level2Passwords = { "money", "vault", "security", "loan", "card"};
    string[] level3Passwords = { "arrest", "prisoner", "uniform", "donuts", "handcuffs"};
    string[] level4Passwords = { "ufo", "alien", "secret", "military", "restricted" };
    string[] level5Passwords = { "musk", "starlink", "starship", "falcon", "spaceflight"};
    const string menuHint = "You may type 'menu' to exit";
    int level;
    string password;
    private Screen currentScreen;
    public Text terminalText;
    enum Screen { MainMenu, Password, Win };
    private void Start()
    {
        ShowMainMenu();
    }
    
    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("");
        Terminal.WriteLine("Press 1 for the social network");
        Terminal.WriteLine("Press 2 for the local bank");
        Terminal.WriteLine("Press 3 for the police station");
        Terminal.WriteLine("Press 4 for the Area 51");
        Terminal.WriteLine("Press 5 for the SpaceX");
        Terminal.WriteLine("");
        Terminal.WriteLine("Enter your selection:");
        terminalText.color = new Color32(0, 255, 76, 255);
    }
    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu();
        } 
        else if (input == "quit" || input == "close" || input == "exit")
        {
            Terminal.WriteLine("If on the WEB close the tab");
            Application.Quit();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    private void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3" || input == "4" || input == "5");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else if (input == "batman") // easter egg
        {
            Terminal.WriteLine("Entering Bat Computer...");
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level (>_<)");
            Terminal.WriteLine(menuHint);
        }
    }

    private void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("You have choosen level " + level);
        Terminal.WriteLine("");
        Terminal.WriteLine(menuHint);
        Terminal.WriteLine("");
        Terminal.WriteLine("Please enter password: ");
        Terminal.WriteLine("Hint: " + password.Anagram());
    }

    private void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            case 4:
                password = level4Passwords[Random.Range(0, level4Passwords.Length)];
                break;
            case 5:
                password = level5Passwords[Random.Range(0, level5Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid Level Number");
                break;
        }
    }

    private void CheckPassword(string input)
    {
        if (input == password)
        {
            
            DisplayWinScreen();
        }
        else
        {
            //terminalText.color = new Color32(255, 0, 0, 255);
            AskForPassword();
            Terminal.WriteLine("");
            Terminal.WriteLine("*ACCESS DENIED*");
            //Terminal.WriteLine("Try again:");
        }
    }

    private void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine("");
        Terminal.WriteLine(menuHint);
    }

    private void ShowLevelReward()
    {
        terminalText.color = new Color32(0, 255, 76, 255);
        Terminal.WriteLine("*ACCESS GRANTED*");
        Terminal.WriteLine("");
        switch(level)
        {
            case 1:
                Terminal.WriteLine("(〜￣▽￣)〜 ————————————————— 〜(￣△￣〜)");
                Terminal.WriteLine("");
                Terminal.WriteLine("YOU HACKED A SOCIAL NETWORK!");
                break;
            case 2:
                Terminal.WriteLine("(=^･ｪ･^=) ——————————————————— (=^･ｪ･^=)");
                Terminal.WriteLine("");
                Terminal.WriteLine("YOU HACKED THE LOCAL BANK!");
                break;
            case 3:
                Terminal.WriteLine("(★^O^★) ————————————————————— (★^O^★)");
                Terminal.WriteLine("");
                Terminal.WriteLine("YOU HACKED THE POLICE STATION!");
                break;
            case 4:
                Terminal.WriteLine("(＊◕ᴗ◕＊) ————————————————————— (＊◕ᴗ◕＊)");
                Terminal.WriteLine("");
                Terminal.WriteLine("YOU HACKED THE AREA 51!");
                break;
            case 5:
                Terminal.WriteLine("＼(*T▽T*)／ ——————————————— ＼(*T▽T*)／");
                Terminal.WriteLine("");
                Terminal.WriteLine("YOU HACKED THE SPACE X!");
                break;
            default:
                Debug.LogError("Invalid level reached");
                break;

        }
    }
}
