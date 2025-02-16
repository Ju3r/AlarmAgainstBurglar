using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AlarmAudioController : MonoBehaviour
{
    public float _targetVolume { get; private set; }

    [SerializeField] private AudioSource _audioSource;

    private float _fadeDuration = 5f;
    private float _maxVolume = 1f;
    private float _minVolume = 0f;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = _minVolume;
    }

    private void Update()
    {
        if (_audioSource.volume != _targetVolume)
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _targetVolume, Time.deltaTime / _fadeDuration);
    }

    public void ChangeTargetVolumeToMax()
    {
        _targetVolume = _maxVolume;
    }
    
    public void ChangeTargetVolumeToMin()
    {
        _targetVolume = _minVolume;
        Debug.Log("”Ã≈Õ‹ÿ»ÀŒ—‹");
    }
}