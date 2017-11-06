using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuManager : MonoBehaviour {

    // The menu canvas is on by default. The rest are off
    public Canvas menu;
    public Canvas play;
    public Canvas info;

    AudioSource buttonSound;

    private void Start() {
        buttonSound = GetComponent<AudioSource>();
    }

    // Turns on the play canvas
    public void PlayTab() {
        turnAllOff();
        buttonSound.Play();
        play.enabled = true;
    }

    // Turns on the info canvas
    public void InfoTab() {
        turnAllOff();
        buttonSound.Play();
        info.enabled = true;
    }

    // Quits the game
    public void QuitTab() {
        Application.Quit();
    }

    // Goes back to menu
    public void BackMenuButton() {
        turnAllOff();
        buttonSound.Play();
        menu.enabled = true;
    }

    // Launches game for one player
    public void OnePlayer() {
        buttonSound.Play();
        SceneManager.LoadScene("Level 1");
    }

    // Launches game for two players
    public void TwoPlayer() {
        buttonSound.Play();
        SceneManager.LoadScene("Level 0");
    }

    // Turns all canvases off
    void turnAllOff() {
        menu.enabled = false;
        play.enabled = false;
        info.enabled = false;
    }
	
}
