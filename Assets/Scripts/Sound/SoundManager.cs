using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{

    [Header("Audio Source")]
    public AudioSource musicSource;
    public AudioSource background;
    public AudioSource walkingSound;
    public AudioSource dieSound;
    public AudioSource jumpSound;

    public AudioSource takeKeySound;
    public AudioSource clickSound;
    public AudioSource enemyFireSound;

    public AudioSource winSound;
    public AudioSource loseSound;


    private void Start()
    {
        musicSource.loop = true;
        musicSource.Play();
        if(GamePrefs.GetMusic() == 1)
        {
            TurnOnMusic();
        }
        else
        {
            TurnOffMusic();
        }
        if (GamePrefs.GetSound() == 1)
        {
            TurnOnSFX();
        }
        else
        {
            TurnOffSFX();
        }
    }

    public void TurnOnMusic()
    {
        musicSource.mute = false;
        GamePrefs.SetMusic(1);
    }

    public void TurnOffMusic()
    {
        musicSource.mute = true;
        GamePrefs.SetMusic(0);
    }

    public void TurnOnSFX()
    {
        // SFXSource.mute = false;
        GamePrefs.SetSound(1);
    }

    public void TurnOffSFX()
    {
        // SFXSource.mute = true;
        GamePrefs.SetSound(0);
    }
}
