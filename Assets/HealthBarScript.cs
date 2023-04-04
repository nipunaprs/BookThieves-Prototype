using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;


public class HealthBarScript : MonoBehaviour
{
    public Slider Slider;
    public Color Low;
    public Color High;
    public Vector3 Offset;
    // Update is called once per frame

    public void SetHealth(float health, float maxHealth)
    {

        UnityEngine.Debug.Log(health);
        Slider.maxValue = maxHealth;
        Slider.value = health;


        Slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(Low, High, Slider.normalizedValue);

    }
    void Start()
    {
        Slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(Low, High, 1);
    }
}
