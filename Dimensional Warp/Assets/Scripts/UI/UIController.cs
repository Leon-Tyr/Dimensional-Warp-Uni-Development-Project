using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text LevelText;
    [SerializeField] private Text ExpText;
    [SerializeField] private AudioClip menuBtnSound;
    [SerializeField] private AudioClip ItemBtn;
    [SerializeField] private AudioClip healBtn;

    private AudioSource audio;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();

        Assert.IsNotNull(audio);
        Assert.IsNotNull(ExpText);
        Assert.IsNotNull(LevelText);
        Assert.IsNotNull(menuBtnSound);
    }

    private void Update()
    {
        updateLevel();
        updateXP();
    }

    public void updateLevel()
    {
        LevelText.text = GameManager.Instance.CurrentPlayer.Lvl.ToString();
    }

    public void updateXP()
    {
        ExpText.text = "Exp: " + GameManager.Instance.CurrentPlayer.Xp.ToString() + " / " + GameManager.Instance.CurrentPlayer.RequiredXp.ToString();
    }

    public void MenuBtnClicked()
    {
        audio.PlayOneShot(menuBtnSound);
    }

    public void UseItemClicked()
    {
        audio.PlayOneShot(ItemBtn);
    }

    public void HealBtnClicked()
    {
        audio.PlayOneShot(healBtn);
    }
}
