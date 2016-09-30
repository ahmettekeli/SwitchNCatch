using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class finalScore : MonoBehaviour {
	
	public Text finalSkor;
	public Text highSkor;
	public int highscore = 0;

    public GoogleMobileAdsDemoScript gmad;
    public GameObject myGO;

    void Start () 
	{
        finalSkor.text = "Your Score: " + ScoreScript.score.ToString();
		if (PlayerPrefs.HasKey("Highscore"))
			highscore = PlayerPrefs.GetInt("Highscore");
		//interstitial ad request.
        //myGO = GameObject.Find("Main Camera");
        //gmad = myGO.GetComponent<GoogleMobileAdsDemoScript>();
        //gmad.ShowInterstitial();
        //GoogleMobileAdsDemoScript.ShowInt();
        GPGS_script.PostScore();

    }
	
	// Update is called once per frame
	void Update () {
		
		//updating highscore dynamically during the game.
        if (PlayerPrefs.HasKey("Highscore"))
        {

            if (ScoreScript.score > PlayerPrefs.GetInt("Highscore"))
            {
                PlayerPrefs.SetInt("Highscore", (int)ScoreScript.score);
                PlayerPrefs.Save();
            }
        }
        else
        {
            PlayerPrefs.SetInt("Highscore", (int)ScoreScript.score);
            PlayerPrefs.Save(); 
        }
        highscore = PlayerPrefs.GetInt("Highscore");
        highSkor.text = "High Score: "+highscore.ToString();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("start game");
        }



    }
}
