using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsOfInterest : MonoBehaviour
{
    private float timer;
    private float count = 30;
    public bool cooldownOn;

    public item m_item;

    Animator anim;

    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
        cooldownOn = false;
    }

    void Update()
    {
        if (cooldownOn == true)
        {
            timer += Time.deltaTime;
            //Debug.Log(timer);
            if (timer >= count)
            {
                timer = 0;
                cooldownOn = false;
                anim.SetBool("Clicked", false);
            }
        }
    }

    public void CrystalClicked()
    {
        cooldownOn = true;
        if (timer == 0)
        {
            if (GameManager.Instance.CurrentInventory == null)
            {
                GameManager.Instance.CurrentInventory.CreateInventory();
            }
            GameManager.Instance.CurrentPlayer.AddXp(100);
            anim.SetBool("Clicked", true);
            GameManager.Instance.CurrentInventory.Add(m_item);
        }
        
    }
}
