using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Timeline;

public class AudioManager : Singleton<AudioManager>
{
    private AudioSource audioSource;
    [SerializeField]private AudioClip[] clips;

    private Dictionary<string, AudioClip> clipDictionary;

    protected override void Awake()
    {
        base.Awake();
        audioSource = GetComponent<AudioSource>();
        clipDictionary= new Dictionary<string, AudioClip>();
    }

    private void Start()
    {
        foreach (AudioClip clip in clips) 
        {
            clipDictionary.Add(clip.name, clip);
        }
        PlayBGM("SpaceGameBgm");
    }

    public void PlayBGM(string name)
    {
        if(clipDictionary.ContainsKey(name))
        {
            audioSource.clip = clipDictionary[name];
            audioSource.Play();
        }
    }


}