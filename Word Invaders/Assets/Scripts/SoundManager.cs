using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource mySounds;
    public AudioClip ButtonHoverSound;
    public AudioClip clickSound;
    public AudioClip gunshot;

    /// <Brief> Button hover sfx
    public void HoverSound() {
        Debug.Log("Hovering...");
        mySounds.PlayOneShot(ButtonHoverSound);
    }

    /// <Brief> Button clicking sfx
    public void ClickSound() {
        Debug.Log("Clicking...");
        mySounds.PlayOneShot(clickSound);
    }
    
    /// <Brief> Shooting sfx
    public void ShootingSound() {
        Debug.Log("Shooting...");
        mySounds.PlayOneShot(gunshot);
    }
}
