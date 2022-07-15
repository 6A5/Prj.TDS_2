using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{
    private static SoundEffectManager _instance;

    public static SoundEffectManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private AudioSource se_truck_1;

    private void Start()
    {
        _instance = this;

        se_truck_1 = gameObject.AddComponent<AudioSource>();
    }

    public void PlaySound(AudioClip clip, float volume = 0.5f)
    {
        se_truck_1.PlayOneShot(clip, volume);
    }
}
