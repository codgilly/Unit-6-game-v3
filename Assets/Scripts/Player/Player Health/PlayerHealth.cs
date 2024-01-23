using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace PlayerHealthB
{
    public class PlayerHealth : MonoBehaviour
    {
        public Slider healthSlider;


        public void SetSlider(float amount)
        {
            healthSlider.value = amount;
        }
        public void SetSliderMax(float amount)
        {
            healthSlider.maxValue = amount;
            SetSlider(amount);
        }
    }


}
