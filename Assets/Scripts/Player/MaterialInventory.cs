
using System.Collections.Generic;
using UnityEngine;

public class MaterialInventory : MonoBehaviour
{
    private Dictionary<RawMaterialData, int> materialsCrafted = new();

    public void AddMaterial(RawMaterialData material, int amount)
    {
        if (material == null || amount <= 0)
            return;

        if (!materialsCrafted.ContainsKey(material))
        {
            materialsCrafted[material] = 0;
        }

        materialsCrafted[material] += amount;

        Debug.Log(
            $"Added {amount} {material.materialName}. " +
            $"Total: {materialsCrafted[material]}"
        );
    }

    public int GetMaterialQuantity(RawMaterialData material)
    {
        if (materialsCrafted.TryGetValue(material, out int amount))
        {
            return amount;
        }

        return 0;
    }

    public bool TryRemoveMaterial(RawMaterialData material, int amount)
    {
        if (material == null || amount <= 0)
            return false;

        if (GetMaterialQuantity(material) < amount)
            return false;

        materialsCrafted[material] -= amount;

        return true;
    }
}
