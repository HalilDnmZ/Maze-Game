using UnityEngine;

public class KeyLock : MonoBehaviour
{
    private bool horizontalKeyPressed = false;
    private bool verticalKeyPressed = false;
    private float cooldownTime = 1f;  // Cooldown time in seconds
    private float lastKeyPressTime;

    // Update is called once per frame
    void Update()
    {
        // Check if the horizontal and vertical keys are pressed
        bool horizontalKey = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow);
        bool verticalKey = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow);

        // Handle the horizontal key
        if (horizontalKey)
        {
            if (!horizontalKeyPressed && Time.time - lastKeyPressTime >= cooldownTime)
            {
                horizontalKeyPressed = true;
                verticalKeyPressed = false;
                lastKeyPressTime = Time.time;
            }
        }

        // Handle the vertical key
        if (verticalKey)
        {
            if (!verticalKeyPressed && Time.time - lastKeyPressTime >= cooldownTime)
            {
                verticalKeyPressed = true;
                horizontalKeyPressed = false;
                lastKeyPressTime = Time.time;
            }
        }

        // Disable keys if one is pressed
        if (horizontalKeyPressed || verticalKeyPressed)
        {
            DisableOtherKeys(horizontalKeyPressed, verticalKeyPressed);
        }
    }

    // Disable other keys
    private void DisableOtherKeys(bool horizontal, bool vertical)
    {
        // You can modify the behavior as per your requirements.
        // In this example, we are simulating key locking by printing messages.
        // Replace this with your actual logic to disable keys in your game.

        if (horizontal)
        {
            Debug.Log("Horizontal key pressed. Locking vertical keys.");
        }
        else if (vertical)
        {
            Debug.Log("Vertical key pressed. Locking horizontal keys.");
        }
    }
}
