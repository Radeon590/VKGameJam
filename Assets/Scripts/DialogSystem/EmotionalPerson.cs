using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmotionalPerson : MonoBehaviour
{
    [SerializeField] protected GameObject GladEmoji;
    [SerializeField] protected GameObject UpsetEmoji;
    protected GameObject _currentEmojiObject;

    public void ShowEmoje(EmojiTypes emojiType)
    {
        _currentEmojiObject?.SetActive(false);
        switch (emojiType)
        {
            case EmojiTypes.Glad:
                _currentEmojiObject = GladEmoji;
                break;
            case EmojiTypes.Upset:
                _currentEmojiObject = UpsetEmoji;
                break;
        }
        _currentEmojiObject.SetActive(true);
        StartCoroutine(DeactivateEmoji());
    }

    protected IEnumerator DeactivateEmoji()
    {
        yield return new WaitForSeconds(3);
        _currentEmojiObject.SetActive(false);
    }
}

public enum EmojiTypes
{
    Glad,
    Upset
}