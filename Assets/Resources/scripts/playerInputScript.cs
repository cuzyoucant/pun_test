using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInputScript : MonoBehaviour
{

    private playerResourceManagerScript pr;

    // Use this for initialization
    void Start()
    {
        pr = GetComponent<playerResourceManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {

        if (this.GetComponent<PhotonView>().isMine == false && PhotonNetwork.connected == true) return;

        if (Input.GetButtonDown("spell1")) performSpell(1);
        if (Input.GetButtonDown("spell2")) performSpell(2);
        if (Input.GetButtonDown("spell3")) performSpell(3);
        if (Input.GetButtonDown("spell4")) performSpell(4);
    }

    private void performSpell(int spellid)
    {
        if (spellid == 1) pr.changeResourceByAmount(1, 10);
        else if (spellid == 2) pr.changeResourceByAmount(2, 10);
        else if (spellid == 3)
        {
            PhotonNetwork.InstantiateSceneObject("box1", transform.position + new Vector3(1, 0, 0), Quaternion.identity, 0, null);
        }
        else if(spellid == 4)
        {
            GetComponent<fireballScript>().castSpell();
        }
    }
}
