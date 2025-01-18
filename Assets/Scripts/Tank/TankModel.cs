using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel
{
    private TankController _tankController;
      
    private float _movementSpeed;
    private float _rotationSpeed;
    private TankTypes _tankType;
    private Material _tankMatColor;


    public TankModel(TankTypes tankType, float movementSpeed, float rotationSpeed, Material tankMatColor) 
    {
        _movementSpeed=movementSpeed;
        _rotationSpeed=rotationSpeed;
        _tankType=tankType;
        _tankMatColor=tankMatColor;            
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
    public TankTypes GetTankType()
    {
        return _tankType;
    }
    public Material GetTankMaterialColor()
    {
        return _tankMatColor;
    }
}
