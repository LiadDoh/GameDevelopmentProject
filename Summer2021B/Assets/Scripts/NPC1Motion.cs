using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC1Motion : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play("Breathing Idle");
    }

    // Update is called once per frame
    void Update()
    {
        if(animator.GetBool(""))
    }
}
