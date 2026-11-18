using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Door : MonoBehaviour
{
    public string message;
    public bool openned = true;
    public float speed = 1f;

    public bool isOpen = false;

    public Quaternion startRotation, endRotation;

    public GameObject textPrefab;
    public Transform pozText;
    public Transform canvas;
    void Start()
    {
        startRotation = transform.localRotation;
        endRotation = Quaternion.Euler(startRotation.eulerAngles - new Vector3(0, 90, 0));
    }

    void Update()
    {
        if (openned)
            transform.localRotation = Quaternion.Lerp(transform.localRotation, endRotation, Time.deltaTime * speed);
        else
            transform.localRotation = Quaternion.Lerp(transform.localRotation, startRotation, Time.deltaTime * speed);
    }

    public void Interact()
    {
        openned = !openned;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Chair"))
        {
            isOpen = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {       
        if (other.gameObject.CompareTag("Chair"))
        {
            isOpen = true;
        }
    }

    public void ShowText()
    {
        if (textPrefab != null && pozText != null)
        {
            GameObject newText = Instantiate(textPrefab, canvas);
            RectTransform rect = newText.GetComponent<RectTransform>();

            if(rect != null)
            {
                rect.anchoredPosition = new Vector2(0, -300);
                rect.localScale = Vector3.one;
            }

            TMP_Text text = newText.GetComponentInChildren<TMP_Text>();

            if (text != null)
            {
                text.text = message;
                Debug.Log("Текст показан: " + message);
            }
        }
    }
    

}
