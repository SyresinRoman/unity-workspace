using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using UnityEngine.Playables;

public class OpenEyes : MonoBehaviour
{
    public AudioSource alarmSource;
    public AudioClip alarmSound;

    public PlayableDirector pd;
    public Volume volume;
    public Image crosshair;
    
    private ColorAdjustments ca;
    
    public float speed = 2f; 
    public float timer = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        if (volume != null && volume.profile.TryGet(out ca))
        {
            ca.postExposure.overrideState = true;
        }
        crosshair.gameObject.SetActive(false);

        if (pd != null)
        {
            pd.Play();
            pd.Pause();
            pd.Evaluate();
        }
        alarmSource.volume = 0;
        alarmSource.loop = true;
        Invoke("PlayMusic", 2f);
    }

    void Update()
    {
        if (alarmSource.isPlaying && alarmSource.volume < 1f) alarmSource.volume += 0.3f * Time.deltaTime;
        if (timer < 2f)
        {
            timer += Time.deltaTime;
            if (ca != null) ca.postExposure.value = -10;
        }
        else
        {
            if (ca == null) return;

            if (ca.postExposure.value < 0f)
                ca.postExposure.value += speed * Time.deltaTime;
            if (timer >= 2f && timer < 4f)
            {
                timer += Time.deltaTime;
            }
            else
            {
                pd.Play();
                pd.Evaluate();
            }
        }
    }
    void PlayMusic()
    {
        if (alarmSource != null)
        {
            alarmSource.Play();
        }
    }
}