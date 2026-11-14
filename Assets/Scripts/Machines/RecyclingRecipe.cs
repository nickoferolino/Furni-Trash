using UnityEngine;

using System;

[Serializable]

public class RecyclingRecipe 
{
    public String recyclingRecipeName;

    public WasteType inputWaste;

    [Min(1)]
    public int wasteRequired = 5;

    public RawMaterialData outputMaterial;

    [Min(1)]
    public int outputQuantity = 1;

}
