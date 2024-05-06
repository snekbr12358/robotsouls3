using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    GerenciadorJogo GJ;
    private void Awake()
    {
        GJ = GameObject.FindGameObjectWithTag("Player").GetComponent<GerenciadorJogo>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GJ.UpdateCheckpoint(transform.position);
        }
    }
}
