using UnityEngine;

public class BricksSounds : MonoBehaviour
{
    [SerializeField] private GameObject brickSound;
    [SerializeField] private float pitchIncreaseAmount = 0.2f;
    [SerializeField] private float breakChainRange = 1f;
    
    private float _currentPitch = 1f;
    private float _lastBreakTime = 0f;

    public void PlaySound()
    {
        GameObject instance = Instantiate(brickSound);

        if (Time.time - _lastBreakTime <= breakChainRange)
        {
            _currentPitch += pitchIncreaseAmount;
        }
        else
        {
            _currentPitch = 1f;
        }
        
        instance.GetComponent<AudioSource>().pitch = _currentPitch;
        _lastBreakTime = Time.time;
    }
}
