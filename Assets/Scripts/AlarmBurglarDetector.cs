using System;
using UnityEngine;

public class AlarmBurglarDetector : MonoBehaviour
{
    public event Action BurglarInHouse;
    public event Action BurglarOutHouse;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Burglar burglar))
            BurglarInHouse?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Burglar burglar))
            BurglarOutHouse?.Invoke();
    }
}
