using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    SavePlayerPos playerPosData;
    public GameObject PausePanel;
    

    private void Start()
    {
        playerPosData = GetComponent<SavePlayerPos>();
    }
    public void returnMenu()
    {
        Time.timeScale = 1.0f;
        playerPosData.PlayerPosSave();
        SceneManager.LoadScene("Menu");
    }

    public void _Continue()
    {
        PausePanel.SetActive(false);
        
         Time.timeScale = 1.0f;
     
       

    }

    public void _Pause()
    {
        
       
       Time.timeScale = 0.0f;
        
           
        PausePanel.SetActive(true);

    }

    public void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (Time.timeScale == 0.0f)
            {
                _Continue();
            }
            else
            {
                _Pause();
            }
            
        }
     
    }
}
