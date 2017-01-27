using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	[SerializeField]
	private Rigidbody2D rb;

	[SerializeField]
	private Animator animator;

	private bool isGrounded = false;
	private bool isRun = false;
	private bool isJump = false;

	private bool facingRight;

	[SerializeField]
	private LayerMask whatIsGround;

    [SerializeField]
    private Transform[ ] groundPoints;
	
	public float pointRadius;

	public float jumpForce;
    public float jumpTime;
    public float runSpeed;
	private float getAxis;

	// Use this for initialization
	void Awake( ) {
		rb = gameObject.GetComponent<Rigidbody2D>( );
		animator = gameObject.GetComponentInChildren<Animator>( );
		facingRight = true;
        
	}
  
  
	void FixedUpdate( ) {
        
		getAxis = Input.GetAxis( "Horizontal" );

        isGrounded = IsGrounded( );

        HandleMovement( );
		Flip( getAxis );
		ResetValues( );
	
	}

	// Update is called once per frame
	void Update( ) {
		HandleInput( );
        
	}

	private void Flip( float getAxis) {
		const int DIRECTION = -1;
			if( getAxis > 0 && facingRight == false || getAxis < 0 && facingRight == true ) {
				facingRight = !facingRight;

				Vector3 theScale = transform.localScale;

				theScale.x *= DIRECTION;

				transform.localScale = theScale;
			}
	}
	private void HandleInput( ) {
		if ( getAxis != 0 ) {
			isRun = true;
		}
		if ( Input.GetKeyDown( KeyCode.Space ) ) {
			isJump = true;
          
		}
        
	
	}
	private void HandleMovement( ) {
		if( isRun ) {
			rb.velocity = new Vector2( getAxis * runSpeed, rb.velocity.y);
			animator.SetFloat ( "speed", Mathf.Abs( getAxis ) );
		}
		if ( isJump && isGrounded  ) {
			isGrounded = false;
            
			rb.AddForce ( new Vector2 ( 0, jumpForce ) ); 
           
           
		} else {
           
        }
       
      
	}

	private void ResetValues( ) {
		isRun = false;
		isJump = false;
	}

    private bool IsGrounded( ) {
        if( rb.velocity.y <= 0 ) {
            foreach( Transform point in groundPoints ) {
                Collider2D[ ] colliders = Physics2D.OverlapAreaAll( point.position, point.position, whatIsGround );
                
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
