using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance { get { return instance;}}
    // Start is called before the first frame update

    public AudioSource soundEffect;
    public AudioSource soundMusic;

    public SoundType[] Sounds;

    private void Awake() {
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }

        soundEffect.PlayOneShot(getSoundClip(global::Sounds.Music));
    }

    public void Play(Sounds sound){
        // Get Sound
        AudioClip clip = getSoundClip(sound);

        // Play, Null Check
        if(clip != null){
            soundEffect.PlayOneShot(clip);
        } else {
            Debug.LogError("Clip not found far sound type: " + sound);
        }
    }

    AudioClip getSoundClip(Sounds sound){
        SoundType item = Array.Find(Sounds, value => value.soundType == sound);
        return item?.soundClip;
    }
}

[Serializable]
    public class SoundType {
        public Sounds soundType;
        public AudioClip soundClip;
    }

    public enum Sounds {
        Music,
        ButtonClick,
        PlayerMove,
        PlayerFootstep,
        PlayerDeath,
        ChomperDeath,
        GunnerFootstep,
        SwitchActivated,
        EnemyDeath
    }

