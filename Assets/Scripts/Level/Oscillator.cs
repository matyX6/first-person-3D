using UnityEngine;

public class Oscillator : MonoBehaviour
{
    [SerializeField] Vector3 movementVector = new Vector3(10f, 10f, 10f);
    [SerializeField] float period = 2f;
    private float movementFactor = 0f;
    private Vector3 startingPos = Vector3.zero;

    void Start()
    {
        startingPos = transform.position;
    }

    void Update()
    {
        ProcessCycles();
    }

    private void ProcessCycles()
    {
        if (period <= Mathf.Epsilon) { return; } //protect agianst period is zero
        float cycles = Time.time / period; //grows continually from 0

        const float tau = Mathf.PI * 2; //about 6.28
        float rawSinWawe = Mathf.Sin(cycles * tau); //goes from -1 to 1

        movementFactor = rawSinWawe / 2f + 0.5f;
        Vector3 offset = movementFactor * movementVector;
        transform.position = startingPos + offset;
    }
}
