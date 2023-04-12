using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//GAME MENU
public class MainMenu : MonoBehaviour
{

    public string sceneLoaded="";
    //function for the level selection
    public void PlayLevel(string livello)
    {
        //load the scene "livello"
        SceneManager.LoadScene(livello);
        
    }

    //function to close the game
    public void QuitGame()
    {
        Application.Quit();
    }

    
}
