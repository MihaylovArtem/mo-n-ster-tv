using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TabControl : MonoBehaviour {

    private Button thisControl;
    private Image thisControlImage;
    private Button anotherControl;
    private Image anotherControlImage;
    private GameObject thisControlGroup;
    private GameObject anotherControlGroup;

    public Color enabledColor;
    public Color disabledColor;

    public bool isDefault;

    void Start() {
        thisControl = gameObject.GetComponent<Button>();

        if (gameObject.name == "tab1") {
            anotherControl = GameObject.Find("tab2").gameObject.GetComponent<Button>();
            thisControlGroup = GameObject.Find("Statistics").gameObject;
            anotherControlGroup = GameObject.Find("Actions").gameObject;
        }
        else {
            anotherControl = GameObject.Find("tab1").gameObject.GetComponent<Button>();
            thisControlGroup = GameObject.Find("Actions").gameObject;
            anotherControlGroup = GameObject.Find("Statistics").gameObject;
        }
        thisControlImage = gameObject.GetComponent<Image>();
        anotherControlImage = anotherControl.GetComponent<Image>();

        if (isDefault) OnClick();

    }

	public void OnClick () {
        anotherControlGroup.transform.localScale = new Vector3(0,0,0);
        thisControlGroup.transform.localScale = new Vector3(1,1,1);
	    thisControlImage.color = enabledColor;
	    anotherControlImage.color = disabledColor;
	}
}
