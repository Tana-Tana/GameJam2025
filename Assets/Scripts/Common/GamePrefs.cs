using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GamePrefs
{
    // sound and music
    public const string SOUND_ON_KEY = "sound";
    public const string MUSIC_ON_KEY = "music";

    public static int GetSound()
    {
        return PlayerPrefs.GetInt(SOUND_ON_KEY, GameConfig.SOUND_ON_START);
    }

    public static void SetSound(int state)
    {
        PlayerPrefs.SetInt(SOUND_ON_KEY, state);
    }

    public static int GetMusic()
    {
        return PlayerPrefs.GetInt(MUSIC_ON_KEY, GameConfig.MUSIC_ON_START);
    }

    public static void SetMusic(int state)
    {
        PlayerPrefs.SetInt(MUSIC_ON_KEY, state);
    }
}
