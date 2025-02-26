using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetGenerator : MonoBehaviour
{
    [SerializeField] GameObject Net;

    [SerializeField] float CoolTime = 0f;
    [SerializeField] bool Use = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        CoolTime = Mathf.Clamp(CoolTime, 0, 12);

        CoolTime += Time.deltaTime;
        if(CoolTime >= 10)
        {
            Use = true;
        }
        else
        {
            Use = false;
        }
    }

    public void UseCannon()
    {
        if (Use == true)
        {
            //アイテムの使用
            Instantiate(Net, this.transform.position, Quaternion.Euler(0, 0, gameObject.transform.localEulerAngles.z));
            CoolTime = 0;
            Debug.Log("use");
        }
    }
}
