using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    private Renderer gateRenderer;
    private bool gateVisible = true;

    private void Start()
    {

        gateRenderer = GetComponent<Renderer>();
    }


    public void ShowGate()
    {
        gateVisible = true;
        gateRenderer.enabled = true;
    }


    public void HideGate()
    {
        Destroy(gameObject, 0.7f);
        gateVisible = false;
        gateRenderer.enabled = false;
    }
}

