using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	[SerializeField]
	private PlayerController player;

	[SerializeField]
	private float offsetX;

	[SerializeField]
	private float offsetY;

	public bool isFllowing;

	// Use this for initialization
	void Start () {
		player = GameObject.FindObjectOfType<PlayerController>( );

		isFllowing = true;

		offsetY = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if( isFllowing ) {
			transform.position = new Vector3( player.transform.position.x + offsetX,
										  	  player.transform.position.y + offsetY,
			                              	  transform.position.z );
		}
	}
}
