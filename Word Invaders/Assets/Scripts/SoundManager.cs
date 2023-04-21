using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource mySounds;
    public AudioClip ButtonHoverSound;
    public AudioClip clickSound;

    public void HoverSound() {
        Debug.Log("Hovering...");
        mySounds.PlayOneShot(ButtonHoverSound);
    }

    public void ClickSound() {
        Debug.Log("Clicking...");
        mySounds.PlayOneShot(clickSound);
    }
}
