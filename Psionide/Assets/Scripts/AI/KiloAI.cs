﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiloAI : GenericAI {
	private Animator _animator;
	// private KiloStateMachine _kiloStateMachine;
	
	private Counter _deathCounter = new Counter(500);

	private void Awake() {
		_animator = GetComponent<Animator>();
		
		// _kiloStateMachine = _animator.GetBehaviour<KiloStateMachine>();
		// _kiloStateMachine.KiloAi = this;
	}

	private void Update() {
		if (!Util.IsPaused) {
			_deathCounter.Update();
		}

		if (_deathCounter.Value <= 0) {
			// _animator.SetTrigger("KiloDeath");
			Destroy(gameObject);
		}
	}
}
