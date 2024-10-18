using System;

[Serializable]
public class NoiseInterface 
{
    [Serializable]
    public class General 
    {
        public bool Use;

        public FastNoiseLite.NoiseType NoiseType;
        public float Frequency;
    }

    [Serializable]
    public class Fractal
    {
        public bool Use;

        public FastNoiseLite.FractalType FractalType;
        public int Octaves;
        public float Lacuranity;
        public float Gain;
        public float WeightedStrength;
    }

    [Serializable]
    public class Callcular 
    {
        public bool Use;

        public FastNoiseLite.CellularDistanceFunction CellularDistanceFunction;
        public FastNoiseLite.CellularReturnType CellularReturnType;
        public float Jitter;
    }

    [Serializable]
    public class DomainWarp 
    {
        public bool Use;

        public FastNoiseLite.DomainWarpType DomainWarpType;
        public float Amplitude;
        public float Frequency;
    }

    public General GeneralSettings;
    public Fractal FractalSettings;
    public Callcular CallcularSettings;
    public DomainWarp DomainWarpSettings;
}