using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour {
    public static int MaxNewsUpgradeCost = 1000;
    public static int EntertainmentUpgradeCost = 1000;
    public static int ScienceUpgradeCost = 1000;
    public static int CriminalUpgradeCost = 1000;

    public static bool is_Open = false;
    public static bool is__Open = false;
    public static bool is___Open = false;

    public GameObject EntertainmentGroup;
    public GameObject ScienceGroup;
    public GameObject CriminalGroup;

    public Button EntertainmentButton;
    public Button ScienceButton;
    public Button CriminalButton;

    public Text MaxNewsUpgradeButtonText;
    public Button MaxNewsUpgradeButton;
    public Text MaxNewsUpgradeText;
    public GameObject UpgradesControlGroup;
    // Use this for initialization
    private void Start() {
        UpgradesControlGroup.transform.localScale = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    private void OnGUI() {
        if (GameManager.MaxNewsInDay <= 5) {
            MaxNewsUpgradeText.text = "Now in staff: " + (GameManager.MaxNewsInDay - 1);
            MaxNewsUpgradeButtonText.text = "Add personal\n" + MaxNewsUpgradeCost + " $";
        }
        else {
            MaxNewsUpgradeButtonText.text = "Max";
            MaxNewsUpgradeButton.interactable = false;
        }
    }

    public void ClickUpgrades() {
        if (UpgradesControlGroup.transform.localScale == new Vector3(0, 0, 0)) {
            UpgradesControlGroup.transform.localScale = new Vector3(1, 1, 1);
        }
        else {
            UpgradesControlGroup.transform.localScale = new Vector3(0, 0, 0);
        }
    }

    public void AddStaff() {
        if (GameManager.Money >= MaxNewsUpgradeCost) {
            GameManager.Money -= MaxNewsUpgradeCost;
            MaxNewsUpgradeCost *= 2;
            GameManager.MaxNewsInDay += 1;
        }
    }

    public void OpenEntertainment() {
        if (GameManager.Money >= EntertainmentUpgradeCost) {
            GameManager.Money -= EntertainmentUpgradeCost;
            EntertainmentGroup.transform.localScale = new Vector3(1,1,1);
            EntertainmentButton.interactable = false;
        }
    }

    public void OpenScience()
    {
        if (GameManager.Money >= ScienceUpgradeCost)
        {
            GameManager.Money -= ScienceUpgradeCost;
            ScienceGroup.transform.localScale = new Vector3(1, 1, 1);
            ScienceButton.interactable = false;
        }
    }

    public void OpenCriminal()
    {
        if (GameManager.Money >= CriminalUpgradeCost)
        {
            GameManager.Money -= CriminalUpgradeCost;
            CriminalGroup.transform.localScale = new Vector3(1, 1, 1);
            CriminalButton.interactable = false;
        }
    }
}