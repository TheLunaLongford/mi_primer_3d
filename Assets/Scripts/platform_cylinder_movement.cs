using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform_cylinder_movement : MonoBehaviour
{
    public Transform center;
    public Transform initial;

    public int delay;

    private float movement_speed;
    // Start is called before the first frame update
    void Start()
    {
        initial = transform;
        movement_speed = 0.5f;
    }

    private void Update()
    {
        Transform A = initial;
        Transform B = center;

        Vector3 direccion = new Vector3(
            A.transform.position.x - B.transform.position.x,
            0.0f,
            A.transform.position.z - B.transform.position.z
            ).normalized;

        transform.Translate(direccion * movement_speed * Time.deltaTime);
    }


}
