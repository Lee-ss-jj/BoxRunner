using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    void SoundPlay()
    {
        GetComponent<AudioSource>().Play();
    }
}
