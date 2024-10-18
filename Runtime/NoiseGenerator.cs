using UnityEngine;

public class NoiseGenerator
{

    private int _seed;
    private Vector3Int _chunksSize;

    public NoiseGenerator(int worldSeed, Vector3Int chunkSize)
    {
        this._seed = worldSeed;
        this._chunksSize = chunkSize;
    }

    private FastNoiseLite GetNoiseSettings(NoiseType biomeType)
    {
        FastNoiseLite fastNoiseLite = new FastNoiseLite(_seed);

        if (biomeType.Noise.GeneralSettings.Use)
        {
            fastNoiseLite.SetNoiseType(biomeType.Noise.GeneralSettings.NoiseType);
            fastNoiseLite.SetFrequency(biomeType.Noise.GeneralSettings.Frequency);
        }

        if (biomeType.Noise.FractalSettings.Use)
        {
            fastNoiseLite.SetFractalType(biomeType.Noise.FractalSettings.FractalType);
            fastNoiseLite.SetFractalOctaves(biomeType.Noise.FractalSettings.Octaves);
            fastNoiseLite.SetFractalLacunarity(biomeType.Noise.FractalSettings.Lacuranity);
            fastNoiseLite.SetFractalGain(biomeType.Noise.FractalSettings.Gain);
            fastNoiseLite.SetFractalWeightedStrength(biomeType.Noise.FractalSettings.WeightedStrength);
        }

        if (biomeType.Noise.CallcularSettings.Use)
        {
            fastNoiseLite.SetCellularDistanceFunction(biomeType.Noise.CallcularSettings.CellularDistanceFunction);
            fastNoiseLite.SetCellularReturnType(biomeType.Noise.CallcularSettings.CellularReturnType);
            fastNoiseLite.SetCellularJitter(biomeType.Noise.CallcularSettings.Jitter);
        }

        if (biomeType.Noise.DomainWarpSettings.Use)
        {
            fastNoiseLite.SetDomainWarpType(biomeType.Noise.DomainWarpSettings.DomainWarpType);
            fastNoiseLite.SetDomainWarpAmp(biomeType.Noise.DomainWarpSettings.Amplitude);
        }

        return fastNoiseLite;
    }

    public float[,] Get2DNoiseAt(NoiseType noiseType, Vector2Int position)
    {
        float[,] noiseMap = new float[_chunksSize.x, _chunksSize.y];

        FastNoiseLite noise = GetNoiseSettings(noiseType);

        for (int x = 0; x < _chunksSize.x; x++)
        {
            for (int y = 0; y < _chunksSize.y; y++)
            {
                float scaledX = (position.x * _chunksSize.x + x) + _seed;
                float scaledY = (position.y * _chunksSize.y + y) + _seed;

                float noiseValue = noise.GetNoise(scaledX, scaledY);

                noiseMap[x, y] = Mathf.Abs(noiseValue);
            }
        }
        return noiseMap;
    }

    public float[,,] Get3DNoiseAt(NoiseType noiseType, Vector3Int position)
    {
        float[,,] noiseMap = new float[_chunksSize.x, _chunksSize.y, _chunksSize.z];

        FastNoiseLite noise = GetNoiseSettings(noiseType);

        for (int x = 0; x < _chunksSize.x; x++)
        {
            for (int y = 0; y < _chunksSize.y; y++)
            {
                for (int z = 0; z < _chunksSize.z; z++)
                {
                    float scaledX = (position.x * _chunksSize.x + x) + _seed;
                    float scaledY = (position.y * _chunksSize.y + y) + _seed;
                    float scaledZ = (position.z * _chunksSize.z + z) + _seed;

                    float noiseValue = noise.GetNoise(scaledX, scaledY, scaledZ);

                    noiseMap[x, y, z] = Mathf.Abs(noiseValue);
                }
            }
        }
        return noiseMap;
    }
}