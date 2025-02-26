using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Item : MonoBehaviour
{
    UIController uiController;
    [SerializeField] ParticleSystem GetParticle;
    [SerializeField] GameObject GetAnim;

    SEObject seObject;

    // Start is called before the first frame update
    void Start()
    {
        GameObject UIObj = GameObject.Find("UIController");
        uiController = UIObj.GetComponent<UIController>();

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
            //Debug.Log("Get");

            UIController.CheeseCount++;

            Instantiate(GetParticle, this.transform.position, Quaternion.identity);
            Instantiate(GetAnim,this.transform.position, Quaternion.identity);

            seObject.GetSE();

            Destroy(gameObject);
        }
    }
}
