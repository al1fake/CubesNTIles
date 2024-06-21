using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewController : MonoBehaviour
{
    public int val = 0;
    private Renderer tileRenderer;
    void Start()
    {
        tileRenderer = GetComponent<Renderer>();
    }

    public void RenderTile()
    {
        switch (val) 
        {
            case 0:
                {
                    tileRenderer.material.SetColor("_Color", Color.white);
                    break;
                }

            case 1:
                {
                    tileRenderer.material.SetColor("_Color", Color.blue);
                    break;
                }
        }
    }
}
