using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkController : MonoBehaviour
{
    PlayerController playerController;
    SEObject seObject;
    float NetSpeed = 20f;
    // Start is called before the first frame update
    void Start()
    {
        GameObject PLC = GameObject.Find("PlayerController");
        playerController = PLC.GetComponent<PlayerController>();

        GameObject SEObj = GameObject.Find("SE");
        seObject = SEObj.GetComponent<SEObject>();

        seObject.NetShot();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.localEulerAngles.z == 0 || transform.localEulerAngles.z == 180)
        {
            NetSpeed = 13.3f;
        }
        else
        {
            NetSpeed = 20f;
        }
        transform.Translate(0, NetSpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "player2")
        {
            playerController.SpeedStop();
            seObject.NetHitSE();
            Destroy(gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "NetWall")
        {
            Destroy(gameObject);
        }
    }
}
