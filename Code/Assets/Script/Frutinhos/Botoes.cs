using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botoes : MonoBehaviour
{

    public Controle Controle;
    public int idBotao;

    void OnMouseDown()
    {
        if(Controle.gamestate == GameState.RESPONDER)
        {
            Controle.StartCoroutine("Responder", idBotao);

        }

    }
}
