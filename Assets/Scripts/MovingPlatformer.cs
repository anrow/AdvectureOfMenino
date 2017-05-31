using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformer : MonoBehaviour {
	[SerializeField]
	private GameObject platformer;

	[SerializeField]
	private Transform currentPoint;

    [SerializeField]
	private Transform[ ] dirPoints;

	[SerializeField]
	private float moveSpeed;

	[SerializeField]
	private int pointSelection;

	void Start( ) {
		currentPoint = dirPoints[ pointSelection ];
	}

	void Update( ) {
		platformer.transform.position = Vector3.MoveTowards( platformer.transform.position, 
															 currentPoint.position, 
															 Time.deltaTime * moveSpeed );

		if( platformer.transform.position == currentPoint.position ) {
			pointSelection++;
			if( pointSelection == dirPoints.Length ) {
				pointSelection = 0;
			}

			currentPoint = dirPoints[ pointSelection ];
		}
	}
}
