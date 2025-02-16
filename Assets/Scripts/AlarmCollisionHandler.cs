using System;
using UnityEngine;

public class AlarmCollisionHandler : MonoBehaviour
{
    public event Action<bool> BurglarInHouse;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Burglar burglar))
            BurglarInHouse?.Invoke(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Burglar burglar))
            BurglarInHouse?.Invoke(false);
    }
}
