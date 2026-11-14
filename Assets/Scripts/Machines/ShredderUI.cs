using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShredderUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Shredder shredder;

    [Header("Selection Panel")]
    [SerializeField] private Image recipeImage;
    [SerializeField] private TextMeshProUGUI recyclingRecipeName;

    [Header("Selection Buttons")]
    [SerializeField] private Button previousRecipeButton;
    [SerializeField] private Button nextRecipeButton;

    [Header("Recipe Details Panel")]
    [SerializeField] private TextMeshProUGUI inputWasteNameText;
    [SerializeField] private TextMeshProUGUI inputQuantityText;

    [SerializeField] private TextMeshProUGUI outputMaterialNameText;
    [SerializeField] private TextMeshProUGUI outputQuantityText;

    [Header("Recycling Button")]
    [SerializeField] private Button recycleButton;

    private void OnEnable()
    {
        WasteEvents.OnWasteStockChanged += UpdateUI;
    }

    private void OnDisable()
    {
        WasteEvents.OnWasteStockChanged -= UpdateUI;
    }
    public void Awake()
    {
        shredder = GetComponent<Shredder>();
    }
    private void Start()
    {
        
        previousRecipeButton.onClick.AddListener(OnPreviousRecipeClicked);
        nextRecipeButton.onClick.AddListener(OnNextRecipeClicked);
        recycleButton.onClick.AddListener(OnRecycleClicked);

        UpdateUI();
    }

    private void OnPreviousRecipeClicked()
    {
        shredder.SelectPreviousRecyclingRecipe();
        UpdateUI();
    }

    private void OnNextRecipeClicked()
    {
        shredder.SelectNextRecyclingRecipe();
        UpdateUI();
    }

    private void OnRecycleClicked()
    {

        shredder.TryRecycleSelectedRecipe();
        UpdateUI();
    }

    private void UpdateUI()
    {
        RecyclingRecipe recipe = shredder.GetSelectedRecyclingRecipe();

        if (recipe == null || recipe.outputMaterial == null)
        {
            recyclingRecipeName.text = "Recipe unavailable";
            recipeImage.sprite = null;
            recipeImage.enabled = false;

            inputWasteNameText.text = "";
            inputQuantityText.text = "";
            outputMaterialNameText.text = "";
            outputQuantityText.text = "";

            recycleButton.interactable = false;
            return;
        }

        RawMaterialData output = recipe.outputMaterial;
        int availableWaste = shredder.GetAvailableWaste(recipe.inputWaste);

        recyclingRecipeName.text = output.materialName;
        recipeImage.sprite = output.materialSprite;
        recipeImage.enabled = output.materialSprite != null;

        inputWasteNameText.text = recipe.inputWaste.ToString();
        inputQuantityText.text = $"{availableWaste} / {recipe.wasteRequired}";

        outputMaterialNameText.text = output.materialName;
        outputQuantityText.text = recipe.outputQuantity.ToString();

        recycleButton.interactable =
            recipe.wasteRequired > 0 &&
            recipe.outputQuantity > 0 &&
            availableWaste >= recipe.wasteRequired;
    }


}