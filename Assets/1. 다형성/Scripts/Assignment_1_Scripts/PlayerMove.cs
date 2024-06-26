using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Transform oTransform;
    Vector3 move;
    float runSpeed = 5.0f;
    Transform unityChanModel;
    Transform cameraTransform;
    Animator chanAnimator;

    void Start()
    {
        oTransform = transform;
        unityChanModel = transform.GetChild(0);
        cameraTransform = Camera.main.transform;

        chanAnimator = unityChanModel.GetComponent<Animator>();
    }

    void Update()
    {
        MoveUnityChan(1f);
    }

    void MoveUnityChan(float rate)
    {
        float tempMoveY = move.y;

        move.y = 0;

        Vector3 inputMoveXZ = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        //oTransform.position += inputMoveXZ * 5f * Time.deltaTime;

        float inputMoveXZMagnitude = inputMoveXZ.sqrMagnitude;

        inputMoveXZ = oTransform.TransformDirection(inputMoveXZ);

        if (inputMoveXZMagnitude <= 1)
        {
            inputMoveXZ *= runSpeed;
        }
        else
        {
            inputMoveXZ = inputMoveXZ.normalized * runSpeed;
        }

        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            Quaternion cameraRotation = cameraTransform.rotation;
           
            cameraRotation.x = cameraRotation.z = 0;
            oTransform.rotation = Quaternion.Slerp(oTransform.rotation, cameraRotation, 10.0f * Time.deltaTime);

            if (move != Vector3.zero)
            {
                Quaternion characterRotation = Quaternion.LookRotation(move);

                characterRotation.x = characterRotation.z = 0;

                unityChanModel.rotation = Quaternion.Slerp(unityChanModel.rotation, characterRotation, 10.0f * Time.deltaTime);
            }

            move = Vector3.MoveTowards(move, inputMoveXZ, rate * runSpeed);
        }
        else
        {
            move = Vector3.MoveTowards(move, Vector3.zero, (1 - inputMoveXZMagnitude) * rate);
        }

        float speed = move.sqrMagnitude;
        oTransform.position += move * Time.deltaTime;
        chanAnimator.SetFloat("Speed", speed);

        move.y = tempMoveY;
    }
}
