using UnityEngine;
using System.Collections;

public class CenterYellowBall : MonoBehaviour {

    public AudioClip destroySound, wrongSound, gameOverSound;
    public powerUpScript pus;

    void Start()
    {
        GameObject circleholder = GameObject.Find("marbles");
        pus = circleholder.GetComponent<powerUpScript>();
    }

    public void OnCollisionEnter(Collision collision)
	{
		if (this.gameObject.tag == "yellow" && collision.gameObject.tag == "yellow")
		{
			Destroy(collision.gameObject);
            AudioSource.PlayClipAtPoint(destroySound, transform.position);
			ScoreScript.scoreIncrease();
		}

		//speed down power up activation
        else if(collision.gameObject.tag=="speeddown")
        {
            Destroy(collision.gameObject);
            pus.speedDownTaken = true;
            pus.speedDownActive = true;
            pus.speedDownPA = true;
            pus.speedDown();
            Debug.Log("speeddown");
        }

		//score multiplier activation
        else if (collision.gameObject.tag == "x2")
        {
            Destroy(collision.gameObject);
            pus.scoreMultipliarInc();
            pus.multiplierActive = true;
            pus.multiplierTaken = true;
        }

        else if(collision.gameObject.tag=="shrink"||collision.gameObject.tag=="grow"||collision.gameObject.tag=="speedup")
        {
            Destroy(collision.gameObject);
            if (ScoreScript.score != 0)
            {
                ScoreScript.scoreDecrease();
                ScoreScript.scoreDecAnim();
            }
        }

        else if(collision.gameObject.tag=="lifeup")
        {
            Destroy(collision.gameObject);
            ScoreScript.lifeIncrease();
            ScoreScript.lifeIncAnim();
        }

		//going back to normal speed and size when wrong ball match.Reseting powerups.
		else
		{
			Destroy(collision.gameObject);
            AudioSource.PlayClipAtPoint(wrongSound, transform.position);
			ScoreScript.lifeDecrease();
            pus.speedFix();
            pus.backToNormalSize();
            Handheld.Vibrate();

        }

		if (ScoreScript.gameLife == 0)
		{
            //AudioSource.PlayClipAtPoint(gameOverSound, transform.position);
            soundSourceScript.soundPlayable = true;
            //gameFinish();
            Invoke("gameFinish", 0.5f);
		}
	}

    public void gameFinish()
    {
        ScoreScript.gameOver = true;
    }
}
