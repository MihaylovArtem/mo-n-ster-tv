using UnityEngine;
using System.Collections;

public class WalkingPeople : MonoBehaviour {
	 
	private Vector3 newPosition;
	private Vector3 currentPosition;
	public float maxSpeed = 10f; 
	private Animator anim;

	// Use this for initialization

	private void Start(){
		anim = GetComponent<Animator>();
		newPosition = new Vector2 (Random.Range (0, 0.05f), Random.Range (0, 0.05f));

	}
	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "staticObject") {
			newPosition = new Vector2(Random.Range (-1f, 0), Random.Range (-1f, 0));
			newPosition = new Vector2 (Random.Range (0, 0.03f), Random.Range (0, 0.03f));
			Destroy(col.gameObject);
		}
		Debug.Log("HOHO");
	}

	void OnTriggerEnter2D(Collider2D col){
		Debug.Log ("HOHO");
	}
	void OnColliderEnter2D(Collider2D col){
		Debug.Log ("HOHO");
	}
	void OnTriggerEnter2D(Collision2D col){
		Debug.Log ("HOHO");
	}

	// Update is called once per frame
	 private void Update () {

		gameObject.transform.LookAt (gameObject.transform.position+newPosition);
		gameObject.transform.rotation.SetLookRotation(gameObject.transform.position+newPosition);
		gameObject.transform.rotation = new Quaternion (0, 0, gameObject.transform.rotation.z-Mathf.PI/6, gameObject.transform.rotation.w);
		gameObject.transform.position += newPosition ;
		//gameObject.transform.Rotate (newPosition);


			}


}			                                      