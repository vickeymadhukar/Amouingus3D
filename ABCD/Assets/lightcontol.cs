using UnityEngine;
using UnityEngine.UI;

public class lightcontol : MonoBehaviour
{
    public Light[] targetLights;
    public Button toggleButton;
    public float turnOffTime = 2f; // Time in seconds to keep the lights off

    private bool areLightsOn = true;
    private float timeOffEnd;
    private CharacterController characterController;

    void Start()
    {
        // Attach the button click event to the ToggleLights method
        toggleButton.onClick.AddListener(ToggleLights);

        // Get the CharacterController component
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Check if the lights are off and if it's time to turn them back on
        if (!areLightsOn && Time.time >= timeOffEnd)
        {
            TurnOnLights();
        }

        // Check for player input to toggle the lights
        if (characterController.isGrounded)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput);

            if (moveDirection.magnitude > 0.1f)
            {
                // Move the player
                characterController.Move(moveDirection * Time.deltaTime * 5f);
            }
        }
    }

    void ToggleLights()
    {
        if (areLightsOn)
        {
            TurnOffLights();
        }
        else
        {
            TurnOnLights();
        }
    }

    void TurnOnLights()
    {
        foreach (var light in targetLights)
        {
            light.enabled = true;
        }

        areLightsOn = true;
    }

    void TurnOffLights()
    {
        foreach (var light in targetLights)
        {
            light.enabled = false;
        }

        areLightsOn = false;

        // Set the time when the lights will turn back on
        timeOffEnd = Time.time + turnOffTime;
    }
}
