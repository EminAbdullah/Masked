using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void NewGame()
    {
        PlayerPrefs.DeleteKey("P_x");
        PlayerPrefs.DeleteKey("P_y");
        PlayerPrefs.DeleteKey("TimeToLoad");
        PlayerPrefs.DeleteKey("Saved");
        PlayerPrefs.DeleteKey("scene");
        PlayerPrefs.DeleteKey("DeathCount");
        SceneManager.LoadScene("Level1");
    }

    public void LoadGame()
    {
        if (PlayerPrefs.GetString("scene")=="Level2")
        {
            SceneManager.LoadScene("Level2");
        }
        else
        {
            SceneManager.LoadScene("Level1");

        }
       
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
