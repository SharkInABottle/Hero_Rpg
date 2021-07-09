using System;
using UnityEngine;
using UnityEngine.UI;

public class graphicQualities : MonoBehaviour
{
    [SerializeField] Toggle low, medium, high, veryHigh;
    

    public void Verify()
    {
        int x = QualitySettings.GetQualityLevel();
        
        switch (x)
        {
            case 0:
                low.isOn = true;
                break;
            case 1:
                medium.isOn = true;
                break;
            case 2:
                high.isOn = true;
                break;
            case 4:
                veryHigh.isOn = true;
                break;
        }
    }

    public void Low()
    {
        if (QualitySettings.GetQualityLevel() != 0)
        {
            QualitySettings.SetQualityLevel(0);
            PlayerPrefs.SetInt("GraphicQ", 0);
        }

    }
    public void Medium()
    {
        if (QualitySettings.GetQualityLevel() != 1)
        {
            QualitySettings.SetQualityLevel(1);
            PlayerPrefs.SetInt("GraphicQ", 1);
        }
    }
    public void High()
    {
        if (QualitySettings.GetQualityLevel() != 2)
        {
            QualitySettings.SetQualityLevel(2);
            PlayerPrefs.SetInt("GraphicQ", 2);
        }
    }
    public void VeryHigh()
    {
        if (QualitySettings.GetQualityLevel() != 4)
        {
            QualitySettings.SetQualityLevel(4);
            PlayerPrefs.SetInt("GraphicQ", 4);
        }
    }

}
