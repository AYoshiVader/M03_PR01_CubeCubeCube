using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public Transform scorer;
    public TextMeshProUGUI scoreText;
    void Update()
    {
        scoreText.text = scorer.position.z.ToString("0");
    }
}
