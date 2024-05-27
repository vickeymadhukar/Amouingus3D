using UnityEngine;

public class soundsc : MonoBehaviour
{
    public float distanceThreshold = 10f;  // Distance threshold for sound activation
    public float fadeSpeed = 5f;  // Speed at which the sound fades

    private AudioSource audioSource;
    private float initialVolume;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        initialVolume = audioSource.volume;
        audioSource.loop = true;  // Set the loop property to true
    }

    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

            // Check if the player is within the distance threshold
            if (distanceToPlayer <= distanceThreshold)
            {
                // Play the sound at the initial volume
                audioSource.volume = initialVolume;

                // Adjust the volume based on the distance
                float normalizedDistance = Mathf.InverseLerp(0f, distanceThreshold, distanceToPlayer);
                audioSource.volume = Mathf.Lerp(0f, initialVolume, normalizedDistance);
            }
            else
            {
                // Fade out the sound when the player is beyond the distance threshold
                audioSource.volume = Mathf.Lerp(audioSource.volume, 0f, fadeSpeed * Time.deltaTime);
            }
        }
    }
}
