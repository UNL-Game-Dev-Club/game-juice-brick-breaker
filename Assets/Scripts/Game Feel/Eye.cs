using System.Collections;
using UnityEngine;

public class Eye : MonoBehaviour
{
	[SerializeField] private GameObject otherEye;
	private float _xOffset = 0f;
	private GameObject _racket;
	private GameObject _ball;

	private void Start()
	{
		_racket = GameObject.FindGameObjectWithTag("Player");
		_xOffset = transform.position.x;
		if (otherEye != null)
			StartCoroutine(Blink());
	}

	private void Update()
	{
		transform.position = 
			new Vector3(_racket.transform.position.x + _xOffset, _racket.transform.position.y, 0);
		
		if (_ball == null)
		{
			_ball = GameObject.FindGameObjectWithTag("Ball");
		}
		else
		{
			Vector2 eyeLook = (_ball.transform.position - transform.position).normalized;
			transform.eulerAngles = new Vector3(0, 0, Vector2.SignedAngle(Vector2.up, eyeLook));
		}
	}

	private IEnumerator Blink()
	{
		while (true)
		{
			yield return new WaitForSeconds(Random.Range(1f, 3f));
			Vector3 scale = transform.localScale;
			transform.localScale = Vector3.zero;
			otherEye.transform.localScale = Vector3.zero;
			yield return new WaitForSeconds(0.15f);
			transform.localScale = scale;
			otherEye.transform.localScale = scale;
		}
	}
}
