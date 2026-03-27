using UnityEngine;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public GameObject shopPanel;
    public PetActions petActions;
    public PetStats petStats;

    public TMP_Text shopMessageText;

    public int foodPrice = 5;
    public int toyPrice = 7;
    public int bedPrice = 6;

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
            shopMessageText.text = "Еда куплена";
        }
        else
        {
            shopMessageText.text = "Недостаточно монет";
        }
    }

    public void BuyToy()
    {
        if (petActions.coins >= toyPrice)
        {
            petActions.coins -= toyPrice;
            petStats.AddHappiness(20f);
            shopMessageText.text = "Игрушка куплена";
        }
        else
        {
            shopMessageText.text = "Недостаточно монет";
        }
    }

    public void BuyBed()
    {
        if (petActions.coins >= bedPrice)
        {
            petActions.coins -= bedPrice;
            petStats.AddEnergy(20f);
            shopMessageText.text = "Подушка куплена";
        }
        else
        {
            shopMessageText.text = "Недостаточно монет";
        }
    }
}