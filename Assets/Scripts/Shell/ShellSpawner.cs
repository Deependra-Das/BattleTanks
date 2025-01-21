using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellSpawner : MonoBehaviour
{
    [SerializeField]
    private ShellView _shellView;

    [System.Serializable]
    public class Shell
    {
        public ShellTypes shellType;
        public Material shellMatColor;
        public float maxDamage;
        public float explosionForce;             
        public float maxLifeTime;                   
        public float explosionRadius;
    }

    [SerializeField]
    private List<Shell> _shellList;

    private void Start()
    {
        SpawnShell(ShellTypes.Normal);
    }

    public void SpawnShell(ShellTypes shellType)
    {
        Shell shell = null;
        switch (shellType)
        {
            case ShellTypes.Normal:
                shell = _shellList[0];
                break;
            case ShellTypes.Medium:
                shell = _shellList[1];
                break;
            case ShellTypes.Heavy:
                shell = _shellList[2];
                break;
        }
        if (shell != null)
        {
            ShellModel shellModel = new ShellModel(
                shell.shellType,
                shell.shellMatColor,
                shell.maxDamage,
                shell.explosionForce,
                shell.maxLifeTime,
                shell.explosionRadius
            );

            ShellController shellController = new ShellController(shellModel, _shellView);
        }
        else
        {
            Debug.Log("Shell data not found");
        }
    }

}
