using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "AudioDatabase", menuName = "Collaborative_PuzzleGame/AudioDatabase", order = 0)]
public class AudioDatabase : ScriptableObject 
{
    public List<Audio> audioList; 
    
}