using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    public int val = 0;
    private Renderer tileRenderer;
    public GameControllers gameControllers;
    void Start()
    {
        tileRenderer = GetComponent<Renderer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickable")
        {
            val = 1;
            tileRenderer.material.SetColor("_Color", Color.blue);
        }
        gameControllers.Recalculate();
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Pickable")
        {
            val = 1;
            tileRenderer.material.SetColor("_Color", Color.blue);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Pickable")
        {
            val = 0;
            tileRenderer.material.SetColor("_Color", Color.white);
        }
        gameControllers.Recalculate();
    }
}
