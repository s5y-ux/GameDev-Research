using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LessComplicatedMovement : MonoBehaviour
{

    public GameObject Player;
    private Transform PlayerSpace;
    private Animator PlayerAnimations;
    public float movementSpeed;
    public float sprintSpeed;
    public float rotationSpeed;

    void Start()
    {
        PlayerSpace = Player.GetComponent<Transform>();
        PlayerAnimations = Player.GetComponent<Animator>();
    }

    void Update()
    {
        bool MovingForward = Input.GetKey("w");
        bool MovingBackwards = Input.GetKey("s");
        bool MovingLeft = Input.GetKey("a");
        bool MovingRight = Input.GetKey("d");
        bool isSprinting = Input.GetKey(KeyCode.LeftShift);

        if (!isSprinting)
        {
            PlayerAnimations.SetBool("isSprinting", false);
        } else
        {
            PlayerAnimations.SetBool("isSprinting", true);
        }

        if (MovingForward)
        {
            PlayerAnimations.SetBool("isWalkingForward", true);
            PlayerAnimations.SetBool("isWalkingBackwards", false);
            if (isSprinting)
            {
                PlayerSpace.Translate(0, 0, 1 * sprintSpeed);
            } else
            {
                PlayerSpace.Translate(0, 0, 1 * movementSpeed);
            }
        } else if (MovingBackwards)
        {
            PlayerAnimations.SetBool("isWalkingForward", false);
            PlayerAnimations.SetBool("isWalkingBackwards", true);
            if (isSprinting)
            {
                PlayerSpace.Translate(0, 0, -1 * sprintSpeed);
            }
            else
            {
                PlayerSpace.Translate(0, 0, -1 * movementSpeed);
            }
        }
        else
        {
            PlayerAnimations.SetBool("isWalkingForward", false);
            PlayerAnimations.SetBool("isWalkingBackwards", false);
        }

        if (MovingLeft)
        {
            PlayerSpace.Rotate(0, -1 * rotationSpeed, 0);
        }
        else if (MovingRight)
        {
            PlayerSpace.Rotate(0, 1 * rotationSpeed, 0);
        }
    }
}
