using System.Security.Cryptography;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
        private HealthSpawners _healthSpawners;
        private void Awake()
        {
                _healthSpawners = FindObjectOfType<HealthSpawners>();
        }

        private void OnTriggerEnter(Collider other)
        {
                if (other.CompareTag("Food"))
                {
                        Destroy(other.gameObject);
                        _healthSpawners.SetTheHealtAdditionText();
                }
        }
}
