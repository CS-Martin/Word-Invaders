using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject playerObject;
    public float shootSpeed = 10f;

    private bool canShoot = true;
    private Word currentWordObject;

    public void WordTyped(Word wordObject) {
        // Set the currentWordObject to the Word object that was typed
        currentWordObject = wordObject;
    }

    private void Update() {
        if (canShoot && currentWordObject != null && currentWordObject.display != null) {
            // Calculate the direction from the Shooter's current position to the target position
            Vector3 direction = currentWordObject.display.transform.position - playerObject.transform.position;

            // Calculate the angle between the Shooter's position and the target position
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Rotate the Shooter to face the target position
            playerObject.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            // Shoot the current word object
            Rigidbody2D wordRigidbody = currentWordObject.display.GetComponent<Rigidbody2D>();
            wordRigidbody.velocity = direction.normalized * shootSpeed;

            // Reset the currentWordObject to null
            currentWordObject = null;
        }
    }
}
