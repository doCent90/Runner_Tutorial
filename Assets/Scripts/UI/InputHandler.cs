using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private UI _uI;
    [SerializeField] private PlayerMover _playerMover;
    [Header("Settings")]
    [Range(0f, 0.02f)]
    [SerializeField] private float _sens;

    private Vector3 _mousePosition;
    private float _saveOffset;
    private bool _isReady = false;

    public float CurrentOffset { get; private set; }

    private void OnEnable()
    {
        _uI.StartClicked += Enable;
    }

    private void OnDisable()
    {
        _uI.StartClicked -= Enable;        
    }

    private void Enable()
    {
        _isReady = true;
    }

    private void Update()
    {
        if (_isReady == false)
            return;

        SetOffsetValue();
    }

    private void SetOffsetValue()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _saveOffset = _playerMover.transform.position.x;
            _mousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 offset = Input.mousePosition - _mousePosition;
            CurrentOffset = _saveOffset + offset.x * _sens;
        }
    }
}
