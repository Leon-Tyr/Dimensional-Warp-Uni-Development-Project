using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{

    public void heal()
    {
        GameManager.Instance.CurrentPlayer.UpdateHeal();
    }
    


}
