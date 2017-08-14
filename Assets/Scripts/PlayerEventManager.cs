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

    [SerializeField]
    private HittingSystem hittingSystem;

    [SerializeField]
    private bool isInvincible = false;

	void Start( ) {

		particle = GameObject.FindObjectOfType<ParticleEventManager>( );

		player = GameObject.FindObjectOfType<PlayerController>( );

		inimigo = GameObject.FindObjectOfType<InimigoController>( );

        cameraController = GameObject.FindObjectOfType<CameraController>( );

        hittingSystem = GameObject.FindObjectOfType<HittingSystem>( );

	}

    public void SetInvincibleStatus( ) {
        if( isInvincible == true ) {
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
        
    }

	void OnCollisionEnter2D( Collision2D other ) {
        switch( other.collider.tag ) {
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
                break;
        }
	}

    void OnCollisionStay2D( Collision2D other) {
        switch ( other.collider.tag ) {
            case "Enemy":
                isInvincible = true;
                SetInvincibleStatus( );
                break;
        }

    }
     void OnTriggerExit2D( Collider2D other) {
        switch ( other.tag ) {
            case "Enemy":
                other.isTrigger = false;
                isInvincible = false;
                break;
        }
    }
}
