using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatStanItem : MonoBehaviour
{
    PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        GameObject PLC = GameObject.Find("PlayerController");
        playerController = PLC.GetComponent<PlayerController>();
        //Invoke("existenceTime", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void existenceTime()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "player1")
        {
            Debug.Log("stan");
            playerController.Stan();
            Destroy(gameObject);
        }
    }
}
