using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launcherScript : Photon.PunBehaviour {

    private void Awake()
    {
        PhotonNetwork.autoJoinLobby = false;
        PhotonNetwork.automaticallySyncScene = true;

        PhotonNetwork.sendRate = 60;
        PhotonNetwork.sendRateOnSerialize = 60;
    }

    // Use this for initialization
    void Start () {
        PhotonNetwork.sendRate = 60;
        PhotonNetwork.sendRateOnSerialize = 60;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void connect()
    {
        PhotonNetwork.ConnectUsingSettings("v0.1");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("DemoAnimator/Launcher: OnConnectedToMaster() was called by PUN");

        PhotonNetwork.JoinRandomRoom();
    }


    public override void OnDisconnectedFromPhoton()
    {
        Debug.LogWarning("DemoAnimator/Launcher: OnDisconnectedFromPhoton() was called by PUN");
    }

    public override void OnPhotonRandomJoinFailed(object[] codeAndMsg)
    {
        Debug.Log("DemoAnimator/Launcher:OnPhotonRandomJoinFailed() was called by PUN. No random room available, so we create one.\nCalling: PhotonNetwork.CreateRoom(null, new RoomOptions() {maxPlayers = 4}, null);");
        // #Critical: we failed to join a random room, maybe none exists or they are all full. No worries, we create a new room.
        PhotonNetwork.CreateRoom(null, new RoomOptions() { MaxPlayers = 4 }, null);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("DemoAnimator/Launcher: OnJoinedRoom() called by PUN. Now this client is in a room.");

        if (PhotonNetwork.isMasterClient) PhotonNetwork.LoadLevel(1);
    }
}
