using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Racket : MonoBehaviour
{
    [SerializeField, Range(50f, 300f)] private float speed = 150f;
    [SerializeField] private GameObject ball = null;
    
    private Rigidbody2D _rigidbody;
    
    private float _hpos = 0f;
    private bool _spawned = false;
    private Vector3 _initalPos = Vector3.zero;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _initalPos = transform.localPosition;
    }

    private void Update()
    {
        _hpos = Camera.main.ScreenToWorldPoint((Vector2) Input.mousePosition).x;

        if (!_spawned && Input.GetKeyDown(KeyCode.Mouse0))
        {
            _spawned = true;
            Instantiate(ball, transform.position + Vector3.up * 10f, Quaternion.identity);
        }
    }

    private void FixedUpdate()
    {
        transform.localPosition = new Vector3(_hpos, _initalPos.y, _initalPos.z);
    }
}
