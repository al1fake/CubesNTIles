using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllers : MonoBehaviourPunCallbacks
{

    private int gameSeed;
    private string gameSeedStringBinary;
    private GameObject[] preview = new GameObject[9];
    private PreviewController[] previewController = new PreviewController[9];
    private TileController[] tileController = new TileController[9];
    private GameObject[] set = new GameObject[9];
    private string pickedString;


    void Start()
    {

        for (int i = 0; i < preview.Length; i++)
        {
            preview[i] = GameObject.Find("Cube" + i);
            previewController[i] = preview[i].GetComponent<PreviewController>();


        }
        for (int i = 0; i < set.Length; i++)
        {
            set[i] = GameObject.Find("Set" + i);
            tileController[i] = set[i].GetComponent<TileController>();
        }
    }

    public void StartGame()
    {
        gameSeedStringBinary = "";
        gameSeed = UnityEngine.Random.Range(0, 511);
        pickedString = "";
        string binary = Convert.ToString(gameSeed, 2);

        if (binary.Length < 9)
        {
            for (int i = 0; i < 9 - binary.Length; i++)
            {
                gameSeedStringBinary += "0";
            }
            gameSeedStringBinary += binary;
        }
        else
        {
            gameSeedStringBinary = binary;
        }
        Debug.Log(gameSeedStringBinary + "GameSeedBinary");
        for (int i = 0; i < preview.Length; i++)
        {
            previewController[i].val = (int)gameSeedStringBinary[i] - (int)'0';
            previewController[i].RenderTile();
        }
    }

    public void Recalculate()
    {
        pickedString = "";
        for (int i = 0; i < preview.Length; i++)
        {
            pickedString += tileController[i].val.ToString();
        }
        Debug.Log(pickedString + "PickedString");
        if (pickedString == gameSeedStringBinary)
        {
            PhotonNetwork.LoadLevel(0);
        }
    }
}
    
