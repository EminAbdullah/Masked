using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2Gecis : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag=="Player")
        {
            gameObject.GetComponent<TextMeshPro>().enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            PlayerPrefs.SetFloat("P_x", -90);
            PlayerPrefs.SetFloat("P_y", 1);
            PlayerPrefs.SetString("scene", "Level2");
            PlayerPrefs.Save();
            SceneManager.LoadScene("Level2");
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            gameObject.GetComponent<TextMeshPro>().enabled = false;
        }
    }
}
