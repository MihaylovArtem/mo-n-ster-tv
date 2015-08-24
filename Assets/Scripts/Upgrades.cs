using System.Net.Mime;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{

    public static int MaxNewsToBroadcast = 2;
    public static int MaxNewsUpgradeCost = 1000;
    public static int OpenCategoryUpgradeCost = 500;

    public static bool is_Open = false;
    public static bool is__Open = false;
    public static bool is___Open = false;

    public GameObject UpgradesControlGroup;

    public Text MaxNewsUpgradeText;
    public Text MaxNewsUpgradeButtonText;
	// Use this for initialization
	void Start ()
	{

	    MaxNewsUpgradeText = GameObject.Find("NowInStaff").GetComponent<Text>();
        UpgradesControlGroup.transform.localScale = new Vector3(0,0,0);


	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (Input.GetKeyDown(KeyCode.G) /*нажата кнопка апгрейдов*/)
	    {
	        UpgradesControlGroup.transform.localScale = new Vector3(1, 1, 1);

	        MaxNewsUpgradeText.text = "Now in staff: " + (MaxNewsToBroadcast - 1);
	        MaxNewsUpgradeButtonText.text = "Add personal\n" + MaxNewsUpgradeCost + " $";

	        //если выбираем апгрейд увелечения новостей, то 
	        // MaxNewsToBroadcast += 1;
	        //GameManager.Money -= MaxNewsToBroadcast;
	        //MaxNewsUpgradeCost *= 2;

	        //если выбираем апгрейд открытия категории 1
	    }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UpgradesControlGroup.transform.localScale = new Vector3(0, 0, 0);
        }

	}
}
