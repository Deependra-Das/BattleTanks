﻿using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class TankController
{
    private TankModel _tankModel;
    private TankView _tankView;
    private Rigidbody _tankRB;


    public TankController(TankModel tankModel, TankView tankView)
    {
        _tankModel = tankModel;
        _tankModel.SetTankController(this);

        _tankView = GameObject.Instantiate<TankView>(tankView);
        _tankRB = _tankView.GetRigidBody();
        _tankView.SetTankController(this);

        _tankView.ChangeColor(_tankModel.GetTankMaterialColor());
    }

    public void Move(float movement, float movementSpeed)
    {
        _tankRB.velocity = _tankView.transform.forward * movement * movementSpeed;
    }

    public void Rotate(float rotation, float rotationSpeed)
    {
        Vector3 vector = new Vector3(0f, rotation * rotationSpeed, 0f);
        Quaternion deltaRotation = Quaternion.Euler(vector * Time.deltaTime);
        _tankRB.MoveRotation(_tankRB.rotation * deltaRotation);
    }

    public float GetMovementSpeed()
    {
        return _tankModel.GetMovementSpeed();
    }
    public float GetRotationSpeed()
    {
        return _tankModel.GetRotationSpeed();
    }
}
