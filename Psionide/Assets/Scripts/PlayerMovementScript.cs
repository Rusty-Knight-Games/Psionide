﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour {
	[Range(0, 10)]
	public float Speed = 7;

	private bool _isMoving = false;
	private Vector3 _originalPositon;
	private Vector3 _newPosition;
	
	void Update () {
		var step = Speed * Time.deltaTime;
		
		_originalPositon = transform.position;
		
		var touches = Input.touches;

		if (touches.Length == 1) {
			var mainFinger = touches[0];

			if (mainFinger.phase == TouchPhase.Began) {
				_newPosition = mainFinger.position;
			}
		}
		else if (Input.GetMouseButtonDown(0)) {
			_isMoving = true;

			_newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			_newPosition.z = 0f;
		}
		
		if (_isMoving) {
			transform.position = Vector3.MoveTowards(transform.position, _newPosition, step);

			if (transform.position == _newPosition) {
				_isMoving = false;
			}
		}
	}
}