using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public PetStats petStats;
    public PetActions petActions;

    public TMP_Text hungerText;
    public TMP_Text energyText;
    public TMP_Text happinessText;
    public TMP_Text coinsText;

    void Update()
    {
        hungerText.text = "Голод: " + Mathf.RoundToInt(petStats.hunger);
        energyText.text = "Энергия: " + Mathf.RoundToInt(petStats.energy);
        happinessText.text = "Счастье: " + Mathf.RoundToInt(petStats.happiness);
        coinsText.text = "Монеты: " + petActions.coins;
    }
}