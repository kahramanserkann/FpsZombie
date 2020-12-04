using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public GameObject howMenu;
    public GameObject gameEnd;
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }    
    public void OpenMenu()
    {
        howMenu.SetActive(true);
    }
    public void CloseMenu()
    {
        howMenu.SetActive(false);
    }
    public void OpenGameEndMenu()
    {
        gameEnd.SetActive(true);
    }
    public void CloseGameEndMenu()
    {
        gameEnd.SetActive(false);
    }

}
