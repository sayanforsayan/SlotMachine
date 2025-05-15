using UnityEngine;
using System.Collections;
using TMPro;
public class Reel : MonoBehaviour
{
    public TMP_Text reelText;
    public string[] symbols = { "0", "A", "B", "C", "D", "E" };

    private string finalSymbol;

    public IEnumerator Spin(float duration, bool forceZero)
    {
        float time = 0f;

        while (time < duration)
        {
            reelText.text = symbols[Random.Range(0, symbols.Length)];
            time += 0.05f;
            yield return new WaitForSeconds(0.05f);
        }

        finalSymbol = forceZero ? "0" : symbols[Random.Range(0, symbols.Length)];
        reelText.text = finalSymbol;
    }

    public string GetResult()
    {
        return finalSymbol;
    }
}
