using UnityEngine;

public class DestroySound : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, GetComponent<AudioSource>().clip.length);
    }
}
