
using UnityEngine;
using UnityEngine.UI;

public class ClipboardUI : MonoBehaviour
{
    [SerializeField] private GameObject clipboardPanel;
    [SerializeField] private Button clipboardButtonToggle;

    private void Awake()
    {
        clipboardPanel.SetActive(false);
    }

    private void OnEnable()
    {
        clipboardButtonToggle.onClick.AddListener(ToggleClipboard);
    }

    private void OnDisable()
    {
        clipboardButtonToggle.onClick.RemoveListener(ToggleClipboard);
    }

    private void ToggleClipboard()
    {
        clipboardPanel.SetActive(!clipboardPanel.activeSelf);
    }
}
