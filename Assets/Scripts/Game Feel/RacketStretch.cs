using UnityEngine;

public class RacketStretch : MonoBehaviour
{
    private Rigidbody2D _rigidbody = null;
    private Vector3 _prevPosition = Vector3.zero;
    private float _speed = 0f;
    private Vector3 _originalScale = Vector3.one;
    private float _area = 0f;
    private float _prevStretchX = 0f;
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _prevPosition = transform.position;
        _originalScale = transform.localScale;
        _area = transform.localScale.x * transform.localScale.y;
    }

    private void FixedUpdate()
    {
        _speed = Mathf.Abs(transform.position.x - _prevPosition.x);
        _prevPosition = transform.position;
        float stretchX = _originalScale.x + _speed;
        if (stretchX - _prevStretchX > 0 && _speed < 5f)
        {
            stretchX = _originalScale.x;
        }
        float stretchY = _area / stretchX;

        transform.localScale = new Vector3(stretchX, stretchY, _originalScale.z);
        _prevStretchX = stretchX;
    }
}
