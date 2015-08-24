using UnityEngine;

public class MiniGame : MonoBehaviour {
    public static float SpeedRate = 4; //скорость ползунка в зависимости от количества выбранных тем

    private static float SpeedRateOnClick = 0.05f;
    // скорость ползунка после остановки пользователем, плавное замедление

    private float IndicatorDirection = 1;
    private bool endOfGame;
    public GameObject greenScale;

    public GameObject indicator;
    public GameObject redScale;
    private float startSpeed;
    public bool userPressedButton;
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
        if (!userPressedButton) {
            if (((indicator.transform.position.y >=
                  (greenScale.GetComponent<Renderer>().bounds.size.y + greenScale.transform.position.y)) &&
                 (IndicatorDirection == 1)) ||
                ((indicator.transform.position.y <=
                  (redScale.transform.position.y - redScale.GetComponent<Renderer>().bounds.size.y)) &&
                 (IndicatorDirection == -1))) {
                IndicatorDirection *= -1;
                indicator.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 200*IndicatorDirection*SpeedRate));
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
                    indicator.GetComponent<Rigidbody2D>().velocity.y - SpeedRateOnClick*IndicatorDirection);
            }
            else {
                if (!endOfGame) {
                    endOfGame = true;
                    indicator.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0);
                    if ((indicator.transform.position.y <=
                         greenScale.transform.position.y + greenScale.GetComponent<Renderer>().bounds.size.y) &&
                        (indicator.transform.position.y >= greenScale.transform.position.y)) {
                        //коэффициенты для зеленой полоски
                        Debug.Log("Green!");
                        NewsLabel.currentResult = NewsLabel.MiniGameResult.perfect;
                    }
                    if ((indicator.transform.position.y <=
                         yellowScale.transform.position.y + yellowScale.GetComponent<Renderer>().bounds.size.y/2) &&
                        (indicator.transform.position.y >=
                         yellowScale.transform.position.y - yellowScale.GetComponent<Renderer>().bounds.size.y/2)) {
                        //коэффициенты для желтой полоски
                        Debug.Log("Yellow!");
                        NewsLabel.currentResult = NewsLabel.MiniGameResult.medium;
                    }
                    if ((indicator.transform.position.y <= redScale.transform.position.y) &&
                        (indicator.transform.position.y >=
                         redScale.transform.position.y - redScale.GetComponent<Renderer>().bounds.size.y)) {
                        //коэффициенты для красной полоски
                        Debug.Log("Red!");
                        NewsLabel.currentResult = NewsLabel.MiniGameResult.bad;
                    }
                    GameObject.Find("NewsPrefab").GetComponent<NewsLabel>().okButtonComponent.interactable = true;
                    NewsLabel.EndMiniGame();
                }
            }
        }
    }
}