using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
	[Range(0, .3f)] [SerializeField] private float MovementSmoothing = .05f;
	[Range(1, 10)] [SerializeField] private float jumpVelocity;
	[SerializeField] private bool AirControl = false;
	[SerializeField] private LayerMask WhatIsGround;
	[SerializeField] private Transform GroundCheck;
	[SerializeField] private Transform CeilingCheck;


	const float GroundedRadius = .2f;
	private bool Grounded;
	private Rigidbody2D Rigidbody2D;
	private Vector3 Velocity = Vector3.zero;

	[Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;

	private void Awake()
	{
		Rigidbody2D = GetComponent<Rigidbody2D>();

		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();

	}

	private void FixedUpdate()
	{
		bool wasGrounded = Grounded;
		Grounded = false;
		Collider2D[] colliders = Physics2D.OverlapCircleAll(GroundCheck.position, GroundedRadius, WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				Grounded = true;
				if (!wasGrounded)
					OnLandEvent.Invoke();
			}
		}
	}

	public void Move(float move, bool jump)
	{
		if (AirControl)
		{
			Vector3 targetVelocity = new Vector2(move * 10f, Rigidbody2D.velocity.y);
			Rigidbody2D.velocity = Vector3.SmoothDamp(Rigidbody2D.velocity, targetVelocity, ref Velocity, MovementSmoothing);
		}

		if (Grounded && jump)
		{
			GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpVelocity;
		}
	}

}
