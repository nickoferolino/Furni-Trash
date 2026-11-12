
using UnityEngine;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private int maxInventorySize = 5;
    [SerializeField] private Transform carryPoint;
    [SerializeField] private float stackSpacing = 0.3f;
    [SerializeField] private int baseSortingOrder = 10;

    [SerializeField] private List<WastePickUp> carriedWaste = new();

    public bool AddToCarriedWaste(WastePickUp waste)
    {
        if (waste == null || carryPoint == null)
            return false;

        if (carriedWaste.Count >= maxInventorySize)
        {
            Debug.Log("Cannot carry more waste!");
            return false;
        }

       
        int stackIndex = carriedWaste.Count;

        carriedWaste.Add(waste);


        // Position the waste
        waste.transform.SetParent(carryPoint);
        waste.transform.localPosition =
            new Vector3(0f, stackIndex * stackSpacing, 0f);

        // Set the rendering order
        SpriteRenderer sr = waste.GetComponent<SpriteRenderer>();

        if (sr != null)
        {
            sr.sortingOrder = baseSortingOrder + stackIndex;
        }
        

        
        Debug.Log($"Carrying {carriedWaste.Count}/{maxInventorySize}");

        return true;
    }
    private void Update()
    {
        UpdateTopWasteHighlight();
    }


    public WastePickUp GetTopWaste()
    {
        if (carriedWaste.Count == 0)
            return null;

        return carriedWaste[carriedWaste.Count - 1];
    }


    public bool RemoveFromCarriedWaste(WastePickUp waste)
    {
        if (waste == null)
            return false;
        if (carriedWaste.Remove(waste))
        {

            Debug.Log($"Removed waste from inventory. Now carrying {carriedWaste.Count}/{maxInventorySize}");
            return true;
        }
        Debug.Log("Waste not found in inventory.");
        return false;
    }

    private void UpdateTopWasteHighlight()
    {
        foreach (WastePickUp waste in carriedWaste)
        {
            waste.UnHighLight();
        }

        WastePickUp topWaste = GetTopWaste();

        if (topWaste != null)
        {
            topWaste.HighLight();
        }
    }
}
