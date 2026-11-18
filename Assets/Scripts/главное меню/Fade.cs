using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public float speed = 0.5f;
    private Image blackScreen;
    private float alpha = 1f;
    void Start()
    {
        blackScreen = GetComponent<Image>();
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (alpha > 0)
        {
            alpha -= speed * Time.deltaTime;
            blackScreen.color = new Color(0, 0, 0, alpha);
        }
        else
            gameObject.SetActive(false);
    }
}
