using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    private bool isEnded = false;
    public static int deathCount = 0;
    public Text deathText;
    //public GameObject Player;
    //public Transform spawnpoint;

    public void ended() {
        
        if(!isEnded) {
            isEnded = true;
            //Debug.Log("Over");
            Invoke("Restart", 1f);
        } 
    }

    public void finish() {
        deathText.text = deathCount.ToString();
    }

    public void restartButton() {
        Restart();
        deathCount = 0;
    }

    public void quitButton() {
        SceneManager.LoadScene(0);
        deathCount = 0;
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        deathCount += 1;
        //Debug.Log(deathCount);
        //Instantiate(Player, spawnpoint.position, Quaternion.identity);
    }

}
