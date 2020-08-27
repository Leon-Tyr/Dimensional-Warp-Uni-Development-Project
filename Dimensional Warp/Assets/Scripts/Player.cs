using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Player : MonoBehaviour
{
    [SerializeField] private int xp = 0;
    [SerializeField] private int requiredXp = 150;
    [SerializeField] private int levelBase = 150;
    //[SerializeField] private List<item> items = Inventory.instance.items;
    private int lvl = 1;

    public int maxHealth = 100;
    public int currentHealth;
    public HpBar Healthbar;

    private string path;

    // Start is called before the first frame update
    void Start()
    {
        path = Application.persistentDataPath + "/player.dat";
        //File.Delete(path);
        Healthbar = GameObject.FindGameObjectWithTag("HpBar").GetComponent<HpBar>();
        Healthbar.SetMaxHealth(maxHealth);
        currentHealth = maxHealth;
        Load(); 
    }

  
    // Update is called once per frame
    void Update()
    {
        Healthbar = GameObject.FindGameObjectWithTag("HpBar").GetComponent<HpBar>();

    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        Healthbar.SetHealth(currentHealth);
    }

    public void UpdateHeal()
    {
        if (currentHealth <= maxHealth)
        {
            currentHealth += 20;
        }
        else
        { currentHealth = 100; }
        Healthbar.SetHealth(currentHealth);
    }

    public void Death()
    {
        currentHealth = 20;
        Healthbar.SetHealth(currentHealth);
    }

    public void IncreaseMaxHealth(int Unit)
    {
        maxHealth = maxHealth + Unit;
        Healthbar.SetMaxHealth(maxHealth);
    }

    public int Xp
    {
        get { return xp; }
    }

    public int RequiredXp
    {
        get { return requiredXp; }
    }

    public int LevelBase
    {
        get { return levelBase; }
    }

    public int Lvl
    {
        get { return lvl; }
    }

    public void AddXp(int xp)
    {
        this.xp += Mathf.Max(0, xp);
        InitLevelData();
        Save();
    }

    /*public List<item> Items
    {
        get { return items; }
    }*/

    private void InitLevelData()
    {
        lvl = (xp / levelBase) + 1;
        requiredXp = levelBase * lvl;
    }

    private void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(path);
        PlayerData data = new PlayerData(this);
        bf.Serialize(file, data);
        file.Close();
    }

    private void Load()
    {
        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(path, FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();
            
            xp = data.Xp;
            requiredXp = data.RequiredXp;
            levelBase = data.LevelBase;
            lvl = data.Lvl;
            //items = data.Items;
        }
        else
        {
            InitLevelData();
        }
    }

    public void Delete()
    {
        Debug.Log("Save Path deleted");
        File.Delete(path);
    }


}
