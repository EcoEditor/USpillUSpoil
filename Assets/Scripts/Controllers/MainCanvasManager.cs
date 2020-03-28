using UnityEngine;
using UnityEngine.Assertions;

public class MainCanvasManager : Singleton<MainCanvasManager>
{
    [SerializeField] private GameObject _gameButtonsPanel;
    [SerializeField] private GameObject _pickUpText;
    [SerializeField] private GameObject _welcomeText;
    [SerializeField] private GameObject _pausePanel;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    void Start()
    {
        Assert.IsNotNull(_gameButtonsPanel);
        Assert.IsNotNull(_pickUpText);
        Assert.IsNotNull(_welcomeText);
        Assert.IsNotNull(_pausePanel);

        _gameButtonsPanel.SetActive(false);
        _pausePanel.SetActive(false);
        _pickUpText.SetActive(true);
        _welcomeText.SetActive(true);
    }

    public void DisplayPickUpCup()
    {

    }

    public void PauseGame()
    {
        if (!_pausePanel.activeInHierarchy)
        {
            Time.timeScale = 0;
            _pausePanel.SetActive(true);
        }

        else
        {
            Time.timeScale = 1;
            _pausePanel.SetActive(false);
        }

    }
}
