using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject _scorePrefabs;
    [SerializeField] private Transform _scorePanel;
    [SerializeField] private GameObject _tutorialPanel;
    [SerializeField] private GameObject _gameOverPanel;

    [SerializeField] private Sprite[] _spritesOfNumber;
    private GameController _gameController;

    private void Start()
    {
        _gameController = FindObjectOfType<GameController>();

        _gameController.UpdateScore += UpdateScore;
        _gameController.OnUpdateGameState += state =>
        {
            ShowPanelIf(_gameOverPanel, state == GameController.GameState.over);
            ShowPanelIf(_tutorialPanel, state == GameController.GameState.preparing);
        };
    }

    private void ShowPanelIf(GameObject panel, bool canShow)
    {
        panel.SetActive(canShow);
    }

    private void UpdateScore(int score)
    {
        string scoreStr = score.ToString();

        while(_scorePanel.childCount < scoreStr.Length)
        {
            Instantiate(_scorePrefabs, _scorePanel);
        }

        for (int i = 0; i < _scorePanel.childCount; i++)
        {
            int scoreNumber = scoreStr[i] - '0';
            _scorePanel.GetChild(i).GetComponent<Image>().sprite = _spritesOfNumber[scoreNumber];
        }
    }
}
