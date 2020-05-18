using System.Collections;
using UnityEngine;

public class HealthZone : MonoBehaviour
{
    [SerializeField] private float _changeAmount = 10f;
    [SerializeField] private float _changeRateInSeconds = 1f;
    private Coroutine _changeHealthRoutine = null;

    private void OnTriggerEnter(Collider collision)
    {
        PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();

        if (playerHealth != null)
            _changeHealthRoutine = StartCoroutine(ChangeHealth(playerHealth));
    }

    private void OnTriggerExit(Collider collision)
    {
        StopCoroutine(_changeHealthRoutine);
    }

    private IEnumerator ChangeHealth(PlayerHealth playerHealth)
    {
        while (true)
        {
            yield return new WaitForSeconds(_changeRateInSeconds);
            playerHealth.ChangeHealth(_changeAmount);
        }
    }
}
