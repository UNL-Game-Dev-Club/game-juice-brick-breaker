using System.Collections;
using UnityEngine;

public class IntroBricks : MonoBehaviour
{
    private Vector3 originalSize = Vector3.one;
    
    private void Start()
    {
        originalSize = transform.GetChild(0).localScale;
        StartCoroutine(EaseInBricks());
    }

    private IEnumerator EaseInBricks()
    {
        foreach (Transform child in transform)
        {
            child.localScale = originalSize / 2;
        }
     
        yield return new WaitForSeconds(0.5f);
        
        foreach (Transform child in transform)
        {
            LeanTween.scale(child.gameObject, originalSize, 1.0f).setEaseOutBack();
        }
    }
}
