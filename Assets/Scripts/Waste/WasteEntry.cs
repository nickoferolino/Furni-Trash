using UnityEngine;

[System.Serializable]
public class WasteEntry 
{

    public WasteData wasteData;
    public int count;
    public WasteEntry(WasteData data, int count)
    {
        this.wasteData = data;
        this.count = count;
    }

}
