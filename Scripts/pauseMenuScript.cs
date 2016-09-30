using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class pauseMenuScript : MonoBehaviour {

    public GameObject pausePanel;
    //public GameObject mute;
    //public AudioSource mySource;
    //[SerializeField]
    //private bool isMute,isSoundOn;

    public void playButton()
    {
        ScoreScript.isPaused = false;
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

 

    public void returnMenu()
    {
        SceneManager.LoadScene("start game");
    }
}
