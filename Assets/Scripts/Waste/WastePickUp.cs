
using UnityEngine;

public class WastePickUp : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float pickUpRange = 1.5f;

    [SerializeField] private bool isCarried = false;

    private GameObject player;
    private WasteData wasteData;
    private PlayerInventory playerInventory;
    private Collider2D wasteCollider;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        wasteCollider = GetComponent<Collider2D>();

        player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
        {
            Debug.LogError("Player not found! Check the Player tag.");
            return;
        }

        playerInventory = player.GetComponent<PlayerInventory>();

        if (playerInventory == null)
        {
            Debug.LogError("PlayerInventory component not found!");
        }
    }

    public void Initialize(WasteData data)
    {
        wasteData = data;

        if (wasteData == null)
        {
            Debug.LogWarning("WasteData is not assigned!");
            return;
        }

        spriteRenderer.sprite = wasteData.wasteSprite;
    }

    public WasteType GetWasteType()
    {
        return wasteData.wasteType;
    }

    public WasteData GetWasteData()
    {
        return wasteData;
    }

    public void TryPickUp()
    {
        if (wasteData == null ||
            player == null ||
            playerInventory == null ||
            isCarried)
            return;

        float distance = Vector2.Distance(
            transform.position,
            player.transform.position
        );

        if (distance > pickUpRange)
        {
            FeedbackEvents.ShowFeedback("Too far away!");
            return;
        }

        if (playerInventory.AddToCarriedWaste(this))
        {
            isCarried = true;

            if (wasteCollider != null)
                wasteCollider.enabled = false;

            if (rb != null)
                rb.simulated = false;

            FeedbackEvents.ShowFeedback(
                $"Picked up {wasteData.wasteName}!"
            );
        }
        else
        {
            FeedbackEvents.ShowFeedback("Inventory full!");
        }
    }

    public void HighLight()
    {
        if (wasteData == null)
            return;

        spriteRenderer.sprite = wasteData.wasteHighlight;
    }

    public void UnHighLight()
    {
        if (wasteData == null)
            return;

        spriteRenderer.sprite = wasteData.wasteSprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MouseIndicator") && !isCarried)
        {
            HighLight();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("MouseIndicator") && !isCarried)
        {
            UnHighLight();
        }
    }
}
