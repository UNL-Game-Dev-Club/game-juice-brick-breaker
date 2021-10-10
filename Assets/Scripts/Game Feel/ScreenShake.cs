using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public void Shake(float time, float amount)
    {
        float xMultiplier = Random.value > 0.5f ? 1 : -1;
        float yMultiplier = Random.value > 0.5f ? 1 : -1;
        
        LeanTween.moveLocalX(gameObject, amount * xMultiplier, time).setEaseShake();
        LeanTween.moveLocalY(gameObject, amount * yMultiplier, time).setEaseShake();
    }
}
