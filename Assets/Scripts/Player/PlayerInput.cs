using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameInput controls { get; private set; }

    private void Awake()
    {
        controls = new GameInput();
    }

    private void OnEnable()
    {
        var playerInput = controls.Player;

        playerInput.Enable();
        
    }

    private void OnDisable()
    {
        var playerInput = controls.Player;
        playerInput.Disable();
    }
    private void OnDestroy()
    {
        var playerInput = controls.Player;
        playerInput.Disable();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
