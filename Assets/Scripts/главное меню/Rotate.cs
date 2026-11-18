using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    public Transform target;      
    public float radius = 3f;     
    public float speed = 1f;      
    public float height = 1.5f;   

    private float angle = 0f;

    void Update()
    {
        if (target == null) return;

        angle += speed * Time.deltaTime;

        float x = target.position.x + Mathf.Cos(angle) * radius;
        float z = target.position.z + Mathf.Sin(angle) * radius;

        transform.position = new Vector3(x, target.position.y + height, z);

        transform.LookAt(target);
    }
}