using UnityEngine;


[CreateAssetMenu(fileName = "WasteData", menuName = "ScriptableObjects/WasteData")]



public class WasteData : ScriptableObject
{
    public Sprite wasteSprite;
    public Sprite wasteHighlight;
    public WasteType wasteType;
    public string wasteName;
    public int wasteValue;
    public WasteConversion materialItGives;

    public void Initialize(Sprite sprite, Sprite highlight, WasteType type, string name)
    {
        wasteSprite = sprite;
        wasteHighlight = highlight;
        wasteType = type;
        wasteName = name;

    }



}

public enum WasteType
{
    Plastic,
    Paper,
    //Glass,  will add later 
    Metal,
    Biodegradable,
    Residual
}


