
using UnityEngine;

[CreateAssetMenu(
    fileName = "NewRawMaterial",
    menuName = "ScriptableObjects/RawMaterial"
)]
public class RawMaterialData : ScriptableObject
{
    public Sprite materialSprite;
    public string materialName;
    public RawMaterialType materialType;
}

public enum RawMaterialType
{
    Plastic,
    Paper,
    Glass,
    Metal,
    Biodegradable,
    Residual
}
