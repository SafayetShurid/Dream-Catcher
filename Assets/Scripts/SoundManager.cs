using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{


    public AudioSource moveAudioSource;   
    public AudioSource otherAudioSource;
    public AudioSource battleOpponentAudioSource;

    public AudioClip cutClip;
    public AudioClip slashClip;
    public AudioClip rageClip;
    public AudioClip scratchClip;

    public AudioClip moveChangeClip;
    public AudioClip buttonPressedClip;
    public AudioClip notEffectiveClip;
    public AudioClip superEffectiveClip;

    public static SoundManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void PlayMovesSource(AudioClip audioClip)
    {
        moveAudioSource.PlayOneShot(audioClip);
    }

    public void PlayOtherSource(AudioClip audioClip)
    {
        otherAudioSource.PlayOneShot(audioClip);        
    }

    public void PlayOtherSource(AudioClip audioClip,float delay)
    {
        otherAudioSource.clip = audioClip;
        otherAudioSource.PlayDelayed(delay);
       
    }


}
