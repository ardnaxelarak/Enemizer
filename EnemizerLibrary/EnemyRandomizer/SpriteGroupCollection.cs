﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace EnemizerLibrary
{
    public class SpriteGroupCollection
    {
        List<SpriteGroup> spriteGroups = new();
        public List<SpriteGroup> SpriteGroups
        {
            get
            {
                if (!Loaded)
                {
                    throw new Exception("SpriteGroupCollection - Tried to access SpriteGroups without loading them");
                }
                return this.spriteGroups;
            }
            set
            {
                this.spriteGroups = value;
            }
        }

        public IEnumerable<SpriteGroup> UsableOverworldSpriteGroups
        {
            // TODO: what should be the max
            // let's assume max of 64 because that is where dungeons start
            // but HM lets you go up to 79....
            get => SpriteGroups.Where(x => x.GroupId > 0 && x.GroupId < 0x40);
        }

        public IEnumerable<SpriteGroup> UsableDungeonSpriteGroups
        {
            get => DungeonSpriteGroups; // .Where(x => !DoNotUseForDungeonGroupIds.Contains(x.DungeonGroupId));
        }

        IEnumerable<SpriteGroup> DungeonSpriteGroups
        {
            get => SpriteGroups.Where(x => x.DungeonGroupId > 0 && x.DungeonGroupId < 60);
        }

        public IEnumerable<SpriteGroup> GetPossibleDungeonSpriteGroups(Room room, List<SpriteRequirement> doNotUpdateSprites = null)
        {
            var needsKey = room.Sprites.Any(x => x.HasAKey);
            var needsKillable = room.IsShutterRoom;
            var needsWater = room.IsWaterRoom;

            var req = dungeonReqs.GetGroupRequirementForRoom(room);

            var waterGroupIds = spriteRequirementsCollection.WaterSprites.SelectMany(x => x.GroupId).ToList();
            var waterSub0Ids = spriteRequirementsCollection.WaterSprites.SelectMany(x => x.SubGroup0).ToList();
            var waterSub1Ids = spriteRequirementsCollection.WaterSprites.SelectMany(x => x.SubGroup1).ToList();
            var waterSub2Ids = spriteRequirementsCollection.WaterSprites.SelectMany(x => x.SubGroup2).ToList();
            var waterSub3Ids = spriteRequirementsCollection.WaterSprites.SelectMany(x => x.SubGroup3).ToList();

            if (!needsKey && !needsKillable && !needsWater
                && (doNotUpdateSprites == null || doNotUpdateSprites.Count == 0)
                && req.GroupId.Count == 0
                && req.SubGroup0.Count == 0 && req.SubGroup1.Count == 0 && req.SubGroup2.Count == 0 && req.SubGroup3.Count == 0)
            {
                var includeGroupId =
                    spriteRequirementsCollection.SpriteRequirements
                        .Where(x => x.IsEnemySprite && !x.Boss)
                        .SelectMany(x => x.GroupId)
                        .Where(x => !waterGroupIds.Contains(x)) // exclude water sprites
                        .ToList();
                var includeSubGroup0Id =
                    spriteRequirementsCollection.SpriteRequirements
                        .Where(x => x.IsEnemySprite && !x.Boss)
                        .SelectMany(x => x.SubGroup0)
                        .Where(x => !waterSub0Ids.Contains(x)) // exclude water sprites
                        .ToList();
                var includeSubGroup1Id =
                    spriteRequirementsCollection.SpriteRequirements
                        .Where(x => x.IsEnemySprite && !x.Boss)
                        .SelectMany(x => x.SubGroup1)
                        .Where(x => !waterSub1Ids.Contains(x)) // exclude water sprites
                        .ToList();
                var includeSubGroup2Id =
                    spriteRequirementsCollection.SpriteRequirements
                        .Where(x => x.IsEnemySprite && !x.Boss)
                        .SelectMany(x => x.SubGroup2)
                        .Where(x => !waterSub2Ids.Contains(x)) // exclude water sprites
                        .ToList();
                var includeSubGroup3Id =
                    spriteRequirementsCollection.SpriteRequirements
                        .Where(x => x.IsEnemySprite && !x.Boss)
                        .SelectMany(x => x.SubGroup3)
                        .Where(x => !waterSub3Ids.Contains(x)) // exclude water sprites
                        .Where(x => x != 54 && x != 80) // exclude squirrels and chickens
                        .ToList();
                return UsableDungeonSpriteGroups
                    .Where(x => includeGroupId.Contains((byte)x.GroupId)
                        || includeSubGroup0Id.Contains((byte)x.SubGroup0)
                        || includeSubGroup1Id.Contains((byte)x.SubGroup1)
                        || includeSubGroup2Id.Contains((byte)x.SubGroup2)
                        || includeSubGroup3Id.Contains((byte)x.SubGroup3));
            }

            // TODO: gotta be a better way to do this
            var doNotUpdateGroupIds = doNotUpdateSprites.SelectMany(x => x.GroupId).ToList();
            var doNotUpdateSub0Ids = doNotUpdateSprites.SelectMany(x => x.SubGroup0).ToList();
            var doNotUpdateSub1Ids = doNotUpdateSprites.SelectMany(x => x.SubGroup1).ToList();
            var doNotUpdateSub2Ids = doNotUpdateSprites.SelectMany(x => x.SubGroup2).ToList();
            var doNotUpdateSub3Ids = doNotUpdateSprites.SelectMany(x => x.SubGroup3).ToList();
            if (!needsKey && !needsKillable && !needsWater
                && doNotUpdateGroupIds.Count == 0
                && doNotUpdateSub0Ids.Count == 0
                && doNotUpdateSub1Ids.Count == 0
                && doNotUpdateSub2Ids.Count == 0
                && doNotUpdateSub3Ids.Count == 0
                && req.GroupId.Count == 0
                && req.SubGroup0.Count == 0 && req.SubGroup1.Count == 0 && req.SubGroup2.Count == 0 && req.SubGroup3.Count == 0)
            {
                // probably a bunny beam or something else that doesn't have a required group
                var includeGroupId =
                        spriteRequirementsCollection.SpriteRequirements
                        .Where(x => x.IsEnemySprite && !x.Boss)
                        .SelectMany(x => x.GroupId)
                        .Where(x => !waterGroupIds.Contains(x)) // exclude water sprites
                        .ToList();
                var includeSubGroup0Id =
                        spriteRequirementsCollection.SpriteRequirements
                        .Where(x => x.IsEnemySprite && !x.Boss)
                        .SelectMany(x => x.SubGroup0)
                        .Where(x => !waterSub0Ids.Contains(x)) // exclude water sprites
                        .ToList();
                var includeSubGroup1Id =
                        spriteRequirementsCollection.SpriteRequirements
                        .Where(x => x.IsEnemySprite && !x.Boss)
                        .SelectMany(x => x.SubGroup1)
                        .Where(x => !waterSub1Ids.Contains(x)) // exclude water sprites
                        .ToList();
                var includeSubGroup2Id =
                        spriteRequirementsCollection.SpriteRequirements
                        .Where(x => x.IsEnemySprite && !x.Boss)
                        .SelectMany(x => x.SubGroup2)
                        .Where(x => !waterSub2Ids.Contains(x)) // exclude water sprites
                        .ToList();
                var includeSubGroup3Id =
                    spriteRequirementsCollection.SpriteRequirements
                        .Where(x => x.IsEnemySprite && !x.Boss)
                        .SelectMany(x => x.SubGroup3)
                        .Where(x => !waterSub3Ids.Contains(x)) // exclude water sprites
                        .Where(x => x != 54 && x != 80) // exclude squirrels and chickens
                        .ToList();
                return UsableDungeonSpriteGroups
                    .Where(x => includeGroupId.Contains((byte)x.GroupId)
                        || includeSubGroup0Id.Contains((byte)x.SubGroup0)
                        || includeSubGroup1Id.Contains((byte)x.SubGroup1)
                        || includeSubGroup2Id.Contains((byte)x.SubGroup2)
                        || includeSubGroup3Id.Contains((byte)x.SubGroup3));
            }

            //var usableGroups = spriteRequirementsCollection.SpriteRequirements.Where(x => x.GroupId)
            var killableGroupIds = spriteRequirementsCollection.KillableSprites.Where(x => x.SpriteId != SpriteConstants.StalSprite).SelectMany(x => x.GroupId).ToList();
            var killableSub0Ids = spriteRequirementsCollection.KillableSprites.Where(x => x.SpriteId != SpriteConstants.StalSprite).SelectMany(x => x.SubGroup0).ToList();
            var killableSub1Ids = spriteRequirementsCollection.KillableSprites.Where(x => x.SpriteId != SpriteConstants.StalSprite).SelectMany(x => x.SubGroup1).ToList();
            var killableSub2Ids = spriteRequirementsCollection.KillableSprites.Where(x => x.SpriteId != SpriteConstants.StalSprite).SelectMany(x => x.SubGroup2).ToList();
            var killableSub3Ids = spriteRequirementsCollection.KillableSprites.Where(x => x.SpriteId != SpriteConstants.StalSprite).SelectMany(x => x.SubGroup3).ToList();

            var keysGroupIds = spriteRequirementsCollection.KillableSprites.Where(x => x.SpriteId != SpriteConstants.StalSprite).Where(x => !x.CannotHaveKey).SelectMany(x => x.GroupId).ToList();
            var keysSub0Ids = spriteRequirementsCollection.KillableSprites.Where(x => x.SpriteId != SpriteConstants.StalSprite).Where(x => !x.CannotHaveKey).SelectMany(x => x.SubGroup0).ToList();
            var keysSub1Ids = spriteRequirementsCollection.KillableSprites.Where(x => x.SpriteId != SpriteConstants.StalSprite).Where(x => !x.CannotHaveKey).SelectMany(x => x.SubGroup1).ToList();
            var keysSub2Ids = spriteRequirementsCollection.KillableSprites.Where(x => x.SpriteId != SpriteConstants.StalSprite).Where(x => !x.CannotHaveKey).SelectMany(x => x.SubGroup2).ToList();
            var keysSub3Ids = spriteRequirementsCollection.KillableSprites.Where(x => x.SpriteId != SpriteConstants.StalSprite).Where(x => !x.CannotHaveKey).SelectMany(x => x.SubGroup3).ToList();

            return UsableDungeonSpriteGroups
                .Where(x => doNotUpdateGroupIds.Count == 0 || doNotUpdateGroupIds.Contains((byte)x.GroupId))
                .Where(x => doNotUpdateSub0Ids.Count == 0 || doNotUpdateSub0Ids.Contains((byte)x.SubGroup0))
                .Where(x => doNotUpdateSub1Ids.Count == 0 || doNotUpdateSub1Ids.Contains((byte)x.SubGroup1))
                .Where(x => doNotUpdateSub2Ids.Count == 0 || doNotUpdateSub2Ids.Contains((byte)x.SubGroup2))
                .Where(x => doNotUpdateSub3Ids.Count == 0 || doNotUpdateSub3Ids.Contains((byte)x.SubGroup3))
                .Where(x => req.GroupId.Count == 0 || req.GroupId.Contains((byte)x.DungeonGroupId))
                .Where(x => req.SubGroup0.Count == 0 || req.SubGroup0.Contains((byte)x.SubGroup0))
                .Where(x => req.SubGroup1.Count == 0 || req.SubGroup1.Contains((byte)x.SubGroup1))
                .Where(x => req.SubGroup2.Count == 0 || req.SubGroup2.Contains((byte)x.SubGroup2))
                .Where(x => req.SubGroup3.Count == 0 || req.SubGroup3.Contains((byte)x.SubGroup3))
                .Where(x => !needsKillable
                    || killableGroupIds.Contains((byte)x.GroupId)
                    || killableSub0Ids.Contains((byte)x.SubGroup0)
                    || killableSub1Ids.Contains((byte)x.SubGroup1)
                    || killableSub2Ids.Contains((byte)x.SubGroup2)
                    || killableSub3Ids.Contains((byte)x.SubGroup3))
                .Where(x => !needsKey
                    || keysGroupIds.Contains((byte)x.GroupId)
                    || keysSub0Ids.Contains((byte)x.SubGroup0)
                    || keysSub1Ids.Contains((byte)x.SubGroup1)
                    || keysSub2Ids.Contains((byte)x.SubGroup2)
                    || keysSub3Ids.Contains((byte)x.SubGroup3))
                .Where(x => !needsWater
                    || waterGroupIds.Contains((byte)x.GroupId)
                    || waterSub0Ids.Contains((byte)x.SubGroup0)
                    || waterSub1Ids.Contains((byte)x.SubGroup1)
                    || waterSub2Ids.Contains((byte)x.SubGroup2)
                    || waterSub3Ids.Contains((byte)x.SubGroup3));
        }

        public IEnumerable<SpriteGroup> GetPossibleOverworldSpriteGroups(List<SpriteRequirement> doNotUpdateSprites = null)
        {
            if (doNotUpdateSprites == null || doNotUpdateSprites.Count == 0)
            {
                return UsableOverworldSpriteGroups;
            }

            // TODO: gotta be a better way to do this
            var doNotUpdateGroupIds = doNotUpdateSprites.SelectMany(x => x.GroupId).ToList();
            var doNotUpdateSub0Ids = doNotUpdateSprites.SelectMany(x => x.SubGroup0).ToList();
            var doNotUpdateSub1Ids = doNotUpdateSprites.SelectMany(x => x.SubGroup1).ToList();
            var doNotUpdateSub2Ids = doNotUpdateSprites.SelectMany(x => x.SubGroup2).ToList();
            var doNotUpdateSub3Ids = doNotUpdateSprites.SelectMany(x => x.SubGroup3).ToList();

            return UsableOverworldSpriteGroups
                .Where(x => doNotUpdateGroupIds.Count == 0 || doNotUpdateGroupIds.Contains((byte)x.GroupId))
                .Where(x => doNotUpdateSub0Ids.Count == 0 || doNotUpdateSub0Ids.Contains((byte)x.SubGroup0))
                .Where(x => doNotUpdateSub1Ids.Count == 0 || doNotUpdateSub1Ids.Contains((byte)x.SubGroup1))
                .Where(x => doNotUpdateSub2Ids.Count == 0 || doNotUpdateSub2Ids.Contains((byte)x.SubGroup2))
                .Where(x => doNotUpdateSub3Ids.Count == 0 || doNotUpdateSub3Ids.Contains((byte)x.SubGroup3))
                ;
        }

        RomData RomData { get; set; }
        Random Rand { get; set; }
        RoomGroupRequirementCollection dungeonReqs;
        SpriteRequirementCollection spriteRequirementsCollection { get; set; }
        public bool Loaded { get; private set; }

        public SpriteGroupCollection(RomData romData, Random rand, SpriteRequirementCollection spriteRequirementsCollection)
        {
            this.RomData = romData;
            this.Rand = rand;
            this.spriteRequirementsCollection = spriteRequirementsCollection;

            dungeonReqs = new RoomGroupRequirementCollection();

            SpriteGroups = new List<SpriteGroup>();
        }

        public void LoadSpriteGroups()
        {
            Loaded = true;

            for (var i = 0; i < 144; i++)
            {
                var sg = new SpriteGroup(RomData, spriteRequirementsCollection, i);

                SpriteGroups.Add(sg);
            }
        }

        public void SetupRequiredOverworldGroups()
        {
            OverworldGroupRequirementCollection owReqs = new OverworldGroupRequirementCollection();

            var rGroup = owReqs.OverworldRequirements.Where(x => x.GroupId != null);
            foreach (var g in rGroup)
            {
                UsableOverworldSpriteGroups.Where(x => g.GroupId == x.GroupId).ToList()
                    .ForEach((x) =>
                    {
                        if (g.Subgroup0 == null && g.Subgroup1 == null && g.Subgroup2 == null && g.Subgroup3 == null)
                        {
                            // lazy
                            x.PreserveSubGroup0 = true;
                            x.PreserveSubGroup1 = true;
                            x.PreserveSubGroup2 = true;
                            x.PreserveSubGroup3 = true;
                        }

                        if (g.Subgroup0 != null)
                        {
                            x.SubGroup0 = (int)(g.Subgroup0 ?? x.SubGroup0);
                            x.PreserveSubGroup0 = true;
                        }
                        if (g.Subgroup1 != null)
                        {
                            x.SubGroup1 = (int)(g.Subgroup1 ?? x.SubGroup1);
                            x.PreserveSubGroup1 = true;
                        }
                        if (g.Subgroup2 != null)
                        {
                            x.SubGroup2 = (int)(g.Subgroup2 ?? x.SubGroup2);
                            x.PreserveSubGroup2 = true;
                        }
                        if (g.Subgroup3 != null)
                        {
                            x.SubGroup3 = (int)(g.Subgroup3 ?? x.SubGroup3);
                            x.PreserveSubGroup3 = true;
                        }
                        //if (g.GroupId != null)
                        //{
                        //    x.ForceRoomsToGroup.AddRange(g.Rooms);
                        //}
                    });
            }
        }

        public void SetupRequiredDungeonGroups()
        {
            dungeonReqs = new RoomGroupRequirementCollection();

            var rGroup = dungeonReqs.RoomRequirements.Where(x => x.GroupId != null);
            foreach (var g in rGroup)
            {
                DungeonSpriteGroups.Where(x => g.GroupId == x.DungeonGroupId).ToList()
                    .ForEach((x) =>
                    {
                        if (g.Subgroup0 != null)
                        {
                            x.SubGroup0 = (int)g.Subgroup0;
                            x.PreserveSubGroup0 = true;
                        }
                        if (g.Subgroup1 != null)
                        {
                            x.SubGroup1 = (int)g.Subgroup1;
                            x.PreserveSubGroup1 = true;
                        }
                        if (g.Subgroup2 != null)
                        {
                            x.SubGroup2 = (int)g.Subgroup2;
                            x.PreserveSubGroup2 = true;
                        }
                        if (g.Subgroup3 != null)
                        {
                            x.SubGroup3 = (int)g.Subgroup3;
                            x.PreserveSubGroup3 = true;
                        }
                        if (g.GroupId != null)
                        {
                            x.ForceRoomsToGroup.AddRange(g.Rooms);
                        }
                    }
                );
            }

            var duplicateRooms = dungeonReqs.RoomRequirements.Where(x => x.GroupId == null)
                .SelectMany(dr => dr.Rooms, (dr, r) => new RoomReq() { RoomId = r, Sub0 = dr.Subgroup0, Sub1 = dr.Subgroup1, Sub2 = dr.Subgroup2, Sub3 = dr.Subgroup3 })
                .ToList();

            var roomsDict = new Dictionary<int, RoomReq>();

            foreach (var d in duplicateRooms)
            {
                if (!roomsDict.ContainsKey(d.RoomId))
                {
                    roomsDict[d.RoomId] = d;
                }

                if (d.Sub0 != null)
                {
                    roomsDict[d.RoomId].Sub0 = d.Sub0;
                }
                if (d.Sub1 != null)
                {
                    roomsDict[d.RoomId].Sub1 = d.Sub1;
                }
                if (d.Sub2 != null)
                {
                    roomsDict[d.RoomId].Sub2 = d.Sub2;
                }
                if (d.Sub3 != null)
                {
                    roomsDict[d.RoomId].Sub3 = d.Sub3;
                }
            }

            var rooms = roomsDict.Values.ToList();

            foreach (var r in rooms)
            {
                // UGGGGGGGGGGGGGGGGGGGGGGG
                // TODO: check if we already saved one for another room and skip this room
                if (DungeonSpriteGroups
                    .Where(x => r.Sub0 == null || (x.SubGroup0 == r.Sub0 && x.PreserveSubGroup0))
                    .Where(x => r.Sub1 == null || (x.SubGroup1 == r.Sub1 && x.PreserveSubGroup1))
                    .Where(x => r.Sub2 == null || (x.SubGroup2 == r.Sub2 && x.PreserveSubGroup2))
                    .Where(x => r.Sub3 == null || (x.SubGroup3 == r.Sub3 && x.PreserveSubGroup3))
                    .Any())
                {
                    // skip this room because we already have a subgroup that will work
                    continue;
                }


                var possibleSubs = DungeonSpriteGroups.Where(y => !y.PreserveSubGroup0 || !y.PreserveSubGroup1 || !y.PreserveSubGroup2 || !y.PreserveSubGroup3).ToList();

                if (r.Sub0 != null)
                {
                    possibleSubs = possibleSubs.Where(x => !x.PreserveSubGroup0).ToList();
                }
                if (r.Sub1 != null)
                {
                    possibleSubs = possibleSubs.Where(x => !x.PreserveSubGroup1).ToList();
                }
                if (r.Sub2 != null)
                {
                    possibleSubs = possibleSubs.Where(x => !x.PreserveSubGroup2).ToList();
                }
                if (r.Sub3 != null)
                {
                    possibleSubs = possibleSubs.Where(x => !x.PreserveSubGroup3).ToList();
                }

                var updateSub = possibleSubs[Rand.Next(possibleSubs.Count)];

                if (r.Sub0 != null)
                {
                    updateSub.SubGroup0 = (int)r.Sub0;
                    updateSub.PreserveSubGroup0 = true;
                }
                if (r.Sub1 != null)
                {
                    updateSub.SubGroup1 = (int)r.Sub1;
                    updateSub.PreserveSubGroup1 = true;
                }
                if (r.Sub2 != null)
                {
                    updateSub.SubGroup2 = (int)r.Sub2;
                    updateSub.PreserveSubGroup2 = true;
                }
                if (r.Sub3 != null)
                {
                    updateSub.SubGroup3 = (int)r.Sub3;
                    updateSub.PreserveSubGroup3 = true;
                }
            }
        }

        class RoomReq
        {
            public int RoomId { get; set; }
            public int? Sub0 { get; set; }
            public int? Sub1 { get; set; }
            public int? Sub2 { get; set; }
            public int? Sub3 { get; set; }
        }

        public void UpdateRom()
        {
            foreach (var sg in SpriteGroups)
            {
                sg.UpdateRom();
            }
        }

        public void RandomizeDungeonGroups()
        {
            // dungeon sprite groups = 60 total. 
            foreach (var sg in UsableDungeonSpriteGroups)
            {
                if (!sg.PreserveSubGroup1 && SetGuardSubset1GroupIds.Contains(sg.DungeonGroupId))
                {
                    sg.PreserveSubGroup1 = true;
                    sg.SubGroup1 = GetRandomSubset1ForGuards();
                }

                if (!sg.PreserveSubGroup0)
                {
                    sg.SubGroup0 = GetRandomSubgroup0();
                }
                if (!sg.PreserveSubGroup1)
                {
                    sg.SubGroup1 = GetRandomSubgroup1();
                }
                if (!sg.PreserveSubGroup2)
                {
                    sg.SubGroup2 = GetRandomSubgroup2();
                }
                if (!sg.PreserveSubGroup3)
                {
                    sg.SubGroup3 = GetRandomSubgroup3();
                }

                // FixPairedGroups(sg);
            }
        }

        public void RandomizeOverworldGroups()
        {
            foreach (var sg in UsableOverworldSpriteGroups)
            {
                //if (!sg.PreserveSubGroup1 && SetGuardSubset1GroupIds.Contains(sg.DungeonGroupId))
                //{
                //    sg.PreserveSubGroup1 = true;
                //    sg.SubGroup1 = GetRandomSubset1ForGuards();
                //}

                if (!sg.PreserveSubGroup0)
                {
                    sg.SubGroup0 = GetRandomSubgroup0();
                }
                if (!sg.PreserveSubGroup1)
                {
                    sg.SubGroup1 = GetRandomSubgroup1();
                }
                if (!sg.PreserveSubGroup2)
                {
                    sg.SubGroup2 = GetRandomSubgroup2();
                }
                if (!sg.PreserveSubGroup3)
                {
                    sg.SubGroup3 = GetRandomSubgroup3();
                }
            }
        }

        byte GetRandomSubset1ForGuards()
        {
            return Rand.Next(2) switch
            {
                0 => 73,
                _ => 13,
            };
        }

        int GetRandomSubgroup0()
        {
            return PotentialSubset0[Rand.Next(PotentialSubset0.Length)];
        }
        int GetRandomSubgroup1()
        {
            return PotentialSubset1[Rand.Next(PotentialSubset1.Length)];
        }
        int GetRandomSubgroup2()
        {
            return PotentialSubset2[Rand.Next(PotentialSubset2.Length)];
        }
        int GetRandomSubgroup3()
        {
            return PotentialSubset3[Rand.Next(PotentialSubset3.Length)];
        }


        /*
        * Don't randomize
            1,
            5,
            7,
            13,
            14, // manually set
            15,
            18,
            23,
            24,
            34,
            40
        */
        /*
        * Remake
            14 = 71, 73, 76, 80 (change rooms 18, 264, 261, 266)
        */

        // TODO: can probably remove this
        //int[] DoNotRandomizeDungeonGroupIds = { 1, 5, 7, 13, 14, 15, 18, 23, 24, 34, 40,
        //    9, 11, 12, 20, 21, 22, 26, 28, 32 }; // bosses. need to change to just preserve the relevant sub group

        // keep this
        int[] DoNotUseForDungeonGroupIds = { 1, 5, 7, 13, 14, 15, 18, 23, 24, 34, 40 };

        //int[] DoNotRandomizeDungeonGroupIds = { 0, 5, 6, 7, 9, 11, 12, 14, 15, 16, 18, 20, 21, 22, 23, 24, 26, 32, 34, 35 };

        int[] PreserveDungeonSubGroup0GroupIds = { 1, 2, 3, 4, 13, 27, 29, 30 };
        int[] PreserveDungeonSubGroup1GroupIds = { 17, 31 };
        int[] PreserveDungeonSubGroup2GroupIds = { 1, 2, 3, 4, 8, 10, 19, 28, 29, 31, 33, 38, 39, 41 };
        int[] PreserveDungeonSubGroup3GroupIds = { 2, 4, 36, 37, 38, 39 };

        int[] SetGuardSubset1GroupIds = { 1, 2, 3, 4 };

        byte[] PotentialSubset0 = { 22, 31, 47, 14 }; //70-72 part of guards we already have 4 guard set don't need more
        byte[] PotentialSubset1 = { 44, 30, 32 };//73-13
        byte[] PotentialSubset2 = { 12, 18, 23, 24, 28, 46, 34, 35, 39, 40, 38, 41, 36, 37, 42 };//19 trainee guard
        byte[] PotentialSubset3 = { 17, 16, 27, 20, 82, 83 };
    }

    struct ManualGroup
    {
        public int GroupId { get; set; }
        public int Subset0 { get; set; }
        public int Subset1 { get; set; }
        public int Subset2 { get; set; }
        public int Subset3 { get; set; }
        public int[] ForceRooms { get; set; }
    }
}
