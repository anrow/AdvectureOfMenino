using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittingSystem : MonoBehaviour {
    
    public Vector3 pointRadius;

    public bool IsHitted( Transform[ ] hittedPoints, LayerMask WhatIsHit ) {
		
        foreach( Transform point in hittedPoints ) {

        	Collider2D[ ] colliders = Physics2D.OverlapAreaAll( point.position, point.position + pointRadius, WhatIsHit );
        
        	for( int i = 0; i < colliders.Length; i++ ) {
        		if( colliders[ i ].gameObject != gameObject ) {
        			return true;
        		}
        	} 
        }
		return false;
	}

}
