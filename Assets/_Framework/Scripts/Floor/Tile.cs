using UnityEngine;
using System.Collections;
namespace Framework{
	
	public class Tile{
		int X;
		int Y;
		int Type;

		public void SetX(int Position){
			X = Position;
		}

		public void SetY(int Position){
			Y = Position;
		}

		public int GetX(){
			return X;
		}

		public int GetY(){
			return Y;
		}
		public void SetType(int TileType){
			Type = TileType;
		}
	}
}