using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMotion : MonoBehaviour
{
    private Animator animator;
    private AudioSource doorOpening;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        doorOpening = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        animator.SetBool("Open", true);
        doorOpening.PlayDelayed(0.5f);
    }

    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("Open", false);
        doorOpening.PlayDelayed(0.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
