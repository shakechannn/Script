using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject[] PlayerArray;
    [SerializeField] GameObject StanItem;
    [SerializeField] ParticleSystem speedUpPar;
    [SerializeField] Animator[] AnimatorArray;
    [SerializeField] SEObject seObject;

    [SerializeField] Enemy enemy;
    [SerializeField] Enemy2 enemy2;

    [SerializeField] bool IsUsed = true;
    [SerializeField] float StanCoolTime = 0f;
    [SerializeField] int xKey;
    [SerializeField] int yKey;

    public bool IsMove = true;
    public bool GameStart = false;
    public float Speed = 3.2f;
    public float Speed2 = 1.45f;

    UIController uicontroller;

    // Start is called before the first frame update
    void Start()
    {
        GameObject UIObj = GameObject.Find("UIController");
        uicontroller = UIObj.GetComponent<UIController>();
    }

    // Update is called once per frame
    void Update()
    {

        if(GameStart)
        {
            Player1Controller();
            Player2Controller();

            StanCoolTime = Mathf.Clamp(StanCoolTime, 0, 3.5f);
            StanCoolTime += Time.deltaTime;
        }    
    }
    void Player1Controller()
    {
        if (Input.GetKey(KeyCode.W))
        {
            PlayerArray[0].transform.Translate(0, Time.deltaTime * Speed2 * 2.5f, 0,Space.World);
            yKey = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            PlayerArray[0].transform.Translate(0, Time.deltaTime * Speed2 * -1 * 2.5f, 0, Space.World);
            yKey = -1;
        }
        else
        {
            yKey = 0;
        }
        if (Input.GetKey(KeyCode.D))
        {
            PlayerArray[0].transform.Translate(Time.deltaTime * Speed2 * 2.5f, 0, 0, Space.World);
            xKey = 1;
        }
        else if(Input.GetKey(KeyCode.A))
        {
            PlayerArray[0].transform.Translate(Time.deltaTime * Speed2 *-1 * 2.5f, 0, 0, Space.World);
            xKey = -1;
        }
        else
        {
            xKey = 0;
        }
        if((xKey != 0 || yKey != 0) && IsMove)
        {
            var vec = new Vector3(xKey,yKey,0);
            var q = Quaternion.FromToRotation(Vector3.up,vec);
            PlayerArray[0].transform.rotation = Quaternion.Slerp(PlayerArray[0].transform.rotation, q, Time.deltaTime * 500f);

            AnimatorArray[0].SetBool("Walk", true);
        }
        else
        {
            AnimatorArray[0].SetBool("Walk", false);
        }

    }

    void Player2Controller()
    {
        float yButton = Input.GetAxis("Vertical2");
        float xButton = Input.GetAxis("Horizontal2");

        if ((yButton != 0 || xButton != 0) && IsMove)
        {
            var vec = new Vector3(xButton, yButton, 0);
            var q = Quaternion.FromToRotation(Vector3.up, vec);
            PlayerArray[1].transform.rotation = Quaternion.Slerp(PlayerArray[1].transform.rotation, q, Time.deltaTime * 500f);

            AnimatorArray[1].SetBool("Walk", true);
        }
        else
        {
            AnimatorArray[1].SetBool("Walk", false);
        }

        PlayerArray[1].transform.Translate(xButton * Speed * Time.deltaTime, yButton * Speed * Time.deltaTime, 0, Space.World);
            
        if (Input.GetButtonDown("BButton") && uicontroller.StanItem > 0 && IsUsed == true && StanCoolTime > 3.0f)
        {
            System.Diagnostics.Debug.WriteLine("Use");
            //Ç±Ç±Ç…èàóùÇí«â¡
            Instantiate(StanItem, PlayerArray[1].transform.position,Quaternion.identity);
            uicontroller.StanItem--;

            StanCoolTime = 0;

            seObject.UseSmoke();
        }
    }

    //-------------------------------//

    public void SpeedUp()
    {
        Speed = Speed * 1.25f;
        AnimatorArray[1].SetFloat("Speed", 1.5f);

        var Parent = GameObject.Find("player2");
        Instantiate(speedUpPar,Parent.transform.position,Quaternion.Euler(90,0,-180),Parent.transform);

        seObject.SpeedUP();

        Invoke("SpeedCoolTime", 3f);
    }
    public void SpeedStop()
    {
        Speed = 0;
        enemy.chaseSpeed = 0;
        enemy2.stop = 0;

        IsUsed = false;
        //IsMove= false;
        Invoke("SpeedCoolTime", 3f);
    }
    public void Speed2Stop()
    {
        Speed2 = 0;
        IsMove= false;
        Invoke("Speed2CoolTime", 3f);
    }
    void Speed2CoolTime()
    {
        Speed2 = 1.45f;
        IsMove = true;
    }

    void SpeedCoolTime()
    {
        IsUsed = true;
        IsMove = true;

        Speed = 3.2f;
        enemy.chaseSpeed = 2;
        enemy2.stop = 1;

        AnimatorArray[1].SetFloat("Speed", 1f);
    }

    public void Stan()
    {
        Speed2 *= -1f;
        PlayerArray[0].transform.localScale = new Vector3(-0.5f, -0.5f, 1f);
        Invoke("cooltime",3f);
    }
    void cooltime()
    {
        Speed2 *= -1f;
        PlayerArray[0].transform.localScale = new Vector3(0.5f,0.5f, 1f);
    }

}
