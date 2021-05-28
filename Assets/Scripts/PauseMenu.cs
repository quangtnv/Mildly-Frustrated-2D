using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePaused = false;
    public GameObject pauseUI;

    public void ButtonPause() {
        if (GamePaused) {
            Resume();
        }
        else {
            Pause();
        }
    }

    public void QuitButton() {
        Resume();
        SceneManager.LoadScene(0);
    }

    public void ResumeButton() {
        Resume();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            ButtonPause();
        }
        //Debug.Log(GamePaused);

    }

    void Resume() {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }

    void Pause() {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }


}
