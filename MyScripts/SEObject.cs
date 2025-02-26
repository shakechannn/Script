using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEObject : MonoBehaviour
{
    [SerializeField] AudioClip[] clips;
    AudioSource source;
    [SerializeField] AudioSource GameBGM;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayStartSE()
    {
        source.PlayOneShot(clips[0]);
    }
    public void StartSE()
    {
        source.PlayOneShot(clips[3]);
    }
    public void BGM()
    {
        GameBGM.Play();
    }
    public void StopBGM()
    {
        GameBGM.Stop();
    }

    public void UseSmoke()
    {
        source.PlayOneShot(clips[1]);
    }
    public void SpeedUP()
    {
        source.PlayOneShot(clips[2]);
    }

    public void GetSE()
    {
        source.PlayOneShot(clips[4]);
    }
    public void CatchSE()
    {
        source.PlayOneShot(clips[5]);
    }
    public void NetShot()
    {
        source.PlayOneShot(clips[6]);
    }
    public void NetHitSE()
    {
        source.PlayOneShot(clips[7]);
    }
    public void FinishSE()
    {
        source.PlayOneShot(clips[8]);
    }
}
