
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Shredder : MonoBehaviour
{
    [SerializeField] private List<RecyclingRecipe> recyclingRecipeList = new();


    [Header("References")]
    [SerializeField] private GameObject player;
    [SerializeField] private SortedWasteInventory sortedWasteInventory;
    [SerializeField] private MaterialInventory materialInventory;

    [Header("Shredder UI Panel")]
    [SerializeField] private GameObject shredderPanel;
    [SerializeField] private TextMeshPro shredderInteractText;


    [SerializeField] private float interactionRange;

    private int selectedRecipeIndex = 0;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        shredderPanel.SetActive(false);
        shredderInteractText.gameObject.SetActive(false);
        if (player == null)
        {
            Debug.Log("Player reference is missing");
            return;
        }

        sortedWasteInventory = player.GetComponent<SortedWasteInventory>();
        materialInventory = player.GetComponent<MaterialInventory>();
    }

    public RecyclingRecipe GetSelectedRecyclingRecipe()
    {
        if (recyclingRecipeList.Count == 0)
            return null;

        return recyclingRecipeList[selectedRecipeIndex];
    }

    public void SelectNextRecyclingRecipe()
    {
        if (recyclingRecipeList.Count == 0)
            return;

        selectedRecipeIndex++;

        if (selectedRecipeIndex >= recyclingRecipeList.Count)
        {
            selectedRecipeIndex = 0;
        }

        Debug.Log(
            "Selected: " +
            GetSelectedRecyclingRecipe().outputMaterial.materialName
        );
    }

    public void SelectPreviousRecyclingRecipe()
    {
        if (recyclingRecipeList.Count == 0)
            return;

        selectedRecipeIndex--;

        if (selectedRecipeIndex < 0)
        {
            selectedRecipeIndex = recyclingRecipeList.Count - 1;
        }

        Debug.Log(
            "Selected: " +
            GetSelectedRecyclingRecipe().outputMaterial.materialName
        );
    }


    public void TryRecycleSelectedRecipe()
    {
        RecyclingRecipe recipeToRecycle = GetSelectedRecyclingRecipe();


        if (recipeToRecycle == null)
        {
            Debug.Log("No Selected Recipe");
            return;
        }

        if (sortedWasteInventory == null || materialInventory == null)
        {
            Debug.LogError("Shredder is missing an inventory reference.", this);
            return;
        }

        if (recipeToRecycle.outputMaterial == null || recipeToRecycle.wasteRequired <= 0 || recipeToRecycle.outputQuantity <= 0)
        {
            Debug.Log("Invalid Recyling Recipe");

            return;
        }

        if(sortedWasteInventory.TryRecyleTheSortedWaste(recipeToRecycle.inputWaste, recipeToRecycle.wasteRequired))
        {

            materialInventory.AddMaterial(recipeToRecycle.outputMaterial, recipeToRecycle.outputQuantity);

            WasteEvents.AnnounceWasteRecycled(recipeToRecycle);

        }

        else
        {
            FeedbackEvents.ShowFeedback($"Not enough {recipeToRecycle.inputWaste} to recycle");
        }



    }

    private void Update()
    {
        if (!IsCloseToShredder())
        {
            CloseShredderUI();
            return;
        }

        

        if (Keyboard.current.eKey.isPressed)
        {
            OpenShredderUI();
        }
    }

    private void OpenShredderUI()
    {
        shredderPanel.SetActive(true);
    }

    private void CloseShredderUI()
    {
        shredderPanel.SetActive(false);
    }
    private bool IsCloseToShredder()
    {
        if (Vector2.Distance(player.transform.position, transform.position) < interactionRange)
        {
            shredderInteractText.gameObject.SetActive(true);

            return true;
        }


        shredderInteractText.gameObject.SetActive(false);
        return false;
    }

    
    public int GetAvailableWaste(WasteType wasteType)
    {
        return sortedWasteInventory != null
            ? sortedWasteInventory.GetTotalSortedValueByType(wasteType)
            : 0;
    }
}
