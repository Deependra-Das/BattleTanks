using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRadarView : MonoBehaviour
{
    private EnemyController _enemyController;

    public void SetEnemyController(EnemyController enemyController)
    {
        _enemyController = enemyController;
    }

    private void OnTriggerEnter(Collider other)
    {
        TankView tankView = other.gameObject.GetComponent<TankView>();

        if (tankView != null)
        {
            _enemyController.SetPlayerInRange(true);
            _enemyController.SetPlayerTransform(tankView.transform);

            _enemyController.SetPlayerInShootingRange(Vector3.Distance(transform.position,_enemyController.GetPlayerTransform().position) <= _enemyController.GetShootingRange());

            _enemyController.PausePatrolling();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        TankView tankView = other.gameObject.GetComponent<TankView>();

        if (tankView != null)
        {
            _enemyController.SetPlayerInRange(false);
            _enemyController.SetPlayerInShootingRange(false);

            _enemyController.ResumePatrolling();
        }
    }

    public void SetRadarParent(Transform spawnTransform)
    {
        this.transform.SetParent(spawnTransform);

        this.transform.position = spawnTransform.position;
        this.transform.localPosition = new Vector3(0f, 0f, 0f);
    }


}
