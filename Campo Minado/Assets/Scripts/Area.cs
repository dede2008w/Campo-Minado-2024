using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour, IArea
{
    [SerializeField] bool bomba;
    public bool revelado, bandeira;

    int indexI, indexJ;

    [SerializeField] Sprite[] spritesVazios;
    [SerializeField] Sprite bombaSprite, bandeiraSprite, spriteOriginal;

    public bool Bomba { get => bomba; set => bomba = value; }


    public delegate void AreaClickedDelegate(int i, int j);
    public event AreaClickedDelegate OnAreaClicked;

    private void Start()
    {
        spriteOriginal = GetComponent<SpriteRenderer>().sprite;
    }

    public void DefinirIndex(int i, int j)
    {
        indexI = i;
        indexJ = j;
    }

    public void Clicado()
    {
        OnAreaClicked?.Invoke(indexI, indexJ);

        if (GameManager.instance.ModoBandeira)
        {
            TransformarBandeira();
        }
        else
        {
            Revelar();
        }
    }

    void TransformarBandeira()
    {
        if (!bandeira)
        {
            bandeira = true;
            GetComponent<SpriteRenderer>().sprite = bandeiraSprite;
        }
        else
        {
            bandeira = false;
            GetComponent<SpriteRenderer>().sprite = spriteOriginal;
        }
    }

    void Revelar()
    {
        if (!revelado && !bandeira)
        {
            if (bomba)
            {
                GameManager.instance.GameOver();
            }
            else
            {
                revelado = true;
                GetComponent<SpriteRenderer>().sprite = spritesVazios[GameManager.instance.ChecarEntorno(indexI, indexJ)];
                GameManager.instance.ChecarVitoria();
            }
        }
    }

    public void RevelarBomba()
    {
        revelado = true;
        GetComponent<SpriteRenderer>().sprite = bombaSprite;
    }
}
