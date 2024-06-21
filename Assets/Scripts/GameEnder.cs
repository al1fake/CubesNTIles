using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnder : MonoBehaviourPunCallbacks

{

    public void EndGame()
    {
        PhotonNetwork.LoadLevel(0);
    }
}
