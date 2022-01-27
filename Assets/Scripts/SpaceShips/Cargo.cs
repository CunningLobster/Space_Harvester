using SpaceCarrier.Celestials;
using UnityEngine;

public class Cargo : MonoBehaviour
{
    [SerializeField] private int maxCapacity = 1000;
    [SerializeField] private int currentCapacity = 0;

    private int purple;
    private int red;
    private int blue;
    private int green;
    private int brown;

    public int MaxCapacity { get => maxCapacity; private set => maxCapacity = value; }
    public int CurrentCapacity { get => currentCapacity; private set => currentCapacity = value; }

    public int Purple { get => purple; private set => purple = value;  }
    public int Red { get => red; private set => red = value; }
    public int Blue { get => blue; private set => blue = value; }
    public int Green { get => green; private set => green = value; }
    public int Brown { get => brown; private set => brown = value; }

    private void Awake()
    {
        purple = PlayerPrefs.GetInt("Purple", 0);
        red = PlayerPrefs.GetInt("Red", 0);
        blue = PlayerPrefs.GetInt("Blue", 0);
        green = PlayerPrefs.GetInt("Green", 0);
        brown = PlayerPrefs.GetInt("Brown", 0);
        currentCapacity = CalculateCapacity();
    }

    public void Fill(int resourceAmount, ResourceTypes type)
    {
        if (currentCapacity >= maxCapacity)
        {
            Debug.Log("Cargo is full");
            return;
        }

        switch (type)
        {
            case ResourceTypes.Purple:
                purple += resourceAmount;
                PlayerPrefs.SetInt("Purple", purple);
                break;
            case ResourceTypes.Red:
                red += resourceAmount;
                PlayerPrefs.SetInt("Red", red);
                break;
            case ResourceTypes.Blue:
                blue += resourceAmount;
                PlayerPrefs.SetInt("Blue", blue);
                break;
            case ResourceTypes.Green:
                green += resourceAmount;
                PlayerPrefs.SetInt("Green", green);
                break;
            case ResourceTypes.Brown:
                brown += resourceAmount;
                PlayerPrefs.SetInt("Brown", brown);
                break;
        }
        currentCapacity = CalculateCapacity();
    }

    public void ResetResources()
    {
        currentCapacity = 0;
        PlayerPrefs.SetInt("Purple", 0);
        PlayerPrefs.SetInt("Red", 0);
        PlayerPrefs.SetInt("Green", 0);
        PlayerPrefs.SetInt("Brown", 0);
        PlayerPrefs.SetInt("Blue", 0);
    }

    private int CalculateCapacity()
    {
        return purple + red + blue + green + brown;
    }

    private void Update()
    {
        Debug.Log("Purple: " + PlayerPrefs.GetInt("Purple", 0));
        Debug.Log("Red: " + PlayerPrefs.GetInt("Red", 0));
        Debug.Log("Green: " + PlayerPrefs.GetInt("Green", 0));
        Debug.Log("Brown: " + PlayerPrefs.GetInt("Brown", 0));
        Debug.Log("Blue: " + PlayerPrefs.GetInt("Blue", 0));
    }
}
