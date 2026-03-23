using UnityEngine;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public GameObject shopPanel;
    public PetActions petActions;
    public PetStats petStats;

    public int foodPrice = 5;
    public int toyPrice = 7;
    public int bedPrice = 6;

    public void OpenShop()
    {
        shopPanel.SetActive(true);
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
        }
    }

    public void BuyToy()
    {
        if (petActions.coins >= toyPrice)
        {
            petActions.coins -= toyPrice;
            petStats.AddHappiness(20f);
        }
    }

    public void BuyBed()
    {
        if (petActions.coins >= bedPrice)
        {
            petActions.coins -= bedPrice;
            petStats.AddEnergy(20f);
        }
    }
}