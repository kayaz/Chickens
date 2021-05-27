using System.Collections;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [Range(1, 10)]
    public float jumpVelocity;
    public Animator animator;


    private void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpVelocity;
            animator.SetBool("IsJumping", true);
        }
    }

}
