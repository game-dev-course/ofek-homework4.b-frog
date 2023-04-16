using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreInitializer : MonoBehaviour
{
    [SerializeField] private NumberField scoreField;
    [SerializeField] private FloatSO scoreSO;

    private void Start()
    {
        // Set initial score value as scoreSO object
        scoreField.SetNumber((int) scoreSO.Value);
    }
}
