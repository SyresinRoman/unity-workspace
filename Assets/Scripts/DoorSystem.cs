using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorSystem : MonoBehaviour
{
    public AudioSource source;

    public AudioClip stopSound;
    public AudioClip openSound;

    private bool textShow = false;
    public float pickUpDistance = 3f;
    public float pickUpForce = 10f;

    public Door door;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;


        if (Physics.Raycast(ray, out hit, pickUpDistance))
        {
            if (hit.collider != null && hit.collider.CompareTag("Door"))
            {
                Door doorScript = hit.collider.GetComponentInParent<Door>();

                if (doorScript != null)
                {
                    if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Mouse1))
                    {
                        if (!doorScript.isOpen)
                        {
                            doorScript.ShowText();
                            source.PlayOneShot(stopSound);
                        }
                        else
                        {
                            doorScript.Interact();
                            source.PlayOneShot(openSound);
                        }
                    }
                }
            }

        }
    }

    
}
