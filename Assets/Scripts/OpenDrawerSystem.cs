using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OpenDrawerSystem : MonoBehaviour
{
    public AudioSource source;

    public AudioClip stopSound;
    public AudioClip openSound;
    public AudioClip closeSound;

    private bool textShow = false;
    public float pickUpDistance = 3f;
    public float pickUpForce = 10f;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;


        if (Physics.Raycast(ray, out hit, pickUpDistance))
        {
            if (hit.collider != null && hit.collider.CompareTag("Drawer"))
            {
                OpenDrawer drawerScript = hit.collider.GetComponentInParent<OpenDrawer>();

                if (drawerScript != null)
                {
                    if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Mouse1))
                    {
                        if (!drawerScript.isOpen)
                        {
                            drawerScript.ShowText();
                            source.PlayOneShot(stopSound);
                        }
                        else if(drawerScript.openned)
                        {
                            drawerScript.Interact();
                            source.PlayOneShot(openSound);
                        }
                        else if (!drawerScript.openned)
                        {
                            drawerScript.Interact();
                            source.PlayOneShot(closeSound);
                        }
                    }
                }
            }

        }
    }


}
