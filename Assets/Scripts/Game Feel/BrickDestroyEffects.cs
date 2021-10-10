using UnityEngine;

public class BrickDestroyEffects : MonoBehaviour
{
    [SerializeField] private GameObject brickDestroyParticles;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        transform.parent.GetComponent<BricksSounds>().PlaySound();
        Instantiate(brickDestroyParticles, transform.position, Quaternion.identity);
    }
}
