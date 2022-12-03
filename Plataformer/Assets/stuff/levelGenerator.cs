using UnityEngine;
using System.IO;
using System;

public class levelGenerator : MonoBehaviour
{
    public Texture2D map;

    public bool isCustomLevel;

    public ColorToPrefab[] colorMappings;

    public string directoryString;

    void Start()
    {
        GenerateLevel();
    }

    void GenerateLevel ()
    {
        if (isCustomLevel)
        {
            directoryString = GracesGames.SimpleFileBrowser.Scripts.DemoCaller.archivo;
            byte[] bytes = File.ReadAllBytes(directoryString);
            map.LoadImage(bytes);
        }

        for (int x = 0; x < map.width; x++)
        {
            for (int y = 0; y < map.height; y++)
            {
                GenerateTile(x, y);
            }
        }
    }

    void GenerateTile (int x, int y)
    {
       Color pixelColor = map.GetPixel(x, y);

        if (pixelColor.a == 0)
        {
            // The pixel is transparent. Let's ignore it!
            return;
        }

        foreach (ColorToPrefab colorMapping in colorMappings)
        {
            if (colorMapping.color.Equals(pixelColor))
            {
                Vector2 position = new Vector2(x, y);
                Instantiate(colorMapping.prefab, position, Quaternion.identity, transform);
            }
        }
    }
}
