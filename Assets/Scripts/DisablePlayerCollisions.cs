using UnityEngine;

public class DisablePlayerCollisions : MonoBehaviour
{
    private void Start()
    {
        Physics2D.IgnoreCollision(GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>(), 
            GetComponent<Collider2D>());
    }

}
