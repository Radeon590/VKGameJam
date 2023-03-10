using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DialogScreen : MonoBehaviour
{
    [SerializeField] private GameObject _okButton;
    [SerializeField] private Image _speakerIcon;

    public Sprite SpeakerIcon
    {
        set
        {
            _speakerIcon.sprite= value;
        }
    }

    [SerializeField] private Text _speakerText;
    public UnityEvent OnEnd;
    //
    private float _timePerOneLetter = 0.1f;
    private string _speach = "";

    public string SpeakerSpeach
    {
        set
        {
            _okButton.SetActive(false);
            _speakerText.text = "";
            _speach = value;
            StartCoroutine(ShowSpeach());
        }
    }

    private IEnumerator ShowSpeach()
    {
        int _currentLetterNumber = 0;
        while (_currentLetterNumber < _speach.Length)
        {
            _speakerText.text += _speach[_currentLetterNumber];
            _currentLetterNumber++;
            yield return new WaitForSeconds(_timePerOneLetter);
        }
        _okButton.SetActive(true);
    }

    public void ShowSpeachNow()
    {
        StopCoroutine(ShowSpeach());
        _speakerText.text = _speach;
        _okButton.SetActive(true);
    }

    public void OkButton()
    {
        OnEnd.Invoke();
    }

    public void SetUpDialogScreen(Sprite speakerIcon, string speach, UnityEvent onEnd)
    {
        SpeakerIcon = speakerIcon;
        SpeakerSpeach = speach;
        OnEnd = onEnd;
    }

    public void SetUpDialogScreen(Sprite speakerIcon, string speach)
    {
        SpeakerIcon = speakerIcon;
        SpeakerSpeach = speach;
    }
}
