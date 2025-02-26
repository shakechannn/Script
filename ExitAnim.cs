using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitAnim : MonoBehaviour
{
    [SerializeField] GameObject FadeIn;
    [SerializeField] SEObject seObject;
    public bool IsStart = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FinishAnim()
    {
        Destroy(gameObject);
    }

    void StartKeyEvent()
    {
        IsStart= true;
    }

    void StartFadeIn()
    {
        var parent = GameObject.Find("Canvas");
        Instantiate(FadeIn, parent.transform.position, Quaternion.identity, parent.transform);
    }

    void PlayStartSE()
    {
        seObject.PlayStartSE();
    }
    void StartSEeve()
    {
        seObject.StartSE();
    }
    void BGMPlay()
    {
        seObject.BGM();
    }
}
