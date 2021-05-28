using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    bool isEnded = false;
    //public GameObject Player;
    //public Transform spawnpoint;

    public void ended() {
        
        if(!isEnded) {
            isEnded = true;
            //Debug.Log("Over");
            Invoke("Restart", 1f);
        } 
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //Instantiate(Player, spawnpoint.position, Quaternion.identity);
    }
}
