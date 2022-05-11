using UnityEngine;

public class RoadMover : MonoBehaviour
{
    [SerializeField] private UI _uI;
    [SerializeField] private Player _player;
    [Header("Settings")]
    [SerializeField] private float _speed;

    private bool _isReady = false;

    private const float Multiply = 1.1f;

    private void OnEnable()
    {
        _uI.StartClicked += Enable;
        _player.TrapTriggered += Disable;
        _player.FinishTriggered += Disable;
        _player.BoosterCollected += OnBoosterCollected;
    }

    private void OnDisable()
    {
        _uI.StartClicked -= Enable;
        _player.TrapTriggered -= Disable;
        _player.FinishTriggered -= Disable;
        _player.BoosterCollected -= OnBoosterCollected;
    }

    private void Update()
    {
        if(_isReady == false)
            return;

        transform.Translate(Vector3.back * _speed * Time.deltaTime);
    }

    private void Enable()
    {
        _isReady = true;
    }

    private void Disable()
    {
        enabled = false;
    }

    private void OnBoosterCollected()
    {
        _speed *= Multiply;
    }
}
