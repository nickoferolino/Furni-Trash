using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SortingBin : MonoBehaviour
{

    [SerializeField] private WasteType typeOfWasteItAccept;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private TextMeshPro sortedWasteCountText;
    [SerializeField] private WasteManager wasteManager;
    [SerializeField] private PlayerInventory playerInventory;

    [SerializeField] private float sortingDistance = 1.5f;

    public void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        if(gameManager == null)
        {
            Debug.LogError("GameManager not found in the scene.");
        }
    }
    private void Update()
    {

    }

    private void OnEnable()
    {
        WasteEvents.OnWasteSorted += HandleWasteSorted;
    }

    private void OnDisable()
    {
        WasteEvents.OnWasteSorted -= HandleWasteSorted;
    }


    private void HandleWasteSorted(WasteData wasteData)
    {
        if(wasteData.wasteType == typeOfWasteItAccept)
        {
            UpdateCountText();
        }
    }
    private void Start()
    {
        wasteManager = FindAnyObjectByType<WasteManager>();

        if (wasteManager == null)
        {
            Debug.LogError("WasteManager not found in the scene.");
        }
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

        WasteData wasteData = wasteToSort.GetWasteData();

        if (typeOfWasteItAccept == wasteData.wasteType)
        {



            if (!playerInventory.RemoveFromCarriedWaste(wasteToSort))
            {
                Debug.Log("Failed to remove waste from inventory");
                return;
            }


            wasteManager.RemoveFromActiveWaste(wasteToSort);

            WasteEvents.AnnounceWasteSorted(wasteData);

            Destroy(wasteToSort.gameObject);

            Debug.Log("Succesfully sorted " + wasteData.wasteName + " into " + typeOfWasteItAccept.ToString() + " bin");
        }

        else
        {
            Debug.Log("Wrong bin for this waste type");
        }

    }


    void UpdateCountText()
    {
        if(gameManager == null)
        {
            Debug.LogError("GameManager is not assigned in SortingBin");
            return;
        }

        int sortedCount = gameManager.GetTotalSortedValueByType(typeOfWasteItAccept);   
        if (sortedWasteCountText != null)
        {
            
            sortedWasteCountText.text = sortedCount.ToString();
            Debug.Log("Updated sorted count text for " + typeOfWasteItAccept.ToString() + " bin: " + sortedCount);

        }
    }

    private bool IsCloseToBin()
    {

        if(playerInventory == null)
        {
            Debug.LogError("Player Inventory is not assigned in SortingBin");
            return false;
        }

        return Vector2.Distance(playerInventory.transform.position, transform.position) < sortingDistance;
    }

}
