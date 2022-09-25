﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace EnemizerLibrary
{
    public class DungeonSpriteRandomizer
    {
        readonly byte[][] randomSpriteGroup = new byte[60][];

        readonly Random rand;
        readonly RomData romData;

        public DungeonSpriteRandomizer(RomData romData, Random rand)
        {
            this.romData = romData;
            this.rand = rand;
        }

        public void RandomizeDungeonSprites(bool absorbable, byte[][] subsetGfxSprites)
        {
            this.CreateSpriteGroup();
            this.PatchSpriteGroup();

            this.Randomize_Dungeons_Sprite(absorbable, subsetGfxSprites);
        }

        public void Randomize_Dungeons_Sprite(bool absorbable, byte[][] subset_gfx_sprites)
        {
            var roomSprites = new RoomSpriteCollection();

            foreach (int room in roomSprites.randomized_rooms)
            {
                while (true)
                {
                    // Select one of the 60 sprites group avoid the ones that are empty because they contain npcs/bosses
                    byte sprite_group = (byte)rand.Next(60);
                    if (randomSpriteGroup[sprite_group].Length == 0) { continue; } // restart

                    // The group we selected is not empty - check if the room is part of a special room

                    /* NOTE: Some rooms have multiple required sprites like shadows, crystal switches;
                     * might need to force a specific group for these rooms
                     */

                    Console.WriteLine("Start Generation " + room.ToString());
                    // tongue switch/crystal subset3 on 83
                    // switch/crystal subset3 on  82
                    if (RoomIdConstants.WallMasterRoom.Contains(room)) // if the current room is switch room
                    {
                        sprite_group = 39;
                        Console.WriteLine("Required Wall Master");
                    }

                    if (RoomIdConstants.canonRoom.Contains(room)) // if the current room is an Moving wall canon room
                    {
                        if (randomSpriteGroup[sprite_group][0] != 47) { continue; }
                        Console.WriteLine("Required Canon1");
                    }

                    if (RoomIdConstants.ShadowRoom.Contains(room)) // if the current room is an Shadow room
                    {
                        if (randomSpriteGroup[sprite_group][1] != 32) { continue; }
                        Console.WriteLine("Shadow");
                    }

                    if (RoomIdConstants.IcemanRoom.Contains(room))
                    {
                        if (randomSpriteGroup[sprite_group][2] != 38) { continue; }
                        Console.WriteLine("Required Iceman");
                    }

                    if (RoomIdConstants.WaterRoom.Contains(room))
                    {
                        if (randomSpriteGroup[sprite_group][2] != 34) { continue; }
                        Console.WriteLine("Required Water");
                    }

                    if (RoomIdConstants.canonRoom2.Contains(room)) //if the current room is a canon room
                    {
                        if (randomSpriteGroup[sprite_group][2] != 46) { continue; }
                        Console.WriteLine("Required Canon2");
                    }

                    if (RoomIdConstants.TonguesRoom.Contains(room)) // if the current room is tongue room
                    {
                        if (randomSpriteGroup[sprite_group][3] != 83) { continue; }
                        Console.WriteLine("Required Tongues");
                    }

                    if (RoomIdConstants.SwitchesRoom.Contains(room)) // if the current room is switch room
                    {
                        if (randomSpriteGroup[sprite_group][3] != 82) { continue; }
                        Console.WriteLine("Required Switches");
                    }

                    if (RoomIdConstants.bumperandcrystalRoom.Contains(room)) // if the current room is bumper/crystal/laser eye room
                    {
                        if (randomSpriteGroup[sprite_group][3] == 82 || randomSpriteGroup[sprite_group][3] == 83)
                        {
                        }
                        else
                        { continue; }
                        Console.WriteLine("Required BumperCrystalEyes");
                    }

                    if (room == RoomIdConstants.R85_CastleSecretEntrance_UncleDeathRoom) // uncle
                    {
                        sprite_group = 13; // force sprite_group to be uncle 13
                    }

                    if (room == RoomIdConstants.R127_IcePalace_BigSpikeTrapsRoom)
                    {
                        if (randomSpriteGroup[sprite_group][0] != 31)
                        {
                            continue;
                        }
                    }

                    if (roomSprites.RoomSprites[room].Length != 0)
                    {
                        // we finally have a sprite_group that contain good subset for that room
                        var sprites = new List<byte>(); // create a new list of sprite that can possibly be in the room

                        var needKillableSprite = false;
                        // check all the sprites addresses of that room we are in check if that room is a "shutter door" room
                        foreach (var shutterRoom in RoomIdConstants.NeedKillable_doors)
                        {
                            if (shutterRoom == room) //if we are in a shutterdoor room then
                            {
                                needKillableSprite = true;
                            }
                        }

                        foreach (var s in subset_gfx_sprites[randomSpriteGroup[sprite_group][0]]) // add all subset0 sprites of the selected group
                        {
                            sprites.Add(s);
                        }
                        foreach (var s in subset_gfx_sprites[randomSpriteGroup[sprite_group][1]]) // add all subset1 sprites of the selected group
                        {
                            sprites.Add(s);
                        }
                        foreach (var s in subset_gfx_sprites[randomSpriteGroup[sprite_group][2]]) // add all subset2 sprites of the selected group
                        {
                            sprites.Add(s);
                        }
                        foreach (var s in subset_gfx_sprites[randomSpriteGroup[sprite_group][3]]) // add all subset3 sprites of the selected group
                        {
                            sprites.Add(s);
                        }
                        if (needKillableSprite)
                        {
                            sprites = RemoveUnkillableSprite(room, sprites);
                        }

                        //our sprites list should contain at least 1 sprite at this point else then restart
                        if (sprites.Count <= 0) continue;
                        var real_sprites = sprites.Count;
                        if (absorbable)
                        {
                            for (var j = 0; j < 3; j++)
                            {
                                // pick 3 sprite
                                sprites.Add(SpriteConstants.AbsorbableSprites[rand.Next(SpriteConstants.AbsorbableSprites.Length)]); // add all the absorbable sprites
                            }
                        }
                        var c = sprites.Count;
                        // LAG REDUCTION CODE !!!
                        if (room == RoomIdConstants.R203_ThievesTown_NorthWestEntranceRoom) // add same amount of green rupee in the pool as the number of sprites
                        {
                            for (int i = 0; i < c; i++)
                            {
                                sprites.Add(0xD9);
                            }
                        }
                        if (room == RoomIdConstants.R204_ThievesTown_NorthEastEntranceRoom) // add same amount of green rupee in the pool as the number of sprites
                        {
                            for (int i = 0; i < c; i++)
                            {
                                sprites.Add(0xD9);
                            }
                        }
                        if (room == RoomIdConstants.R220_ThievesTown_SouthEastEntranceRoom) // add same amount of green rupee in the pool as the number of sprites
                        {
                            for (int i = 0; i < c; i++)
                            {
                                sprites.Add(0xD9);
                            }
                        }

                        // for each sprites address in the room we are currently modifying
                        for (var i = 0; i < roomSprites.RoomSprites[room].Length; i++)
                        {
                            var selectedSprite = sprites[rand.Next(real_sprites)];
                            // Select a new sprite from the sprites list we will put at that address
                            if (absorbable)
                            {
                                selectedSprite = sprites[rand.Next(real_sprites + (rand.Next(3)))];
                            }

                            if (RoomIdConstants.noStatueRoom.Contains(room))
                            {
                                if (selectedSprite == 0x1C) continue;
                            }

                            if (room == RoomIdConstants.R63_IcePalace_MapChestRoom | room == RoomIdConstants.R206_IcePalace_HoletoKholdstareRoom)
                            {
                                if (selectedSprite == 0x86) continue;
                            }

                            if (room == RoomIdConstants.R291_MiniMoldormCave)
                            {
                                if (selectedSprite == 0xE4) continue;
                            }

                            if (roomSprites.RoomSprites[room][i] == 0x04DE29)
                            {
                                if (selectedSprite.IsIn<byte>(0x7D, 0x8A, 0x61, 0x15)) continue;
                            }

                            for (var j = 0; j < SpriteConstants.KepSprites.Length; j++)
                            {
                                // Check if the sprite address we are modifying is a key drop sprite then it need to be a killable sprite
                                if (roomSprites.RoomSprites[room][i] == SpriteConstants.KepSprites[j])
                                {
                                    byte protection_try = 0;
                                    while (true)
                                    {
                                        protection_try++;
                                        selectedSprite = sprites[rand.Next(sprites.Count)]; //generate a new sprite to get a killable sprite
                                        if (SpriteConstants.NonKillable.Contains(selectedSprite)) // if the selected sprite we have is invincible then restart
                                        {
                                            if (room == RoomIdConstants.R107_GanonsTower_MimicsRooms
                                                || room == RoomIdConstants.R109_GanonsTower_Gauntlet4_5
                                                || room == RoomIdConstants.R93_GanonsTower_Gauntlet1_2_3
                                                || room == RoomIdConstants.R27_PalaceofDarkness_Mimics_MovingWallRoom
                                                || room == RoomIdConstants.R11_PalaceofDarkness_TurtleRoom
                                                || room == RoomIdConstants.R123_GanonsTower
                                                || room == RoomIdConstants.R125_GanonsTower_Winder_WarpMazeRoom)
                                            {
                                                if (SpriteConstants.BowSprites.Contains(selectedSprite)) break;
                                                if (SpriteConstants.HammerSprites.Contains(selectedSprite)) break;
                                            }
                                            if (room == RoomIdConstants.R75_PalaceofDarkness_Warps_SouthMimicsRoom
                                                || room == RoomIdConstants.R216_EasternPalace_PreArmosKnightsRoom
                                                || room == RoomIdConstants.R217_EasternPalace_CanonballRoom
                                                || room == RoomIdConstants.R218_EasternPalace)
                                            {
                                                if (SpriteConstants.BowSprites.Contains(selectedSprite)) break;
                                            }
                                            if (protection_try >= 200) break;
                                            continue; //add a protection timer if after 200 try then it might be possible the selected group do not have killable sprite then restart from the begining
                                        }
                                        break;
                                    }
                                    if (protection_try >= 200) break; // reset from the start
                                }
                            }

                            if (room == RoomIdConstants.R151_MiseryMire_TorchPuzzle_MovingWallRoom)
                            {
                                romData[roomSprites.RoomSprites[room][i] - 2] = 0x15;
                                romData[roomSprites.RoomSprites[room][i] - 1] = 0x07;
                            }

                            //Modify the sprite in the ROM / also set all overlord sprites on normal sprites to prevent any crashes
                            romData[roomSprites.RoomSprites[room][i]] = selectedSprite;
                            romData[roomSprites.RoomSprites[room][i] - 1] = (byte)(romData[roomSprites.RoomSprites[room][i] - 1] & 0x1F);//change overlord into normal sprite
                                                                                                                                         //extra_roll = 0;
                        }
                    }

                    romData[0x120090 + (room * 14) + 3] = sprite_group; //set the room header sprite gfx

                    break; //if everything is fine in that room then go to the next one
                }
            }

            // remove key in skull wood to prevent a softlock
            romData[0x04DD74] = 0x16;
            romData[0x04DD75] = 0x05;
            romData[0x04DD76] = 0xE4;

            // remove all sprite in the room before boss room in mire can cause problem with different boss in the room
            // NOT NEEDED ANYMORE
            // ROM_DATA[0x04E591] = 0xFF;
        }

        public List<byte> RemoveUnkillableSprite(int room, List<byte> sprites)
        {
            for (var i = 0; i < sprites.Count; i++)
            {
                var noChange = false;
                if (room == RoomIdConstants.R107_GanonsTower_MimicsRooms
                    || room == RoomIdConstants.R109_GanonsTower_Gauntlet4_5
                    || room == RoomIdConstants.R93_GanonsTower_Gauntlet1_2_3
                    || room == RoomIdConstants.R27_PalaceofDarkness_Mimics_MovingWallRoom
                    || room == RoomIdConstants.R11_PalaceofDarkness_TurtleRoom
                    || room == RoomIdConstants.R123_GanonsTower
                    || room == RoomIdConstants.R125_GanonsTower_Winder_WarpMazeRoom)
                {

                    if (SpriteConstants.BowSprites.Contains(sprites[i]))
                    {
                        noChange = true;
                    }
                    if (SpriteConstants.HammerSprites.Contains(sprites[i]))
                    {
                        noChange = true;
                    }
                }

                if (room == RoomIdConstants.R75_PalaceofDarkness_Warps_SouthMimicsRoom
                    || room == RoomIdConstants.R216_EasternPalace_PreArmosKnightsRoom
                    || room == RoomIdConstants.R217_EasternPalace_CanonballRoom
                    || room == RoomIdConstants.R218_EasternPalace)
                {
                    if (SpriteConstants.BowSprites.Contains(sprites[i]))
                    {
                        noChange = true;
                    }
                }

                if (!noChange)
                {
                    if (SpriteConstants.NonKillableShutter.Contains(sprites[i]))
                    {
                        sprites.RemoveAt(i);
                        continue;
                    }
                }
            }
            return sprites;
        }

        public void CreateSpriteGroup()
        {
            // id + 0x40 (64) = HM block id
            // Creations of the guards group :
            randomSpriteGroup[0] = new byte[] { }; // Do not randomize that group (Ending thing?)
            randomSpriteGroup[1] = new byte[] { 70, GetGuardSubset1(), 19, SpriteConstants.SpriteSubset3[rand.Next(SpriteConstants.SpriteSubset3.Length)] };
            randomSpriteGroup[2] = new byte[] { 70, GetGuardSubset1(), 19, 83 }; // tongue switch group
            randomSpriteGroup[3] = new byte[] { 72, GetGuardSubset1(), 19, SpriteConstants.SpriteSubset3[rand.Next(SpriteConstants.SpriteSubset3.Length)] };
            randomSpriteGroup[4] = new byte[] { 72, GetGuardSubset1(), 19, 82 }; // switch group
            randomSpriteGroup[5] = new byte[] { }; // Do not randomize that group (Npcs, Items, some others thing)
            randomSpriteGroup[6] = new byte[] { }; // Do not randomize that group (Sanctuary Mantle, Priest)
            randomSpriteGroup[7] = new byte[] { }; // Do not randomize that group (Npcs, Arghus)
            randomSpriteGroup[8] = FullyRandomizeThatGroup(); // Force Group 8 for Iceman subset2 on 38
            randomSpriteGroup[8][2] = 38;
            randomSpriteGroup[9] = new byte[] { }; // Do not randomize that group (Armos Knight)
            randomSpriteGroup[10] = FullyRandomizeThatGroup(); // Force Group 10 for Watersprites subset2 on 34
            randomSpriteGroup[10][2] = 34;
            randomSpriteGroup[11] = new byte[] { }; // Do not randomize that group (Lanmolas)
            randomSpriteGroup[12] = new byte[] { }; // Do not randomize that group (Moldorm)
            randomSpriteGroup[13] = FullyRandomizeThatGroup(); //(Link's House)/Sewer restore uncle (81)
            randomSpriteGroup[13][0] = 81;
            randomSpriteGroup[14] = new byte[] { }; // Do not randomize that group (Npcs)
            randomSpriteGroup[15] = new byte[] { }; // Do not randomize that group (Npcs)
            randomSpriteGroup[16] = new byte[] { }; // Do not randomize that group (Minigame npcs, witch)
            randomSpriteGroup[17] = FullyRandomizeThatGroup();//Force Group 17 for Shadow(Zoro) Subset 1 on 32
            randomSpriteGroup[17][1] = 32;
            randomSpriteGroup[18] = new byte[] { }; // Do not randomize that group (Vitreous?,Agahnim)
            randomSpriteGroup[19] = FullyRandomizeThatGroup();//Force group 19 for Wallmaster Subset2 on 35
            randomSpriteGroup[19][2] = 35;
            randomSpriteGroup[20] = new byte[] { }; // Do not randomize that group (Bosses)
            randomSpriteGroup[21] = new byte[] { }; // Do not randomize that group (Bosses)
            randomSpriteGroup[22] = new byte[] { }; // Do not randomize that group (Bosses)
            randomSpriteGroup[23] = new byte[] { }; // Do not randomize that group (Bosses)
            randomSpriteGroup[24] = new byte[] { }; // Do not randomize that group (Bosses)
            randomSpriteGroup[25] = FullyRandomizeThatGroup();
            randomSpriteGroup[26] = new byte[] { }; // Do not randomize that group (Bosses)
            randomSpriteGroup[27] = FullyRandomizeThatGroup(); // Force group 27 for movingwallcanon subset0 on 47
            randomSpriteGroup[27][0] = 47;
            randomSpriteGroup[28] = FullyRandomizeThatGroup(); // Force group 27 for canon rooms subset2 on 46
            randomSpriteGroup[28][2] = 46;
            randomSpriteGroup[29] = FullyRandomizeThatGroup();
            randomSpriteGroup[30] = FullyRandomizeThatGroup();
            randomSpriteGroup[31] = FullyRandomizeThatGroup();
            randomSpriteGroup[32] = new byte[] { }; // Do not randomize that group (Bosses)
            randomSpriteGroup[33] = FullyRandomizeThatGroup();
            randomSpriteGroup[34] = new byte[] { }; // Do not randomize that group (Ganon)
            randomSpriteGroup[35] = new byte[] { }; // Do not randomize that group (Lanmolas)
            randomSpriteGroup[36] = FullyRandomizeThatGroup();
            randomSpriteGroup[37] = FullyRandomizeThatGroup();
            randomSpriteGroup[38] = FullyRandomizeThatGroup();
            randomSpriteGroup[39] = FullyRandomizeThatGroup();
            randomSpriteGroup[39][2] = 35;
            randomSpriteGroup[39][3] = 82;

            // room 88 require bumper, switch
            // room 104 require bumper, wall master
            randomSpriteGroup[40] = new byte[] { }; // Do not randomize that group (Npcs)
            for (var i = 41; i < 60; i++)
            {
                randomSpriteGroup[i] = FullyRandomizeThatGroup(); // group from 105 to 124 are empty
            }

            randomSpriteGroup[29][0] = 47;
            randomSpriteGroup[29][2] = 46;
            randomSpriteGroup[30][0] = 14;
            randomSpriteGroup[31][1] = 32;
            randomSpriteGroup[31][2] = 28;
            randomSpriteGroup[38][2] = 38;
            randomSpriteGroup[38][3] = 82;
            randomSpriteGroup[33][2] = 34;
            randomSpriteGroup[36][3] = 83;
            randomSpriteGroup[37][3] = 82;
            randomSpriteGroup[41][2] = 35;

            for (int i = 0; i < SpriteConstants.StatisSprites.Length; i++)
            {
                romData[0x6B44C + SpriteConstants.StatisSprites[i]] = (byte)(romData[0x6B44C + SpriteConstants.StatisSprites[i]] | 0x40);
            }
        }

        public void PatchSpriteGroup()
        {
            for (int i = 0; i < 60; i++)
            {
                if (randomSpriteGroup[i].Length != 0)
                {
                    romData[0x05C97 + (i * 4)] = randomSpriteGroup[i][0];
                    romData[0x05C97 + (i * 4) + 1] = randomSpriteGroup[i][1];
                    romData[0x05C97 + (i * 4) + 2] = randomSpriteGroup[i][2];
                    romData[0x05C97 + (i * 4) + 3] = randomSpriteGroup[i][3];
                }
            }
        }

        public byte GetGuardSubset1()
        {
            return rand.Next(2) switch
            {
                0 => 73,
                _ => 13,
            };
        }

        public byte[] FullyRandomizeThatGroup()
        {
            return new byte[]
            {
                SpriteConstants.SpriteSubset0[rand.Next(SpriteConstants.SpriteSubset0.Length)],
                SpriteConstants.SpriteSubset1[rand.Next(SpriteConstants.SpriteSubset1.Length)],
                SpriteConstants.SpriteSubset2[rand.Next(SpriteConstants.SpriteSubset2.Length)],
                SpriteConstants.SpriteSubset3[rand.Next(SpriteConstants.SpriteSubset3.Length)]
            };
        }
    }
}
