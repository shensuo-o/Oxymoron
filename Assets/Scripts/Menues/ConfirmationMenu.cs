using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ConfirmationMenu : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private TextMeshProUGUI prompt;
    [SerializeField] private Button yesButton;
    [SerializeField] private Button noButton;
}
