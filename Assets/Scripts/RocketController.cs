using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]
    private float rocketRotationSpeed;
    [SerializeField]
    private float rocketThrustSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();//Access the component
    }

    // Update is called once per frame
    void Update()
    {
        MoverocketUp();
    }

    private void MoverocketUp()
    {
        RocketThrust();

        RocketRotate();
    }

    private void RocketRotate()
    {
        // rb.freezeRotation = false;
        float speed = 100f;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rocketRotationSpeed = speed * Time.deltaTime;//Independence of the frame
            transform.Rotate(Vector3.forward * rocketRotationSpeed);
            print("Forward Rotation");
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.back * rocketRotationSpeed);
            print("Forward Rotation");
        }
    }

    private void RocketThrust()
    {
        float thrustSpeed = 100;
        rocketThrustSpeed = thrustSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddRelativeForce(Vector3.up * rocketThrustSpeed);//vector3.up = (0,1,0)
            print("Uparrow is pressed");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            string scenceName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(scenceName);
            
        }
    }

}
