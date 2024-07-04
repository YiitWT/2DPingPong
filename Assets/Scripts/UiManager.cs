using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public TextMeshProUGUI aiScoreText;
    public TextMeshProUGUI PlayerScoreText;
    public Slider speedSlider;
    public Slider hardnessSlider;
    public Slider  playerSpeed;
    public GameObject ai_obj;
    public GameObject player_obj;

    private void Start()
    {
        PlayerController player = player_obj.GetComponent<PlayerController>();
        Ai ai = ai_obj.GetComponent<Ai>();
        speedSlider.onValueChanged.AddListener((v) => { ai.moveSpeed = v; });
        hardnessSlider.onValueChanged.AddListener((v) => { ai.hardness = v; });
        playerSpeed.onValueChanged.AddListener((v) => { player.speed = v; });
    }


    public void resetScore()
    {
        PlayerScoreText.text = "0";
        aiScoreText.text = "0";
    }
}
