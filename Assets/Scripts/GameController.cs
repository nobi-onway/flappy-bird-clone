using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public enum GameState
    {
        preparing,
        running,
        over,
    }

    private int _currentScore;

    [SerializeField] private BirdController _birdControlller;
    [SerializeField] private PineSpawnerController _pineSpawnerController;

    private GameState _state;

    public event Action<int> UpdateScore;
    public event Action<GameState> OnUpdateGameState;

    void Start()
    {
        OnUpdateGameState += UpdateGameState;
        ResetGameState();
        SubscribeBirdEvent();
    }


    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (_state == GameState.running) return;

            if(_state == GameState.preparing) StartGame();

            if (_state == GameState.over) ResetGameState();
        }
    }

    private void ResetGameState()
    {
        _currentScore = 0;
        UpdateScore?.Invoke(_currentScore);
        OnUpdateGameState?.Invoke(GameState.preparing);
        _birdControlller.ResetState();
        _pineSpawnerController.ResetPine();
    }

    private void StartGame()
    {
        OnUpdateGameState?.Invoke(GameState.running);
        _pineSpawnerController.EnableSpawner();
        _birdControlller.Init();
    }

    private void GameOver()
    {
        OnUpdateGameState?.Invoke(GameState.over);
        _pineSpawnerController.DisableSpawner();
    }

    private void IncreaseScore()
    {
        _currentScore += 1;
        UpdateScore?.Invoke(_currentScore);
    }

    private void SubscribeBirdEvent()
    {
        _birdControlller.OnScore += IncreaseScore;
        _birdControlller.OnDead += GameOver;
    }

    private void UpdateGameState(GameState state)
    {
        _state = state;
    }
}
