using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Audio Collection")]
public class SoundCollection : ScriptableObject
{
    public List<AudioClip> clips;
}
