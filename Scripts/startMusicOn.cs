using UnityEngine;
using System.Collections;

public class startMusicOn : MonoBehaviour {

    private GameObject myMusicHolder;
    public AudioSource mySource;

    // Use this for initialization
    void Start () {
        myMusicHolder = GameObject.Find("musicHolder");
        mySource = myMusicHolder.GetComponent<AudioSource>();
        if(mySource.isPlaying==false)
        mySource.Play();

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
