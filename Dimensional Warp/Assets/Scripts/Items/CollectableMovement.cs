using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableMovement : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 50;
    [SerializeField] private float floatAmp = 2.0f;
    [SerializeField] private float floatFreq = 0.5f;
    [SerializeField] Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
        Vector3 tempPos = startPos;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * floatFreq) * floatAmp;

        transform.position = tempPos;
    }
}
