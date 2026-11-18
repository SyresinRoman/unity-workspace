using UnityEngine;

public class AlarmLight : MonoBehaviour
{
    public float minIntensity = 0.5f; 
    public float maxIntensity = 5f;   
    public float speed = 2f;          

    private Light alarmLight;

    void Start()
    {
        alarmLight = GetComponent<Light>();
    }
    void Update()
    {
        alarmLight.intensity = Mathf.Lerp(minIntensity, maxIntensity, Mathf.PingPong(Time.time * speed, 1f));
    }
}