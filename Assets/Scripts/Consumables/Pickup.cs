using DefaultNamespace;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private PickupFactory factory;
    
    private void Awake() => factory = FindObjectOfType<PickupFactory>();
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var consumable = GetComponent<IConsumable>();
            consumable?.Consume(other.gameObject);
            
            var randomPos = factory.GetRandomRoadPosition();
            transform.position = randomPos;
        }
    }
}