using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerContols : MonoBehaviourPunCallbacks
{
    private PhotonView playerView;
    private bool isHandsBusy = false;
    private GameObject triggeredObject;
    private GameObject pickedObject;
    private Vector3 currentPosition;
    private Vector3 targetPosition;
    private Button _leave;

    void Start()
    {
        playerView = GetComponent<PhotonView>();      
        _leave = GameObject.Find("LeaveButton").GetComponent<Button>();
        _leave.onClick.AddListener(Leave);
    }

    private void OnTriggerStay(Collider other)
    {
      triggeredObject = other.gameObject;
    }
    private void OnTriggerExit(Collider other)
    {
        triggeredObject = null;
    }
    void Update()
    {
        if (!playerView.IsMine) return;
        if (Input.GetKey(KeyCode.A)) transform.Translate(-Time.deltaTime * 5, 0, 0);
        if (Input.GetKey(KeyCode.D)) transform.Translate(Time.deltaTime * 5, 0, 0);
        if (Input.GetKey(KeyCode.S)) transform.Translate(0, 0, -Time.deltaTime * 5);
        if (Input.GetKey(KeyCode.W)) transform.Translate(0, 0, Time.deltaTime * 5);
        if (Input.GetKeyDown(KeyCode.Space)) Action();
       
        if (isHandsBusy)
        {
            currentPosition = pickedObject.transform.position;
            targetPosition = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
            pickedObject.transform.position = targetPosition;
            pickedObject.transform.position = Vector3.MoveTowards(currentPosition, targetPosition,100);
        }
    }
    public override void OnLeftRoom()
    {
        SceneManager.LoadScene(0);
    }
    public void Leave()
    {
        PhotonNetwork.LeaveRoom();
    }
    public void Action()
    {
        if (isHandsBusy)
        {
            DropDown();
        }
        else
        {
            if (triggeredObject != null && triggeredObject.tag == "Pickable")
                PickUp();
        }
    }
    void PickUp()
    {
        isHandsBusy = !isHandsBusy;
        pickedObject = triggeredObject;
        pickedObject.GetComponent<Rigidbody>().isKinematic = true;
    }
    void DropDown()
    {
        isHandsBusy = !isHandsBusy;
        pickedObject.GetComponent<Rigidbody>().isKinematic = false;
        pickedObject = null;
    }

}
