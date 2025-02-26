using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    PlayerController controller;
    ItemGenerator itemGenerator;
    SEObject seObject;
    [SerializeField] ParticleSystem particle;

    // Start is called before the first frame update
    void Start()
    {
        GameObject playerObj = GameObject.Find("PlayerController");
        GameObject gn = GameObject.Find("Generator");
        controller = playerObj.GetComponent<PlayerController>();
        itemGenerator = gn.GetComponent<ItemGenerator>();

        GameObject SEObj = GameObject.Find("SE");
        seObject = SEObj.GetComponent<SEObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "player2")
        {
            controller.SpeedUp();
            itemGenerator.SpawnSpItem();
            Instantiate(particle, transform.position, Quaternion.identity);
            seObject.SpeedUP();
            Destroy(gameObject);
        }
    }
}
