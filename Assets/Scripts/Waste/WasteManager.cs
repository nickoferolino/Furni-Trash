
using UnityEngine;
using System.Collections.Generic;

public class WasteManager : MonoBehaviour
{

    [SerializeField] private List<WasteData> wasteDataList = new List<WasteData>();

    [SerializeField] private List<WastePickUp> activeWasteInGame = new List<WastePickUp>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created



    public WasteData GetRandomWaste()
    {
        if(wasteDataList.Count == 0)
        {
            Debug.Log("There is no waste data in the list.");
            return null;
        }


        int randomIndex = Random.Range(0, wasteDataList.Count);

        WasteData wasteToSpawn = wasteDataList[randomIndex];
  
        return wasteToSpawn;
    }

    public void AddToActiveWaste(WastePickUp wasteToAdd)
    {
        activeWasteInGame.Add(wasteToAdd);
    }
    public void RemoveFromActiveWaste(WastePickUp wasteToRemove)
    {
        activeWasteInGame.Remove(wasteToRemove);
    }

    public WastePickUp GetCarriedWaste()
    {
        return activeWasteInGame.Count > 0 ? activeWasteInGame[activeWasteInGame.Count - 1] : null;
    }

    
}
