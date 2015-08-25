using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogScript : MonoBehaviour {

    public Text text;
    public GameObject resultMessage;


	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void OnGUI () {
	    if (GameManager.DayCount == 3) {
	        text.text =
	            "FBI comes in\nA dangerous murderer did the prison break. We have worked badly and could not catch him. Publish news that he was caught.";
	    }

        if (GameManager.DayCount == 5)
        {
            text.text =
                "Chief comes in\nOur competitors have opened a new restaurant. Publish news that they use spoiled food.";
        }


        if (GameManager.DayCount == 7)
        {
            text.text =
                "Chief comes in\nOur competitors have opened a new restaurant. Publish news that they use spoiled food.";
        }


        if (GameManager.DayCount == 9)
        {
            text.text =
                "President comes in\nPublish the report that I am the most suitable candidate for the presidency.";
        }   
	}

    public void Accept()
    {
        if (GameManager.DayCount == 4) {
            GameManager.MaxNewsInDay++;
            GameManager.Interest.Science -= 15;
            GameManager.Interest.Social -= 15;
            GameManager.Interest.Sport -= 15;
            GameManager.Interest.Entertainment -= 15;
            GameManager.Interest.Polytics -= 15;
            GameManager.Interest.Cryminal -= 15;
            ResultScript.textToAppear = "1 employee wants to work with you, but people don’t trust you. -15% to all categories.";
            GameManager.moral--;
        }
        
        else if (GameManager.DayCount == 6)
        {
            GameManager.Interest.Social += 30;
            GameManager.Money -= 400;
            ResultScript.textToAppear = "You recieved +20% to social interest, but lost 400$ for slander.";
            GameManager.moral--;
        }
        else if (GameManager.DayCount == 8)
        {
            GameManager.Interest.Social -= 30;
            GameManager.Money += 2000;
            ResultScript.textToAppear = "You earn 2000$, but lost 30% in social interest";
            GameManager.moral--;
        }

        else if (GameManager.DayCount == 10 )
        {
            ResultScript.textToAppear = "President likes your news";
            GameManager.moral--;
        }

        gameObject.transform.localScale = new Vector3(0,0,0);
        resultMessage.transform.localScale = new Vector3(1,1,1);
    }

    public void Decline() {
        if (GameManager.DayCount == 4)
        {
            ResultScript.textToAppear = "You saved 5 people from death.";
            GameManager.moral++;
        }

        else if (GameManager.DayCount == 6)
        {
            ResultScript.textToAppear = "You prevented damaging people’s health.";
            GameManager.moral++;
        }
        else if (GameManager.DayCount == 8)
        {
            ResultScript.textToAppear = "People love this restaurant. You too.";

            GameManager.moral++;
        }
        else if (GameManager.DayCount == 10) {
            GameManager.MaxNewsInDay = 2;
            GameManager.Money -= 1500;
            ResultScript.textToAppear = "Spot check found your employees working illegal. You have to pay fines. Now you are only one. -1500$ -all employees.";
            GameManager.moral++;
        }
        gameObject.transform.localScale = new Vector3(0, 0, 0);
        resultMessage.transform.localScale = new Vector3(1, 1, 1);
    }
}