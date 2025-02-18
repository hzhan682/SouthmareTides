﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class boatMovement : MonoBehaviour
{

    private float m_moveSpeed = 0.0f;
    [SerializeField] private float m_moveSpeedDelta = 2.0f;
    [SerializeField] private float m_turnSpeed = 100.0f;

    private float m_currentV = 0;
    private float m_currentH = 0;

    private readonly float m_interpolation = 10;
    private Vector3 m_currentDirection = Vector3.zero;

    private void Update()
    {
        DirectUpdate();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void DirectUpdate()
    {
        float velocity = Input.GetAxis("Vertical");
        float rotation = Input.GetAxis("Horizontal");


        m_moveSpeed += velocity * m_moveSpeedDelta * Time.deltaTime;
        //Currently no rotating of the ship
        //transform.rotation = Quaternion.LookRotation(m_currentDirection);

        transform.Rotate(new Vector3(0, rotation * Time.deltaTime * m_turnSpeed, 0));
        transform.position += transform.forward * m_moveSpeed;
    }

    public void OnCollisionEnter(Collision collision)
    {
        //Check if the boat collided with a normal explore island
        if (collision.collider.tag == "Island_Explore")
        {
            SceneManager.LoadScene("ExploreIsland");
        }

        //check if the boat collided with a shipwreck island
        else if (collision.collider.tag == "Island_Shipwreck")
        {
            SceneManager.LoadScene("ExploreShipwreck");
        }

        //check if the boat collided with another boat
        else if (collision.collider.tag == "Ship_Explore")
        {
            SceneManager.LoadScene("ExploreShip");
        }

        //Check if hit a border wall
        else if (collision.collider.tag == "Explore_Border")
        {
            //hit a borderwall
        }

        else
        {
            Debug.Log("The other collider, tag: "+collision.collider.tag);
            Debug.Log("The other collider, transform: " + collision.collider.transform);
        }
    }

}
