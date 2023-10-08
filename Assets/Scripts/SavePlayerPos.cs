using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SavePlayerPos : MonoBehaviour
{
    public static SavePlayerPos instance;
    private void Awake()
    {
        instance = this;
        PlayerPosLoad();
    }

    public GameObject player;
    public Vector3 CheckPoint;
    public Vector3 respawnPoint;
    private float health;
    [SerializeField]
    private Slider healthSlider;
    [SerializeField]
    private TMP_Text deathText;
    private int deathCount;
    void Start()
    {
        respawnPoint = player.transform.position;
        health = player.GetComponentInChildren<Stats>().currentHealth;
        deathCount= PlayerPrefs.GetInt("DeathCount");

        if (PlayerPrefs.GetInt("Saved")==1 && PlayerPrefs.GetInt("TimeToLoad")==1)
        {
            
            float pX = CheckPoint.x;
            float pY = CheckPoint.y;

            pX = PlayerPrefs.GetFloat("P_x");
            pY = PlayerPrefs.GetFloat("P_y");
            player.transform.position = new Vector2(pX, pY);
            PlayerPrefs.SetInt("TimeToLoad",0);
            PlayerPrefs.Save();
        }

    }

    public void PlayerPosSave()
    {
        PlayerPrefs.SetFloat("P_x", CheckPoint.x);
        PlayerPrefs.SetFloat("P_y", CheckPoint.y);
        PlayerPrefs.SetInt("Saved", 1);
        PlayerPrefs.Save();
    }

    public void PlayerPosLoad()
    {
        PlayerPrefs.SetInt("TimeToLoad", 1);
        PlayerPrefs.Save();
    }


    private void Update()
    {
        health = player.GetComponentInChildren<Stats>().currentHealth;
        CheckPoint = respawnPoint;
       
        if (health <=0)
        {
          
            PlayerDeath();   
            player.GetComponentInChildren<Stats>().IncreaseHealth(100);
          

        }
      
        healthSlider.value = health;

        if (Input.GetKeyDown(KeyCode.K))
        {
            player.GetComponentInChildren<Stats>().DecreaseHealth(health);
        }

        deathText.text= "Ölüm: "+ deathCount.ToString();
    
    }
    public void PlayerDeath()
    {
        StartCoroutine(DeathWait());
    }

    private IEnumerator DeathWait()
    {

        deathCount++;
        PlayerPrefs.SetInt("DeathCount", deathCount);
        yield return new WaitForSeconds(0.8f);
    
        player.gameObject.SetActive(true);
      
        player.transform.position = SavePlayerPos.instance.respawnPoint;

     

    }
}
