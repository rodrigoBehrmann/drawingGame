using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EpisodeHandle : MonoBehaviour
{
    [Header("Episode Data")]
    [SerializeField] private Episode _episode;    

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
    [SerializeField] private GameObject _option1_Episode;
    [SerializeField] private GameObject _option2_Episode;


    void Start()
    {
        if (_episode.HaveOptions)
        {
            _option1Button.gameObject.SetActive(true);
            
            _option2Button.gameObject.SetActive(true);
            
            _option1ButtonText.text = _episode.Option1;

            _option2ButtonText.text = _episode.Option2;

            _forwardButton.gameObject.SetActive(false);

            _dialogueText.gameObject.SetActive(false);
        }
        else
        {
            _option1Button.gameObject.SetActive(false);
            _option2Button.gameObject.SetActive(false);
            
            if(_episode.IsFinalEpisode)
            {
                _forwardButton.onClick.AddListener(() =>
                {
                    _nextEpisode.SetActive(true);
                    gameObject.SetActive(false);
                });
            }else
            {
                _forwardButton.onClick.AddListener(() =>
                {
                    _nextEpisode.SetActive(true);
                    gameObject.SetActive(false);
                });
            }

            _dialogueText.text = _episode.Dialogue;
        }

        _option1Button.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
            _option1_Episode.SetActive(true);
            _option2_Episode.SetActive(false);
        });

        _option2Button.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
            _option1_Episode.SetActive(false);
            _option2_Episode.SetActive(true);
        });

        if(_episode.EpisodeNumber != 1)
        {
            gameObject.SetActive(false);
        }

        

        GetComponent<Image>().sprite = _episode.Image;
    }

    public void SetEpisode(Episode episode)
    {
        _episode = episode;
    }

}
