using Photon.Pun;
using Photon.Pun.Demo.Cockpit;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public Text LogText;
    void Start()
    {
        if(PhotonNetwork.InRoom)
        {
            PhotonNetwork.LeaveRoom();
        }
        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.NickName = "Player " + Random.Range(1, 100);
            Log("Nickname: " + PhotonNetwork.NickName);

            PhotonNetwork.GameVersion = "1";
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public override void OnConnectedToMaster()
    {
        Log("Connected To Master");
    }

    public void HostGame()
    {
        PhotonNetwork.CreateRoom(null, new Photon.Realtime.RoomOptions { MaxPlayers = 2 });
        StartCoroutine(StartHost());
    }
    public void PlayGame()
    {
        PhotonNetwork.JoinRandomRoom();
        StartCoroutine(StartPlayer());   
    }

    public override void OnJoinedRoom()
    {
        Log("Joined the Room");

    }

    private void Log(string message)
    {
        Debug.Log(message);
        LogText.text += "\n";
        LogText.text += message;

    }
    IEnumerator StartHost()
    {
        while(!PhotonNetwork.InRoom)
        {
            yield return new WaitForSeconds(0.5f);
        }
        PhotonNetwork.LoadLevel(1);
        StopCoroutine(StartHost());
    }
    IEnumerator StartPlayer()
    {
        while(!PhotonNetwork.InRoom)
        {
            yield return new WaitForSeconds(0.5f);
        }
        PhotonNetwork.LoadLevel(2);
        StopCoroutine(StartPlayer());
    }

}
