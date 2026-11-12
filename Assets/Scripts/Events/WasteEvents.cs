using System;
using UnityEngine;

public static class WasteEvents
{

    public static event Action<WasteData> OnWasteSorted;

    public static void AnnounceWasteSorted(WasteData wasteData)
    {
        OnWasteSorted?.Invoke(wasteData);
    }



}
