using System.Collections;
using UnityEngine;

public class BallAnim : MonoBehaviour
{
	[SerializeField] private GameObject bounceParticles = null;
	
	private Rigidbody2D _rigidbody = null;
	private Vector3 _originalSize = Vector3.one;
	private float _area = 1f;
	private Color _originalColor = Color.white;
	
	private void Start()
	{
		_rigidbody = GetComponent<Rigidbody2D>();
		_originalSize = transform.localScale;
		_area = _originalSize.x * _originalSize.y;
		_originalColor = transform.GetChild(0).GetComponent<SpriteRenderer>().color;
	}

	private void FixedUpdate()
	{
		float speed = _rigidbody.velocity.magnitude;
		float stretchY = _originalSize.y + speed * 0.01f;
		float stretchX = _area / stretchY;

		transform.localScale = new Vector3(stretchX, stretchY, _originalSize.z);
	}

	private IEnumerator PlayBallAnim()
	{ 
		if (!LeanTween.isTweening())
		{
			LeanTween.scale(gameObject, _originalSize * 2, 0.4f).setEasePunch();
		}

		LeanTween.rotateZ(gameObject, Vector2.SignedAngle(Vector2.up, _rigidbody.velocity), 0.05f);
		LeanTween.color(transform.GetChild(0).gameObject, Color.white, 0.1f);
		yield return new WaitForSeconds(0.1f);
		LeanTween.color(transform.GetChild(0).gameObject, _originalColor, 0.1f);
		yield return new WaitForSeconds(0.3f);
		transform.localScale = _originalSize;
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		StartCoroutine(PlayBallAnim());
		Instantiate(bounceParticles, other.contacts[0].point,
			Quaternion.Euler(0, 0, transform.GetChild(0).localEulerAngles.z + 180f));
		Camera.main.GetComponent<ScreenShake>().Shake(0.2f, 1);
	}
}
