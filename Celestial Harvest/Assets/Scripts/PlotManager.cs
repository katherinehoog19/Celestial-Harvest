using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlotManager : MonoBehaviour
{
    [SerializeField] Text day;
    bool isPlanted = false;
    SpriteRenderer plantSprite;
    int plantStage = 0;
    float timer;

    PlantObject selectedPlant;
    FarmManager fm;

    void Start(){
        plantSprite = GetComponent<SpriteRenderer>();
        fm = transform.parent.GetComponent<FarmManager>();
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
        if (isPlanted){

            if (plantStage == selectedPlant.plantStages.Length - 1){
                Harvest();
            }
        }

        else if(fm.isPlanting && fm.selectPlant.plant.buyPrice <= fm.money){
            Plant(fm.selectPlant.plant);
        }
    }

    void Harvest(){
        isPlanted = false;
        if (plantSprite){
            plantSprite.gameObject.SetActive(false);
            plantSprite.gameObject.SetActive(true);
            fm.Transaction(selectedPlant.sellPrice);
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
