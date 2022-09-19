using UnityEngine;
using UnityEngine.Tilemaps;

namespace PlatformerTutorial
{
    public class LevelGeneratorView : MonoBehaviour
    {
        public Tilemap tilemap;
        public Tile tile;

        public int mapHeight;
        public int mapWidth;

        [Range(0, 100)] public int fillPercent;
        [Range(0, 100)] public int smoothPassage;

        public bool borders;
    }
}