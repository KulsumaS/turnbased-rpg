using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio; 
using System;
using Random = UnityEngine.Random;

public class SoundEffectLibary : MonoBehaviour
{
    [SerializeField] private SoundEffectGroup[] soundEffectGroups;
    private Dictionary<string, List<AudioClip>> soundDictionary;

    private void Awake()
    {
        InitializeDictionary();
    }

    private void InitializeDictionary()
    {
       soundDictionary = new Dictionary<string, List<AudioClip>>();
       foreach (SoundEffectGroup soundEffectGroup in soundEffectGroups)
       {
           soundDictionary[soundEffectGroup.name] = soundEffectGroup.audioClips;//name functions as a key, so that the audio clips cna be stored in the dictionary  under that key  
       }
    }

    public AudioClip GetRandomClip(string name)
    {
        //check if it exits in the libary 
        if (soundDictionary.ContainsKey(name))
        {
            List<AudioClip> audioClips = soundDictionary[name];
            if (audioClips.Count > 0)
            {
                return audioClips[Random.Range(0, audioClips.Count)];
            }
        }
        return null;
    }

}
[System.Serializable] //allows us to view dictionary from within the unity inspector
public struct SoundEffectGroup
{
    public string name;
    public List<AudioClip> audioClips;
}