using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AlarmAudioController : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private float _fadeDuration = 5f;
    private float _maxVolume = 1f;
    private float _minVolume = 0f;

    private Coroutine _currentCoroutine;

    public float _targetVolume { get; private set; }

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = _minVolume;
    }

    private IEnumerator ChangeVolume()
    {
        while (_audioSource.volume != _targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _targetVolume, Time.deltaTime / _fadeDuration);

            yield return null;
        }
    }

    public void ChangeTargetVolumeToMax()
    {
        _targetVolume = _maxVolume;
        RelaunchCoroutine();
    }

    public void ChangeTargetVolumeToMin()
    {
        _targetVolume = _minVolume;
        RelaunchCoroutine();
    }

    private void RelaunchCoroutine()
    {
        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }

        _currentCoroutine = StartCoroutine(ChangeVolume());
    }
}