using System;
using UnityEngine;

[Serializable]
public class NoiseInterface 
{
    [Serializable] public class General
    {
        public FastNoiseLite.NoiseType NoiseType; // Убрал private set
        public float Frequency;
    }
    [Serializable] public class Fractal
    {
        public FastNoiseLite.FractalType FractalType;
        public int Octaves;
        public float Lacunarity;
        public float Gain;
        public float WeightedStrength;
    }
    [Serializable] public class Callcular
    {
        public FastNoiseLite.CellularDistanceFunction CellularDistanceFunction;
        public FastNoiseLite.CellularReturnType CellularReturnType;
        public float Jitter;
    }
    [Serializable] public class DomainWarp
    {
        public FastNoiseLite.DomainWarpType DomainWarpType;
        public float Amplitude;
        public float Frequency;
    }
    
    [HideInInspector] public bool useFractalSettings = false;
    [HideInInspector] public bool useCallcularSettings = false;
    [HideInInspector] public bool useDomainWarpSettings = false;

    [HideInInspector] public General generalSettings = new General(); // Инициализация
    [HideInInspector] public Fractal fractalSettings = new Fractal();
    [HideInInspector] public Callcular callcularSettings = new Callcular();
    [HideInInspector] public DomainWarp domainWarpSettings = new DomainWarp();
}