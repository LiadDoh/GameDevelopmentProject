using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public AudioSource itemPicked;

    float throwForce = 600f;
    Vector3 objectPos;
    float distance;
    public float distanceAlowed = 2f;

    public bool canHold = true;
    public GameObject item;
    private GameObject tempParent;
    public bool isHolding = false;

    private void Start()
    {
        if (tempParent == null)
            tempParent = GameObject.Find("Dest");
    }

    private void Update()
    {
        distance = Vector3.Distance(item.transform.position, tempParent.transform.position);
        if (distance > distanceAlowed)
        {
            isHolding = false;
        }
        if (isHolding)
        {
            item.GetComponent<Rigidbody>().velocity = Vector3.zero;
            item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            item.transform.SetParent(tempParent.transform);


            if (Input.GetMouseButtonDown(1))
            {
                item.GetComponent<Rigidbody>().AddForce(tempParent.transform.forward * throwForce);
                isHolding = false;
            }
        }
        else
        {
            objectPos = item.transform.position;
            item.transform.SetParent(null);
            item.GetComponent<Rigidbody>().useGravity = true;
            item.transform.position = objectPos;
        }
    }

    private void OnMouseDown()
    {
        if (distance <= distanceAlowed)
        {
            if (!isHolding && itemPicked != null)
                itemPicked.Play();
            isHolding = true;
            item.GetComponent<Rigidbody>().useGravity = false;
            item.GetComponent<Rigidbody>().detectCollisions = true;
            item.transform.SetPositionAndRotation(tempParent.transform.position, tempParent.transform.rotation);
        }
    }
    private void OnMouseUp()
    {
        isHolding = false;
    }
}
