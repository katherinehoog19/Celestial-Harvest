using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlotManager : MonoBehaviour
{
    [SerializeField] Text day;
    bool isPlanted = false; // check if something is planted
    SpriteRenderer plantSprite;
    int plantStage = 0; // 4 stages for each plant
    float timer;

    PlantObject selectedPlant;
    FarmManager fm;

    void Start(){
        plantSprite = GetComponent<SpriteRenderer>();
        fm = transform.parent.GetComponent<FarmManager>(); // what is this doing?
    }

    void Update(){
        if (isPlanted){
            timer -= Time.deltaTime;

            if (timer < 0 && plantStage < selectedPlant.plantStages.Length - 1){
                timer = selectedPlant.timeBtwStages;
                plantStage++;
                UpdatePlant();
            }
        }
    }

    void OnMouseDown(){
        /*if (isPlanted){

            if (plantStage == selectedPlant.plantStages.Length - 1){ // if the plant stage is the last stage then you can harvest it
                Harvest();
            }
        }*/

        if(fm.isPlanting && (fm.selectPlant.plant.buyPrice <= fm.money)){ // if it's planted and there is something that has been selected and it's less than the money in the bank
            Plant(fm.selectPlant.plant); // plant the plant on mouse click 
        }
        else if (isPlanted){

            if (plantStage == selectedPlant.plantStages.Length - 1){
                Harvest();
            }
        }
    }

    void Harvest(){
        isPlanted = false;
        if (plantSprite){ // if it's not equal to null?
            plantSprite.gameObject.SetActive(false); // what the fuck is this doing?
            //plantSprite.gameObject.SetActive(true);
            fm.Transaction(selectedPlant.sellPrice); // auto sell on harvest 
        }
    }

    void Plant(PlantObject newPlant){
        selectedPlant = newPlant;
        isPlanted = true;

        fm.Transaction(-selectedPlant.buyPrice);
        plantStage = 0;
        UpdatePlant();
        timer = selectedPlant.timeBtwStages;
        plantSprite.gameObject.SetActive(true);
    }

    void UpdatePlant (){
        plantSprite.sprite = selectedPlant.plantStages[plantStage];
    }

}
