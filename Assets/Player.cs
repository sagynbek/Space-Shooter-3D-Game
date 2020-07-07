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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float verticalThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = horizontalThrow * Time.deltaTime * xSpeed;
        float yOffset = verticalThrow * Time.deltaTime * ySpeed;

        float rawNewXPos = transform.localPosition.x + xOffset;
        float rawNewYPos = transform.localPosition.y + yOffset;

        float clampedXPos = Mathf.Clamp(rawNewXPos, -xClamp, xClamp);
        float clampedYPos = Mathf.Clamp(rawNewYPos, -yClamp, yClamp);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
}
