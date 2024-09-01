using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    private GameObject Target;
    private Transform TargetPosition;
    public GameObject ZombieObject;
    private Transform ZombiePosition;
    private Animator ZombieAnimations;
    public float rotationSpeed;

    void Start()
    {
        ZombieAnimations = ZombieObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            Target = other.gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Target != null && Target.name == "Player")
        {
            ZombiePosition = ZombieObject.transform;
            TargetPosition = Target.transform;
            ZombieAnimations.SetBool("isWalking", true);
            ZombiePosition.position = Vector3.MoveTowards(ZombiePosition.position, TargetPosition.position, Time.deltaTime);
            Vector3 newDirection = Vector3.RotateTowards(ZombiePosition.forward, TargetPosition.position - ZombiePosition.position, rotationSpeed * Time.deltaTime, 0.0f);
            ZombiePosition.rotation = Quaternion.LookRotation(newDirection);
        }
    }
}
