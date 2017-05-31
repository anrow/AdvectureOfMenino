using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEventManager : MonoBehaviour {
	[SerializeField]
	private PlayerController player;

    [SerializeField]
    private InimigoController inimigo;

	[SerializeField]
	private GameObject damageParticle;

    [SerializeField]
    private GameObject enemyParticle;

    [SerializeField]
    private float respawnDelay;
	void Start( ) {

		player = GameObject.FindObjectOfType<PlayerController>( );
        inimigo = GameObject.FindObjectOfType<InimigoController>( );
        respawnDelay = 1.0f;
	}

    /*public void SetRespawnParticle( ) {
		
        StartCoroutine( "RespawnParticle" );

	}
    public IEnumerator RespawnParticle( GameObject particleType, Transform particleTrans ) {
        Instantiate( particleType, particleTrans.position, particleTrans.rotation );
        yield return new WaitForSeconds( respawnDelay );
       
    }
	*/
    void RespawnParticle( GameObject particleType, Transform particleTrans ) {
        Instantiate( particleType, particleTrans.position, particleTrans.rotation );
    }

    public void SetDamageParticle( ) {
        RespawnParticle( damageParticle, player.transform );
    } 
    public void SetEnemyParticle( ) {
        RespawnParticle( enemyParticle, inimigo.transform );
    } 
}

