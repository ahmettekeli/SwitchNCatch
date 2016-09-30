using UnityEngine;
using System.Collections;

public class SwipeToRotateScript : MonoBehaviour
{
    public float speed = 440f;
    public static float powerSpeed = 1;
    public float minSwipeDist, maxSwipeTime;
    public AudioClip rotationSound;
    public int rotationDirection;
    public Vector3 currentRotation, targetRotation;
    private Vector3 curEuler;

    private Vector3 startPos;
    private float swipeStartTime;
    private float minSwipeDistX;
    private float minSwipeDistY;
    [SerializeField]
    private bool rotating;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];

			//recognizin what kind of touch has been happened?
            switch (touch.phase)
            {
                case TouchPhase.Began:

                    startPos = touch.position;
                    break;

                case TouchPhase.Ended:

                    float swipeDistHorizontal = (new Vector3(touch.position.x, 0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;
                    if (swipeDistHorizontal > minSwipeDistX)
                    {
						//right swipe
                        float swipeValue = Mathf.Sign(touch.position.x - startPos.x);
                        if (swipeValue > 0)
                        {
                            rotationDirection = 1;
                            ballRotate();
                            //transform.position = new Vector3(transform.position.x + 0.03f, transform.position.y, transform.position.z);
                        }

						//letf swipe
                        else if (swipeValue < 0)
                        {
                            rotationDirection = -1;
                            ballRotate();

                        }
                    }
                    break;
            }
        }
    }

    IEnumerator rotateAngle()
    {
		//ignoring touches when rotating
        if (rotating)
        {
            yield break;
        }
        rotating = true;
		
		//rotating 90 degrees depending on rotation direction
        if (rotationDirection == -1)
        {
            float newAngle = curEuler.z + 90f;
            while (curEuler.z < newAngle)
            {
                curEuler.z = Mathf.MoveTowards(curEuler.z, newAngle, speed * Time.deltaTime*powerSpeed);
                transform.eulerAngles = curEuler;
                yield return null;
            }
        }

        else if (rotationDirection == 1)
        {
            float newAngle = curEuler.z - 90f;
            while (curEuler.z > newAngle)
            {
                curEuler.z = Mathf.MoveTowards(curEuler.z, newAngle, speed * Time.deltaTime*powerSpeed);
                transform.eulerAngles = curEuler;
                yield return null;
            }
        }

        rotating = false;
    }

    public void ballRotate()
    {
        StartCoroutine("rotateAngle");
    }
}
