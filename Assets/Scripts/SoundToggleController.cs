using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundToggleController : MonoBehaviour
{
    public Toggle SFXToggle;
    public Toggle MusicToggle;

    public delegate void SoundToggle(SoundType type, bool enabled);
    public static event SoundToggle Toggle;

    public void OnSFXToggle()
    {
        Toggle(SoundType.SFX, SFXToggle.isOn);
    }

    public void OnMusicToggle()
    {
        Toggle(SoundType.Music, MusicToggle.isOn);
    }

}