using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{
    public TextMeshProUGUI chip1Text, chip2Text, chip5Text, chip10Text;
    public TextMeshProUGUI euroText, starText, lincolnText, moneyText;

    private int chip1, chip2, chip5, chip10, euro, star, lincoln;

    public void AddChip(int value)
    {
        switch (value)
        {
            case 1: chip1++; chip1Text.text = chip1.ToString(); break;
            case 2: chip2++; chip2Text.text = chip2.ToString(); break;
            case 5: chip5++; chip5Text.text = chip5.ToString(); break;
            case 10: chip10++; chip10Text.text = chip10.ToString(); break;
        }
        UpdateMoney();
    }
    
    public void AddCoin(string type)
    {
        switch (type)
        {
            case "Euro": euro++; euroText.text = euro.ToString(); break;
            case "Star": star++; starText.text = star.ToString(); break;
            case "Lincoln": lincoln++; lincolnText.text = lincoln.ToString(); break;
        }
        UpdateMoney();
    }

    void UpdateMoney()
    {
        float money = (chip1 * 1) + (chip2 * 2) + (chip5 * 5) + (chip10 * 10);
        moneyText.text = $": {money}$";
    }
}
