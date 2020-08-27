using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class GameManager : Singleton<GameManager>
{
    private Player currentPlayer;
    private Inventory currentInventory;

    public Player CurrentPlayer {
        get
        {
            if (currentPlayer == null)
            {
                currentPlayer = gameObject.AddComponent<Player>();
            }
            return currentPlayer;
        }
    }

    public Inventory CurrentInventory
    {
        get
        {
            if (currentInventory == null)
            {
                currentInventory = gameObject.AddComponent<Inventory>();
            }
            return currentInventory;
        }
    }

}
