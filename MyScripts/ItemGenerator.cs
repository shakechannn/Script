using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    [SerializeField] GameObject cheese;
    [SerializeField] GameObject item;
    [SerializeField] GameObject OBItem;

    [SerializeField] public int Count = 0;

     // Start is called before the first frame update
    void Start()
    {
        Invoke("StartC", 7.0f);

        SpawnSpItem();
        ObstructionItemSpawn();
    }

    void StartC()
    {
        StartCoroutine(SpawnItem());
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] cheeseObj = GameObject.FindGameObjectsWithTag("Cheese");
        Count = cheeseObj.Length;
    }

    public void SpawnSpItem()
    {
        float startRandom = Random.Range(8f, 15f);
        Invoke("Spawn", startRandom);
    }
    public void ObstructionItemSpawn()
    {
        float startRandom = Random.Range(8f, 15f);
        Invoke("SpawnOB", startRandom);
    }

    void Spawn()
    {
        float SpawnPosX = Random.Range(-6f, 6f);
        float SpawnPosY = Random.Range(-4.5f, 1.7f);

        Vector2 randomPosition = new Vector2(SpawnPosX, SpawnPosY);
        if (!IsOverlapping(randomPosition))
        {
            Instantiate(item, new Vector3(SpawnPosX, SpawnPosY, 0), Quaternion.identity);
        }
        else
        {
            Spawn();
            Debug.Log("ReJudge");
        }
    }
    void SpawnOB()
    {
        float SpawnPosX = Random.Range(-6f, 6f);
        float SpawnPosY = Random.Range(-4.5f, 1.7f);

        Vector2 randomPosition = new Vector2(SpawnPosX, SpawnPosY);
        if (!IsOverlapping(randomPosition))
        {
            Instantiate(OBItem, new Vector3(SpawnPosX, SpawnPosY, 0), Quaternion.identity);
        }
        else
        {
            SpawnOB();
            Debug.Log("ReJudge");
        }  
    }

    IEnumerator SpawnItem()
    {
        while (true)
        {         
            if (Count < 2)
            {
                float SpawnPosX = Random.Range(-6f, 6f);
                float SpawnPosY = Random.Range(-4.5f, 1.7f);

                Vector2 randomPosition = new Vector2(SpawnPosX,SpawnPosY);
                if (!IsOverlapping(randomPosition))
                {
                    Instantiate(cheese, randomPosition, Quaternion.identity);
                }
            } 

            yield return new WaitForSeconds(2);
        }
    }

    bool IsOverlapping(Vector2 position)
    {
        // 指定位置に障害物があるかを確認
        Collider2D hit = Physics2D.OverlapCircle(position, 0.3f,LayerMask.GetMask("WallLayer"));
        //Debug.Log($"HIT: {hit?.name}");
        return hit != null; 
    }
}
