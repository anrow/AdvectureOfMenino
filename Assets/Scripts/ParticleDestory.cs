using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDestory : MonoBehaviour {
    [SerializeField]
    private float destroyDelay = 1.0f;
    void Start( ){
        Destroy( gameObject, destroyDelay );
    }

}
