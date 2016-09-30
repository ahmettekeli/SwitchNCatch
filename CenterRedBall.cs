using UnityEngine;
using System.Collections;

public class CenterRedBall : MonoBehaviour {

	public AudioClip destroySound, wrongSound, gameOverSound;
    public powerUpScript pus;

    void Start()
    {
        GameObject circleholder = GameObject.Find("marbles");
        pus = circleholder.GetComponent<powerUpScript>();
    }

    public void OnCollisionEnter(Collision collision)
	{
		if (this.gameObject.tag == "red" && collision.gameObject.tag == "red")
		{
			Destroy(collision.gameObject);
			AudioSource.PlayClipAtPoint(destroySound, transform.position);
			ScoreScript.scoreIncrease();
		}

        // activating shrink powerup
        else if (collision.gameObject.tag =="shrink")
        {
            Destroy(collision.gameObject);
            pus.shrinkTaken = true;
            pus.shrinkActive = true;
            pus.shrinkPA = true;
            pus.shrink();

        }
        //increasing score multiplier by x2
        else if (collision.gameObject.tag == "x2")
        {
            Destroy(collision.gameObject);
            pus.scoreMultipliarInc();
            pus.multiplierActive = true;
            pus.multiplierTaken = true;
        }

        else if(collision.gameObject.tag=="grow"||collision.gameObject.tag=="speedup"||collision.gameObject.tag=="speeddown")
        {
            Destroy(collision.gameObject);
            if (ScoreScript.score != 0)
            {
                ScoreScript.scoreDecrease();
                ScoreScript.scoreDecAnim();
            }

        }

        else if(collision.gameObject.tag=="lifeUp")
        {
            Destroy(collision.gameObject);
            ScoreScript.lifeIncrease();
            ScoreScript.lifeIncAnim();
        }

		else
		{
            //fixing back to default speed and size on wrong catch
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
