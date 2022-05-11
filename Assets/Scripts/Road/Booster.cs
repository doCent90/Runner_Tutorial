using UnityEngine;

public class Booster : MonoBehaviour
{
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private ParticleSystem _particleSystem;

    public void Destroy()
    {
        _particleSystem.Play();
        _meshRenderer.enabled = false;
    }
}
