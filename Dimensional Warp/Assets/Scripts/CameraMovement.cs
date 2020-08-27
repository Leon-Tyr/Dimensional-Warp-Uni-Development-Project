using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMovement : MonoBehaviour
{
    private Touch initTouch = new Touch();

    public float speed;
    public GameObject player;

    public Camera cam;
    public float minZoom = 50;
    public float maxZoom = 120;

    private float rotX;
    private float rotY;
    private Vector3 originalRot;

    public float rotSpeed = 3.0f;
    public float dir = -1;

    public GameObject returnBut;
    public GameObject healthBarUI;
    private bool POIActive;

    private AudioSource audio;
    public AudioClip POIsound;


    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        POIActive = false;
        originalRot = cam.transform.eulerAngles;
        rotX = originalRot.x;
        rotY = originalRot.y;
       
        healthBarUI = GameObject.Find("Health bar");
        returnBut = GameObject.FindGameObjectWithTag("ReturnBtn");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 eulerRotation = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(eulerRotation.x, eulerRotation.y, 0);

        if (POIActive == false)
        {
            if (Input.touchCount > 0)
            {
                if (Input.touchCount >= 2)
                {
                    Touch touchZero = Input.GetTouch(0);
                    Touch touchOne = Input.GetTouch(1);

                    Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
                    Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

                    float preMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
                    float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

                    float difference = currentMagnitude - preMagnitude;

                    zoom(difference * 0.1f);
                }
                /* else if (Input.GetTouch(0).phase == TouchPhase.Moved)
                 {
                     Vector2 touchDeltaPostion = Input.GetTouch(0).deltaPosition;
                     transform.Translate(-touchDeltaPostion.x * speed, -touchDeltaPostion.y * speed, 0);


                     transform.position = new Vector3(
                     Mathf.Clamp(transform.position.x, player.transform.position.x - 25.0f, player.transform.position.x + 25.0f),
                     Mathf.Clamp(transform.position.y, player.transform.position.y + 10.0f, player.transform.position.y + 20.0f),
                     Mathf.Clamp(transform.position.z, player.transform.position.z - 25.0f, player.transform.position.z + 25.0f));


                 }*/

            }
            /*  if (Input.touchCount < 2)
               {
                   foreach (Touch touch in Input.touches)
                   {
                       if (touch.phase == TouchPhase.Began)
                       {
                           initTouch = touch;
                       }
                       else if (touch.phase == TouchPhase.Moved)
                       {

                           float deltaX = initTouch.position.x - touch.position.x;
                           float deltaY = initTouch.position.y - touch.position.y;
                           rotX += deltaY * Time.deltaTime * rotSpeed * dir;
                           rotY -= deltaX * Time.deltaTime * rotSpeed * dir;
                           Mathf.Clamp(rotX, 0.0f, 20.0f);
                           Mathf.Clamp(rotY, -180.0f, 180.0f);

                           cam.transform.eulerAngles = new Vector3(rotX, rotY, 0f);
                       }
                       else if (touch.phase == TouchPhase.Ended)
                       {
                           initTouch = new Touch();
                       }
                   }
               }*/
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    Debug.Log(hit.transform.name);
                    if (hit.collider != null)
                    {
                        GameObject touchedObj = hit.transform.gameObject;
                        Debug.Log("touched " + touchedObj.transform.name);
                        if (touchedObj.tag == "POI")
                        {
                            Debug.Log("touch POI");
                            POIActive = true;
                            transform.parent = hit.transform;
                            cam.fieldOfView = 100.0f;
                            transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                            transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y + 20.0f, hit.transform.position.z + 15.0f);
                            returnBut.GetComponent<Image>().enabled = true;
                            returnBut.GetComponent<Button>().enabled = true;
                            hit.transform.gameObject.GetComponent<PointsOfInterest>().CrystalClicked();
                            healthBarUI.SetActive(false);
                            audio.PlayOneShot(POIsound);
                        }

                    }
                }

            }

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
                float rotX = touchDeltaPosition.y * (rotSpeed * Time.deltaTime);
                float rotY = -touchDeltaPosition.x * (rotSpeed * Time.deltaTime);
                transform.Rotate(rotX, rotY, 0);
                Vector3 currentRot = transform.localRotation.eulerAngles;
                currentRot.x = Mathf.Clamp(currentRot.x, 5, 80);
                transform.localRotation = Quaternion.Euler(currentRot);

            }

        }
       
    }

    void zoom(float increment)
    {
        cam.fieldOfView = Mathf.Clamp(cam.fieldOfView - increment, minZoom, maxZoom);
    }

    public void returnCamtoPlayer()
    {
        transform.parent = player.transform;
        transform.position =  new Vector3(player.transform.position.x, player.transform.position.y +5.0f, player.transform.position.z);
        returnBut.GetComponent<Image>().enabled = false;
        returnBut.GetComponent<Button>().enabled = false;
        POIActive = false;
        healthBarUI.SetActive(true);
    }

}
