using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Colors")]

    [Tooltip("Determines if the color of the text should changes as Health is lost.")]
    [SerializeField]
    private bool updateColor = true;

    [Tooltip("Determines how fast the color changes as the health is lost.")]
    [SerializeField]
    private float emptySpeed = 1.5f;

    [Tooltip("Color used on this text when the player character has low health.")]
    [SerializeField]
    private Color emptyColor = Color.red;

    public float totalhealth = 100;
    public float health = 100;
    public TextMeshProUGUI healthText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HealthLoss()
    {
        healthText.text = health.ToString();
        //Calculate Color Alpha. Helpful to make the text color change based on count.
        float colorAlpha = (health / totalhealth) * emptySpeed;
        //Lerp Color. This makes sure that the text color changes based on count.
        healthText.color = Color.Lerp(emptyColor, Color.white, colorAlpha);
    }
}
