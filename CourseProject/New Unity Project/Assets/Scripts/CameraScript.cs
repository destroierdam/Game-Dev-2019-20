using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    // The leftmost part of the scene that should be visible.
    float leftmostPosition = -7.7f;
    [SerializeField]
    // The rightmost part of the screent that should be visible.
    float rightmostPosition = 7.7f;
    [SerializeField]
    // The topmost part of the screen that should be visible.
    float topmostPosition;
    [SerializeField]
    private GameObject player;
    // The offset between the player and the camera position. Used for following the player
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = this.transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = player.transform.position + offset;
        if (leftmostPosition <= newPosition.x  && newPosition.x <= rightmostPosition ) {
            if (newPosition.y <= topmostPosition) {
                this.transform.position = newPosition;
            }
        }
    }
}
