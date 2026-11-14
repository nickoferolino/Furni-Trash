using System;
using Unity.VisualScripting;
using UnityEngine;

public static class WasteEvents
{

    public static event Action<WasteData> OnWasteSorted;

    public static event Action OnWasteStockChanged;

    public static event Action<RecyclingRecipe> OnWasteRecycled;

    

    public static void AnnounceWasteSorted(WasteData wasteData)
    {
        OnWasteSorted?.Invoke(wasteData);
        OnWasteStockChanged?.Invoke();
    }


    public static void AnnounceWasteRecycled(RecyclingRecipe recyledMaterial)
    {
        OnWasteRecycled?.Invoke(recyledMaterial);
        OnWasteStockChanged?.Invoke();
    }
    



}
