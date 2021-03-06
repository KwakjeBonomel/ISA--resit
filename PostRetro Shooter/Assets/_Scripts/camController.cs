﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camController : MonoBehaviour {
	
	Vector2 mouseLook;
	Vector2 smoothV;
	public float sensitivity = 5.0f;
	public float smoothing = 2.0f;

	GameObject player;

	// Use this for initialization
	void Start (){ 
		player = this.transform.parent.gameObject; 
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update (){
		var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

		md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
		smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
		smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
		mouseLook += smoothV;

		mouseLook.y = Mathf.Clamp(mouseLook.y, -89f, 89f);

		transform.localRotation = Quaternion.AngleAxis(angle: -mouseLook.y, axis: Vector3.right);
		player.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, player.transform.up);
	}
}