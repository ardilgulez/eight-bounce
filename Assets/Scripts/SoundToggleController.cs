using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundToggleController : MonoBehaviour
{

    public SoundType soundType;
    private Toggle toggle;
    
    public delegate void SoundToggle(SoundType type, bool enabled);
    public static event SoundToggle Toggle;

    private void Awake()
    {
        toggle = GetComponent<Toggle>();
    }

    private void OnEnable()
    {
        toggle.isOn = GameManager.instance.GetSoundEnabled(soundType);
    }

    public void OnToggle()
    {
        Toggle(soundType, toggle.isOn);
    }

}
