using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Episode", menuName = "Episode", order = 0)]
public class Episode : ScriptableObject {
    
    [Header("Episode ID")]
    public int EpisodeNumber;

    [Header("Episode Image")]
    public Sprite Image;

    [Header("Episode Dialogue Text")]
    public string Dialogue;

    [Header("Episode Sound Effect")]
    public AudioClip SoundEffect;
    
    public bool HaveOptions;

    [HideInInspector]
    public string Option1;
    [HideInInspector]
    public string Option2;

    public bool IsFinalEpisode;
}
