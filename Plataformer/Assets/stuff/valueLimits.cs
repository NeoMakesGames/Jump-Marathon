using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class valueLimits : MonoBehaviour
{
    public Scrollbar Scrollbar;

   public void valueLimitsscroll ()
    {
        if (0 == Scrollbar.value)
        {
            Scrollbar.value = 1;
        }
        if (0.2 == Scrollbar.value)
        {
            Scrollbar.value = 2;
        }
        if (0.4 == Scrollbar.value)
        {
            Scrollbar.value = 3;
        }
        if (0.6 == Scrollbar.value)
        {
            Scrollbar.value = 4;
        }
        if (0.8 == Scrollbar.value)
        {
            Scrollbar.value = 5;
        }
        if (1 == Scrollbar.value)
        {
            Scrollbar.value = 6;
        }
    }
}
