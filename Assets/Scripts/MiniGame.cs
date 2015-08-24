﻿using UnityEngine;

public class MiniGame : MonoBehaviour {
    public static float SpeedRate = 4; //скорость ползунка в зависимости от количества выбранных тем

<<<<<<< HEAD
    private static float SpeedRateOnClick = 0.01f;
        // скорость ползунка после остановки пользователем, плавное замедление

    private float IndicatorDirection = 1;
    private bool endOfGame;
    public GameObject greenScale;

    public GameObject indicator;
    public GameObject redScale;
    private float startSpeed;
    public GameObject yellowScale;

    private void Start() {
        indicator.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, SpeedRate*IndicatorDirection*100));
        startSpeed = indicator.GetComponent<Rigidbody2D>().velocity.y;
        indicator.transform.position =
            new Vector3(yellowScale.transform.position.x + yellowScale.GetComponent<Renderer>().bounds.size.x/2,
                yellowScale.transform.position.y);
        redScale.transform.position = new Vector3(yellowScale.transform.position.x,
            yellowScale.transform.position.y - yellowScale.GetComponent<Renderer>().bounds.size.y/2);
        greenScale.transform.position = new Vector3(yellowScale.transform.position.x,
            yellowScale.transform.position.y + yellowScale.GetComponent<Renderer>().bounds.size.y/2);
    }

    private void Update() {
        if (!endOfGame) {
            if (((indicator.transform.position.y >=
                  (greenScale.GetComponent<Renderer>().bounds.size.y + greenScale.transform.position.y)) &&
                 (IndicatorDirection == 1)) ||
                ((indicator.transform.position.y <=
                  (redScale.transform.position.y - redScale.GetComponent<Renderer>().bounds.size.y)) &&
                 (IndicatorDirection == -1))) {
                IndicatorDirection *= -1;
                indicator.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 200*IndicatorDirection*SpeedRate));
            }
            if (Input.GetKeyDown(KeyCode.Space)) {
                endOfGame = true;
            }
        }
        else {
            if ((IndicatorDirection*indicator.GetComponent<Rigidbody2D>().velocity.y) > 0) {
                if (((indicator.transform.position.y >=
                      (greenScale.GetComponent<Renderer>().bounds.size.y + greenScale.transform.position.y)) &&
                     (IndicatorDirection == 1)) ||
                    ((indicator.transform.position.y <=
                      (redScale.transform.position.y - redScale.GetComponent<Renderer>().bounds.size.y)) &&
                     (IndicatorDirection == -1))) {
                    IndicatorDirection *= -1;
                    indicator.GetComponent<Rigidbody2D>().velocity = new Vector2(0,
                        -indicator.GetComponent<Rigidbody2D>().velocity.y);
                }
                indicator.GetComponent<Rigidbody2D>().velocity = new Vector2(0,
                    indicator.GetComponent<Rigidbody2D>().velocity.y*(1 - SpeedRateOnClick));
            }
            else {
                indicator.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0);
                if ((indicator.transform.position.y <=
                     greenScale.transform.position.y + greenScale.GetComponent<Renderer>().bounds.size.y) &&
                    (indicator.transform.position.y >= greenScale.transform.position.y)) {
                    //коэффициенты для зеленой полоски
                    Debug.Log("Green!");
                }
                if ((indicator.transform.position.y <=
                     yellowScale.transform.position.y + yellowScale.GetComponent<Renderer>().bounds.size.y/2) &&
                    (indicator.transform.position.y >=
                     yellowScale.transform.position.y - yellowScale.GetComponent<Renderer>().bounds.size.y/2)) {
                    //коэффициенты для желтой полоски
                    Debug.Log("Yellow!");
                }
                if ((indicator.transform.position.y <= redScale.transform.position.y) &&
                    (indicator.transform.position.y >=
                     redScale.transform.position.y - redScale.GetComponent<Renderer>().bounds.size.y)) {
                    //коэффициенты для красной полоски
                    Debug.Log("Red!");
                }
            }
        }
    }
}
=======
    public GameObject MiniGameControlGroup;

    public GameObject yellowScale;
    public GameObject redScale;
    public GameObject greenScale;

    public GameObject indicator;

    private bool endOfGame;
    private bool isMiniGameControlGroupShown = false;

    public static float SpeedRate = 4; //скорость ползунка в зависимости от количества выбранных тем
    private static float SpeedRateOnClick = 0.01f; // скорость ползунка после остановки пользователем, плавное замедление
    private float IndicatorDirection;
    private float startSpeed;
	void Start ()
	{
        MiniGameControlGroup.transform.localScale = new Vector3(0, 0, 0);
        }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.T) && !isMiniGameControlGroupShown /*если выбрана новость*/)
        {
            isMiniGameControlGroupShown = true;
            endOfGame = false;
            IndicatorDirection = 1;
            MiniGameControlGroup.transform.localScale = new Vector3(1,1,1);
            indicator.GetComponent<Rigidbody2D>().velocity =  new Vector2(0, SpeedRate);
            startSpeed = indicator.GetComponent<Rigidbody2D>().velocity.y;
            indicator.transform.position = new Vector3(yellowScale.transform.position.x + yellowScale.GetComponent<Renderer>().bounds.size.x / 2, yellowScale.transform.position.y);
            redScale.transform.position = new Vector3(yellowScale.transform.position.x, yellowScale.transform.position.y - yellowScale.GetComponent<Renderer>().bounds.size.y / 2);
            greenScale.transform.position = new Vector3(yellowScale.transform.position.x, yellowScale.transform.position.y + yellowScale.GetComponent<Renderer>().bounds.size.y / 2);
	
        }
        if (isMiniGameControlGroupShown)
        {
            if (!endOfGame)
            {
                if (((indicator.transform.position.y >=
                      (greenScale.GetComponent<Renderer>().bounds.size.y + greenScale.transform.position.y)) &&
                     (IndicatorDirection == 1)) ||
                    ((indicator.transform.position.y <=
                      (redScale.transform.position.y - redScale.GetComponent<Renderer>().bounds.size.y)) &&
                     (IndicatorDirection == -1)))
                {
                    Debug.Log(indicator.GetComponent<Rigidbody2D>().velocity.y);
                    IndicatorDirection *= -1;
                    indicator.GetComponent<Rigidbody2D>().velocity  = new Vector2(0, IndicatorDirection*indicator.GetComponent<Rigidbody2D>().velocity.y);
                }
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    endOfGame = true;
                }
            }
            else
            {

                if ((IndicatorDirection*indicator.GetComponent<Rigidbody2D>().velocity.y) > 0)
                {
                    if (((indicator.transform.position.y >=
                          (greenScale.GetComponent<Renderer>().bounds.size.y + greenScale.transform.position.y)) &&
                         (IndicatorDirection == 1)) ||
                        ((indicator.transform.position.y <=
                          (redScale.transform.position.y - redScale.GetComponent<Renderer>().bounds.size.y)) &&
                         (IndicatorDirection == -1)))
                    {
                        IndicatorDirection *= -1;
                        indicator.GetComponent<Rigidbody2D>().velocity = new Vector2(0,
                            -indicator.GetComponent<Rigidbody2D>().velocity.y);
                    }
                    indicator.GetComponent<Rigidbody2D>().velocity = new Vector2(0,
                        indicator.GetComponent<Rigidbody2D>().velocity.y*(1 - SpeedRateOnClick));
                }
                else
                {
                    indicator.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0);
                    if ((indicator.transform.position.y <=
                         greenScale.transform.position.y + greenScale.GetComponent<Renderer>().bounds.size.y) &&
                        (indicator.transform.position.y > greenScale.transform.position.y))
                    {
                        //коэффициенты для зеленой полоски
                        Debug.Log("Green!");
                    }
                    if ((indicator.transform.position.y <=
                         yellowScale.transform.position.y + yellowScale.GetComponent<Renderer>().bounds.size.y/2) &&
                        (indicator.transform.position.y >=
                         yellowScale.transform.position.y - yellowScale.GetComponent<Renderer>().bounds.size.y/2))
                    {
                        //коэффициенты для желтой полоски
                        Debug.Log("Yellow!");
                    }
                    if ((indicator.transform.position.y < redScale.transform.position.y) &&
                        (indicator.transform.position.y >=
                         redScale.transform.position.y - redScale.GetComponent<Renderer>().bounds.size.y))
                    {
                        //коэффициенты для красной полоски
                        Debug.Log("Red!");
                    }

                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            isMiniGameControlGroupShown = false;
            MiniGameControlGroup.transform.localScale = new Vector3(0, 0, 0);

        }

    }
  }
>>>>>>> 7f6da00519947760da9fa58d494c28fbbe34f8f8
