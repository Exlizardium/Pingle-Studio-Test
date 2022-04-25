using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private InputHandler input;

    [SerializeField] private float moveSpeed = 50;
    [SerializeField] private float rotateSpeed = 15;

    [SerializeField] private new Camera camera;

    private void Awake()
    {
        input = GetComponent<InputHandler>();
    }

    private void Update()
    {
        var targetVector = new Vector3(input.InputVector.x, 0, input.InputVector.y);

        var movementVector = MoveTowardsTarget(targetVector);
        RotateToMovementVector(movementVector);
    }

    private void RotateToMovementVector( Vector3 movementVector)
    {
        if(movementVector.magnitude == 0) { return; }
        var rotation = Quaternion.LookRotation(movementVector);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotateSpeed);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotateSpeed * Time.deltaTime);

    }

    private Vector3 MoveTowardsTarget(Vector3 targetVector)
    {
        var speed = moveSpeed * Time.deltaTime;

        targetVector = Quaternion.Euler(0, camera.gameObject.transform.eulerAngles.y, 0) * targetVector;
        var targetPosition = transform.position + targetVector * speed;
        transform.position = targetPosition;
        return targetVector;
    }
}
