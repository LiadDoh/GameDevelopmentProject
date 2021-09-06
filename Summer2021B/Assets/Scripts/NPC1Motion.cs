using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NPC1Motion : MonoBehaviour
{
    NavMeshAgent nav;
    Rigidbody rb;
    private Animator anim;
    public Transform target;
    public Transform []wayPoints;
    public int curWaypoints;
    public float speed;
    public float stopDistance;
    public float pauseTimer;
    [SerializeField]
    private float curTimer;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        rb.freezeRotation = true;
        target = wayPoints[curWaypoints];
        curTimer = pauseTimer;
    }

    // Update is called once per frame
    void Update()
    {
        nav.acceleration = speed;
        nav.stoppingDistance = stopDistance;

        float distance = Vector3.Distance(transform.position, target.position);

        if(distance > stopDistance && wayPoints.Length > 0)
        {
            anim.SetBool("isWalking", true);
            target = wayPoints[curWaypoints];
        }
        else if(distance<= stopDistance && wayPoints.Length > 0)
        {
            if(curTimer > 0)
            {
                curTimer -= 0.01f;
                anim.SetBool("isWalking", false);
            }

            if (curTimer <= 0)
            {

                curWaypoints++;
                if (curWaypoints >= wayPoints.Length)
                {
                    curWaypoints = 0;
                }
                target = wayPoints[curWaypoints];
                curTimer = pauseTimer;
            }
        }
        nav.SetDestination(target.position);

    }
}
