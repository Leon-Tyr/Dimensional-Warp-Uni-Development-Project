using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gyro : MonoBehaviour
{

    #region Instace
    private static Gyro instance;
    public static Gyro Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Gyro>();
                if (instance == null)
                {
                    instance = new GameObject("Spawned Gyro", typeof(Gyro)).GetComponent<Gyro>(); 
                }
            }

            return instance;
        }
        set {  instance = value;   }
    }
    #endregion

    [Header("Logic")]
    private Gyroscope gyro;
    private Quaternion rotation;
    private bool arReady = false;

 
    private void Update()
    {
        if (arReady)
        {
            rotation = gyro.attitude;
        }
    }

    public void EnableGyro()
    {
        if (arReady)
            return;

        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
        }
        arReady = gyro.enabled;

    }

    public Quaternion GetGyroRotation()
    {
        return rotation;
    }


}
