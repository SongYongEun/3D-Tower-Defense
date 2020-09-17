using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;

        AddEffectAudio(gameObject.GetComponent<AudioSource>());
    }

    private AudioSource backgroundAudio;
    private List<AudioSource> effectAudio = new List<AudioSource>();

    public Slider backgroundSlider;
    public Slider effectSlider;

    private float saveBackgroundVol = 1f;
    private float saveEffectVol = 1f;

    private void Start()
    {
        backgroundAudio = Camera.main.gameObject.GetComponent<AudioSource>();
        saveBackgroundVol = PlayerPrefs.GetFloat("backVol", 1f);
        saveEffectVol = PlayerPrefs.GetFloat("effectVol", 1f);

        backgroundSlider.value = saveBackgroundVol;
        backgroundAudio.volume = backgroundSlider.value;

        effectSlider.value = saveEffectVol;
        for(int i =0; i < effectAudio.Count; ++i)
        {
            effectAudio[i].volume = effectSlider.value;
        }
    }

    public void Update()
    {
        EffectSoundControl();
        BackgorundSoundControl();
    }

    public void AddEffectAudio(AudioSource _effectAudio)
    {
        effectAudio.Add(_effectAudio);
    }
    
    public void EraseAudio(AudioSource _effectAudio)
    {
        effectAudio.Remove(_effectAudio);
    }

    public void EffectSoundControl()
    {
        for(int i=0; i < effectAudio.Count; ++i)
        {
            effectAudio[i].volume = effectSlider.value;

            saveEffectVol = effectSlider.value;
            PlayerPrefs.SetFloat("effectVol", saveEffectVol);
        }
    }

    public void BackgorundSoundControl()
    {
        backgroundAudio.volume = backgroundSlider.value;

        saveBackgroundVol = backgroundSlider.value;
        PlayerPrefs.SetFloat("backVol", saveBackgroundVol);
    }
}
