using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyScript : MonoBehaviour
{
    [SerializeField]
    private float speed = 10;
    private Vector3 jumpVector;

    private Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }   

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized * Time.deltaTime * speed;
        Vector3 pointToLookAt = transform.position + moveDirection * 100;
        transform.position += moveDirection;
        transform.LookAt(pointToLookAt);

        if (Input.GetKeyUp(KeyCode.Space)) {
            rigidBody.AddForce(0, 10f, 0, ForceMode.Impulse);
        }
    }
}
