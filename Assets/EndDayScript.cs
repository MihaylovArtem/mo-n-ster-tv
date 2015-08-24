using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndDayScript : MonoBehaviour {

    public Text title;
    public Text earnings;
    public Text expenses;
    public Text total;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnGUI () {
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
