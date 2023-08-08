using UnityEngine;
using System.IO;
using TMPro;

public class ButtonController : MonoBehaviour
{
    private string filePath;
    public TMPro.TextMeshProUGUI displayText;
    public TMPro.TextMeshProUGUI diceText;
    public TMPro.TextMeshProUGUI displayLast;

    private void Start()
    {
        filePath = Application.dataPath + "/directions.txt";

        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, "");
        }
    }

    public void RecordDirection(string direction)
    {
        File.AppendAllText(filePath, direction + "\n");
    }

    public void GenerateRandomNumber()
    {
        int randomNumber = Random.Range(1, 21);
        diceText.text = "Dice: " + randomNumber;

        // Append to the text file
        File.AppendAllText(filePath, "Dice: " + randomNumber + "\n");
    }

    public void DisplayLastLine()
    {
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            if (lines.Length > 0)
            {
                string lastLine = lines[lines.Length - 1];
                displayLast.text = lastLine;
            }
            else
            {
            displayLast.text = "Text file is empty.";
            }
        }
        else
        {
            displayLast.text = "Text file does not exist.";
        }
    }

    public void DisplayTextFileContents()
    {
        if (File.Exists(filePath))
        {
            string fileContents = File.ReadAllText(filePath);
            displayText.text = fileContents;
        }
        else
        {
            displayText.text = "Text file does not exist.";
        }
    }
    
    // New methods to be called programmatically
    public void OnUpButtonClicked()
    {
        RecordDirection("Up");
    }

    public void OnDownButtonClicked()
    {
        RecordDirection("Down");
    }

    public void OnLeftButtonClicked()
    {
        RecordDirection("Left");
    }

    public void OnRightButtonClicked()
    {
        RecordDirection("Right");
    }

    public void OnDiceButtonClicked()
    {
        GenerateRandomNumber();
    }

    public void OnDisplayButtonClicked()
    {
        DisplayTextFileContents();
    }
}