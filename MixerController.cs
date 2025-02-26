using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MixerController : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;

    [SerializeField] Slider MasterSlider;
    [SerializeField] Slider BGMSlider;
    [SerializeField] Slider SESlider;

    [SerializeField] AudioClip[] clip;
    [SerializeField] AudioSource source;

    float Mastervolume;
    float BGMvolume;
    float SEvolume;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Mastervolume = MasterSlider.value;
        audioMixer.SetFloat("Master", Mastervolume);

        BGMvolume = BGMSlider.value;
        audioMixer.SetFloat("BGM", BGMvolume);

        SEvolume = SESlider.value;
        audioMixer.SetFloat("SE", SEvolume);
    }

    public void OnSEClick()
    {
        int num = Random.Range(0, clip.Length);
        source.PlayOneShot(clip[num]);
    }
}
