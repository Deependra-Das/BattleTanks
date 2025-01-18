using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSpawner : MonoBehaviour
{
    [SerializeField]
    private TankView _tankView;

    [SerializeField]
    private float _movementSpeed;

    [SerializeField]
    private float _rotationSpeed;


    void Start()
    {
        CreateTank();
    }

    private void CreateTank()
    {
       TankModel tankModel = new TankModel(_movementSpeed,_rotationSpeed);
       TankController tankController = new TankController(tankModel, _tankView);
    }


}
