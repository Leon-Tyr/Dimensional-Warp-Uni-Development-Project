using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SubCam : MonoBehaviour
{
    NavMeshAgent agent;
    private Camera cam;
    public GameObject mainCam;

    // Start is called before the first frame update
    void Start()
    {
        cam = gameObject.GetComponent<Camera>();
        agent = GetComponent<NavMeshAgent>();
        cam.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    GameObject touchedObj = hit.transform.gameObject;
                    Debug.Log("touched " + touchedObj.transform.name);
                    if (touchedObj.tag == "POI")
                    {
                        cam.enabled = true;
                        agent.SetDestination(hit.transform.position);
                        mainCam.SetActive(false);
                    }

                }
            }

        }
    }
}
