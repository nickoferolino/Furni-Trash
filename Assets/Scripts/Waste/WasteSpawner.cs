using UnityEngine;
using UnityEngine.InputSystem;

public class WasteSpawner : MonoBehaviour
{

    [SerializeField] private WasteManager wasteManager;
    [SerializeField] private WastePickUp wastePickUpPrefab; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            RandomSpawnWaste();
        }
    }


    void RandomSpawnWaste()
    {
        if(wasteManager == null || wastePickUpPrefab == null)
        {
            Debug.Log("WasteManager is not assigned.");
            return;
        }


        WasteData randomWaste = wasteManager.GetRandomWaste();

        if(randomWaste == null)
        {
            Debug.Log("No waste data available.");
            return;
        }

        WastePickUp spawnWaste = Instantiate(wastePickUpPrefab, transform.position + new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f),0), Quaternion.identity);

        spawnWaste.Initialize(randomWaste);
        wasteManager.AddToActiveWaste(spawnWaste);
    }
}
