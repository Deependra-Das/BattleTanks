using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject tankPrefab;

    void Start()
    {
        Instantiate(tankPrefab, transform.position, Quaternion.identity);
    }


}
