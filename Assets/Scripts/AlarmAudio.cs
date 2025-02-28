using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AlarmAudio : MonoBehaviour
{
    private AudioSource _audioSource;

    private float _fadeDuration = 5f;
    private float _maxVolume = 1f;
    private float _minVolume = 0f;

    private Coroutine _currentCoroutine;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = _minVolume;
    }

    public void ChangeTargetVolumeToMax()
    {
        if (_audioSource.isPlaying == false)
        {
            _audioSource.Play();
        }

        RelaunchCoroutine(_maxVolume);
    }

    public void ChangeTargetVolumeToMin()
    {
        RelaunchCoroutine(_minVolume);
    }

    private void RelaunchCoroutine(float targetVolume)
    {
        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }

        _currentCoroutine = StartCoroutine(ChangeVolume(targetVolume));
    }

    private IEnumerator ChangeVolume(float targetVolume)
    {
        while (_audioSource.volume != targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, Time.deltaTime / _fadeDuration);

            yield return null;
        }

        if (_audioSource.isPlaying && _audioSource.volume == _minVolume)
        {
            _audioSource.Stop();
        }
    }
}