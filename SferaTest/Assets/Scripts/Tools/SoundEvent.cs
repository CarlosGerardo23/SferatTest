using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class SoundEvent : MonoBehaviour
{
    [SerializeField] SoundCollection collection;
    AudioSource audiosSource;
    private void Awake()
    {
        audiosSource = GetComponent<AudioSource>();
    }
    public void PlayClip(int index)
    {
        audiosSource.clip = collection.clips[index];
        audiosSource.loop = false;
        audiosSource.Play();
    }
}
