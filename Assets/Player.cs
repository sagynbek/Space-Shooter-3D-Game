using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("In m/s")][SerializeField] float xSpeed = 15f;
    [Tooltip("In m/s")] [SerializeField] float xClamp = 5f;

    [Tooltip("In m/s")] [SerializeField] float ySpeed = 5f;
    [Tooltip("In m/s")] [SerializeField] float yClamp = 3f;

    [Tooltip("In m/s")] [SerializeField] float zSpeed = 60f;
    [Tooltip("In m/s")] [SerializeField] float zClamp = 60f;

    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float controlPitchFactor = -20f;

    [SerializeField] float positionYawFactor = 5f;

    [SerializeField] float controlRollFactor = -20f;
    

    float xThrow, yThrow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessRotation()
    {
        float pitch = transform.localPosition.y*positionPitchFactor + yThrow*controlPitchFactor;

        float yaw = transform.localPosition.x*positionYawFactor;

        float roll = xThrow * controlRollFactor;


        //float horizontalThrow = CrossPlatformInputManager.GetAxis("Horizontal");

        //float rawNewZRot = horizontalThrow * zSpeed* Time.deltaTime + transform.localRotation.z;
        //Debug.Log(rawNewZRot + " " +transform.localRotation.z);

        //float clampedZRot = Mathf.Clamp(rawNewZRot, -zClamp, zClamp);

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * xSpeed;
        float yOffset = yThrow * Time.deltaTime * ySpeed;

        float rawNewXPos = transform.localPosition.x + xOffset;
        float rawNewYPos = transform.localPosition.y + yOffset;

        float clampedXPos = Mathf.Clamp(rawNewXPos, -xClamp, xClamp);
        float clampedYPos = Mathf.Clamp(rawNewYPos, -yClamp, yClamp);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

}
