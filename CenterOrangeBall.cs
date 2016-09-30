using UnityEngine;
using System.Collections;

public class CenterOrangeBall : MonoBehaviour {

	public AudioClip destroySound, wrongSound, gameOverSound;
    public powerUpScript pus;

    void Start()
    {
        GameObject circleholder = GameObject.Find("marbles");
        pus = circleholder.GetComponent<powerUpScript>();
    }

	public void OnCollisionEnter(Collision collision)
	{
		if (this.gameObject.tag == "orange" && collision.gameObject.tag == "orange") //when same color ball collides , score increases,audioclip plays
		{
			Destroy(collision.gameObject);
			AudioSource.PlayClipAtPoint(destroySound, transform.position);
			ScoreScript.scoreIncrease();
			
		}

        else if(collision.gameObject.tag=="speedup") //speedup powerup can only be picked by yellow center ball
        {
            Destroy(collision.gameObject);
            pus.speedUpTaken = true;
            pus.speedUpActive = true;
            pus.speedUpPA = true;
            pus.speedUp();
            Debug.Log("speedup");

        }

        else if(collision.gameObject.tag=="grow"||collision.gameObject.tag=="shrink"||collision.gameObject.tag=="speeddown") //if any other power up collides with red center ball, score decrease.
        {
            Destroy(collision.gameObject);
            if (ScoreScript.score != 0)
            {
                ScoreScript.scoreDecrease();
                ScoreScript.scoreDecAnim();
            }
            AudioSource.PlayClipAtPoint(wrongSound, transform.position);
            //Handheld.Vibrate(); //vibration on wrong matches
        }

        else if(collision.gameObject.tag=="lifeup") // lifeleft increases
        {
            Destroy(collision.gameObject);
            ScoreScript.lifeIncrease();
            ScoreScript.lifeIncAnim();
        }

		//score multiplier activation
        else if (collision.gameObject.tag == "x2")
        {
            Destroy(collision.gameObject);
            pus.scoreMultipliarInc();
            pus.multiplierActive = true;
            pus.multiplierTaken = true;
        }

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
			AudioSource.PlayClipAtPoint(gameOverSound, transform.position);
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
