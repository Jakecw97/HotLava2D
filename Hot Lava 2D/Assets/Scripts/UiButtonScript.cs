using UnityEngine;
using UnityEngine.UI;
public class UIButtonScript : MonoBehaviour
{
    private float value;
    public float Value
    { // Readonly for security
        get
        {
            return value;
        }
    }
    public Button PositiveButton;
    public Button NegativeButton;
    public void UpdateAxisValue(int v)
    {
        value += v;
    }
}
