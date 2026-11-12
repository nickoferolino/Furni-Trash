using System;
using UnityEngine;

public static class FeedbackEvents
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static event Action<string> OnFeedbackRequested;

    public static void ShowFeedback(string message)
    {
        OnFeedbackRequested?.Invoke(message);
    }


}
