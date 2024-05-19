using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audio;
    private bool isNext = true;

    public AudioClip buttonClick;
    public AudioClip levelCompleted;
    public AudioClip playerJump;
    public AudioClip playerDeath;

    public AudioClip[] backGroundsMusic;


    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(isNext)
        {
            int randomMusicNumber = Random.Range(0, backGroundsMusic.Length);
            AudioClip randomBackAudio = backGroundsMusic[randomMusicNumber];
            StartCoroutine(PlayMusic(randomBackAudio, randomBackAudio.length));
        }
    }

    public void PlayButtonClick() 
    {
        StartCoroutine(PlaySound(buttonClick, buttonClick.length));
    }
    public void PlayLevelCompleted() 
    {
        StartCoroutine(PlaySound(levelCompleted, levelCompleted.length));
    }
    public void PlayPlayerJump() 
    {
        StartCoroutine(PlaySound(playerJump, playerJump.length));
    }
    public void PlayPlayerDeath() 
    {
        StartCoroutine(PlaySound(playerDeath, playerDeath.length));
    }

    IEnumerator PlaySound(AudioClip audioClip, float time)
    {
        AudioSource audio = gameObject.AddComponent<AudioSource>();
        audio.clip = audioClip;
        audio.pitch = Random.Range(0.9f, 1.1f);
        audio.Play();
        yield return new WaitForSeconds(time);
        Destroy(audio);
    }

    IEnumerator PlayMusic(AudioClip audioClip, float time)
    {
        audio.pitch = 1;
        isNext = false;
        audio.clip = audioClip;
        audio.Play();
        yield return new WaitForSeconds(time);
        isNext = true;
    }
}
