using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource BGSource;
    public AudioClip[] RandomBG;
    public AudioSource[]SESource ;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {

    }
    public void PlayBG()
    {
        int RandomIndex = Random.Range(0, RandomBG.Length);
        BGSource.clip = RandomBG[RandomIndex];
        BGSource.Play();
    }
    public void PlaySound(AudioClip audioClip)
    {
        foreach (var SE in SESource)
        {
            if (!SE.isPlaying)
            {
                SE.PlayOneShot(audioClip);
                break;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
