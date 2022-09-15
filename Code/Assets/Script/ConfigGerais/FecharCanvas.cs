using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FecharCanvas : MonoBehaviour
{
    public void Fechar(GameObject obj)
    {
        obj.SetActive(false);
    }
    public void Abrir(GameObject obj)
    {
        obj.SetActive(true);
    }
}
