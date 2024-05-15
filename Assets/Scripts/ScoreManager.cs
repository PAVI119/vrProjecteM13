using System.Collections;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score = 0; // Variable para mantener la puntuación
    public TextMeshProUGUI scoreText; // Referencia al componente TextMeshPro
    private bool canScore = true; // Variable para controlar si se puede incrementar la puntuación

    private void OnTriggerEnter(Collider collision)
    {
        // Verifica si el objeto con el que se colisionó es uno de los cubos de puntos y si se puede incrementar la puntuación
        if (canScore && (collision.gameObject.name == "PointCube1" || collision.gameObject.name == "PointCube2"))
        {
            score += 1; // Incrementa la puntuación
            scoreText.text = score.ToString(); // Actualiza el texto
            canScore = false; // Desactiva la capacidad de incrementar la puntuación temporalmente
            StartCoroutine(EnableScoringAfterDelay(0.5f)); // Espera medio segundo antes de permitir la puntuación nuevamente
        }
    }

    IEnumerator EnableScoringAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Espera el tiempo especificado
        canScore = true; // Activa la capacidad de incrementar la puntuación nuevamente
    }
}