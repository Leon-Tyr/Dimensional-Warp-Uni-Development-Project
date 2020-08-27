using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    private float speed = 2f;
    private float height = 0.5f;

    void Update()
    {
      //  transform.RotateAround(Camera.main.transform.position, Vector3.up, 10 * Time.deltaTime);

        Vector3 pos = transform.position;
        float newY = Mathf.Sin(Time.time * speed) * height + pos.y;
        transform.position = new Vector3(pos.x, newY, pos.z);
       
    }
}
