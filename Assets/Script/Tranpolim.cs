using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tranpolim : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Pe")
        {
            animator.SetTrigger("pulo");
        }

    }
 



}
