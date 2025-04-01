using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public Transform player;
    public TextMeshProUGUI scoreText;
    float scoreValue = 0;

    void Update()
    {
        scoreValue = player.position.z;
        scoreText.text = scoreValue.ToString("0");
    }
}
