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

    public bool isInvincible = false;

    [SerializeField]
    private HittingSystem hittingSystem;

    [SerializeField]
    private InimigoController[ ] inimigos;

	[SerializeField]
	private LayerMask whatIsGround;

    [SerializeField]
    public Transform[ ] groundPoints;
	
	[SerializeField]
    private Vector3 pointRadius;

    [SerializeField]
	private float jumpForce;

    [SerializeField]
    private float jumpForceRate;

    [SerializeField]
    private float runSpeed;

    [SerializeField]
    private LayerMask whatIsEnemy;

    [SerializeField]
	private float getAxisHorizontal;

	[SerializeField]
	private BoxCollider2D attackCol;

	// Use this for initialization
	void Awake( ) {
		rb = gameObject.GetComponent<Rigidbody2D>( );

		animator = gameObject.GetComponentInChildren<Animator>( );

        inimigos = GameObject.FindObjectsOfType<InimigoController>( );

        hittingSystem = GameObject.FindObjectOfType<HittingSystem>( );
        
		attackCol = gameObject.GetComponentInChildren<BoxCollider2D>( );

		facingRight = true;
	}
  
  
	void FixedUpdate( ) {
        
		getAxisHorizontal = Input.GetAxis( "Horizontal" );

        isGrounded = IsGrounded( );

        if( rb.velocity.y <= 0 ) {
            IsAttackHitted( );
        }
        HandleMovement( );

		Flip( getAxisHorizontal );

		ResetValues( );
	
	}

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
        if( rb.velocity.y <= 0 ) {
            animator.SetBool( "isGrounded", isGrounded );
            if( hittingSystem.IsHitted( groundPoints, whatIsGround ) ) {
                isGrounded = true;
                return true;
            }
        }
        return false;
    }
    private bool IsAttackHitted( ) {

			
        if( hittingSystem.IsHitted( groundPoints, whatIsEnemy ) ) {
			
            rb.AddForce( Vector2.up * jumpForce * jumpForceRate );
		}
        return false;
    }
 
    public void SetInvincibleStatus( ) {
        if( !isInvincible ) {
            isInvincible = true;
            StartCoroutine( InvincibleStatus( ) );
        }
    }

    //無敵状態
    private IEnumerator InvincibleStatus( ) {
       
        int damageTimeCount = 10;

		while ( damageTimeCount > 0 ) {
			//透明にする
			gameObject.GetComponentInChildren<SpriteRenderer>( ).color = new Color( 1, 1, 1, 0 );
			//0.05秒待つ
			yield return new WaitForSeconds( 0.05f );
			//元に戻す
			gameObject.GetComponentInChildren<SpriteRenderer>( ).color = new Color( 1, 1, 1, 1 );
			//0.05秒待つ
			yield return new WaitForSeconds( 0.05f );
			damageTimeCount--;
		}

        isInvincible = false;
    }
   
}
