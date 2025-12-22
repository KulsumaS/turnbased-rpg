using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundEffectLibary : MonoBehaviour
{
    [UnityEngine.SerializeFeild] private SoundEffectGroup[] soundEffectGroups;
    private Dictionary<string, List<AudioClip>> soundDictionary; // creates a dictionary for the soundeffect 

    private void Awake()
    {
        InitializeDictionary();
    }

    private void InitializeDictionary()
    {
        soundDictionary = new Dictionary<string, List<AudioCip>>();
        foreach (SoundEffectGroup soundEffectGroup in soundEffectGroups)
        {
            soundDictionary[soundEffectGroup.name] = soundEffectGroup.audioClips;
        }
    }

    public AudioClip GetRandomClip(string name)
    {
        if (soundDictionary.ContainsKey(name))//checks if the key is in the list 
        {
            List<AudioClip> audioClips = soundDictionary[name];
            if (audioClips.Count > 0)
                return audioClips[Random.Range(0, audioClips.Count)];
        }
        return null;
    }
}
[System.Serializable]
public struct SoundEffectGroup// allows us to access the dictiionary from within unitys inspector
{
    public string name;//key for the dictionary 
    public List<AudioClip> audioClips;
}   