using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private UI _uI;
    [SerializeField] private Player _player;
    [SerializeField] private Animator _animator;

    private const string Run = "Run";
    private const string Jump = "Jump";
    private const string Speed = "Speed";
    private const string Selfie = "Selfie";
    private const string StanBack = "StanBack";
    private const float Multiply = 1.1f;

    private void OnEnable()
    {
        _uI.StartClicked += OnStarted;
        _player.JumpTriggered += PlayJump;
        _player.TrapTriggered += PlayStanBack;
        _player.FinishTriggered += PlaySelfie;
        _player.BoosterCollected += IncreaseSpeed;
    }

    private void OnDisable()
    {
        _uI.StartClicked -= OnStarted;        
        _player.JumpTriggered -= PlayJump;
        _player.TrapTriggered -= PlayStanBack;
        _player.FinishTriggered -= PlaySelfie;
        _player.BoosterCollected -= IncreaseSpeed;
    }

    private void OnStarted()
    {
        _animator.SetBool(Run, true);
    }

    private void PlayJump()
    {
        _animator.SetTrigger(Jump);
    }

    private void PlaySelfie()
    {
        _animator.SetTrigger(Selfie);
    }

    private void PlayStanBack()
    {
        _animator.SetTrigger(StanBack);
    }

    private void IncreaseSpeed()
    {
        float speed = _animator.GetFloat(Speed);
        speed *= Multiply;

        _animator.SetFloat(Speed, speed);
    }
}
