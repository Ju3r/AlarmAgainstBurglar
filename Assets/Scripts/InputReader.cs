using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";
    private const string VerticalAxis = "Vertical";

    private float DirectionX;
    private float DirectionY;

    public Vector2 Direction { get; private set; }

    private void Update()
    {
        DirectionX = Input.GetAxis(HorizontalAxis);
        DirectionY = Input.GetAxis(VerticalAxis);

        Direction = new Vector2(DirectionX, DirectionY);
    }
}