using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxRotateScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(PhotonNetwork.isMasterClient) transform.Rotate(Vector3.right * Time.deltaTime * 5);
    }
}
