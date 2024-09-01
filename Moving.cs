using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    private Rigidbody physics;
    private Transform playerTransform;
    private Animator playerAnimations;
    private bool forward;
    private bool backward;
    private bool left;
    private bool right;
    private bool isSprinting;
    private float VelocityX = 0.0f;
    private float VelocityY = 0.0f;
    public float movementSpeed;
    public float rotationSpeed;
    void Start()
    {
        physics = player.GetComponent<Rigidbody>();
        playerTransform = player.transform;
        playerAnimations = player.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        forward = Input.GetKey("w");
        backward = Input.GetKey("s");
        left = Input.GetKey("a");
        right = Input.GetKey("d");
        isSprinting = Input.GetKey(KeyCode.LeftShift);

        if (forward)
        {
            Debug.Log("Forward...");
            if (isSprinting)
            {
                if(VelocityY < 3.0f)
                {
                    VelocityY += Time.deltaTime * 1.5f;
                }
            } else
            {
                if(VelocityY < 1.5f)
                {
                    VelocityY += Time.deltaTime;
                } else
                {
                    VelocityY -= Time.deltaTime;
                }
            }
        } 
        
        if (backward)
        {
            if (isSprinting)
            {
                if (VelocityY > -3.0f)
                {
                    VelocityY -= Time.deltaTime * 1.5f;
                }
            }
            else
            {
                if (VelocityY > -1.5f)
                {
                    VelocityY -= Time.deltaTime;
                }
                else
                {
                    VelocityY += Time.deltaTime;
                }
            }
        }

        if (left)
        {
            if(VelocityX > -3)
            {
                VelocityX -= Time.deltaTime * 3f;
            } 
        }
        
        if (right)
        {
            if (VelocityX < 3)
            {
                VelocityX += Time.deltaTime * 3f;
            }
        }

        if (!forward && !backward)
        {
            if(VelocityY > 0f)
            {
                VelocityY -= Time.deltaTime * 1.5f;
            } 
            else if(VelocityY < 0f)
            {
                VelocityY += Time.deltaTime * 1.5f;
            }
        }

        if (!left && !right)
        {
            if (VelocityX > 0f)
            {
                VelocityX -= Time.deltaTime * 3f;
            }
            else if (VelocityX < 0f)
            {
                VelocityX += Time.deltaTime * 3f;
            }
        }

        playerAnimations.SetFloat("Velocity X", VelocityX);
        playerAnimations.SetFloat("Velocity Z", VelocityY);

        if (forward)
        {
            playerTransform.Translate(0, 0, 1 * movementSpeed);
        }

        if (backward)
        {
            playerTransform.Translate(0, 0, -1 * movementSpeed);
        }

        if (left)
        {
            playerTransform.Rotate(0, 1 * rotationSpeed, 0);
        }

        if (right)
        {
            playerTransform.Rotate(0, -1 * rotationSpeed, 0);
        }

    }
}
