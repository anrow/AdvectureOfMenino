using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	[SerializeField]
	private Rigidbody2D rb;

	[SerializeField]
	private Animator animator;

	private bool isGrounded = true;
	private bool isRun = false;
	private bool isJump = false;

	private bool facingRight;

	[SerializeField]
	private LayerMask whatIsGround;

    [SerializeField]
    private Transform[ ] groundPoints;
	
	[SerializeField]
    private Vector3 pointRadius;

    [SerializeField]
	private float jumpForce;

    [SerializeField]
    private float runSpeed;

    [SerializeField]
	private float getAxisHorizontal;

	// Use this for initialization
	void Awake( ) {
		rb = gameObject.GetComponent<Rigidbody2D>( );
		animator = gameObject.GetComponentInChildren<Animator>( );
		facingRight = true;
        
	}
  
  
	void FixedUpdate( ) {
        
		getAxisHorizontal = Input.GetAxis( "Horizontal" );

        isGrounded = IsGrounded( );
        HandleMovement( );
		Flip( getAxisHorizontal );
		ResetValues( );
	
	}

	// Update is called once per frame
	void Update( ) {
        
		HandleInput( );
        animator.SetFloat( "jumpSpeed", rb.velocity.y ); 
        
	}

	private void Flip( float axisVaule ) {
		const int flipDirection = -1;
			if( axisVaule > 0 && facingRight == false || axisVaule < 0 && facingRight == true ) {
				facingRight = !facingRight;

				Vector3 theScale = transform.localScale;

				theScale.x *= flipDirection;

				transform.localScale = theScale;
			}
	}
	private void HandleInput( ) {
		if ( getAxisHorizontal != 0 ) {
			isRun = true;
		}
		if ( Input.GetKeyDown( KeyCode.Space ) ) {
			isJump = true;
		} 
	}
	private void HandleMovement( ) {
		if( isRun ) {
			rb.velocity = new Vector2( getAxisHorizontal * runSpeed, rb.velocity.y);
			animator.SetFloat ( "speed", Mathf.Abs( getAxisHorizontal ) );
		}
		if ( isJump && isGrounded  ) {
			isGrounded = false;
            rb.AddForce( Vector2.up * jumpForce ); 
            animator.SetBool( "isGrounded", isGrounded );
            
		}
	}

	private void ResetValues( ) {
		isRun = false;
		isJump = false;
	}

    private bool IsGrounded( ) {
        animator.SetBool( "isGrounded", isGrounded );
        if( rb.velocity.y <= 0 ) {
            foreach( Transform point in groundPoints ) {
                Collider2D[ ] colliders = Physics2D.OverlapAreaAll( point.position, point.position + pointRadius, whatIsGround );
                
                for( int i = 0; i < colliders.Length; i++ ) {
                    if( colliders[ i ].gameObject != gameObject ) {
                        return true;
                    }
                } 
            }
        }
        return false;
    }

  
}
