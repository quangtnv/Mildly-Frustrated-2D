using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Manager : MonoBehaviour
{
    private bool isEnded = false;
    public static bool isWin = false;
    public static int deathCount = 0;
    public GameObject pauseUI_script;
    public GameObject pauseButton;
    public GameObject finishMenu;
    public GameObject movement;
    //public TextMeshPro deathText;
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
        if (isWin) {
            finishMenu.SetActive(true);
            pauseUI_script.GetComponent<PauseMenu>().enabled = false;
            movement.GetComponent<CharacterController2D>().enabled = false;
            pauseButton.SetActive(false);
        }
        else {
            finishMenu.SetActive(false);
        }
        
    }

    public void restartButton() {
        finishMenu.SetActive(false);
        Restart();
        deathCount = 0;
    }

    public void quitButton() {
        finishMenu.SetActive(false);
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
