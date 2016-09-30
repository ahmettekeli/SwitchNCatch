using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour 
{

	public static float score;
	public static float gameLife=3;
    public static float multipliar = 1;
    public static bool gameOver;
    public static bool isPaused;
    public GameObject[] lifeLeft;
    public GameObject pausePanel;
    public Text scoreTxt;
    public Text bestScoreTxt;

    private int bestScore;
    private bool isBest;
    [SerializeField]
    private AudioClip bestSound;
    [SerializeField]
    private AudioClip gameOverSound;

	// Use this for initialization
	void Start () 
	{
		score = 0;
		gameLife = 3;
		gameOver = false;
        bestScore = PlayerPrefs.GetInt("Highscore");

    }
	
	// Update is called once per frame
	void Update () 
	{
        //back button config
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene("Game Over");
        //menu button config
        if (Input.GetKeyDown(KeyCode.Menu))
            isPaused = true;
        if (gameOver)
        {
            AudioSource.PlayClipAtPoint(gameOverSound, transform.position);
            SceneManager.LoadScene("Game Over");
           // admob_script.ShowAd();
        }

        //hearts' visibility
        if (gameLife == 2)
            lifeLeft[2].SetActive(false);
        else if (gameLife == 1)
            lifeLeft[1].SetActive(false);
        else if (gameLife == 0)
            lifeLeft[0].SetActive(false);

        //score
        scoreTxt.text = score.ToString();
        bestScoreTxt.text = "Best: "+bestScore.ToString();

        if (score>bestScore)
        {
            isBest = true;
            bestScore = (int)score;
            if(isBest)
            {
                isBest = false;
                AudioSource.PlayClipAtPoint(bestSound, transform.position);
            }
            
        }

    }

	public static void lifeDecrease()
	{
		gameLife -= 1f;
	}

    public static void lifeIncrease()
    {
        gameLife += 1f;
    }

	public static void scoreIncrease()
	{
        Debug.Log("score increase icine girdi");
		score += 1f*multipliar;
	}

    public static void scoreDecrease()
    {
        score -= 1f;
    }

    public static void scoreDecAnim()
    {
        //score -1 animation
    }

    public static void lifeIncAnim()
    {
        //life +1 animation
    }
    public void pausePlay()
    {
        isPaused = true;
        if (isPaused)
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
            //pausePanel.transform.position = new Vector3(0,0,-150f);
            //Debug.Log(pausePanel.transform.position.z);
        }
    }

}
