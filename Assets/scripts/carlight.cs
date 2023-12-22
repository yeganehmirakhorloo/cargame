using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carlight : MonoBehaviour
{

    public Light carLight;
    public string tunnelTag = "tunnel";

    private void Start()
    {
        // Ensure that the car light is initially turned off
        if (carLight != null)
        {
            carLight.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the car enters a collider with the specified tag
        if (other.CompareTag(tunnelTag))
        {
            // Turn on the car light when entering the tunnel
            if (carLight != null)
            {
                carLight.enabled = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the car exits a collider with the specified tag
        if (other.CompareTag(tunnelTag))
        {
            // Turn off the car light when exiting the tunnel
            if (carLight != null)
            {
                carLight.enabled = false;
            }
        }
    }

}
