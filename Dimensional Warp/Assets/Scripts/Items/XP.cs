using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XP : MonoBehaviour
{
    [SerializeField] private int bonus = 10;
    public item m_item;
    public GameObject Obj;

    public AudioClip XP_clip;
    private AudioSource audio;
    private GameObject camController;

    void Start()
    {
        camController = GameObject.Find("Camera Controller");
        audio = camController.GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        if (GameManager.Instance.CurrentInventory == null)
        {
            GameManager.Instance.CurrentInventory.CreateInventory();
        }
        audio.PlayOneShot(XP_clip);
        GameManager.Instance.CurrentPlayer.AddXp(bonus);
        bool wasPickedUp = GameManager.Instance.CurrentInventory.Add(m_item);
        if (wasPickedUp == true)
        {
            Destroy(Obj);
        }

    }
}
