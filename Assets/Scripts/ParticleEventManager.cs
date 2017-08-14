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

	void Start( ) {
		player = GameObject.FindObjectOfType<PlayerController>( );
        inimigo = GameObject.FindObjectOfType<InimigoController>( );
	}

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

