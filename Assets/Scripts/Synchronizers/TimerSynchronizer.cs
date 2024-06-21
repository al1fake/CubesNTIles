using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;


public class TimerSynchronizer : MonoBehaviourPunCallbacks, IPunObservable
{

    public Slider slider;

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        
        if (stream.IsWriting)
        {
            stream.SendNext(slider.value);       
        }
        else
        {
            slider.value = (float)stream.ReceiveNext();       
        }
    }


   
}
