using System;
using System.Collections;


using UnityEngine;
using UnityEngine.SceneManagement;


public class gameManagerScript : MonoBehaviour
{
    public GameObject playerPrefab;

    void Start()
    {
        if (playerPrefab == null)
        {
            Debug.LogError("<Color=Red><a>Missing</a></Color> playerPrefab Reference. Please set it up in GameObject 'Game Manager'", this);
        }
        else
        {
            Debug.Log("We are Instantiating LocalPlayer from ");
            // we're in a room. spawn a character for the local player. it gets synced by using PhotonNetwork.Instantiate
            GameObject tmp = PhotonNetwork.Instantiate(this.playerPrefab.name, new Vector3(0f, 0f, 0f), Quaternion.identity, 0);

            Camera.main.GetComponent<cameraFollow>().player = tmp;


        }
    }

    #region Photon Messages


    /// <summary>
    /// Called when the local player left the room. We need to load the launcher scene.
    /// </summary>
    public void OnLeftRoom()
    {
        SceneManager.LoadScene(0);
    }


    #endregion


    #region Public Methods


    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }


    #endregion
}