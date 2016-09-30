using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class soundManager : MonoBehaviour {

    public GameObject mute;
    public AudioSource mySource;
    public static bool isMute;
    public AudioClip gameOverSound;

    [SerializeField]
    private GameObject myMusicHolder;

    void Start()
    {
        myMusicHolder = GameObject.Find("musicHolder");
        mySource = myMusicHolder.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (isMute)
            mute.SetActive(false);

        if (isMute == false)
            mute.SetActive(true);

    }

    public void soundPrefs()
    {
        isMute = !isMute;
        if (isMute)
        {
            //hiding mute button when mute is pressed
            mySource.volume = 0;
        }

        else
        {
            //hiding sound button when sound On is pressed
            mySource.volume = 0.2f;
        }

    }
}
