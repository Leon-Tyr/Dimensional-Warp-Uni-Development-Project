using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collectable : MonoBehaviour
{
    public item m_item;
    public GameObject Obj;

    private GameObject GUI;
    private Animator anim;

    void Start()
    {
        GUI = GameObject.Find("GUI");
        anim = GUI.GetComponent<Animator>();
    }

    private void OnMouseDown()
    {
        if (GameManager.Instance.CurrentInventory == null)
        {
            GameManager.Instance.CurrentInventory.CreateInventory();
        }
        anim.SetTrigger("Fade");
       
       StartCoroutine(ExecuteAfterTime(0.5f));

        
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        SceneTransitionManager.Instance.GoToScene("CamScene", new List<GameObject>());
        bool wasPickedUp = GameManager.Instance.CurrentInventory.Add(m_item);
        if (wasPickedUp == true)
        {
            Destroy(Obj);
        }
    }
}
