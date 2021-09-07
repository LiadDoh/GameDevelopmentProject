using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenCloseDoor : MonoBehaviour
{
    private Animator animator;
    private int isDoorOpen;
    public GameObject crossHair;
    public GameObject crossHairTouch;
    private Transform cam;
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isDoorOpen = 0;
        cam = Camera.main.transform;

        text = GameObject.Find("Interactions").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Physics.Raycast(cam.position, cam.forward, out RaycastHit hit);
        if (hit.transform != null && hit.transform.gameObject != null && hit.distance < 3)
        {
            if (hit.transform.gameObject == this.gameObject)
            {
                idleCrossHair(false);
                text.text = "Press left mouse button to interact";
                if (Input.GetMouseButton(0))
                {
                    if (isDoorOpen == 0)
                    {
                        animator.SetBool("isDoorOpen", true);
                        isDoorOpen = 1;
                    }
                    else
                    {
                        animator.SetBool("isDoorOpen", false);
                        isDoorOpen = 0;
                    }
                }
            } else
            {
                idleCrossHair(true);
            }
        }
        else
        {
            idleCrossHair(true);
            if (text.text.Equals("Press left mouse button to interact"))
                text.text = "";
        }
    }

    private void idleCrossHair(bool b)
    {
        crossHair.SetActive(b);
        crossHairTouch.SetActive(!b);
    }
}
