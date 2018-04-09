using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

    public GameObject text;
    public int startTime; 

	// Use this for initialization
	void Start () {
        startTime = System.DateTime.Now.Second;
	}
	
	// Update is called once per frame
	void Update () {
        int timeDiff = System.DateTime.Now.Second - startTime;
        if (timeDiff > 6)
        {
            text.SetActive(false);
        }
    }
}
