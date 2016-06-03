﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public GUIText countText;
	public GUIText winText;
	private int count;
	
	private Rigidbody rb;
		
	void Start ()
	{
		count = 0;
		SetCountText ();
		winText.text = "";

		rb = GetComponent<Rigidbody>();
	}
    void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

	
		rb.AddForce (movement * speed);
	
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Pick Up") 
		{
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
		}
	}
	void SetCountText()
		{
			countText.text= "Count: " + count.ToString();
		if (count >= 5)
		{
			winText.text = "You Win!";
		}

}
}

