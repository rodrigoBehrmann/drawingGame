using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject _menuPanel;

    [Header("Seasons")]
    [SerializeField] private Button _season1Button;
    [SerializeField] private GameObject _season1;

    void Start()
    {
        _season1Button.onClick.AddListener(() =>
        {
            _season1.SetActive(true);
            _menuPanel.SetActive(false);

            _season1.transform.GetChild(0).gameObject.SetActive(true);
        });
    }

}
