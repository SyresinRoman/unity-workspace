using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HintSystem : MonoBehaviour
{
    public TMP_Text textUse;

    public float pickUpDistance = 3f;
    public float pickUpForce = 10f;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        bool looking = false;

        if (Physics.Raycast(ray, out hit, pickUpDistance))
        {
            if (hit.collider.CompareTag("Door") || hit.collider.CompareTag("Drawer"))
            {
                textUse.text = "Открыть";
            }
            if (hit.collider.CompareTag("PickUp"))
            {
                textUse.text = "Взять";
            }

            if (hit.collider.CompareTag("Door") || 
                hit.collider.CompareTag("PickUp") || 
                hit.collider.CompareTag("Drawer"))
            {
                looking = true;
            }
        }

        textUse.gameObject.SetActive(looking);
    }
}
