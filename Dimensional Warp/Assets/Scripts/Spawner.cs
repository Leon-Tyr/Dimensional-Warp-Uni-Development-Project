using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] Items;

    public GameObject Player;

    private float SpawnTimer;
    private float startTimer = 5.0f;
    public float decreaseTime;
    public float minTime = 0.65f;

    private int SpawnCount = 0;
    public int MaxSpawn = 10;
    private bool CanSpawn = true;

    // Start is called before the first frame update
    void Start()
    {
        SpawnTimer = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (SpawnCount >= MaxSpawn)
        {
            CanSpawn = false;
        }




        float roll = Random.Range(-120.0f, 120.0f);
        float roll2 = Random.Range(-120.0f, 120.0f);

        if (SpawnTimer <= 0 && CanSpawn)
        {
            transform.position = new Vector3(Player.transform.position.x + roll, 5, Player.transform.position.z + roll2);
            int rand = Random.Range(0, Items.Length);
            Instantiate(Items[rand], transform.position, Quaternion.identity);
            SpawnTimer = startTimer;
            SpawnCount++;
            if (startTimer > minTime)
            {
                startTimer -= decreaseTime;
            }

        }
        else
        {
            SpawnTimer -= Time.deltaTime;

        }

    }
}
