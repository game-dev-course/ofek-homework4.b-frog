using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Class resets all the game values.
 */
public class ResetGameValues : MonoBehaviour
{
    [SerializeField] private FloatSO scoreSO;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreSO.Value = 0;
    }
}
