using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    [SerializeField] private Button _muteButton;
    [SerializeField] private Button _unmuteButton;

    [SerializeField] private AudioMixer _audioMixer;

    void Start()
    {
        _unmuteButton.onClick.AddListener(() =>
        {
            _audioMixer.SetFloat("Volume", -80);
            _muteButton.gameObject.SetActive(true);
            _unmuteButton.gameObject.SetActive(false);
        });

        _muteButton.onClick.AddListener(() =>
        {
            _audioMixer.SetFloat("Volume", 0);
            _unmuteButton.gameObject.SetActive(true);
            _muteButton.gameObject.SetActive(false);
        });

        _muteButton.gameObject.SetActive(false);
    }

    void Update()
    {
        
    }
}
