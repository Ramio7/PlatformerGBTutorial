using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

namespace PlatformerTutorial
{
    public class LevelGeneratorController
    {
        private Tilemap _tilemap;
        private Tile _tile;

        private int _mapHeight;
        private int _mapWidth;

        private int _fillPercent;
        private int _smoothPassage;

        private bool _borders;

        private int[,] _map;

        public LevelGeneratorController(LevelGeneratorView generatorView)
        {
            _tilemap = generatorView.tilemap;
            _tile = generatorView.tile;

            _mapHeight = generatorView.mapHeight;
            _mapWidth = generatorView.mapWidth;

            _fillPercent = generatorView.fillPercent;
            _smoothPassage = generatorView.smoothPassage;

            _borders = generatorView.borders;

            _map = new int[_mapWidth, _mapHeight];
        }

        public void Start()
        {
            FillMap();
            SmoothMap(_smoothPassage);
            DrawMap();
        }

        private void DrawMap()
        {
            if (_map == null) return;

            for (int x = 0; x < _mapWidth; x++)
            {
                for (int y = 0; y < _mapHeight; y++)
                {
                    if (_map[x,y] == 1)
                    {
                        _tilemap.SetTile(new Vector3Int(-_mapWidth / 2 + x, _mapHeight / 2 + y, 0), _tile);
                    }
                }
            }
        }

        private void SmoothMap(int smoothPassage)
        {
            for (int i = 0; i <= smoothPassage; i++)
            {
                for (int x = 0; x < _mapWidth; x++)
                {
                    for (int y = 0; y < _mapHeight; y++)
                    {
                        int neighbour = GetNeighbour(x, y);

                        if (neighbour > 4) _map[x, y] = 1;
                        else if (neighbour < 4) _map[x, y] = 0;
                    }
                }
            }
        }

        private int GetNeighbour(int xCoordinate, int yCoordinate)
        {
            int neighbour = 0;

            for (int gridX = xCoordinate - 1; gridX <= xCoordinate + 1; gridX++)
            {
                for (int gridY = yCoordinate - 1; gridY <= yCoordinate + 1; gridY++)
                {
                    if (gridX >= 0 && gridX < _mapWidth && gridY >= 0 && gridY < _mapHeight)
                    {
                        if (gridX != xCoordinate || gridY != yCoordinate) neighbour += _map[gridX, gridY];
                    }
                    else neighbour++;
                }
            }
            return neighbour;
        }

        private void FillMap()
        {
            for (int x = 0; x < _mapWidth; x++)
            {
                for (int y = 0; y < _mapHeight; y++)
                {
                    if (x == 0 || x == _mapWidth - 1 || y == 0 || y == _mapHeight - 1)
                    {
                        if (_borders) _map[x, y] = 1;
                    }
                    else
                    {
                        _map[x, y] = Random.Range(0, 100) < _fillPercent ? 1 : 0;
                    }
                }
            }
        }
    }
}