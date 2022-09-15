using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameState
{
    SEQUENCIA,
    RESPONDER,
    ERRO
}

public class Controle : MonoBehaviour
{
    public GameState gamestate;

    public GameObject particula;

    public Text pontosText;

    public Text rodadaTextGameOver;
    public Text pontosTextGameOver;

    public List<int> sequencia;

    public GameObject startButton;

    public GameObject vitoria;

    public GameObject fimDeJogo;

    public GameObject[] botoes;

    private AudioSource fonteAudio;
    public AudioClip[] sons;

    private int rodada, qtdCores, idResposta, pontos;

    void Start()
    {
        fimDeJogo.SetActive(false);

        qtdCores = 1;
        fonteAudio = GetComponent<AudioSource>();
    }

    public void StartGame()
    {
        rodada = 0;
        pontos = 0;

        pontosText.text = "" + pontos;


        sequencia.Clear();

        foreach(GameObject obj in botoes)
        {
            //obj.GetComponent<SpriteRenderer>().color = Color.white;
        }

        StartCoroutine("Sequencia", qtdCores);

        startButton.SetActive(false);

    }

    IEnumerator Sequencia(int qtd)
    {
        //Repetir as cores
        foreach (int x in sequencia)
        {
            yield return new WaitForSeconds(1);
            //botoes[x].GetComponent<SpriteRenderer>().color = Color.red;

            botoes[x].GetComponent<Animator>().SetTrigger("Treme");
            fonteAudio.PlayOneShot(sons[x]);

            yield return new WaitForSeconds(1.5f);
            //botoes[x].GetComponent<SpriteRenderer>().color = Color.white;
        }

        //Cor nova
        for (int i = qtd; i > 0; i--)
        {
            yield return new WaitForSeconds(1);
            int sorteio = Random.Range(0, botoes.Length);
            //botoes[sorteio].GetComponent<SpriteRenderer>().color = Color.red;

            botoes[sorteio].GetComponent<Animator>().SetTrigger("Treme");
            fonteAudio.PlayOneShot(sons[sorteio]);

            sequencia.Add(sorteio);

            yield return new WaitForSeconds(1.5f);
            //botoes[sorteio].GetComponent<SpriteRenderer>().color = Color.white;
        }

        
        gamestate = GameState.RESPONDER;
        idResposta = 0;
    }

    IEnumerator Responder(int idBotao)
    {
        //botoes[idBotao].GetComponent<SpriteRenderer>().color = Color.red;

        botoes[idBotao].GetComponent<Animator>().SetTrigger("Treme");

        if (sequencia[idResposta] == idBotao)
        {
            fonteAudio.PlayOneShot(sons[idBotao]);

            if (pontos > 12)
            {
                gamestate = GameState.ERRO;
                StartCoroutine(Vitoria());
            }
        }
        else
        {
            gamestate = GameState.ERRO;
            StartCoroutine("GameOver");
        }

        

        idResposta += 1;
        if(idResposta == sequencia.Count)
        {
            gamestate = GameState.SEQUENCIA;

            rodada += 1;
            pontos += 2;

            yield return new WaitForSeconds(0.5f);
            pontosText.text = "" + pontos;

            yield return new WaitForSeconds(1);
            StartCoroutine("Sequencia", qtdCores);
        }
        yield return new WaitForSeconds(0.3f);
       // botoes[idBotao].GetComponent<SpriteRenderer>().color = Color.white;
    }

    IEnumerator GameOver()
    {
        sequencia.Clear();

        pontosTextGameOver.text = "" + pontos;
        rodadaTextGameOver.text = "" + (rodada+1);

        fonteAudio.PlayOneShot(sons[3]);

        yield return new WaitForSeconds(1);
        for(int i = 3; i > 0; i--)
        {
            foreach (GameObject obj in botoes)
            {
                //obj.GetComponent<SpriteRenderer>().color = Color.red;

                obj.GetComponent<Animator>().SetTrigger("Treme");
            }
            yield return new WaitForSeconds(0.3f);
            foreach (GameObject obj in botoes)
            {
                //obj.GetComponent<SpriteRenderer>().color = Color.white;
            }
            yield return new WaitForSeconds(0.3f);
        }

        int idB = 0;
        for (int i = 12; i > 0; i--)
        {
            //botoes[idB].GetComponent<SpriteRenderer>().color = Color.red;

            botoes[idB].GetComponent<Animator>().SetTrigger("Treme");
            yield return new WaitForSeconds(0.1f);
            //botoes[idB].GetComponent<SpriteRenderer>().color = Color.white; 
            idB += 1; if (idB == 3) { idB = 0; }

        }

        yield return new WaitForSeconds(0.5f);

        fimDeJogo.SetActive(true);
    }

    IEnumerator Vitoria()
    {
        Instantiate(particula);

        sequencia.Clear();

        fonteAudio.PlayOneShot(sons[4]);

        yield return new WaitForSeconds(1.5f);
        for (int i = 3; i > 0; i--)
        {
            foreach (GameObject obj in botoes)
            {
                //obj.GetComponent<SpriteRenderer>().color = Color.green;

                obj.GetComponent<Animator>().SetTrigger("Treme");
            }
            yield return new WaitForSeconds(0.3f);
            foreach (GameObject obj in botoes)
            {
                //obj.GetComponent<SpriteRenderer>().color = Color.white;
            }
            yield return new WaitForSeconds(0.3f);
        }

        int idB = 0;
        for (int i = 12; i > 0; i--)
        {
            //botoes[idB].GetComponent<SpriteRenderer>().color = Color.green;

            botoes[idB].GetComponent<Animator>().SetTrigger("Treme");
            yield return new WaitForSeconds(0.1f);
            //botoes[idB].GetComponent<SpriteRenderer>().color = Color.white;
            idB += 1; if (idB == 3) { idB = 0; }

        }

        yield return new WaitForSeconds(0.5f);

        vitoria.SetActive(true);
        
    }
}
