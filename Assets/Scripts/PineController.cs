using UnityEngine;

public class PineController : MonoBehaviour
{
    private const float VELOCITY_MAGTITUDE = 3.0f;
    [SerializeField] private Rigidbody2D _rb2D;

    private GameController _gameController;

    private void Start()
    {
        _gameController = FindObjectOfType<GameController>();

        _gameController.OnUpdateGameState += state =>
        {
            if (state == GameController.GameState.over) SetVelocity(0);
        };

        SetVelocity(VELOCITY_MAGTITUDE);
    }

    private void SetVelocity(float magtitude)
    {
        if (_rb2D == null) return;
        _rb2D.velocity = Vector2.left * magtitude;
    }
}
