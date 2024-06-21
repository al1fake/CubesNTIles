using Photon.Pun;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HostManager : MonoBehaviourPunCallbacks
{
    private float timer;
    private float maxTime = 3;
    public GameObject timerObject;
    public GameControllers gameControllers;
    
    private void Start()
    {  
        StartCoroutine(WaitingForPlayer());
    }
    public override void OnLeftRoom()
    {
        Debug.Log("OnLeftRoom");
        SceneManager.LoadScene(0);
    }
    public void Leave()
    {
        Debug.Log("Leave");
        PhotonNetwork.LeaveRoom();
    }
    IEnumerator WaitingForPlayer()
    {
        while(PhotonNetwork.CurrentRoom.PlayerCount != 2)
        {
            yield return new WaitForSeconds(0.5f);           
        }
        StartCoroutine(HostTurn());
        StopCoroutine(WaitingForPlayer()); 
    }
    IEnumerator HostTurn()
    {
     
        timer = maxTime;
       
        while (timer > 0) 
        {
           
            timer -= 0.1f;
            yield return new WaitForSeconds(0.1f);
        }       
        EndHostTurn();  
    }
    public void EndHostTurn()
    {
        StopCoroutine(HostTurn());
        gameControllers.StartGame();       
    }


    
}
