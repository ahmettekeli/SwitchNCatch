using UnityEngine;
using System.Collections;

public class CenterGreenBall : MonoBehaviour {

	public AudioClip destroySound, wrongSound,gameOverSound;
    public powerUpScript pus;

    void Start()
    {
        GameObject circleholder = GameObject.Find("marbles");
        pus = circleholder.GetComponent<powerUpScript>();
    }

    public void OnCollisionEnter(Collision collision)
	{
		if (this.gameObject.tag == "green" && collision.gameObject.tag == "green")
		{
            Debug.Log("green-green icine girdi");
			Destroy(collision.gameObject);
			AudioSource.PlayClipAtPoint(destroySound, transform.position);
			ScoreScript.scoreIncrease();
		}

		//score multiplier power up activation
        else if (collision.gameObject.tag == "x2")
        {
            Destroy(collision.gameObject);
            pus.scoreMultipliarInc();
            pus.multiplierActive = true;
            pus.multiplierTaken = true;
        }

        else if (collision.gameObject.tag=="shrink"|| collision.gameObject.tag=="speeddown" || collision.gameObject.tag=="speedup")
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

		//grow power up activation.
        else if(collision.gameObject.tag=="grow")
        {
            Destroy(collision.gameObject);
            pus.growTaken = true;
            pus.growActive = true;
            pus.growPA = true;
            pus.grow();
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
			ScoreScript.gameOver = true;
            Invoke("gameFinish", 0.5f);
        }

	}

	

	public void gameFinish()
	{
		ScoreScript.gameOver = true;
	}


}
