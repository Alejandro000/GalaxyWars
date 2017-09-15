using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigtherController : MonoBehaviour {

	public float speed = 8f;
	public float padding = (1f/3)*4;
	public GameObject bullet;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float hInput = Input.GetAxis ("Horizontal");
		transform.position += new Vector3 (hInput * speed * Time.deltaTime, 0, 0);

		float vInput = Input.GetAxis ("Vertical");
		transform.position += new Vector3 (0, vInput * speed * Time.deltaTime, 0);

		float newX = Mathf.Clamp (transform.position.x, -10 + padding, 10-padding);
		float newY = Mathf.Clamp(transform.position.y, -10 + padding, 10-padding);
			transform.position = new Vector3 (newX, newY, transform.position.z);

		if (Input.GetKeyDown (KeyCode.Space)) {
			//Repetidor en marcha
			InvokeRepeating("Fire", 0.001f, 0.25f);
		} else if (Input.GetKeyUp (KeyCode.Space))
			//detener repetidor
			CancelInvoke("Fire");
		}

	void Fire(){
		var fighter = GameObject.Find ("Fighter");
		if (fighter != null) {

			Vector3 newleftPosition = fighter.transform.position + Vector3.left * 0.7f + Vector3.up * 0.7f;
			Vector3 newrightPosition = fighter.transform.position + Vector3.right * 0.7f + Vector3.up * 0.7f;
			Instantiate (bullet, newleftPosition, Quaternion.identity);
			Instantiate (bullet, newrightPosition, Quaternion.identity);
		}
	}
}