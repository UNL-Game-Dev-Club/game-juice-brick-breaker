using UnityEngine;

public class Brick : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other) {
        Destroy(gameObject);
    }
}
