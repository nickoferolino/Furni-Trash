using Unity.VisualScripting;
using UnityEngine;

public class WastePickUp : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject player;
    [SerializeField] private float pickUpRange = 1.5f;
    
    [SerializeField] bool isCarried = false;
    private WasteData wasteData;

    private PlayerInventory playerInventory;
    private Collider2D wasteCollider;
    private Rigidbody2D rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        wasteCollider = GetComponent<Collider2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform.gameObject;
        if(player == null)
        {
            Debug.LogError("Player GameObject not found in the scene. Please ensure the player has the 'Player' tag.");
            return;
        }
        playerInventory = player.GetComponent<PlayerInventory>();
    }

    public void Initialize(WasteData data)
    {
        wasteData = data;
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
            Debug.Log("Too far away!");
            return;
        }

        if (playerInventory.AddToInventory(this))
        {
            isCarried = true;
            wasteCollider.enabled = false;
            rb.simulated = false;
            Debug.Log($"Picked up {wasteData.wasteName}");
        }
    }


    public void HighLight()
    {
        if (wasteData == null) return;

        spriteRenderer.sprite = wasteData.wasteHighlight;
    }

    public void UnHighLight()
    {
        if (wasteData == null) return;

        spriteRenderer.sprite = wasteData.wasteSprite;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MouseIndicator"))
        {
            HighLight();
        }
      
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MouseIndicator"))
        {
            UnHighLight();
        }
    }


}

