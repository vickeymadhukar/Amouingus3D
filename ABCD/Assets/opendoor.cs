using UnityEngine;
using UnityEngine.UI;

public class opendoor : MonoBehaviour
{
    private Animator doorAnimator;

  //  public Button openButton;  // UI Button to open the door
    public Button closeButton; // UI Button to close the door
    public float AnimationDuration = 20f;
    private bool isClosing = false;
    private AudioSource gatesound;
    private void Start()
    {
        // Assuming the script is attached to the GameObject with the Animator component
        doorAnimator = GetComponent<Animator>();
        gatesound = GetComponent<AudioSource>();
       
        // openButton.onClick.AddListener(OpenDoor);
        doorAnimator.SetBool("isclose", false);
       // closeButton.onClick.AddListener(CloseDoor);
    }

    private void Update()
    {
        closeButton.onClick.AddListener(CloseDoor);
        if (isClosing)
        {
            if (AnimationDuration > 0f)
            {
                AnimationDuration -= Time.deltaTime;

                if (AnimationDuration <= 0f)
                {
                    doorAnimator.SetBool("isclose", false);
                    gatesound.Play();
                    closeButton.interactable = true;

                }
            }
        }
        
    }
    private void OpenDoor()
    {
        // Trigger the "Open" animation
        doorAnimator.SetBool("isclose", false);
        gatesound.Play();
        
    }

    private void CloseDoor()
    {
        // Trigger the "Close" animation
        doorAnimator.SetBool("isclose", true);
        gatesound.Play();
        closeButton.interactable = false;
        isClosing = true;
        resetime();

}

    private void resetime()
    {
        AnimationDuration = 20f;
    }
}
