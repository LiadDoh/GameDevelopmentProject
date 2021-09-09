using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC3Motion : MonoBehaviour
{
    private Vector3 pos;
    private Animator animator;
    private int state;
    public GameObject crossHair;
    public GameObject crossHairTouch;
    private Transform cam;
    private Text text;
    public float distance = 3;
    private bool canChangeCrossHair = true;
    private float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        state = 0;
        cam = Camera.main.transform;
        pos = transform.position;
        transform.position -= new Vector3(0, 0.25f, 0);
        text = GameObject.Find("Interactions").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Physics.Raycast(cam.position, cam.forward, out RaycastHit hit);
        if (hit.transform != null && hit.transform.gameObject != null && hit.distance < distance)
        {
            if (hit.transform.gameObject == this.gameObject)
            {
                idleCrossHair(false);
                canChangeCrossHair = true;
                text.text = "Press E to interact";
                if (Input.GetKeyDown(KeyCode.E) && (Time.time - time > 0.3 || time == 0))
                {
                    if (state == 0)
                    {
                        transform.position = pos;
                        animator.Play("Stand Up");
                        state = 1;

                    }
                    else if (state == 1)
                    {
                        animator.Play("Standing Idle To Fight Idle");
                        state = 2;
                    }
                    else if (state == 2)
                    {
                        animator.Play("Sitting");
                        state = 0;
                    }
                    time = Time.time;
                }
            }
            else
            {
                idleCrossHair(true);
            }
        }
        else
        {
            idleCrossHair(true);
            if (text.text.Equals("Press E to interact"))
                text.text = "";
        }
    }

    private void idleCrossHair(bool b)
    {
        if (!b || canChangeCrossHair)
        {
            crossHair.SetActive(b);
            crossHairTouch.SetActive(!b);
        }
        canChangeCrossHair = false;
    }
}
