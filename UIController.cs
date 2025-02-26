using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] Text CountText;
    [SerializeField] TextMeshProUGUI Timer;
    [SerializeField] TextMeshProUGUI Item;

    [SerializeField] GameObject barrier;
    [SerializeField] GameObject[] LifeImage;
    [SerializeField] GameObject[] NPCs;
    [SerializeField] PolygonCollider2D table;
    [SerializeField] Enemy enemy;
    [SerializeField] Enemy2 enemy2;

    [SerializeField] SEObject seObject;

    public static int CheeseCount = 0;
    public int StanItem = 0;
    public float time = 90.0f;
    public MouseLife mouseLife;
    public float StartTime;
    public bool FinishAnim = false;

    public PlayerController playerController;
    public ExitAnim exitanim;
    public Animator StartTrigger;

    bool[] NPC_Spawn = { false, false };
    bool Playone = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        CheeseCount = Mathf.Clamp(CheeseCount, 0, 100);

        //CheeseÇÃêîÇï\é¶
        CountText.text = "Å~"+CheeseCount.ToString();

        //êßå¿éûä‘ÇÃåvéZ   
        if(FinishAnim)
        {
            if(StartTrigger!= null)
            {
                StartTrigger.SetBool("PlayStart", true);
            }

            if (exitanim.IsStart)
            {
                playerController.GameStart = true;
                barrier.SetActive(true);
                table.enabled = true;

                if (time <= 0)
                {
                    playerController.Speed = 0;
                    playerController.Speed2 = 0;

                    enemy.chaseSpeed = 0;
                    enemy2.speed = 0;

                    playerController.IsMove = false;
                    seObject.StopBGM();
                    if(!Playone)
                    {
                        seObject.FinishSE();
                        Playone = true;
                    }
                }
                else
                {
                    if(playerController.IsMove)
                    {
                        time -= Time.deltaTime;
                    }            
                }
            }

            if(time <= 60f)
            {       
                if (!NPC_Spawn[0])
                {
                    Debug.Log("NPC-Spawn");
                    NPCs[0].SetActive(true);
                    NPC_Spawn[0] = true;
                }
                if(time <= 30f)
                {
                    if (!NPC_Spawn[1])
                    {
                        Debug.Log("NPC-Spawn2");
                        NPCs[1].SetActive(true);
                        NPC_Spawn[1] = true;
                    }
                }
            }
        }
        
        Timer.text = time.ToString("F2");

        //ñWäQÉAÉCÉeÉÄÇégÇ¶ÇÈÇ©Ç«Ç§Ç©ÇÃîªï 

        StanItem = Mathf.Clamp(StanItem, 0, 3);
         
        if(StanItem != 0)
        {
            Item.text = "Å~"+StanItem.ToString();
        }
        else
        {
            Item.text = "Å~ 0";
        }
        
        switch(mouseLife.lives)
        {
            case 3:
                LifeImage[0].SetActive(true);
                LifeImage[1].SetActive(true);
                LifeImage[2].SetActive(true);
                break;
            case 2:
                LifeImage[0].SetActive(true);
                LifeImage[1].SetActive(true);
                LifeImage[2].SetActive(false);
                break;
            case 1:
                LifeImage[0].SetActive(true);
                LifeImage[1].SetActive(false);
                LifeImage[2].SetActive(false);
                break;
            case 0:
                LifeImage[0].SetActive(false);
                LifeImage[1].SetActive(false);
                LifeImage[2].SetActive(false);
                break;
        }
    }
}
