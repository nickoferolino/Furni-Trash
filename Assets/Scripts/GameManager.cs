using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{

    //Total of waste sorted tracker across the game
    private Dictionary<WasteType, int> allWasteSortedHistory = new Dictionary<WasteType, int>();
    private Dictionary<RecyclingRecipe, int> allRecycledWasteHistory = new Dictionary<RecyclingRecipe, int>();

    [SerializeField] private int lifetimeSortedWaste;
    [SerializeField] private int lifetimeRecycledWaste;

    private void Awake()
    {

        // Initialize the dictionary with all waste types and set their initial count to 0
        foreach (WasteType type in System.Enum.GetValues(typeof(WasteType)))
        {
            allWasteSortedHistory[type] = 0;
        }



    }


    private void OnEnable()
    {
        WasteEvents.OnWasteSorted += HandleWasteSorted;
        WasteEvents.OnWasteRecycled += HandleWasteRecycled;
    }

    private void OnDisable()
    {
        WasteEvents.OnWasteSorted -= HandleWasteSorted;
        WasteEvents.OnWasteRecycled -= HandleWasteRecycled;
    }

    private void HandleWasteRecycled(RecyclingRecipe recycledMaterial)
    {
        if(recycledMaterial == null)
        {
            Debug.Log("Null Raw Material Data from Waste Events");
        }

        if (!allRecycledWasteHistory.ContainsKey(recycledMaterial))
        {
            allRecycledWasteHistory[recycledMaterial] = 0;
        }

        allRecycledWasteHistory[recycledMaterial] += recycledMaterial.outputQuantity;


        Debug.Log($"Recycled Waste: {recycledMaterial.recyclingRecipeName}, Total: {allRecycledWasteHistory[recycledMaterial]} ");



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

        lifetimeSortedWaste++;


        allWasteSortedHistory[wasteType] += value;


        Debug.Log($"Waste sorted: {wasteType}, Value: {value}. Total sorted for this type: {allWasteSortedHistory[wasteType]}");



    }

    public int GetLifeTimeTotalSortedValueByType(WasteType wasteType)
    {

        int totalValue = 0;

        if (allWasteSortedHistory.ContainsKey(wasteType))
        {
            totalValue = allWasteSortedHistory[wasteType];
            
        }

        return totalValue;
    }

    public int GetTotalOfSortedWasteAllTheTime()
    {
        return lifetimeSortedWaste;
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
