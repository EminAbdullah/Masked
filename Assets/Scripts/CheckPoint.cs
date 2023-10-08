using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.ParticleSystem;

public class CheckPoint : MonoBehaviour
{
    private GameObject flag;
    private GameObject[] LastFlag;

    private void Start()
    {
        flag = transform.GetChild(1).gameObject;
        LastFlag = GameObject.FindGameObjectsWithTag("flag");
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Player")
        {
            for (int i = 0; i < LastFlag.Length; i++)
            {
                if (LastFlag[i].GetComponent<SpriteRenderer>().enabled)
                {
                    LastFlag[i].GetComponent<SpriteRenderer>().enabled = false;
                }
            }
           
            flag.GetComponent<SpriteRenderer>().enabled = true;

            PlayerPrefs.SetFloat("P_x", gameObject.transform.position.x);
            PlayerPrefs.SetFloat("P_y", gameObject.transform.position.y);
            PlayerPrefs.SetInt("Saved", 1);
            PlayerPrefs.Save();
        }
    }

}
