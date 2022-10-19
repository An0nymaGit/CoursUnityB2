using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private RotationController rotationController;
    [SerializeField] private MoveController moveController;
    
    void Update()
    {
        rotationController.inputRotationX = Input.GetAxis("Mouse Y");
        rotationController.inputRotationY = Input.GetAxis("Mouse X");

        moveController.horizontalInput = Input.GetAxis("Horizontal");
        moveController.verticalInput = Input.GetAxis("Vertical");
    }
}
