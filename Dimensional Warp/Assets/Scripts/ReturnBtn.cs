using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnBtn : MonoBehaviour
{
    private GameObject cc;
    private CameraMovement camScript;

    // Update is called once per frame
    void LateUpdate()
    {
        cc = GameObject.FindGameObjectWithTag("CC");
        camScript = cc.GetComponent<CameraMovement>();
    }

    public void returnActive()
    {
        camScript.returnCamtoPlayer();
    }
    
}
