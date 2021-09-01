using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer1 : MonoBehaviour
{
    private Animator animator;
    private int isOpen;
    public GameObject crossHair;
    public GameObject crossHairTouch;
    public GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isOpen = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Physics.Raycast(camera.transform.position, camera.transform.forward, out RaycastHit hit);
        if (hit.transform.gameObject != null && hit.distance < 3 )
        {
            if (hit.transform.gameObject == this.gameObject) {
            crossHair.SetActive(false);
            crossHairTouch.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (isOpen == 0)
                {
                    animator.SetBool("isOpen", true);
                    isOpen = 1;
                }
                else
                {
                    animator.SetBool("isOpen", false);
                    isOpen = 0;
                }
            }
        }
            }
        else
        {
            crossHair.SetActive(true);
            crossHairTouch.SetActive(false);
        }
    }

}
