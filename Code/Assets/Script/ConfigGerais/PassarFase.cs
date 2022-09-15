using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PassarFase : MonoBehaviour
{
    public void Passar(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
