using UnityEngine;
using System.Collections;

public class soundSourceScript : MonoBehaviour {

	public static bool soundPlayable=false;
	public AudioClip gameOverSound;
	// Use this for initialization
	
	// Update is called once per frame
	void Update (){

		//if(soundPlayable==true)
		//{
			//AudioSource.PlayClipAtPoint(gameOverSound, transform.position);
			//soundPlayable = false;
		//}
		//DontDestroyOnLoad(this.gameObject);
	
	}
}
