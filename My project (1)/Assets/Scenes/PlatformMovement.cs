using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement: MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    
    public Transform GroundCheck;

    
    public float GroundCheckRadius = 0.05f;

    
    public float speed = 2f;

    
    public float jumpForce = 10f;

   
    public LayerMask collisionMask;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        var inputX = Input.GetAxisRaw("Horizontal");
        var jumpInput = Input.GetButton("Jump");

        _rigidbody.velocity = new Vector2(inputX * speed, _rigidbody.velocity.y);

        if(jumpInput && IsGrounded())
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpForce);

        }

        if(inputX != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(inputX), 1, 1);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRadius, collisionMask );
    }

}
