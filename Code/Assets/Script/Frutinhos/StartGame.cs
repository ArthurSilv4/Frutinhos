using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public Controle Controle;

    void OnMouseDown()
    {
        Controle.StartGame();
    }

    public void Aparecer()
    {
        gameObject.SetActive(true);
    }
}
