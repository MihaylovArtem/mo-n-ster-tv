using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour {
    public static int MaxNewsUpgradeCost = 1000;
    public static int OpenCategoryUpgradeCost = 500;

    public static bool is_Open = false;
    public static bool is__Open = false;
    public static bool is___Open = false;

    public Text MaxNewsUpgradeButtonText;
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
        if (GameManager.Money >= MaxNewsUpgradeCost) GameManager.Money -= MaxNewsUpgradeCost;
        MaxNewsUpgradeCost *= 2;
        GameManager.MaxNewsInDay += 1;
    }
}