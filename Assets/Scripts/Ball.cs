using UnityEngine;

public class Ball : MonoBehaviour
{
	[SerializeField, Range(50f, 300f)] private float speed = 100f;

	private Rigidbody2D _rigidbody;

	private void Start()
	{
		_rigidbody = GetComponent<Rigidbody2D>();
		_rigidbody.velocity = Vector2.up * speed;
	}

	private void Update()
	{
		// Limit speed in case we glitch the game somehow
		_rigidbody.velocity = _rigidbody.velocity.normalized * speed;
	}

	/// <summary>Helper for calculating how we hit the ball.</summary>
	private float HitFactor(Vector2 ballPos, Vector2 racketPos, float racketWidth)
	{
		return (ballPos.x - racketPos.x) / racketWidth;
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			// Calculate which way we hit it
			float x = HitFactor(transform.position, other.transform.position, other.collider.bounds.size.x);
			
			// Calculate the direction vector and normalize it
			Vector2 newDir = new Vector2(x, 1).normalized;
			
			// Change the direction of the ball
			_rigidbody.velocity = newDir * speed;
		}
	}
}