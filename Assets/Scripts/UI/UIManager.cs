using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public PetStats petStats;
    public PetActions petActions;
    public DaySystem daySystem;

    public TMP_Text hungerText;
    public TMP_Text energyText;
    public TMP_Text happinessText;
    public TMP_Text coinsText;
    public TMP_Text dayText;
    public TMP_Text statusText;
    public TMP_Text stageText;
    public Slider hungerSlider;
    public Slider energySlider;
    public Slider happinessSlider;

    void Update()
    {
        hungerText.text = "Голод: " + Mathf.RoundToInt(petStats.hunger);
        energyText.text = "Энергия: " + Mathf.RoundToInt(petStats.energy);
        happinessText.text = "Счастье: " + Mathf.RoundToInt(petStats.happiness);
        coinsText.text = "Монеты: " + petActions.coins;
        dayText.text = "День: " + daySystem.currentDay;

        hungerSlider.value = petStats.hunger;
        energySlider.value = petStats.energy;
        happinessSlider.value = petStats.happiness;

        // СТАТУС 
        if (petStats.hunger < 25 || petStats.happiness < 25)
            statusText.text = "Состояние: Грустный";
        else if (petStats.energy < 25)
            statusText.text = "Состояние: Устал";
        else
            statusText.text = "Состояние: Нормально";

        // СТАДИЯ 
        if (daySystem.currentDay < 3)
            stageText.text = "Стадия: Младенец";
        else if (daySystem.currentDay < 5)
            stageText.text = "Стадия: Подросток";
        else
            stageText.text = "Стадия: Взрослый";
    }
}