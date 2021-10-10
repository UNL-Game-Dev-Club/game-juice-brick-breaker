using UnityEngine;

public class IntroAnim : MonoBehaviour
{
    private void Start()
    {
        transform.position = Vector3.up * 300f;
        LeanTween.moveY(gameObject, 0f, 1.0f).setEase(LeanTweenType.easeInOutBack);
    }
}
