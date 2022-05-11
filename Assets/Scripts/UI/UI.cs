using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private Button _start;
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _winText;
    [SerializeField] private TMP_Text _loseText;

    public event Action StartClicked;

    private void OnEnable()
    {
        _player.TrapTriggered += ShowLoseText;
        _player.FinishTriggered += ShowWinText;
        _start.onClick.AddListener(OnStartClicked);
    }

    private void OnDisable()
    {
        _player.TrapTriggered -= ShowLoseText;
        _player.FinishTriggered -= ShowWinText;
        _start.onClick.RemoveListener(OnStartClicked);        
    }

    private void OnStartClicked()
    {
        DisableButton();
        StartClicked?.Invoke();
    }

    private void DisableButton()
    {
        _start.gameObject.SetActive(false);
    }

    private void ShowWinText()
    {
        _winText.enabled = true;
    }

    private void ShowLoseText()
    {
        _loseText.enabled = true;
    }
}
