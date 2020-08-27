using UnityEngine;
using UnityEngine.UI;
public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Text text;
    private GameObject slot;
    private Image img;
    item m_item;

    void Start()
    {
        //slot = this.gameObject;
        img = GetComponent<Image>();
    }


    public void AddItem(item newItem)
    {
        m_item = newItem;
        img.enabled = true;

        icon.sprite = m_item.icon;
        icon.enabled = true;
        text.text = m_item.name;
        text.enabled = true;

        

    }

    public void ClearSlot()
    {
        m_item = null;

        icon.sprite = null;
        icon.enabled = false;
        text.text = null;
        text.enabled = false;

        img.enabled = false;
    }

    public void UseItem()
    {
        if(m_item != null)
        {
            m_item.Use();
            GameManager.Instance.CurrentInventory.Remove(m_item);
        }

    }
}
