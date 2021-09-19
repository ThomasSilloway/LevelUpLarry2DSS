using System;
using UnityEngine;

public class LarryController : MonoBehaviour
{
    [SerializeField]
    private float RunSpeed = 40f;
    [SerializeField]
    private float JumpForce = 400f;
    [SerializeField]
    private float MovementSmoothTime = 0.05f;

    private Vector3 Velocity = Vector3.zero;
    private bool IsFacingRight = true;
    private float HorizontalInput = 0f;
    private bool StartJump = true;

    private Rigidbody2D Physics;

    private Animator Animator;

    // Start is called before the first frame update
    private void Awake()
    {
        Physics = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        HorizontalInput = Input.GetAxisRaw("Horizontal");
        UpdateAnimator();
        UpdateSpriteFlip();

        if(Input.GetButtonDown("Jump"))
        {
            StartJump = true;
        }
    }

    private void FixedUpdate() 
    {
        Move(Time.fixedDeltaTime);
        StartJump = false;
    }

    private void Move(float deltaTime)
    {
        var targetVelocity = new Vector2(HorizontalInput * RunSpeed * deltaTime, Physics.velocity.y);
        Physics.velocity = Vector3.SmoothDamp(Physics.velocity, targetVelocity, ref Velocity, MovementSmoothTime);
    }

    private void UpdateAnimator()
    {
        Animator.SetFloat("MoveSpeed", Mathf.Abs(HorizontalInput));
    }

    private void UpdateSpriteFlip()
    {
        if((HorizontalInput > 0 && !IsFacingRight) || (HorizontalInput < 0 && IsFacingRight))
        {
            IsFacingRight = !IsFacingRight;
            var newScale = transform.localScale;
            newScale.x *= -1;
            transform.localScale = newScale;
        }
    }
}
