using UnityEngine;

[RequireComponent(typeof(AlarmCollisionHandler), typeof(AlarmAudioController))]
public class Alarm : MonoBehaviour
{
    private AlarmCollisionHandler _collisionHandler;
    private AlarmAudioController _audioController;

    private void Awake()
    {
        _collisionHandler = GetComponent<AlarmCollisionHandler>();
        _audioController = GetComponent<AlarmAudioController>();
    }

    private void OnEnable()
    {
        _collisionHandler.BurglarInHouse += OnBurglarInHouse;
    }

    private void OnDisable()
    {
        _collisionHandler.BurglarInHouse -= OnBurglarInHouse;
    }

    private void OnBurglarInHouse(bool inHouse)
    {
        if (inHouse)
            _audioController.ChangeTargetVolumeToMax();
        else
            _audioController.ChangeTargetVolumeToMin();
    }
}