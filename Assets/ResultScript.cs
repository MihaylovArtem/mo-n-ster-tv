using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResultScript : MonoBehaviour {

    public Text text;
    public static string textToAppear;

	// Use this for initialization
	void Start () {
	
	}
	


	// Update is called once per frame
	void OnGUI () {
	    text.text = textToAppear;
	}

    public void Close() {
        gameObject.transform.localScale = new Vector3(0,0,0);
    }
}
