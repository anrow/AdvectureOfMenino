using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerEventManager : MonoBehaviour {

	[SerializeField]
	private ParticleEventManager particle;

	[SerializeField]
	private PlayerController player;

	[SerializeField]
	private InimigoController inimigo;

    [SerializeField]
    private CameraController cameraController;

	void Start( ) {

		particle = GameObject.FindObjectOfType<ParticleEventManager>( );

		player = GameObject.FindObjectOfType<PlayerController>( );

		inimigo = GameObject.FindObjectOfType<InimigoController>( );

        cameraController = GameObject.FindObjectOfType<CameraController>( );

	}

	void OnTriggerEnter2D( Collider2D other ) {
        switch( other.tag ) {
            case "Spike":
                particle.SetDamageParticle( );
                Destroy( gameObject );
                SceneManager.LoadScene( "Main" );
                break;

            case "Border":
                particle.SetDamageParticle( );
                Destroy( gameObject );
                SceneManager.LoadScene( "Main" );
                break;

			case "Enemy":
                if( !player.isInvincible ) {
                    player.SetInvincibleStatus( );
                    particle.SetDamageParticle( );
                }
                break;
        }

	}
    
  
}
