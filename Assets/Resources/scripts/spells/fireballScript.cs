using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireballScript : MonoBehaviour {

    public GameObject spellPrefab;
    public Vector3 spellOffset;
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void castSpell()
    {
        GameObject tmp = PhotonNetwork.Instantiate(spellPrefab.name, transform.position + spellOffset, Quaternion.identity, 0, null);
        tmp.transform.parent = this.transform;
    }
}
