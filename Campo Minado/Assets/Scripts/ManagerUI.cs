using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ManagerUI : MonoBehaviour
{
    [SerializeField]
    Image barraDeDificuldade;

    [SerializeField] Gradient corDaBarra;

    [SerializeField] TextMeshProUGUI gameOverText;

    private void OnEnable()
    {

        GameManager.instance.OnGameOver += OnGameOver;
        GameManager.instance.OnVictory += OnVictory;
    }

    private void OnDisable()
    {

        GameManager.instance.OnGameOver -= OnGameOver;
        GameManager.instance.OnVictory -= OnVictory;
    }

    public void AtualizarBarra(float value)
    {
        barraDeDificuldade.fillAmount = value;
        barraDeDificuldade.color = corDaBarra.Evaluate(value);
    }

    public void AtualizarTexto(bool venceu)
    {
        if (venceu)
        {
            gameOverText.text = "Vitoria";
        }
        else
        {
            gameOverText.text = "Derrota";
        }
    }

    private void OnGameOver()
    {
        AtualizarTexto(false);
    }

    private void OnVictory()
    {
        AtualizarTexto(true);
    }
}
