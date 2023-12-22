using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car : MonoBehaviour
{
    
  public float aceleration = 20f, airResistance = 1.0f, maxVelocity = 20f, minVelocity = -5f, maxTurnSpeed = 100f, gravity = 9.8f;
  public CharacterController Car;
  private float currentVelocity = 0f, yMovement = 0;
  

  // Update is called once per frame
  void Update()
  {
    float zMovement = Input.GetAxis("Vertical");
    float xMovement = Input.GetAxis("Horizontal") * Time.deltaTime;

    if (Car.isGrounded)
    {
      float currentAceleration = zMovement * aceleration;
      if (currentVelocity > 0)
      {
        currentAceleration -= airResistance;
      }
      if (currentVelocity < 0)
      {
        currentAceleration += airResistance;
      }
      currentAceleration *= Time.deltaTime;
      currentVelocity = Mathf.Clamp((currentVelocity + currentAceleration), minVelocity, maxVelocity);

      float turnSpeed = Mathf.Abs((currentVelocity / maxVelocity) * maxTurnSpeed);
      transform.Rotate(Vector3.up * xMovement * turnSpeed);
    }
    else
    {
      yMovement -= gravity * Time.deltaTime;
    }

    Vector3 moveDirection = transform.forward * currentVelocity + transform.up * yMovement;

    Car.Move(moveDirection * Time.deltaTime);
  }

}
