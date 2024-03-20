using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTheme : MonoBehaviour
{
    void Start()
    {
        SoundManager.Instance.Play(Sounds.Music);
    }
}
