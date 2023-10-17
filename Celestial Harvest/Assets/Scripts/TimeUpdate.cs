using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeUpdate : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Text day;
    [SerializeField] Text time;
    int hours;
    int date;

    void Start()
    {
        date = 1;
        hours = 0; //change back to 6 for startin day 
        time.text = hours.ToString() + ":00";
        StartCoroutine(TimeRoutine());

    }

    IEnumerator TimeRoutine(){
        while(true)
        {
            yield return new WaitForSeconds(1); // this is the delay
            hours += 1;
            if (hours >= 24){
                hours = 0;
                date += 1;
                day.text = "Day: " + date.ToString();
            }
            time.text = hours.ToString() + ":00" ;
        }
        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
