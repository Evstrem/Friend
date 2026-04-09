using UnityEngine;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public GameObject shopPanel;
    public PetActions petActions;
    public PetStats petStats;

    public TMP_Text shopMessageText;

    public GameObject foodPrefab;      // префаб миски
    public GameObject foodSpawnPoint;   // точка появления миски
    private GameObject currentFood;    // для хранения созданной миски

    public GameObject toyPrefab;       // префаб мячика
    public GameObject toySpawnPoint;    // точка появления мячика
    private GameObject currentToy;     // для хранения созданного мячика

    public GameObject bedPrefab;
    public GameObject bedSpawnPoint;
    private GameObject currentBed;

    public int foodPrice = 5;
    public int toyPrice = 7;
    public int bedPrice = 6;

    void Start()
    {
        // Находим точки спавна по имени, если они не назначены в инспекторе
        if (foodSpawnPoint == null)
            foodSpawnPoint = GameObject.Find("SpawnPointFood");
        
        if (toySpawnPoint == null)
            toySpawnPoint = GameObject.Find("SpawnPointToy");
        
        if (foodSpawnPoint == null) Debug.LogError("Не найден SpawnPoint_Food!");
        if (toySpawnPoint == null) Debug.LogError("Не найден SpawnPoint_Toy!");

        if (bedSpawnPoint == null)
            bedSpawnPoint = GameObject.Find("SpawnPointBed");
        
        // Дополнительно: проверяем, что префабы назначены
        if (foodPrefab == null) Debug.LogError("FoodPrefab не назначен в ShopManager!");
        if (toyPrefab == null) Debug.LogError("ToyPrefab не назначен в ShopManager!");
    }

    public void OpenShop()
    {
        shopPanel.SetActive(true);
        shopMessageText.text = "";
    }

    public void CloseShop()
    {
        shopPanel.SetActive(false);
    }

    public void BuyFood()
    {
        if (petActions.coins >= foodPrice)
        {
            petActions.coins -= foodPrice;
            petStats.AddHunger(20f);
            // Создаём миску
            if (foodPrefab != null && foodSpawnPoint != null)
            {
                if (currentFood != null) Destroy(currentFood);
                currentFood = Instantiate(foodPrefab, foodSpawnPoint.transform.position, foodSpawnPoint.transform.rotation);
            }
            shopMessageText.text = "��� �������";
        }
        else
        {
            shopMessageText.text = "������������ �����";
        }
    }

    public void BuyToy()
    {
        if (petActions.coins >= toyPrice)
        {
            petActions.coins -= toyPrice;
            petStats.AddHappiness(20f);
            // Создаём мячик
            if (toyPrefab != null && toySpawnPoint != null)
            {
                if (currentToy != null) Destroy(currentToy);
                currentToy = Instantiate(toyPrefab, toySpawnPoint.transform.position, toySpawnPoint.transform.rotation);
            }
            shopMessageText.text = "������� �������";
        }
        else
        {
            shopMessageText.text = "������������ �����";
        }
    }

    public void BuyBed()
    {
        if (petActions.coins >= bedPrice)
        {
            petActions.coins -= bedPrice;
            petStats.AddEnergy(20f);

            if (bedPrefab != null && bedSpawnPoint != null)
            {
                if (currentBed != null) Destroy(currentBed);
                currentBed = Instantiate(bedPrefab, bedSpawnPoint.transform.position, bedSpawnPoint.transform.rotation);
            }
            shopMessageText.text = "Кровать куплена";
        }
        else
        {
            shopMessageText.text = "Недостаточно монет";
        }
    }
}