using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndDayScript : MonoBehaviour {

    public Text title;
    public Text earnings;
    public Text expenses;
    public Text total;

    public GameObject GameOverScreen;

    public Text GameOverMessage;
    public Text OverallStats;
    public Text InterestStats;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnGUI () {
	    if (GameManager.Money < 0) {
	        GameOverScreen.transform.localScale = new Vector3(1,1,1);
	        GameOverMessage.text = "GAME OVER\nYOU LOST ALL YOUR MONEY";
	    }
        else if (GameManager.Audience < 0) {
            GameOverScreen.transform.localScale = new Vector3(1, 1, 1);
            GameOverMessage.text = "GAME OVER\nYOU LOST ALL YOUR AUDIENCE";
        }
        else if (GameManager.DayCount == 11)
	    {
            GameOverScreen.transform.localScale = new Vector3(1, 1, 1);
            GameOverMessage.text = "YOU WIN\nYOU LASTED 10 DAYS";
	    }
        else {
            GameOverScreen.transform.localScale = new Vector3(0, 0, 0);
        }
	    OverallStats.text = "TOTAL MONEY: " + GameManager.Money + "$\nTOTAL VIEWERS: " + GameManager.Audience + "\nYOU ARE NEUTRAL";
	    InterestStats.text = "SCIENCE INTEREST " + GameManager.Interest.Science + "%\nSPORT INTEREST " +
	                         GameManager.Interest.Sport + "%\nSOCIAL INTEREST " + GameManager.Interest.Social +
	                         "%\nPOLITICS INTEREST " + GameManager.Interest.Polytics
	                         + "%\nENTERTAINMENT INTEREST " + GameManager.Interest.Entertainment + "%\nCRIMINAL INTEREST " +
	                         GameManager.Interest.Cryminal; 

        title.text = "END OF DAY " + (GameManager.DayCount-1);
        earnings.text = "YOU EARNED " + GameManager.incomeFromNews + "$";
        expenses.text = "EXPENSES:\nSALARY: " + GameManager.SALARY + "$ * " + (GameManager.MaxNewsInDay - 2) + " = " + GameManager.SALARY * (GameManager.MaxNewsInDay - 1)
            + "$\nRENT: " + GameManager.RENT + "$\nTAXES: " + GameManager.GOVERNMENT_PERCENT + "% * " + GameManager.incomeFromNews + "$ = " + GameManager.incomeFromNews * GameManager.GOVERNMENT_PERCENT / 100 + "$";
        total.text = "PROFIT: " + GameManager.incomeFromNews + "$ - " + 
	    (GameManager.SALARY*(GameManager.MaxNewsInDay - 1) + GameManager.RENT +
	    GameManager.incomeFromNews*GameManager.GOVERNMENT_PERCENT/100) + "$ = " + (GameManager.incomeFromNews- (GameManager.SALARY*(GameManager.MaxNewsInDay - 1) + GameManager.RENT +
	    GameManager.incomeFromNews*GameManager.GOVERNMENT_PERCENT/100)) + "$";
	}
}
