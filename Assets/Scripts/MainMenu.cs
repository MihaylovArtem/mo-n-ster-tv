using System.Net.Mime;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{


    public GameObject ContactsView;
    public GameObject HowToPlayView;
    public Text HowToPlayText;

    private bool isContactsButtonPressed = false;
    private bool isHowToPlayButtonPressed = false;

    private int HowToPlayClicks = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	    if (isContactsButtonPressed)
	    {
	        if (ContactsView.transform.localScale.x < 1)
	        {
	            ContactsView.transform.localScale += new Vector3(0.05f,0.05f,0);
	        }
	        if (Input.GetKeyDown(KeyCode.Mouse0))
	        {
	            isContactsButtonPressed = false;
                ContactsView.transform.localScale = new Vector3(0,0,1);
	        }
	    }
	    if (isHowToPlayButtonPressed)
	    {
            if (HowToPlayView.transform.localScale.x < 1)
            {
                HowToPlayView.transform.localScale += new Vector3(0.05f, 0.05f, 0);
            }
	        if (Input.GetKeyDown(KeyCode.Mouse0)) 
                switch (HowToPlayClicks)
            {
                case 0:
                    HowToPlayText.text = "Each day you have to choose news to publish. You will earn more money, if people interested in this category.";
                    HowToPlayClicks++;
                    break;
                case 1:
                    HowToPlayText.text = "Buy different boosts to develop your agency. More employees will speed up your work.";
                    HowToPlayClicks++;
                    break;
                case 2:
                    HowToPlayView.transform.localScale = new Vector3(0, 0, 1);
                    HowToPlayClicks = 0;
                    isHowToPlayButtonPressed = false;
                    break;

            }
	    }
	}

    public void StartGame()
    {
        Application.LoadLevel("game");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Contacts()
    {
        isContactsButtonPressed = true;
        
    }

    public void HowToPlay()
    {
        isHowToPlayButtonPressed = true;
        HowToPlayText.text = "Good afternoon! You are the head of the news agency. Publish news, increase amount of your followers - earn more and more money. You need to hold out for 10 days.";
    }
}
