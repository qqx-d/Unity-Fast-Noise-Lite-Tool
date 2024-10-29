using UnityEngine;

public class NoiseGenerator
{
    
    private readonly int _seed;
    private Vector3Int _chunksSize;

    public NoiseGenerator(int worldSeed, Vector3Int chunkSize)
    {
        _seed = worldSeed;
        _chunksSize = chunkSize;
    }

    private FastNoiseLite GetNoiseSettings(NoiseType biomeType)
    {
        FastNoiseLite fastNoiseLite = new FastNoiseLite(_seed);

        fastNoiseLite.SetNoiseType(biomeType.noise.generalSettings.NoiseType);
        fastNoiseLite.SetFrequency(biomeType.noise.generalSettings.Frequency);

        if (biomeType.noise.useFractalSettings)
        {
            fastNoiseLite.SetFractalType(biomeType.noise.fractalSettings.FractalType);
            fastNoiseLite.SetFractalOctaves(biomeType.noise.fractalSettings.Octaves);
            fastNoiseLite.SetFractalLacunarity(biomeType.noise.fractalSettings.Lacunarity);
            fastNoiseLite.SetFractalGain(biomeType.noise.fractalSettings.Gain);
            fastNoiseLite.SetFractalWeightedStrength(biomeType.noise.fractalSettings.WeightedStrength);
        }

        if (biomeType.noise.useCallcularSettings)
        {
            fastNoiseLite.SetCellularDistanceFunction(biomeType.noise.callcularSettings.CellularDistanceFunction);
            fastNoiseLite.SetCellularReturnType(biomeType.noise.callcularSettings.CellularReturnType);
            fastNoiseLite.SetCellularJitter(biomeType.noise.callcularSettings.Jitter);
        }

        if (biomeType.noise.useDomainWarpSettings)
        {
            fastNoiseLite.SetDomainWarpType(biomeType.noise.domainWarpSettings.DomainWarpType);
            fastNoiseLite.SetDomainWarpAmp(biomeType.noise.domainWarpSettings.Amplitude);
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
                float scaledX = (position.x + x) + _seed;
                float scaledY = (position.y + y) + _seed;

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
                    float scaledX = (position.x + x) + _seed;
                    float scaledY = (position.y + y) + _seed;
                    float scaledZ = (position.z + z) + _seed;

                    float noiseValue = noise.GetNoise(scaledX, scaledY, scaledZ);

                    noiseMap[x, y, z] = Mathf.Abs(noiseValue);
                }
            }
        }
        return noiseMap;
    }
}