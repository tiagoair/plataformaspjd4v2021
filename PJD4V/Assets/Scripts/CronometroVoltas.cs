using UnityEngine;
using TMPro;

public class CronometroVoltas : MonoBehaviour
{
    public TextMeshProUGUI textoCronometro;
    public TextMeshProUGUI textoVoltas;

    private float tempoAtual = 0f;
    private int numeroVoltas = 0;

    void Update()
    {
        tempoAtual += Time.deltaTime;
        textoCronometro.text = "Tempo: " + tempoAtual.ToString("F2");
    }

    public void RegistrarVolta()
    {
        numeroVoltas++;
        textoVoltas.text = "Voltas: " + numeroVoltas;
        tempoAtual = 0f;
    }
}
