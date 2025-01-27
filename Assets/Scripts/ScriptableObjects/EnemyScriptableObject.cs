using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName= "EnemyScriptableObject", menuName= "ScriptableObjects/NewEnemyScriptableObject")]
public class EnemyScriptableObject : ScriptableObject
{
    public EnemyTypes enemyType;
    public float movementSpeed;
    public float rotationSpeed;
    public Material enemyMatColor;
    public float initialHealth;
    public float minLaunchForce;
    public float maxLaunchForce;
    public float maxChargeTime;
    public float waitTimeAtWaypoint;
    public float shootingCooldown;
    public float shootingRange;
}
