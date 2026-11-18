using UnityEngine;
using UnityEngine.Playables;
using Cinemachine;
using UnityEngine.UI;

public class TimelineController : MonoBehaviour
{
    [Header("—сылки")]
    [SerializeField] private PlayableDirector director;
    [SerializeField] private GameObject virtualCamera;  
    [SerializeField] private GameObject playerObject;
    [SerializeField] private Image crosshair;
    

    void Start()
    {
        if (director != null)
        {
            director.stopped += OnTimelineFinished;
        }
    }

    private void OnTimelineFinished(PlayableDirector pd)
    {
        if (virtualCamera != null)
        {
            virtualCamera.SetActive(false);
        }

        if (playerObject != null)
        {
            var moveScript = playerObject.GetComponent<Movement>();
            if (moveScript != null) moveScript.enabled = true;
        }

        var mainCam = Camera.main;
        if (mainCam != null)
        {
            crosshair.gameObject.SetActive(true);
            var brain = mainCam.GetComponent<CinemachineBrain>();
            var camScript = mainCam.GetComponent<MouseLook>();

            Camera.main.transform.localPosition = new Vector3(0f, 0.5f, 0f);
            Camera.main.fieldOfView = 60;
            if (brain != null)
            {
                brain.enabled = false; 
            }
            if (camScript != null)
            {
                camScript.enabled = true;
            }
        }
    }

    void OnDestroy()
    {
        if (director != null) director.stopped -= OnTimelineFinished;
    }
}