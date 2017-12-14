using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatorTestScript : MonoBehaviour {

    private Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("jump"))
        {
            anim.SetBool("Jump", true);
            Debug.Log("play jump");
        }
        else
        {
            anim.SetBool("Idle", true);
        }
    }
}
