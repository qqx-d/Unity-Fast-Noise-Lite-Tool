using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Noise Type", menuName = "Fast Noise Lite/New Noise")]
public class NoiseType : ScriptableObject
{
    
    public NoiseInterface noise = new NoiseInterface();
    
}