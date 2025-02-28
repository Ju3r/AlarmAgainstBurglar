using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";
    private const string VerticalAxis = "Vertical";

    private float _directionX;
    private float _directionY;

    public Vector2 Direction { get; private set; }

    private void Update()
    {
        _directionX = Input.GetAxis(HorizontalAxis);
        _directionY = Input.GetAxis(VerticalAxis);

        Direction = new Vector2(_directionX, _directionY);
    }
}