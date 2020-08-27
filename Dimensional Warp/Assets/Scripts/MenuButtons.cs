using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{

    public GameObject Settings;

    public GameObject inventoryPanels;

    public GameObject musicSlide;

    public void SettingsMenuOn()
    {

        if (Settings != null)
        {
            bool SettingsisActive = Settings.activeSelf;
            Settings.SetActive(!SettingsisActive);
        }

    }
    public void InventroyButton()
    {
        if (inventoryPanels != null)
        {
            bool isActive = inventoryPanels.activeSelf;
            inventoryPanels.SetActive(!isActive);
        }
    }

    public void MusicButton()
    {
        if (musicSlide != null)
        {
            bool isActive = musicSlide.activeSelf;
            musicSlide.SetActive(!isActive);
        }
    }

    public void ClosePanel()
    {
        inventoryPanels.SetActive(false);
    }


}
