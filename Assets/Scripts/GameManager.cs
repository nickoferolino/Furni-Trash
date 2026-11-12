using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{

    private Dictionary<WasteType, int> allWasteSortedInventoryByType = new Dictionary<WasteType, int>();


    private void Awake()
    {

        // Initialize the dictionary with all waste types and set their initial count to 0
        foreach (WasteType type in System.Enum.GetValues(typeof(WasteType)))
        {
            allWasteSortedInventoryByType[type] = 0;
        }
    }


    private void OnEnable()
    {
        WasteEvents.OnWasteSorted += HandleWasteSorted;
    }

    private void OnDisable()
    {
        WasteEvents.OnWasteSorted -= HandleWasteSorted;
    }

    private void HandleWasteSorted(WasteData wasteData)
    {
        if(wasteData == null)
        {
            Debug.Log("Null Waste Data received in HandleWasteSorted Events.");
            return;
        }

        WasteType wasteType = wasteData.wasteType;
        int value = wasteData.wasteValue;

        allWasteSortedInventoryByType[wasteType] += value;

        Debug.Log($"Waste sorted: {wasteType}, Value: {value}. Total sorted for this type: {allWasteSortedInventoryByType[wasteType]}");



    }

    public int GetTotalSortedValueByType(WasteType wasteType)
    {

        int totalValue = 0;

        if (allWasteSortedInventoryByType.ContainsKey(wasteType))
        {
            totalValue = allWasteSortedInventoryByType[wasteType];
            
        }

        return totalValue;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
