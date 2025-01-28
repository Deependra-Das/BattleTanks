using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TankSelection : MonoBehaviour
{
    public void GreenTankSelected()
    {
       GameService.Instance.StartGame(TankTypes.GreenTank);
        this.gameObject.SetActive(false);
    }

    public void BlueTankSelected()
    {
        GameService.Instance.StartGame(TankTypes.BlueTank);
        this.gameObject.SetActive(false);
    }

    public void RedTankSelected()
    {
        GameService.Instance.StartGame(TankTypes.RedTank);
        this.gameObject.SetActive(false);
    }
    public void OnBackButtonPressed()
    {
        SceneManager.LoadScene(0);
    }
}
