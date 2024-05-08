
using TMPro;
using UnityEngine;

// Brody Soedel
// Class that handles overall game behavior, for now just handles tooltips
public static class GameController
{
    // Start is called before the first frame update
    public static GameObject tooltip;
    public static TextMeshProUGUI tooltipKey;
    public static TextMeshProUGUI tooltipInstructions;

    public static void setTooltip(string key, string instructions)
    {
        tooltipKey.text = key;
        tooltipInstructions.text = instructions;
    }

    public static void showTooltip()
    {
        tooltip.SetActive(true);
    }

    public static void hideTooltip()
    {
        tooltip.SetActive(false);
    }
};
