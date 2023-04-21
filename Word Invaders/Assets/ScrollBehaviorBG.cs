using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBehaviorBG : MonoBehaviour
{
    public float speed = 4f;
    private Vector3 StartPosition;

    // Start is called before the first frame update
    /// <Brief> Gets the starting position of the background image
    void Start()
    {
        StartPosition = transform.position; 
    }

    // Update is called once per frame
    /// <Brief> Makes the background scroll
    void Update()
    {
        /// <Note> BG scrolls from left to right
        transform.Translate(Vector3.left * speed * Time.deltaTime); 
        
        /// <Note> If BG reaches -1444.24 on x-axis, then repeat from starting position
        if (transform.position.x < -1444.24f) {
            transform.position = StartPosition;
        }
    }
}
