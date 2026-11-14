using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInteract : MonoBehaviour
{

    [Header("Interaction Settings")]
    private PlayerMovement playerMovement;
    private Vector2 mousePos;
    [SerializeField] private GameObject mouseIndicator;
    [SerializeField] LayerMask wasteLayer;
    [SerializeField] LayerMask binLayer;
    [SerializeField] private PlayerInventory playerInventory;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerInventory = GetComponent<PlayerInventory>();


    }

    // Update is called once per frame
    void Update()
    {
        MoveMouseIndicatorToMousePos();

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            TryInteract();
            
        }

        if(Mouse.current.rightButton.wasPressedThisFrame)
        {
            TrySortWaste();
        }
    }



    void MoveMouseIndicatorToMousePos()
    {
        mousePos = playerMovement.GetMousePosition();
        mouseIndicator.transform.position = new Vector3(mousePos.x, mousePos.y, 0f);
    }


    void TryInteract()
    {
        Collider2D hit = Physics2D.OverlapPoint(mousePos, wasteLayer);

        if (hit != null)
        {
            WastePickUp waste = hit.GetComponent<WastePickUp>();
            if (waste != null)
            {
                waste.TryPickUp();
            }
        }
    }

    void TrySortWaste()
    {
        Collider2D hit = Physics2D.OverlapPoint(mousePos, binLayer);

        if (hit != null)
        {
            SortingBin bin = hit.GetComponent<SortingBin>();
            if (bin != null)
            {
                bin.TrySortTheTrash(playerInventory.GetTopWaste());
            }
        }
    }


}
