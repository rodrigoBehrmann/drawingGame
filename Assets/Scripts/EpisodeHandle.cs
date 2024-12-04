using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EpisodeHandle : MonoBehaviour
{
    [Header("Episode Data")]
    [SerializeField] private Episode _episode; 

    [Header("Episode Sound Effect")]   
    [SerializeField] private AudioSource _audioSource;

    [Header("Forward Button - IF NO OPTIONS")]
    [SerializeField] private TextMeshProUGUI _dialogueText;
    [SerializeField] private Button _forwardButton;
    [SerializeField] private GameObject _nextEpisode;

    [Header("Option Buttons - IF HAVE OPTIONS")]
    [SerializeField] private Button _option1Button;
    [SerializeField] private TextMeshProUGUI _option1ButtonText;
    [SerializeField] private Button _option2Button;
    [SerializeField] private TextMeshProUGUI _option2ButtonText;

    [Header("Option Panels - IF HAVE OPTIONS")]
    [SerializeField] private GameObject _option1Episode;
    [SerializeField] private GameObject _option2Episode;


    // Called at the start of the game to initialize episode behavior
    void Start()
    {
        InitializeEpisodeUI();
    }

    // Initializes the UI elements based on whether there are options or not
    private void InitializeEpisodeUI()
    {
        if (_episode.HaveOptions)
        {
            SetUpOptionButtons();
        }
        else
        {
            SetUpForwardButton();
        }

        SetOptionButtonListeners();

        // Hide the episode initially if it's not the first episode
        if (_episode.EpisodeNumber != 1)
        {
            gameObject.SetActive(false);
        }

        // Set the episode image
        GetComponent<Image>().sprite = _episode.Image;
    }

    // Sets up the UI for episodes with options
    private void SetUpOptionButtons()
    {
        _option1Button.gameObject.SetActive(true);
        _option2Button.gameObject.SetActive(true);
        _option1ButtonText.text = _episode.Option1;
        _option2ButtonText.text = _episode.Option2;
        _forwardButton.gameObject.SetActive(false);
        _dialogueText.gameObject.SetActive(false);
    }

    // Sets up the UI for episodes without options
    private void SetUpForwardButton()
    {
        _option1Button.gameObject.SetActive(false);
        _option2Button.gameObject.SetActive(false);
        _forwardButton.onClick.AddListener(OnForwardButtonClick);
        _dialogueText.text = _episode.Dialogue;
    }

    // Sets listeners for the option buttons
    private void SetOptionButtonListeners()
    {
        _option1Button.onClick.AddListener(() =>
        {
            SwitchToOption1Episode();
        });

        _option2Button.onClick.AddListener(() =>
        {
            SwitchToOption2Episode();
        });
    }

    // Handles forward button click (for episodes without options)
    private void OnForwardButtonClick()
    {
        _nextEpisode.SetActive(true);
        _audioSource.Stop();
        gameObject.SetActive(false);
    }

    // Switches to the episode for option 1
    private void SwitchToOption1Episode()
    {
        gameObject.SetActive(false);
        _option1Episode.SetActive(true);
        _option2Episode.SetActive(false);
    }

    // Switches to the episode for option 2
    private void SwitchToOption2Episode()
    {
        gameObject.SetActive(false);
        _option1Episode.SetActive(false);
        _option2Episode.SetActive(true);
    }

    // Called when the episode is enabled to play the sound effect
    private void OnEnable() 
    {
        if (_episode == null) return;

        _audioSource.clip = _episode.SoundEffect;
        _audioSource.Play();
    }

}
