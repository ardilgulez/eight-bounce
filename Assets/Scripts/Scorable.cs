using UnityEngine;
using System.Collections;

public class Scorable : MonoBehaviour
{
    public delegate void ScoreEvent(float score);
    public static ScoreEvent Score;
}
