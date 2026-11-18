using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OpenDrawer : MonoBehaviour
{
    public string message;
    public bool openned = false;
    public float speed = 1f;

    public bool isOpen;

    public Vector3 startPoz, endPoz;
    public Vector3 openOffset = new Vector3(0f, 0.5f, 0f);

    public GameObject textPrefab;
    public Transform pozText;
    public Transform canvas;
    void Start()
    {
        startPoz = transform.localPosition;
        endPoz = startPoz + openOffset;
    }

    void Update()
    {
        if (openned)
            transform.localPosition = Vector3.Lerp(transform.localPosition, endPoz, Time.deltaTime * speed);
        else
            transform.localPosition = Vector3.Lerp(transform.localPosition, startPoz, Time.deltaTime * speed);
    }

    public void Interact()
    {
        openned = !openned;
    }

    public void ShowText()
    {
        if (textPrefab != null && pozText != null)
        {
            GameObject newText = Instantiate(textPrefab, canvas);
            RectTransform rect = newText.GetComponent<RectTransform>();

            if (rect != null)
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
