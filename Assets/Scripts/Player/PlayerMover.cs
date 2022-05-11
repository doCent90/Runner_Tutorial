using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private InputHandler _inputHandler;

    private const float Treshold = 1.5f;

    private void OnEnable()
    {
        _player.TrapTriggered += Disable;
        _player.FinishTriggered -= Disable;        
    }

    private void OnDisable()
    {
        _player.TrapTriggered -= Disable;        
        _player.FinishTriggered -= Disable;        
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float offset = _inputHandler.CurrentOffset;
        float x = Mathf.Clamp(offset, -Treshold, Treshold);

        Vector3 targetPosition = new Vector3(x, transform.position.y, transform.position.z);
        transform.position = targetPosition;
    }

    private void Disable()
    {
        enabled = false;
    }
}
