using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float boostSpped = 30f;
    [SerializeField] float baseSpeed = 20f;

    Rigidbody2D rigidBody2D;
    SurfaceEffector2D surfaceEffector2D;

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        //!Recuperamos el objeto Surface Effector, del cual solo hay uno y esta en el terreno:
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();

    }

    void Update()
    {
        RotatePlayer();
        RespondToBoost();
    }

    private void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidBody2D.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidBody2D.AddTorque(-torqueAmount);
        }
    }

    private void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed = boostSpped;
        }
        else
        {
            surfaceEffector2D.speed = baseSpeed;
        }
    }

}
