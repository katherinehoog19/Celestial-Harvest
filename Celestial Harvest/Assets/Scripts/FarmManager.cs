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
    [SerializeField] Button button;
    Image buttonImage;

    [SerializeField] private Color selectColor;   
    [SerializeField] private Color unselectColor;

    // Start is called before the first frame update
    void Start()
    {
        moneyText.text = "$" + money; // setting the money text 
        buttonImage = button.GetComponent<Image>();
    }

    public void SelectPlant(PlantItem newPlant){ // this is on the shop button 
        if (selectPlant == newPlant){
            buttonImage.color = unselectColor;
            Debug.Log("deselected " + selectPlant.plant.plantName);
            selectPlant = null;
            isPlanting = false;
            
        }
        else {
            buttonImage.color = selectColor;
            selectPlant = newPlant;
            Debug.Log("selected " + selectPlant.plant.plantName);
            isPlanting = true; // you're in planting mode mean you have something selected and are going to plant something
        }
    }

    public void Transaction (int value){
        money += value;
        moneyText.text = "$" + money;
    }

    public int currentWallet(){
        return money;
    }
}
