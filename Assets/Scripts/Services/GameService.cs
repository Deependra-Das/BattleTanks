using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameService : GenericMonoSingleton<GameService>
{
    [SerializeField]
    private TankSpawner _tankSpawner;

    [SerializeField]
    private TargetSpawner _targetSpawner;

    [SerializeField]
    private EnemySpawner _enemySpawner;

    [SerializeField]
    private MarkerUI _markerUIObj;

    public void StartGame(TankTypes tankType)
    {
        _tankSpawner.CreateTank(tankType);
        _targetSpawner.CreateTargets();
        _markerUIObj.SetTargetList();
        _enemySpawner.CreateEnemy();
    }
}
