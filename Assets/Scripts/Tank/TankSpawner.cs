using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSpawner : MonoBehaviour
{
    [SerializeField]
    private TankView _tankView;

    void Start()
    {
        CreateTank();
    }

    private void CreateTank()
    {
       TankModel tankModel = new TankModel();
       TankController tankController = new TankController(tankModel, _tankView);
    }


}
