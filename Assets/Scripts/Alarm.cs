using UnityEngine;

[RequireComponent(typeof(AlarmBurglarDetector), typeof(AlarmAudio))]
public class Alarm : MonoBehaviour
{
    private AlarmBurglarDetector _collisionHandler;
    private AlarmAudio _audioController;

    private void Awake()
    {
        _collisionHandler = GetComponent<AlarmBurglarDetector>();
        _audioController = GetComponent<AlarmAudio>();
    }

    private void OnEnable()
    {
        _collisionHandler.BurglarInHouse += OnBurglarInHouse;
        _collisionHandler.BurglarOutHouse += OnBurglarOutHouse;
    }

    private void OnDisable()
    {
        _collisionHandler.BurglarInHouse -= OnBurglarInHouse;
        _collisionHandler.BurglarOutHouse -= OnBurglarOutHouse;
    }

    private void OnBurglarInHouse()
    { 
        _audioController.ChangeTargetVolumeToMax();
    }

    private void OnBurglarOutHouse()
    {
        _audioController.ChangeTargetVolumeToMin();
    }
}