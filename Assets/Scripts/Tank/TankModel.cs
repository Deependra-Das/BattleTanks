using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel
{
    private TankController _tankController;
      
    private float _movementSpeed;
    private float _rotationSpeed;

    public TankModel(float movementSpeed, float rotationSpeed) 
    {
        _movementSpeed=movementSpeed;
        _rotationSpeed=rotationSpeed;
    }

    public void SetTankController(TankController tankController)
    {
        _tankController = tankController;
    }

    public float GetMovementSpeed()
    {
        return _movementSpeed;
    }
    public float GetRotationSpeed()
    {
        return _rotationSpeed;
    }
}
