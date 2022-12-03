using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class plusOne : MonoBehaviour
{
    public UnityEngine.UI.Text levelDisplay;
    public Scrollbar scrollbar;
   public void ChangeNumber()
    {
        levelDisplay.text = "Level: " + scrollbar.value;
    }
}
