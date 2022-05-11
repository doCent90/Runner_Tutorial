using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event Action JumpTriggered;
    public event Action TrapTriggered;
    public event Action FinishTriggered;
    public event Action BoosterCollected;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Booster booster))
        {
            booster.Destroy();
            BoosterCollected?.Invoke();
        }

        if(other.TryGetComponent(out JumpTrigger jumpTrigger))
            JumpTriggered?.Invoke();

        if(other.TryGetComponent(out TrapTrigger trapTrigger))
            TrapTriggered?.Invoke();

        if(other.TryGetComponent(out FinishTrigger finishTrigger))
            FinishTriggered?.Invoke();
    }
}
