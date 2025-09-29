using UnityEngine;

public class PickupFactory : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject coinPrefab;
    public GameObject[] powerupPrefabs;

    [Header("Spawn Settings")]
    public int coinCount = 20;
    public int powerupCount = 5;
    public float spawnHeight = 50f;
    
    private Bounds roadBounds;
    private void Start()
    {
        CalculateRoadBounds();
        SpawnCoins();
        SpawnPowerups();
    }
    
    private void CalculateRoadBounds()
    {
        roadBounds = new Bounds();

        bool first = true;
        foreach (GameObject road in FindObjectsOfType<GameObject>())
        {
            Debug.Log("Checking road: " + road.name);
            if (road.layer == LayerMask.NameToLayer("Road"))
            {
                Renderer r = road.GetComponent<Renderer>();
                if (r != null)
                {
                    if (first)
                    {
                        roadBounds = r.bounds;
                        first = false;
                    }
                    else
                    {
                        roadBounds.Encapsulate(r.bounds);
                    }
                }
            }
        }
    }

    private void SpawnCoins()
    {
        for (int i = 0; i < coinCount; i++)
        {
            Vector3 position = GetRandomRoadPosition();
            Instantiate(coinPrefab, position, Quaternion.identity);
        }
    }

    private void SpawnPowerups()
    {
        for (int i = 0; i < powerupCount; i++)
        {
            Vector3 position = GetRandomRoadPosition();
            int randomIndex = Random.Range(0, powerupPrefabs.Length);
            Instantiate(powerupPrefabs[randomIndex], position, Quaternion.identity);
        }
    }
    
    public Vector3 GetRandomRoadPosition()
    {
        for (int attempt = 0; attempt < 10; attempt++)
        {
            var x = Random.Range(roadBounds.min.x, roadBounds.max.x);
            var z = Random.Range(roadBounds.min.z, roadBounds.max.z);
            var randomPos = new Vector3(x, 50, z);

            if (Physics.Raycast(randomPos, Vector3.down, out RaycastHit hit, 100f))
            {
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Road"))
                {
                    return hit.point + Vector3.up * 0.5f + Vector3.up * spawnHeight;
                }
            }
        }
        return Vector3.zero;
    }
}