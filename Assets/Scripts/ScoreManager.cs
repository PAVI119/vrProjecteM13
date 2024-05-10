using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score = 0; // Variable para mantener la puntuaci�n
    public TextMeshProUGUI scoreText; // Referencia al componente TextMeshPro

    private void OnTriggerEnter(Collider collision)
    {
        // Verifica si el objeto con el que se colision� es uno de los cubos de puntos
        if (collision.gameObject.name == "PointCube1" || collision.gameObject.name == "PointCube2")
        {
            score += 1; // Incrementa la puntuaci�n
            scoreText.text = score.ToString();// Actualiza el texto
        }
    }
}
