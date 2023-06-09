using UnityEngine;
using UnityEngine.UI;

// Script attached to the Enemy Prefab
// PuRef = Button colorChangeButton ; InputField colorInputField
// PrRef = Renderer rendererComponent

public class Enemy : MonoBehaviour
{
    public static Color sharedColor; // Static field representing the shared color for all enemy instances

    public Button colorChangeButton; // Button reference for color change
    public InputField colorInputField; // Input field reference for color selection

    private Renderer rendererComponent; // Reference to the Renderer component

    private void Awake()
    {
        rendererComponent = GetComponent<Renderer>(); // Get the Renderer component
    }

    private void Start()
    {
        // Add a listener to the colorChangeButton that calls ChangeColor with "green" as the chosen color
        colorChangeButton.onClick.AddListener(() => ChangeColor("green"));
    }

    private void Update()
    {
        // Add a listener to the colorInputField's onEndEdit event that calls UpdateColor method
        colorInputField.onEndEdit.AddListener(UpdateColor);
    }

    private void ChangeColor(string colorStartButton)
    {
        // Declares a local variable color of type Color to store the chosen color value.
        Color color;

        switch (colorStartButton)
        {
            case "red":
                color = Color.red;
                break;

            case "green":
                color = Color.green;
                break;

            case "blue":
                color = Color.blue;
                break;

            default:
                color = Color.black;
                break;
        }

        SetSharedColor(color);

        // Find all enemy instances in the scene
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        foreach (Enemy enemy in enemies)
        {
            enemy.ApplyColor(); // Apply the color change to each enemy instance
        }
    }

    private void UpdateColor(string colorUpdatesField)
    {
        Color color;

        switch (colorUpdatesField)
        {
            case "red":
                color = Color.red;
                break;

            case "green":
                color = Color.green;
                break;

            case "blue":
                color = Color.blue;
                break;

            default:
                color = Color.black;
                break;
        }

        SetSharedColor(color);

        // Find all enemy instances in the scene
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        foreach (Enemy enemy in enemies)
        {
            enemy.ApplyColor(); // Apply the color change to each enemy instance
        }
    }

    public static void SetSharedColor(Color newColor)
    {
        sharedColor = newColor; // Update the sharedColor field with the new color
    }

    private void ApplyColor()
    {
        rendererComponent.material.color = sharedColor; // Set the renderer component's color to the sharedColor
    }
}