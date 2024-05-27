using UnityEngine;
using UnityEngine.UI;

public class switchonoff : MonoBehaviour
{
    public GameObject[] buttons; // Array to hold buttons
    private bool[] buttonStates; // Array to track button states (on or off)
    private bool gameOver = false;

    void Start()
    {
        // Initialize button states
        buttonStates = new bool[buttons.Length];

        // Randomly turn buttons on or off
        for (int i = 0; i < buttons.Length; i++)
        {
            bool isOn = Random.Range(0, 2) == 1;
            buttonStates[i] = isOn;
            buttons[i].GetComponent<Button>().interactable = isOn;

            // Add listener to button
            int index = i; // Capture the current value of i
            buttons[i].GetComponent<Button>().onClick.AddListener(() => OnButtonClick(index));
        }
    }

    void OnButtonClick(int index)
    {
        if (gameOver)
            return;

        // Toggle the button state
        buttonStates[index] = !buttonStates[index];
        buttons[index].GetComponent<Button>().interactable = buttonStates[index];

        if (!buttonStates[index])
        {
            GameOver();
        }
        else
        {
            CheckIfTaskCompleted();
        }
    }

    void GameOver()
    {
        gameOver = true;
        Debug.Log("Game Over!");
        // Implement game over logic here
    }

    void CheckIfTaskCompleted()
    {
        foreach (bool state in buttonStates)
        {
            if (!state)
                return;
        }

        Debug.Log("Task Completed!");
        // Implement task completed logic here
    }
}
