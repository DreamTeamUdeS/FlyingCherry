using UnityEngine;
using System.Collections;
using System.IO;
using System;
using Framework;
using System.Collections.Generic;

public class floorGenerator : MonoBehaviour {
	public GameObject Tile;


	public void LoadMap(string FileName){
		byte[] FileBytes = File.ReadAllBytes (FileName);

		short[] FileShort = new short[(short)Math.Ceiling ((double)FileBytes.Length / 2)];
		Buffer.BlockCopy (FileBytes, 0, FileShort, 0, FileBytes.Length);

		short TileCount = FileShort [0];
		List<Tile> Tiles  = new List<Tile>(TileCount);

		short offset = 1;

		for(int i = 0; i < TileCount; i++){
			Tiles.Add(new Tile());
			Tiles[i].SetX(FileShort[offset]);
			offset++;
			Tiles [i].SetY(FileShort[offset]);
			offset++;
			Tiles [i].SetType(FileShort[offset]);
			offset++;
			GameObject maTile = Instantiate (Tile);
			Vector3 position = new Vector3 (Tiles [i].GetX (), 0, Tiles [i].GetY ());

			maTile.transform.position= position;
		}
	}
		
	public void GenerateBinaryMap(){
		
		using (BinaryWriter binWriter =	new BinaryWriter(new FileStream(Path.Combine(UnityEngine.Application.dataPath, "_Game/map/map.bin"), FileMode.Create)))
		{
			binWriter.Write((short)4);
			binWriter.Write((short)0);//x
			binWriter.Write((short)0);//y
			binWriter.Write((short)0);//type
			binWriter.Write((short)1);//x
			binWriter.Write((short)0);//y
			binWriter.Write((short)0);//type
			binWriter.Write((short)0);//x
			binWriter.Write((short)1);//y
			binWriter.Write((short)0);//type
			binWriter.Write((short)1);//x
			binWriter.Write((short)1);//y
			binWriter.Write((short)0);//type
		}
	}

	void Start(){
		GenerateBinaryMap();
		LoadMap(Path.Combine(UnityEngine.Application.dataPath, "_Game/map/map.bin"));
	}
}