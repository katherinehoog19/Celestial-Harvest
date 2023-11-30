using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FarmManager : MonoBehaviour
{
    public PlantItem selectPlant;
    public bool isPlanting = false;
    public int money = 100;
    public Text moneyText;

    // Start is called before the first frame update
    void Start()
    {
        moneyText.text = "$" + money;
    }

    public void SelectPlant(PlantItem newPlant){
        if (selectPlant == newPlant){
            Debug.Log("deselected " + selectPlant.plant.plantName);
            selectPlant = null;
            isPlanting = false;
            
        }
        else {
            selectPlant = newPlant;
            Debug.Log("selected " + selectPlant.plant.plantName);
            isPlanting = true;
        }
    }

    public void Transaction (int value){
        money += value;
        moneyText.text = "$" + money;
    }
}
