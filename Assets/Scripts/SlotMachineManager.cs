using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
public class SlotMachineManager : MonoBehaviour
{
    [SerializeField] private Reel[] reels;
    [SerializeField] private Button spinButton;
    [SerializeField] private TMP_Text resultText;

    [Range(0f, 1f)]
    [SerializeField] private float matchProbability = 0.2f; // 20% chance to win

    void Start()
    {
        spinButton.onClick.AddListener(StartSpin);
        resultText.text = "";
    }

    void StartSpin()
    {
        spinButton.interactable = false;
        resultText.text = "";
        StartCoroutine(SpinAllReels());
    }

    IEnumerator SpinAllReels()
    {
        float spinTime = 1.5f;
        bool isWinningSpin = Random.value < matchProbability;

        for (int i = 0; i < reels.Length; i++)
        {
            StartCoroutine(reels[i].Spin(spinTime + i * 0.1f, isWinningSpin));
        }

        yield return new WaitForSeconds(spinTime + 0.3f);

        // Check match
        string first = reels[0].GetResult();
        bool allMatch = true;

        for (int i = 1; i < reels.Length; i++)
        {
            if (reels[i].GetResult() != first)
            {
                allMatch = false;
                break;
            }
        }

        resultText.text = allMatch ? "You Win!" : "Try Again!";
        spinButton.interactable = true;
    }
}
