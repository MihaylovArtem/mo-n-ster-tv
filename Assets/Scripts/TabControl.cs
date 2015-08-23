using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TabControl : MonoBehaviour {

    public Button thisControl;
    public Button anotherControl;
    public GameObject thisControlGroup;
    public GameObject anotherControlGroup;

    void Start() {
        thisControl = gameObject.GetComponent<Button>();

        if (gameObject.name == "tab1") {
            anotherControl = GameObject.Find("tab2").gameObject.GetComponent<Button>();
            thisControlGroup = GameObject.Find("Statistics").gameObject;
        }
        else {
            anotherControl = GameObject.Find("tab1").gameObject.GetComponent<Button>();
            anotherControlGroup = GameObject.Find("Actions").gameObject;
        }
    }

	void OnClick () {

	}
}
