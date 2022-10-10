using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    //LIST FOR SOUND EFFECT IN GAME
    public AudioSource myAudio;
    public AudioClip[] soundEffects;


    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAudio(int trackNumber)
    {
        myAudio.PlayOneShot(soundEffects[trackNumber]);
    }
    
}
