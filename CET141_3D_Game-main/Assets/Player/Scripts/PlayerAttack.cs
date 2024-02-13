using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerAttack : MonoBehaviour
{
    Transform cameraTransform;
    float range = 100f;

    [SerializeField]
    float rawDamage = 10f;

    private void Update()
    {
        FireWeapon();
    }

    void FireWeapon()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            cameraTransform = Camera.main.transform;
            Ray ray = new Ray(cameraTransform.position, cameraTransform.forward);
            RaycastHit raycastHit;

            if (Physics.Raycast(ray, out raycastHit, range))
            {
                if (raycastHit.transform != null)
                {
                    raycastHit.collider.SendMessageUpwards("Hit", rawDamage, SendMessageOptions.DontRequireReceiver);
                }

                else
                {
                    Debug.Log("NO RAYCAST");
                }
            }
        }
    }
}
