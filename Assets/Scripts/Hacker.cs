using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Hacker : MonoBehaviour
{
    string[] level1Passwords = { "facebook", "privacy", "content", "profile", "repost"};
    string[] level2Passwords = { "money", "vault", "security", "loan", "card"};
    string[] level3Passwords = { "arrest", "prisoner", "uniform", "donuts", "handcuffs"};
    string[] level4Passwords = { "ufo", "alien", "secret", "military", "restricted" };
    string[] level5Passwords = { "musk", "starlink", "starship", "falcon", "spaceflight"};
    int level;
    string password;
    public Text terminalText;
    enum Screen { MainMenu, Password, Win };
    private Screen currentScreen;
    void Start()
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
        if (input == "1")
        {
            level = 1;
            password = level1Passwords[2];
            StartGame();
        }
        else if (input == "2")
        {
            level = 2;
            password = level2Passwords[1];
            StartGame();
        }
        else if (input == "batman") // easter egg
        {
            Terminal.WriteLine("Entering Bat Computer...");
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level");
        }
    }

    private void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.WriteLine("You have choosen level " + level);
        Terminal.ClearScreen();
        Terminal.WriteLine("Please enter password ");
    }
    private void CheckPassword(string input)
    {
        if (input == password)
        {
            Terminal.WriteLine("*ACCESS GRANTED*");
            terminalText.color = new Color32(0, 255, 76, 255);
        }
        else
        {
            Terminal.WriteLine("*ACCESS DENIED*");
            terminalText.color = new Color32(255, 0, 0, 255);
            Terminal.WriteLine("Try again:");
        }
    }
}
