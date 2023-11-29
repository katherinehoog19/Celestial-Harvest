using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resolution : MonoBehaviour
{
    [SerializeField] Dropdown resolutionDropdown;

    Resolution[] resolutions;

    void Start(){
        resolutions = Screen.resolutions;

        for (int i = 0; i < resolutions.Length; i++){
            string resolutionString = resolutions[i].width.ToString() + " x " + resolutions[i].height.ToString();
            resolutionDropdown.options.Add(new Dropdown.OptionData(resolutionString));
        }
    }
}
