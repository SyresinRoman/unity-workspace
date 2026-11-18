using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Text_closed_door : MonoBehaviour
{
    public float speed = 50f;
    public float fadeDuration = 1.5f;

    private TMP_Text text;
    private Color startColor;
    private RectTransform rectTransform;
    private float timer = 0f;

    void Start()
    {
        text = GetComponent<TMP_Text>();
        rectTransform = GetComponent<RectTransform>();
        startColor = text.color;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (rectTransform != null)
            rectTransform.anchoredPosition += new Vector2(0, speed * Time.deltaTime);
        float alpha = 1f - (timer / fadeDuration);
        text.color = new Color(startColor.r, startColor.g, startColor.b, alpha);

        if (timer >= fadeDuration)
            Destroy(gameObject);
    }
}
