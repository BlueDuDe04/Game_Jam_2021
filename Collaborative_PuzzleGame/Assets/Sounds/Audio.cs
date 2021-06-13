using UnityEngine;

[CreateAssetMenu(fileName = "Audio", menuName = "Collaborative_PuzzleGame/Audio", order = 0)]
public class Audio : ScriptableObject 
{
    public string clipName;
    public AudioClip clip;   
}