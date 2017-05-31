using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCoin : MonoBehaviour {

	[SerializeField]
	private int addPoint;

	void OnTriggerEnter2D( Collider2D other ) {
		if( other.GetComponent<PlayerController>( ) == null ) {
			return;
		}

		ScoreController.AddScore( addPoint );

		Destroy( gameObject );
	}
}
