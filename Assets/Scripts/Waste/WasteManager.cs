
using UnityEngine;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

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

    public WasteData GetRandomWasteByType(WasteType type)
    {
        List<WasteData> wasteByTypeList = GetAllWasteByType(type);

        if (wasteByTypeList.Count == 0)
        {
            Debug.LogWarning($"No waste found for type: {type}");
            return null;
        }

        int randomIndex = Random.Range(0, wasteByTypeList.Count);

        return wasteByTypeList[randomIndex];
    }



    private List<WasteData> GetAllWasteByType(WasteType type)
    {
        List<WasteData> wasteByTypeList = new List<WasteData>();

        foreach (WasteData waste in wasteDataList)
        {
            if (waste.wasteType == type)
            {
                wasteByTypeList.Add(waste);
            }
        }

        return wasteByTypeList;
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
