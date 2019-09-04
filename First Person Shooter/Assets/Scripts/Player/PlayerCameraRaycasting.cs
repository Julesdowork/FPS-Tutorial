using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraRaycasting : MonoBehaviour
{
    ILootable currentTarget;
    [SerializeField] float range = 7f;

    void Update()
    {
        HandleRaycast();

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentTarget != null)
            {
                currentTarget.OnInteract();
            }
        }
    }

    private void HandleRaycast()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            ILootable lootable = hit.collider.GetComponent<ILootable>();

            if (lootable != null)
            {
                if (lootable == currentTarget) return;
                else if (currentTarget != null)
                {
                    currentTarget.OnLookAway();
                    currentTarget = lootable;
                    currentTarget.OnLook();
                }
                else
                {
                    currentTarget = lootable;
                    currentTarget.OnLook();
                }
            }
            else
            {
                if (currentTarget != null)
                {
                    currentTarget.OnLookAway();
                    currentTarget = null;
                }
            }
        }
        else
        {
            if (currentTarget != null)
            {
                currentTarget.OnLookAway();
                currentTarget = null;
            }
        }
    }
}
