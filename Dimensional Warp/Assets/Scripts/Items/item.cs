using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Item", menuName ="Inventory/Item")]

public class item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    //public string text = null;
    public bool isDefaultItem = false;
     

    public virtual void Use()
    {
        if (name == "Green Crystal")
        {
            Debug.Log("Green item Used");
            GameManager.Instance.CurrentPlayer.AddXp(50);
        }
        if (name == "White Crystal")
        {
            Debug.Log("White item Used");
            GameManager.Instance.CurrentPlayer.IncreaseMaxHealth(20);

        }
        if (name == "Red Crystal")
        {
            Debug.Log("Red item Used");
            GameManager.Instance.CurrentPlayer.UpdateHeal();
        }
    }
}
