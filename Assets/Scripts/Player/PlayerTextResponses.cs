using TMPro;
using UnityEngine;
using System.Collections;
public class PlayerTextResponses : MonoBehaviour
{

    [SerializeField] TextMeshPro playerResponseText;
    [SerializeField] float messageDuration = 2f;

    private Coroutine currentMessageRoutine;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerResponseText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        FeedbackEvents.OnFeedbackRequested += HandleFeedback;
    }

    
    private void OnDisable()
    {
        FeedbackEvents.OnFeedbackRequested -= HandleFeedback;
    }

    private void HandleFeedback(string message)
    {
        if(currentMessageRoutine != null)
        {
            StopCoroutine(currentMessageRoutine);
        }

        playerResponseText.text = message;

        currentMessageRoutine = StartCoroutine(ClearMessageAfterDelay());


    }

    private IEnumerator ClearMessageAfterDelay()
    {
        yield return new WaitForSeconds(messageDuration);

        playerResponseText.text = " ";
        currentMessageRoutine = null;
    }
}
