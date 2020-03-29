using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    public Sprite _pausedGame;
    public Sprite _unPausedGame;
    private Image _myImage;
    private bool _isAnswered;
    //pause will also be called when head mount disaply is off

    private void Start()
    {
        _myImage = GetComponent<Image>();
        _myImage.color = Color.white;
        _myImage.sprite = _unPausedGame;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("RightHand") || other.gameObject.CompareTag("LeftHand"))
        {
            if(!_isAnswered)
            {
                _myImage.color = Color.red;
                Invoke("RecordAnswer", 0.4f);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (_isAnswered) return;
        CancelInvoke();
        _myImage.color = Color.white;
    }

    private void RecordAnswer()
    {
        _isAnswered = true;
        _myImage.sprite = _pausedGame;
        MainCanvasManager.Instance.PauseGame();
    }
}
