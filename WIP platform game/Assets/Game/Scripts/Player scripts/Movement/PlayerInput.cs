using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Movement))]
public class PlayerInput : MonoBehaviour {

	Movement movement;

	void Start () {
		movement = GetComponent<Movement> ();
	}

	void Update () {
		if (!movement.lockDirectionalInput)
		{
			Vector2 directionalInput = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
			movement.SetDirectionalInput (directionalInput);
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			movement.OnJumpInputDown ();
		}
		if (Input.GetKeyUp (KeyCode.Space)) {
			movement.OnJumpInputUp ();
		}
	}
}
