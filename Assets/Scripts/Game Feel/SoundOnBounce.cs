using UnityEngine;

public class SoundOnBounce : MonoBehaviour
{
    [SerializeField] private GameObject audioPlayer;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        GameObject instance = Instantiate(audioPlayer);
        instance.GetComponent<AudioSource>().pitch += Random.Range(-0.15f, 0.15f);
    }
}
