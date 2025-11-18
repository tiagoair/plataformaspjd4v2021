using UnityEngine;

public class MarcadorDeVolta : MonoBehaviour
{
    public CronometroVoltas cronometro;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            cronometro.RegistrarVolta();
        }
    }
}
