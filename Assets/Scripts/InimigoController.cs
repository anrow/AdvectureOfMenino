using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoController : MonoBehaviour {

	[SerializeField]
	private Rigidbody2D rb;

	private bool isWallHitted = true;

	private bool isEdgeHitted = true;

	public bool facingRight = true;

	[SerializeField]
	private LayerMask whatIsWall;

	[SerializeField]
	private Transform[ ] wallPoints;

	[SerializeField]
	private Vector3 pointRadius;

	[SerializeField]
	private Transform[ ] edgePoints;

	[SerializeField]
	private LayerMask whatIsEdge;

	[SerializeField]
	private float runSpeed;

	[SerializeField]
	private PlayerController player;

    [SerializeField]
    private HittingSystem hittingSystem;

	[SerializeField]
	private ParticleEventManager particle;

	// Use this for initialization
	void Start( ) {
		
		rb = gameObject.GetComponent<Rigidbody2D>( );

		facingRight = true;

		player = GameObject.FindObjectOfType<PlayerController>( );

        hittingSystem = GameObject.FindObjectOfType<HittingSystem>( );

		particle = GameObject.FindObjectOfType<ParticleEventManager>( );

	}
	void FixedUpdate( ) {
		
		isWallHitted = hittingSystem.IsHitted( wallPoints, whatIsWall );

		isEdgeHitted = hittingSystem.IsHitted( edgePoints, whatIsEdge ); 

		if( isWallHitted || !isEdgeHitted ) {
			facingRight =  !facingRight;
		}

		if( facingRight ) {
			rb.velocity = new Vector2( runSpeed, rb.velocity.y );
			transform.localScale = new Vector3( -1, 1, 1 );
		} else {
			rb.velocity = new Vector2( -runSpeed, rb.velocity.y );
			transform.localScale = new Vector3( 1, 1, 1 );
		}
			
	}	
		
    public void Dead( ) {
		particle.SetEnemyParticle( );
        gameObject.SetActive( false );
    }

  
}
