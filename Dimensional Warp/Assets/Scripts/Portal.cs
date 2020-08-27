using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{

    public GameObject portal;

    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(1);

            if ((touch.position.x == portal.transform.position.x) && (touch.position.y == portal.transform.position.y))
            {
                Debug.Log("object was touched");
                SceneManager.LoadScene("CamScene");
            }
        }
       

    }

}
