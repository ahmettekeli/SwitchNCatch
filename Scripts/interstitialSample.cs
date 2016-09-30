using UnityEngine;
using System.Collections;

public class interstitialSample : MonoBehaviour {

	// Use this for initialization
	void Start () {

        Invoke("interstitialShow", 2f);
	}
	public void interstitialShow()
    {
        GoogleMobileAdsDemoScript.ShowInt();
    }
}
