using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(NoiseType))]
public class NoiseInterfaceEditor : Editor
{
    private SerializedProperty _noiseProperty;
    private SerializedProperty _generalSettings;
    private SerializedProperty _useFractalSettings;
    private SerializedProperty _fractalSettings;
    private SerializedProperty _useCallcularSettings;
    private SerializedProperty _callcularSettings;
    private SerializedProperty _useDomainWarpSettings;
    private SerializedProperty _domainWarpSettings;

    private void OnEnable()
    {
        _noiseProperty = serializedObject.FindProperty(nameof(NoiseType.noise));
        if (_noiseProperty != null)
        {
            _generalSettings = _noiseProperty.FindPropertyRelative(nameof(NoiseInterface.generalSettings));
            _useFractalSettings = _noiseProperty.FindPropertyRelative(nameof(NoiseInterface.useFractalSettings));
            _fractalSettings = _noiseProperty.FindPropertyRelative(nameof(NoiseInterface.fractalSettings));
            _useCallcularSettings = _noiseProperty.FindPropertyRelative(nameof(NoiseInterface.useCallcularSettings));
            _callcularSettings = _noiseProperty.FindPropertyRelative(nameof(NoiseInterface.callcularSettings));
            _useDomainWarpSettings = _noiseProperty.FindPropertyRelative(nameof(NoiseInterface.useDomainWarpSettings));
            _domainWarpSettings = _noiseProperty.FindPropertyRelative(nameof(NoiseInterface.domainWarpSettings));
        }
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        if (_generalSettings != null)
        {
            EditorGUILayout.LabelField("General Settings", EditorStyles.boldLabel);
            EditorGUILayout.BeginVertical("box");
            EditorGUILayout.PropertyField(_generalSettings.FindPropertyRelative(nameof(NoiseInterface.General.NoiseType)), new GUIContent("Noise Type"));
            EditorGUILayout.PropertyField(_generalSettings.FindPropertyRelative(nameof(NoiseInterface.General.Frequency)), new GUIContent("Frequency"));
            EditorGUILayout.EndVertical();
        }

        if (_useFractalSettings != null)
        {
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Fractal Settings", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(_useFractalSettings, new GUIContent("Enable Fractal Settings"));

            if (_useFractalSettings.boolValue && _fractalSettings != null)
            {
                EditorGUILayout.BeginVertical("box");
                EditorGUILayout.PropertyField(_fractalSettings.FindPropertyRelative(nameof(NoiseInterface.Fractal.FractalType)), new GUIContent("Fractal Type"));
                EditorGUILayout.PropertyField(_fractalSettings.FindPropertyRelative(nameof(NoiseInterface.Fractal.Octaves)), new GUIContent("Octaves"));
                EditorGUILayout.PropertyField(_fractalSettings.FindPropertyRelative(nameof(NoiseInterface.Fractal.Lacunarity)), new GUIContent("Lacunarity"));
                EditorGUILayout.PropertyField(_fractalSettings.FindPropertyRelative(nameof(NoiseInterface.Fractal.Gain)), new GUIContent("Gain"));
                EditorGUILayout.PropertyField(_fractalSettings.FindPropertyRelative(nameof(NoiseInterface.Fractal.WeightedStrength)), new GUIContent("Weighted Strength"));
                EditorGUILayout.EndVertical();
            }
        }

        if (_useCallcularSettings != null)
        {
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Callcular Settings", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(_useCallcularSettings, new GUIContent("Enable Callcular Settings"));

            if (_useCallcularSettings.boolValue && _callcularSettings != null)
            {
                EditorGUILayout.BeginVertical("box");
                EditorGUILayout.PropertyField(_callcularSettings.FindPropertyRelative(nameof(NoiseInterface.Callcular.CellularDistanceFunction)), new GUIContent("Cellular Distance Function"));
                EditorGUILayout.PropertyField(_callcularSettings.FindPropertyRelative(nameof(NoiseInterface.Callcular.CellularReturnType)), new GUIContent("Cellular Return Type"));
                EditorGUILayout.PropertyField(_callcularSettings.FindPropertyRelative(nameof(NoiseInterface.Callcular.Jitter)), new GUIContent("Jitter"));
                EditorGUILayout.EndVertical();
            }
        }

        if (_useDomainWarpSettings != null)
        {
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Domain Warp Settings", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(_useDomainWarpSettings, new GUIContent("Enable Domain Warp Settings"));

            if (_useDomainWarpSettings.boolValue && _domainWarpSettings != null)
            {
                EditorGUILayout.BeginVertical("box");
                EditorGUILayout.PropertyField(_domainWarpSettings.FindPropertyRelative(nameof(NoiseInterface.DomainWarp.DomainWarpType)), new GUIContent("Domain Warp Type"));
                EditorGUILayout.PropertyField(_domainWarpSettings.FindPropertyRelative(nameof(NoiseInterface.DomainWarp.Amplitude)), new GUIContent("Amplitude"));
                EditorGUILayout.PropertyField(_domainWarpSettings.FindPropertyRelative(nameof(NoiseInterface.DomainWarp.Frequency)), new GUIContent("Frequency"));
                EditorGUILayout.EndVertical();
            }
        }

        serializedObject.ApplyModifiedProperties();
    }
}