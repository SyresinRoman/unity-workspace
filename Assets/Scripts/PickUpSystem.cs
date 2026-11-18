using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickUpSystem : MonoBehaviour
{
    public Transform handle;
    public AudioSource player_source;
    public AudioClip pickUp_clip;

    public float pickUpDistance = 3f;
    public float pickUpForce = 10f;

    

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, pickUpDistance))
        {
            if (hit.collider.CompareTag("PickUp"))
            {
                if (Input.GetKey(KeyCode.E))
                {
                    PickUpItem(hit.collider.gameObject);
                    player_source.PlayOneShot(pickUp_clip);
                }
            }
        }

        if (Input.GetKey(KeyCode.Q) && handle.childCount > 0)
        {
            GameObject item = handle.GetChild(0).gameObject;
            DropItem(item);
        }
    }

    void PickUpItem(GameObject item)
    {
        Rigidbody rb = item.GetComponent<Rigidbody>();
        if (rb == null) rb = item.AddComponent<Rigidbody>();

        rb.useGravity = false;
        rb.isKinematic = true;

        if (handle != null)
        {
            rb.transform.SetParent(handle);
            rb.transform.localPosition = Vector3.zero;
            rb.transform.localRotation = Quaternion.Euler(0f, -90f, 180f);
        }
    }
    void DropItem(GameObject item)
    {
        Rigidbody rb = item.GetComponent<Rigidbody>();
        if (rb == null) rb = item.AddComponent<Rigidbody>();

        rb.useGravity = true;
        rb.isKinematic = false;

        if (handle != null)
        {
            rb.transform.SetParent(null);
        }
    }
}
