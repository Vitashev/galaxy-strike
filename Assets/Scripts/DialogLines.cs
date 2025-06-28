using TMPro;
using UnityEngine;

public class DialogLines : MonoBehaviour
{
    [SerializeField] string[] dialogLines; // Array to hold the dialog lines
    [SerializeField] TMP_Text dialogText; // Reference to the UI Text component to display the dialog

    int currentLineIndex = 0; // Index to track the current dialog line
    public void NextLine()
    {
        Debug.Log("NextLine called. Current line index: " + currentLineIndex);
        if (currentLineIndex < dialogLines.Length)
        {
            dialogText.text = dialogLines[currentLineIndex];
            currentLineIndex++; // Move to the next line
        }
    }
}
