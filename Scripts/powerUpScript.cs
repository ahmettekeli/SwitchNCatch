using UnityEngine;
using System.Collections;

public class powerUpScript : MonoBehaviour {

    public float growAmount=3f;
    public float shrinkAmount=1f;
    public GameObject ballHolder;
    public float growtimer = 10f, shrinkTimer = 10f, speedUpTimer = 10f, speedDownTimer = 10f, multiplierTimer = 10f;
    public bool growTaken, shrinkTaken, speedUpTaken, speedDownTaken,multiplierTaken;
    public float puSpeed = 2f;

    private Vector3 defaultSize;
    public bool growActive,shrinkActive, speedUpActive,speedDownActive,multiplierActive;
    public bool growPA, shrinkPA, speedUpPA, speedDownPA;
    private float sizePower=0.005f;
    private float second = .00002f;

    void Start()
    {
        defaultSize = ballHolder.transform.localScale;
        growAmount = defaultSize.x + 0.6f;
        shrinkAmount = defaultSize.x - 0.4f;
    }

    void Update()
    {
        //grow power up timer
        if (growTaken)
        {        
            //StartCoroutine("growPower"); //growActive tekrar grow alındıgında true olmalı.
            if(growActive)
            {
                growtimer = 10;
                growActive = false;
            }
            growtimer -= Time.deltaTime;
            if (growtimer <= 0)
            {
                backToNormalSize();
                growTaken = false;
                growtimer = 10f;
            }
            growPA = false;       
            

        } //grow power up timer end

        //shrink power up timer
        if (shrinkTaken)
        {
            if (shrinkActive)
            {
                shrinkTimer = 10;
                shrinkActive = false;
            }
            shrinkTimer -= Time.deltaTime;
            if (shrinkTimer <= 0)
            {
                backToNormalSize();
                shrinkTaken = false;
                shrinkTimer = 10f;
            }
            shrinkPA = false;
        }//shrink power up end

        //speedup power up timer
        if (speedUpTaken)
        {
            if (speedUpActive)
            {
                speedUpTimer = 10;
                speedUpActive = false;
            }
            speedUpTimer -= Time.deltaTime;
            if (speedUpTimer <= 0)
            {
                if(!speedDownPA)
                speedFix();
                speedUpTaken = false;
                speedUpTimer = 10f;
            }
            speedUpPA = false;
        }//speed up timer end

        //speed down power up timer
        if (speedDownTaken)
        {
            if (speedDownActive)
            {
                speedDownTimer = 10;
                speedDownActive = false;
            }
            speedDownTimer -= Time.deltaTime;
            if (speedDownTimer <= 0)
            {
                if(!speedUpPA)
                speedFix();
                speedDownTaken = false;
                speedDownTimer = 10f;
            }
            speedDownPA = false;
        }//speed down timer end

        //Score multiplier power up taken
        if (multiplierTaken)
        {
            if (multiplierActive)
            {
                multiplierTimer = 10;
                multiplierActive = false;
            }
            multiplierTimer -= Time.deltaTime;
            if (multiplierTimer <= 0)
            {
                scoreMultipliarFix();
                multiplierTaken = false;
                multiplierTimer = 10f;
            }


        } //grow power up timer end



    }


    //Smooth growth --> growing the balls over time
    IEnumerator growCoroutine()
    {
        while (transform.localScale.x < growAmount)
        {
            transform.localScale += new Vector3(1f, 1f, 0f) * (Time.deltaTime * puSpeed);
            yield return new WaitForSeconds(second);

        }
        yield return null;


    }

    //smooth shrink --> shinking the balls over time
    IEnumerator shrinkCoroutine()
    {
        while(transform.localScale.x>shrinkAmount)
        {
            transform.localScale -= new Vector3(1f, 1f, 0f) * (Time.deltaTime * puSpeed);
            yield return new WaitForSeconds(second);
        }
        yield return null;
    }

    IEnumerator BackToNormalSizeCoroutine()
    {
        if (transform.localScale.x < defaultSize.x)
        {
            while (transform.localScale.x < defaultSize.x)
            {
                transform.localScale += new Vector3(1f,1f,0f) * (Time.deltaTime*puSpeed);
                yield return new WaitForSeconds(second);
            }
        }

        else if (transform.localScale.x > defaultSize.x)
        {
            while (transform.localScale.x > defaultSize.x)
            {
                transform.localScale -= new Vector3(1f,1f,0f) * (Time.deltaTime*puSpeed);
                yield return new WaitForSeconds(second);
            }
        }

        yield return null;
    }

    public void grow()
    {
        StartCoroutine("growCoroutine");
    }

    public void shrink()
    {
        StartCoroutine("shrinkCoroutine");
    }

    public void backToNormalSize()
    {
        StartCoroutine("BackToNormalSizeCoroutine");
    }

    public void speedUp()
    {
        SwipeToRotateScript.powerSpeed = 2.6f;
    }

    public void speedDown()
    {
        SwipeToRotateScript.powerSpeed = 0.4f;
    }

    public void speedFix()
    {
        SwipeToRotateScript.powerSpeed = 1;
    }

    public void scoreMultipliarInc()
    {
        ScoreScript.multipliar = 2;
    }

    public void scoreMultipliarFix()
    {
        ScoreScript.multipliar = 1;
    }
}
