using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Controller2D))]
public class Player : MonoBehaviour
{
	[Header("MoveSpeed")]
	[SerializeField] private float defaultSpeed;
	[SerializeField] private float sprintingSpeed;
	
	public float maxJumpHeight = 4;
	public float minJumpHeight = 1;
	public float timeToJumpApex = .4f;
	public float accelerationTimeAirborne = .2f;
	public float accelerationTimeGrounded = .1f;
	float moveSpeed = 6;

	public Vector2 wallJumpClimb;
	public Vector2 wallJumpOff;
	public Vector2 wallLeap;

	public float wallSlideSpeedMax = 3;
	public float wallStickTime = .25f;
	float timeToWallUnstick;

	float gravity;
	float maxJumpVelocity;
	float minJumpVelocity;
	Vector3 velocity;
	float velocityXSmoothing;

	Controller2D controller;

	Vector2 directionalInput;
	bool wallSliding;
	int wallDirX;

	[Header("Dash")] 


	public float dashDuration;
	public float dashDelayDuration;
	public float strength;

	[HideInInspector] public bool lockDirectionalInput;
	private float dashTime;
	[SerializeField]private float dashDelay;
	private bool isDashing;
	private float dashDir;


	void Start()
	{
		controller = GetComponent<Controller2D> ();

		gravity = -(2 * maxJumpHeight) / Mathf.Pow (timeToJumpApex, 2);
		maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
		minJumpVelocity = Mathf.Sqrt (2 * Mathf.Abs (gravity) * minJumpHeight);
		defaultSpeed = moveSpeed;
		sprintingSpeed = moveSpeed * 3 / 2;
		dashTime = dashDuration;
		dashDelay = dashDelayDuration;

	}

	void Update() {
		IsSprinting();
		CalculateVelocity ();
		HandleWallSliding ();
		HandleDash();

		controller.Move (velocity * Time.deltaTime, directionalInput);

		if (controller.collisions.above || controller.collisions.below) {
			if (controller.collisions.slidingDownMaxSlope) {
				velocity.y += controller.collisions.slopeNormal.y * -gravity * Time.deltaTime;
			} else {
				velocity.y = 0;
			}
		}
	}

	public void SetDirectionalInput (Vector2 input) {
		directionalInput = input;
	}

	public void OnJumpInputDown() {
		if (wallSliding) {
			if (wallDirX == directionalInput.x) {
				velocity.x = -wallDirX * wallJumpClimb.x;
				velocity.y = wallJumpClimb.y;
			}
			else if (directionalInput.x == 0) {
				velocity.x = -wallDirX * wallJumpOff.x;
				velocity.y = wallJumpOff.y;
			}
			else {
				velocity.x = -wallDirX * wallLeap.x;
				velocity.y = wallLeap.y;
			}
		}
		if (controller.collisions.below) {
			if (controller.collisions.slidingDownMaxSlope) {
				if (directionalInput.x != -Mathf.Sign (controller.collisions.slopeNormal.x)) { // not jumping against max slope
					velocity.y = maxJumpVelocity * controller.collisions.slopeNormal.y;
					velocity.x = maxJumpVelocity * controller.collisions.slopeNormal.x;
				}
			} else {
				velocity.y = maxJumpVelocity;
			}
		}
	}

	public void OnJumpInputUp() {
		if (velocity.y > minJumpVelocity) {
			velocity.y = minJumpVelocity;
		}
	}
		
//Todo make a knockback method that takes the direction of which way it has to propel itself towards.

	public void ChangeVelocityToDir(Vector2 dir)
	{
		velocity = Vector3.zero;
		velocity = dir;
	}

	public void AddVelocityToDir(Vector2 dir) => velocity = dir;

	public void HandleDash()
	{
		dashDelay -= Time.deltaTime;
		if (dashDelay <= 0)
		{
			if (Input.GetKeyDown(KeyCode.LeftShift) && directionalInput != Vector2.zero && !(controller.collisions.left || controller.collisions.right))
			{
				isDashing = true;
				dashDir = directionalInput.x;
				lockDirectionalInput = true;
			}
			if (isDashing)
			{
				if (dashTime <= 0)
				{
					isDashing  = false;
					lockDirectionalInput = false;
					dashDelay = dashDelayDuration;
					dashTime = dashDuration;
				}
				else
				{
					dashTime -= Time.deltaTime;
					velocity.y = 0;
					velocity.x = dashDir * strength;	
				}
			}	
		}
	}

	void HandleWallSliding() {
		wallDirX = (controller.collisions.left) ? -1 : 1;
		wallSliding = false;
		if ((controller.collisions.left || controller.collisions.right) && !controller.collisions.below && velocity.y < 0) {
			wallSliding = true;

			if (velocity.y < -wallSlideSpeedMax) {
				velocity.y = -wallSlideSpeedMax;
			}

			if (timeToWallUnstick > 0) {
				velocityXSmoothing = 0;
				velocity.x = 0;

				if (directionalInput.x != wallDirX && directionalInput.x != 0) {
					timeToWallUnstick -= Time.deltaTime;
				}
				else {
					timeToWallUnstick = wallStickTime;
				}
			}
			else {
				timeToWallUnstick = wallStickTime;
			}

		}

	}
	
	void IsSprinting() => moveSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintingSpeed : defaultSpeed;
	

	void CalculateVelocity() {
		float targetVelocityX = directionalInput.x * moveSpeed;
		velocity.x = Mathf.SmoothDamp (velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below)?accelerationTimeGrounded:accelerationTimeAirborne);
		velocity.y += gravity * Time.deltaTime;
	}
}
