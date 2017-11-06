using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine;

public class PauseManager : MonoBehaviour {

    public Canvas canvas;
    public AudioSource music;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (Time.timeScale == 0) {
                Resume();
                music.UnPause();
            } else {
                Time.timeScale = 0;
                canvas.enabled = true;
                music.Pause();
            }      
        }
    }

    public void Resume() {
        Time.timeScale = 1;
        canvas.enabled = false;
    }

    public void BackToMenu() {
        SceneManager.LoadScene("Menu");
    }

    public void Quit() {
        Application.Quit();
    }

}
