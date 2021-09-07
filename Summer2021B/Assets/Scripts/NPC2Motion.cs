using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC2Motion : MonoBehaviour
{
    public Transform playerTransform;
    private Vector3 playerPos;
    private Vector3 npcPos;

    private float distance;
    public float wantedDistance;
    private Vector3 originalSize;

    public AudioSource zombieAS;
    private bool isBigger = false;

    private void Start()
    {
        originalSize = gameObject.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = playerTransform.position;
        npcPos = transform.position;
        Vector3 delta = new Vector3(playerPos.x - npcPos.x, 0.0f, playerPos.z - npcPos.z);

        Quaternion rotation = Quaternion.LookRotation(delta);
        gameObject.transform.rotation = rotation;

        distance = Vector3.Distance(npcPos, playerPos);
        if (distance < wantedDistance)
        {
            gameObject.transform.localScale = originalSize * 2;
            if (!isBigger)
                zombieAS.Play();
            isBigger = true;
        }
        else
        {
            gameObject.transform.localScale = originalSize;
            isBigger = false;
        }

    }
}
