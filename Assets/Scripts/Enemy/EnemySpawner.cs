using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TankSpawner;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private EnemyView _enemyView;

    [SerializeField]
    private EnemyRadarView _enemyRadarView;

    [SerializeField]
    private EnemyScriptableObject[] _enemyConfigurations;

    [System.Serializable]
    public class Enemy
    {
        public EnemyTypes enemyType;
        public Vector3 spawnPosition;
        public Vector3 spawnRotation;
        public Transform[] patrolPoints;
    }

    [SerializeField]
    private List<Enemy> _enemyList;

    public void CreateEnemy()
    {
        for (int i = 0; i < _enemyList.Count; i++)
        {
            EnemyScriptableObject enemyConfig = null;
            switch (_enemyList[i].enemyType)
            {
                case EnemyTypes.HeavyAssault:
                    enemyConfig = _enemyConfigurations[0];
                    break;
                case EnemyTypes.Scout:
                    enemyConfig = _enemyConfigurations[1];
                    break;
                case EnemyTypes.Artillery:
                    enemyConfig = _enemyConfigurations[2];
                    break;
            }
            Enemy enemy = _enemyList[i];

            if (enemy != null)
            {
                EnemyModel enemyModel = new EnemyModel(
                    enemyConfig,
                    enemy.spawnPosition,
                    enemy.spawnRotation,
                    enemy.patrolPoints
                );

                EnemyController enemyController = new EnemyController(enemyModel, _enemyView, _enemyRadarView);

            }
            else
            {
                Debug.Log("Enemy data not found");
            }
        }
    }

}
