using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScipt : MonoBehaviour
{
    private void OnBecameInvisible() {
        // Destroy the game object when it becomes invisible
        Destroy(gameObject);
    }
}
