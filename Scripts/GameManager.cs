using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static bool gameStarter;

    public GoogleMobileAdsDemoScript gmad;

    private static GameManager instance = null;
    public static GameManager Instance
    {
        get { return instance; }
    }

    void Awake()
    {
		//game manager stays alive with every single scene.
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);

        gmad.RequestBanner();
        gmad.ShowBanner();
        gmad.RequestInterstitial();
    }



    public void startGame()
    {
        gameStarter = true;
    }

}
