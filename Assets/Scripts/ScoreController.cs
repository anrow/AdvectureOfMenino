using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

    public static int scorePoint;

    [SerializeField]
    private Text scoreCounter;

    void Start( ) {

        scoreCounter = gameObject.GetComponent<Text>( );

        scorePoint = 0;
    }

    void Update( ){
		
        if( scorePoint < 0 ) {
            scorePoint = 0;
        }
        scoreCounter.text = "" + scorePoint;
    }

	public static void AddScore( int addPoint ) {
		scorePoint += addPoint;
	}

	public static void ResetScoreVaule( ) {
		scorePoint = 0;
	}
}
