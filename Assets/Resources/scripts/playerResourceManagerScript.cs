using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerResourceManagerScript : MonoBehaviour , IPunObservable{

    private int maxHealth;
    private int curHealth;
    private int maxMana;
    private int curMana;

	// Use this for initialization
	void Start () {

        maxHealth = 100;
        maxMana = 100;
        curHealth = 100;
        curMana = 100;
	}

    public int getResource(int resourceType)
    {
        if (resourceType == 1) return curHealth;
        return curMana;
    }

    public int changeResourceByAmount(int resourceType, int amount)
    {
        if (resourceType == 1)
        {
            curHealth = Mathf.Clamp(curHealth - amount, 0, maxHealth);
            if (curHealth == 0) return 1;
        }
        else curMana = Mathf.Clamp(curMana - amount, 0, maxMana);

        return 0;
    }

    public int getMaxResource(int resourceType)
    {
        if (resourceType == 1) return maxHealth;
        return maxMana;
    }

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            // We own this player: send the others our data
            stream.SendNext(curHealth);
            stream.SendNext(curMana);
        }
        else
        {
            // Network player, receive data
            this.curHealth = (int)stream.ReceiveNext();
            this.curMana = (int)stream.ReceiveNext();
        }
    }
}
