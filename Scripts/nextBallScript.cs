using UnityEngine;
using System.Collections;

public class nextBallScript : MonoBehaviour {

	
	public  GameObject[] balls;
	public  Vector3 pos;
    public Spawner spwn;
	// Use this for initialization
	void Start () {
		pos = transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	public void nextBallSign()
	{
		switch (spwn.i)
		{
			case 0:
				GameObject Ball = Instantiate(balls[0], pos ,Quaternion.identity) as GameObject;
				break;
			case 1:
				GameObject Ball2 = Instantiate(balls[1],pos, Quaternion.identity) as GameObject;
				break;
			case 2:
				GameObject Ball3 = Instantiate(balls[2],pos, Quaternion.identity) as GameObject;
				break;
			case 3:
				GameObject Ball4 = Instantiate(balls[3],pos, Quaternion.identity) as GameObject;
				break;
		}
	}

}
