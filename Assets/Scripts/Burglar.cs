using UnityEngine;

[RequireComponent (typeof(InputReader), typeof(Mover))]
public class Burglar : MonoBehaviour
{
    private InputReader _inputReader;
    private Mover _mover;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _mover = GetComponent<Mover>();
    }

    private void FixedUpdate()
    {
        _mover.Move(_inputReader.Direction);
    }
}