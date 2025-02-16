using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    private const float SpeedCoefficient = 50f;

    private Rigidbody2D _rigidbody;
    private float _speed = 1f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 direction)
    {
        float step = _speed * SpeedCoefficient * Time.fixedDeltaTime;

        _rigidbody.velocity = new Vector2(
            direction.x * step,
            direction.y * step);
    }
}