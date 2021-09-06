using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCFollowing : MonoBehaviour
{
    public GameObject player;
    public GameObject NPC;
    public float targetDistance;
    public float allowedDistance = 5;
    public float followSpeed;
    public RaycastHit shot;
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out shot))
        {
            targetDistance = shot.distance;
            if (targetDistance >= allowedDistance)
            {
                followSpeed = 0.05f;
                NPC.GetComponent<Animation>().Play("running");
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, followSpeed);
            }
            else
            {
                followSpeed = 0;
                NPC.GetComponent<Animation>().Play("idle");
            }
        }
    }
}
