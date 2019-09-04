using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardUI : MonoBehaviour
{
    Camera playerCam;

    // Start is called before the first frame update
    void Start()
    {
        playerCam = Camera.main;
    }

    void FixedUpdate()
    {
        LookAtPlayer();
    }

    private void LookAtPlayer()
    {
        transform.LookAt(transform.position + playerCam.transform.rotation * Vector3.forward,
            playerCam.transform.rotation * Vector3.up);
    }
}
