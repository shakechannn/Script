using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstructionItem : MonoBehaviour
{
    UIController uicontroller;
    ItemGenerator generator;
    SEObject seObject;
    [SerializeField] ParticleSystem particle;

    // Start is called before the first frame update
    void Start()
    {
        GameObject UIObj = GameObject.Find("UIController");
        GameObject GN = GameObject.Find("Generator");
        uicontroller = UIObj.GetComponent<UIController>();
        generator = GN.GetComponent<ItemGenerator>();

        GameObject SEObj = GameObject.Find("SE");
        seObject = SEObj.GetComponent<SEObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player2")
        {
            //Debug.Log("ObstructionGet");
            uicontroller.StanItem += 1;
            generator.ObstructionItemSpawn();
            Instantiate(particle, transform.position, Quaternion.identity);
            seObject.GetSE();
            Destroy(gameObject);
        }
        
    }
}
