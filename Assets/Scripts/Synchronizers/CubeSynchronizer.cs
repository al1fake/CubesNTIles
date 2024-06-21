using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CubeSynchronizer : MonoBehaviourPunCallbacks, IPunObservable
{
    public Rigidbody rigidBody;
   
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        
        if (stream.IsWriting) stream.SendNext(rigidBody.isKinematic);
        else rigidBody.isKinematic = (bool)stream.ReceiveNext();
    }
 
}
