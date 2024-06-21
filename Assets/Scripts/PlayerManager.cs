using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourPunCallbacks
{
    public GameObject PlayerPrefab;
    public GameObject CubePrefab;
    private void Start()
    {
       PhotonNetwork.Instantiate(PlayerPrefab.name, new Vector3(2, 1, 3), Quaternion.identity);
       SpawnCubes();
    }
    public override void OnLeftRoom()
    {
        SceneManager.LoadScene(0);
    }
    public void Leave()
    {
        PhotonNetwork.LeaveRoom();
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.LogFormat("Player {0} entered room", newPlayer.NickName);
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.LogFormat("Player {0} left room", otherPlayer.NickName);
    }
    void SpawnCubes()
    {
        for (int i = 0; i < 9; i++)
        {
            PhotonNetwork.Instantiate(CubePrefab.name, new Vector3(2, 1, -((float)i / 1.9f + 1)), Quaternion.identity);
        }
    }
}

