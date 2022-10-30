using System.Collections.Generic;
using Factories.Tile;
using Grid.Tile;
using UnityEngine;

namespace Grid
{
	public class GridService : IGridService
	{
		private readonly ITileFactory _tileFactory;
		private readonly Dictionary<Vector2Int, ITilePresenter> _tiles = new();
		
		public GridService(ITileFactory tileFactory)
		{
			_tileFactory = tileFactory;
		}

		public void GenerateGrid(int width, int height)
		{
			for (var x = 0; x < width; x++)
			{
				for (var y = 0; y < height; y++)
				{
					var position = new Vector2Int(x, y);
					var tile = _tileFactory.Create(position);
					_tiles.Add(new Vector2Int(x, y), tile);
				}
			}
		}

		public ITilePresenter GetTile(Vector2Int vector2Int) => _tiles[vector2Int];
	}
}