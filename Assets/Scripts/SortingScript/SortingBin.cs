using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SortingBin : MonoBehaviour
{

    [SerializeField] private WasteType typeOfWasteItAccept;
    [SerializeField] private int sortedWasteCount = 0;
    [SerializeField] private TextMeshPro sortedWasteCountText;
    [SerializeField] private WasteManager wasteManager;
    [SerializeField] private PlayerInventory playerInventory;

    private void Update()
    {
        IsCloseToBin();
    }
    private void Start()
    {
        sortedWasteCountText.text = sortedWasteCount.ToString();
    }

    public void TrySortTheTrash(WastePickUp wasteToSort)
    {
        if(!IsCloseToBin())
        {
            Debug.Log("Not close enough to the bin");
            return;
        }

        if (wasteToSort == null)
        {
            Debug.Log("Nothing to sort");
            return;
        }

        if(typeOfWasteItAccept == wasteToSort.GetWasteData().wasteType)
        {
            sortedWasteCount += wasteToSort.GetWasteData().wasteValue;
            UpdateCountText();
           
            playerInventory.RemoveFromInventory(wasteToSort);
            wasteManager.RemoveFromActiveWaste(wasteToSort);


            Destroy(wasteToSort.gameObject);

            Debug.Log("Succesfully sorted " + wasteToSort.GetWasteData().wasteName + " into " + typeOfWasteItAccept.ToString() + " bin");
        }

        else
        {
            Debug.Log("Wrong bin for this waste type");
        }

    }


    void UpdateCountText()
    {
        if (sortedWasteCountText != null)
        {
            sortedWasteCountText.text = sortedWasteCount.ToString();
        }
    }

    private bool IsCloseToBin()
    {

        return Vector2.Distance(playerInventory.transform.position, transform.position) < 1.5f;
    }

}
