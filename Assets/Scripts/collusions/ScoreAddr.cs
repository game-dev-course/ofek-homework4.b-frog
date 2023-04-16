using UnityEngine;

/**
 * This component increases a given "score" field whenever it is triggered.
 */
public class ScoreAddr : MonoBehaviour {
    [Tooltip("Every object tagged with this tag will trigger adding score to the score field.")]
    [SerializeField] string triggeringTag;
    [SerializeField] NumberField scoreField;
    [SerializeField] int pointsToAdd;
    [SerializeField] private Vector3 startingPoint;
    [SerializeField] private FloatSO scoreSO;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(triggeringTag) || scoreField == null) return;
        
        scoreField.AddNumber(pointsToAdd);
        scoreSO.Value += pointsToAdd;
            
        // If player reach finish he will be respawned
        if (triggeringTag == "Finish")
        {
            this.gameObject.transform.position = startingPoint;
        }
    }

    public void SetScoreField(NumberField newTextField) {
        this.scoreField = newTextField;
    }
}