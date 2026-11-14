using UnityEngine;
using System.Collections.Generic;
using System;
public class SortedWasteInventory : MonoBehaviour
{
    private Dictionary<WasteType, int> availableWasteSortedInventory = new Dictionary<WasteType, int>();



    private void Awake()
    {
        // this will set the invetory to store all the type of waste player could get
        foreach(WasteType type in Enum.GetValues(typeof(WasteType)))
        {

            availableWasteSortedInventory[type] = 0;
        
        
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
        if (wasteData == null)
        {
            Debug.Log("Null Waste Data received in HandleWasteSorted Events.");
            return;
        }

        WasteType type = wasteData.wasteType;
        int value = wasteData.wasteValue;

        if(value < 0)
        {
            Debug.Log("This waste value is 0, need to fix");
            return;
        }

        availableWasteSortedInventory[type] += value;

        Debug.Log($"Available {type}: {availableWasteSortedInventory[type]}");

    }


    public int GetTotalSortedValueByType(WasteType type)
    {
        int totalValue = 0;

        if (availableWasteSortedInventory.ContainsKey(type))
        {
            totalValue = availableWasteSortedInventory[type];
        }


        return totalValue;

    }

    public bool TryRecyleTheSortedWaste(WasteType type, int quantityNeed)
    {

        if(quantityNeed <= 0)
        {
            return false;
        }

        if(GetTotalSortedValueByType(type) < quantityNeed)
        {
            return false;
        }


        availableWasteSortedInventory[type] -= quantityNeed;

        Debug.Log($"Used {quantityNeed} {type}. + \nRemaining: {availableWasteSortedInventory[type]} ");

        return true;
    }


}