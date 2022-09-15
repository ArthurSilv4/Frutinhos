using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transisao : MonoBehaviour
{
    private Animator anin;

    private void Start()
    {
        anin = gameObject.GetComponent<Animator>();

        gameObject.SetActive(true);

    }

    private void Update()
    {
        StartCoroutine(Fechar());
    }

    IEnumerator Fechar()
    {
        yield return new WaitForSeconds(0.8f);
        gameObject.SetActive(false);
    }
}
