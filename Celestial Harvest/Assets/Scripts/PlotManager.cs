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

    public PlantObject selectedPlant;

    void Start(){
        plantSprite = GetComponent<SpriteRenderer>();
    }

    void Update(){
        // if (day.text != null){
        //     string[] dayNumber = day.text.Split(' ');
        //     Debug.Log(dayNumber[1]);
        // }

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

        else{
            Plant();
        }
    }

    void Harvest(){
        isPlanted = false;
        if (plantSprite){
            plantSprite.gameObject.SetActive(false);
            plantSprite.gameObject.SetActive(true);
        }
    }

    void Plant(){
        isPlanted = true;
        plantStage = 0;
        UpdatePlant();
        timer = selectedPlant.timeBtwStages;
        plantSprite.gameObject.SetActive(true);
    }

    void UpdatePlant (){
        plantSprite.sprite = selectedPlant.plantStages[plantStage];
    }
}
