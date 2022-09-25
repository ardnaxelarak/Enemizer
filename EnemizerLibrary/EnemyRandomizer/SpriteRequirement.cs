﻿using System.Collections.Generic;
using System.Linq;

namespace EnemizerLibrary
{
    public class SpriteRequirement
    {
        public int SpriteId { get; set; }
        public string SpriteName { get => SpriteConstants.GetSpriteName(SpriteId); }
        public bool Overlord { get; set; }
        public bool Boss { get; set; }
        public bool DoNotRandomize { get; set; }
        public bool Killable { get; set; }
        public bool NPC { get; set; }
        public bool NeverUseDungeon { get; set; }
        public bool NeverUseOverworld { get; set; }
        public bool CannotHaveKey { get; set; }
        public bool IsObject { get; set; }
        public bool Absorbable { get; set; }
        public bool IsWaterSprite { get; set; }
        public bool IsEnemySprite { get; set; }
        public List<byte> GroupId { get; set; } = new List<byte>();
        public List<byte> SubGroup0 { get; set; } = new List<byte>();
        public List<byte> SubGroup1 { get; set; } = new List<byte>();
        public List<byte> SubGroup2 { get; set; } = new List<byte>();
        public List<byte> SubGroup3 { get; set; } = new List<byte>();
        public byte? Parameters { get; set; }
        public bool SpecialGlitched { get; set; }

        readonly List<int> excludedRooms = new();
        readonly List<int> dontRandomizeRooms = new();
        readonly List<int> spawnableRooms = new();

        public SpriteRequirement(int SpriteId)
        {
            this.SpriteId = SpriteId;
            this.IsEnemySprite = true;
        }

        public static SpriteRequirement New(int spriteId)
        {
            return new SpriteRequirement(spriteId);
        }

        public SpriteRequirement SetBoss()
        {
            Boss = true;
            DoNotRandomize = true; // TODO: ???
            return this;
        }

        public SpriteRequirement SetNPC()
        {
            NPC = true;
            DoNotRandomize = true;
            IsEnemySprite = false;
            return this;
        }

        public SpriteRequirement SetNeverUse()
        {
            NeverUseDungeon = true;
            NeverUseOverworld = true;
            // DoNotRandomize = true;
            return this;
        }

        public SpriteRequirement SetNeverUseDungeon()
        {
            NeverUseDungeon = true;
            return this;
        }

        public SpriteRequirement SetNeverUseOverworld()
        {
            NeverUseOverworld = true;
            return this;
        }

        public SpriteRequirement SetDoNotRandomize()
        {
            DoNotRandomize = true;
            return this;
        }

        public SpriteRequirement SetIsEnemySprite()
        {
            IsEnemySprite = true;
            return this;
        }

        public SpriteRequirement SetNotEnemySprite()
        {
            IsEnemySprite = false;
            return this;
        }

        public SpriteRequirement SetWaterSprite()
        {
            IsWaterSprite = true;
            CannotHaveKey = true; // TODO: remove this after we fix water sprites only showing up on water areas
            return this;
        }

        public SpriteRequirement SetOverlord()
        {
            DoNotRandomize = true;
            Overlord = true;
            return this;
        }

        public SpriteRequirement SetAbsorbable()
        {
            Absorbable = true;
            CannotHaveKey = true;
            return this;
        }

        public SpriteRequirement SetCannotHaveKey()
        {
            CannotHaveKey = true;
            return this;
        }

        public SpriteRequirement SetIsObject()
        {
            IsObject = true;
            IsEnemySprite = false;
            return this;
        }

        public SpriteRequirement SetKillable()
        {
            Killable = true;
            return this;
        }

        public SpriteRequirement AddGroup(params byte[] groupId)
        {
            this.GroupId.AddRange(groupId);
            return this;
        }

        public SpriteRequirement AddSubgroup0(params byte[] subgroup0)
        {
            this.SubGroup0.AddRange(subgroup0);
            return this;
        }

        public SpriteRequirement AddSubgroup1(params byte[] subgroup1)
        {
            this.SubGroup1.AddRange(subgroup1);
            return this;
        }

        public SpriteRequirement AddSubgroup2(params byte[] subgroup2)
        {
            this.SubGroup2.AddRange(subgroup2);
            return this;
        }

        public SpriteRequirement AddSubgroup3(params byte[] subgroup3)
        {
            this.SubGroup3.AddRange(subgroup3);
            return this;
        }

        public SpriteRequirement SetParameters(byte parameters)
        {
            this.Parameters = parameters;
            return this;
        }

        public SpriteRequirement IsSpecialGlitched()
        {
            SpecialGlitched = true;
            return this;
        }

        public SpriteRequirement AddExcludedRooms(params int[] roomIds)
        {
            this.excludedRooms.AddRange(roomIds);
            return this;
        }

        public SpriteRequirement AddDontRandomizeRooms(params int[] roomIds)
        {
            this.dontRandomizeRooms.AddRange(roomIds);
            return this;
        }

        public SpriteRequirement AddSpawnableRooms(params int[] roomIds)
        {
            this.spawnableRooms.AddRange(roomIds);
            return this;
        }

        public bool SpriteInGroup(SpriteGroup spriteGroup)
        {
            if (this.GroupId != null && this.GroupId.Count > 0 && !this.GroupId.Contains((byte)spriteGroup.DungeonGroupId))
            {
                return false;
            }
            if (this.SubGroup0 != null && this.SubGroup0.Count > 0 && !this.SubGroup0.Contains((byte)spriteGroup.SubGroup0))
            {
                return false;
            }
            if (this.SubGroup1 != null && this.SubGroup1.Count > 0 && !this.SubGroup1.Contains((byte)spriteGroup.SubGroup1))
            {
                return false;
            }
            if (this.SubGroup2 != null && this.SubGroup2.Count > 0 && !this.SubGroup2.Contains((byte)spriteGroup.SubGroup2))
            {
                return false;
            }
            if (this.SubGroup3 != null && this.SubGroup3.Count > 0 && !this.SubGroup3.Contains((byte)spriteGroup.SubGroup3))
            {
                return false;
            }

            return true;
        }

        public bool CanSpawnInRoom(Room room)
        {
            return !excludedRooms.Contains(room.RoomId)
                && (spawnableRooms.Count == 0 || spawnableRooms.Contains(room.RoomId)
                && (this.SpriteId != SpriteConstants.WallmasterSprite || room.RoomId < 256)); // wall masters need an 'exit' set and only rooms 0-255 have one
        }

        public bool CanBeRandomizedInRoom(Room room)
        {
            return !DoNotRandomize && (dontRandomizeRooms.Count == 0 || dontRandomizeRooms.Contains(room.RoomId));
        }
    }

    public class SpriteRequirementCollection
    {
        public List<SpriteRequirement> SpriteRequirements { get; set; }

        public IEnumerable<SpriteRequirement> RandomizableSprites
        {
            get => SpriteRequirements.Where(x => !x.DoNotRandomize);
        }

        public List<SpriteRequirement> DoNotRandomizeSprites
        {
            get => SpriteRequirements.Where(x => x.DoNotRandomize).ToList();
        }

        public IEnumerable<SpriteRequirement> UsableEnemySprites
        {
            get => SpriteRequirements.Where(x => !x.NPC && x.IsEnemySprite && !x.Boss && !x.Overlord && !x.IsObject);
        }

        public IEnumerable<SpriteRequirement> GetUsableDungeonEnemySprites(bool allowAbsorbable = false)
        {
            return UsableEnemySprites.Where(x => !x.NeverUseDungeon && (!x.Absorbable || allowAbsorbable));
        }

        public IEnumerable<SpriteRequirement> GetUsableOverworldEnemySprites(bool allowAbsorbable = false)
        {
            // TODO: figure out why absorbables won't show up (red rupees, bombs, etc. won't show up...)
            return UsableEnemySprites.Where(x => !x.NeverUseOverworld && (!x.Absorbable || allowAbsorbable));
        }

        public IEnumerable<SpriteRequirement> KillableSprites
        {
            get => SpriteRequirements.Where(x => x.Killable);
        }

        public IEnumerable<SpriteRequirement> WaterSprites
        {
            get => SpriteRequirements.Where(x => x.IsWaterSprite);
        }

        public SpriteRequirementCollection()
        {
            SpriteRequirements = new List<SpriteRequirement>
            {
                SpriteRequirement.New(SpriteConstants.RavenSprite)
                    .SetCannotHaveKey()
                    .AddSubgroup3(17, 25)
                    .AddExcludedRooms(dontUseFlyingSprites),

                SpriteRequirement.New(SpriteConstants.VultureSprite)
                    .SetCannotHaveKey()
                    .AddSubgroup2(18)
                    .AddExcludedRooms(dontUseFlyingSprites),

                // SpriteRequirement.New(SpriteConstants.FlyingStalfosHeadSprite),

                SpriteRequirement.New(SpriteConstants.EmptySprite)
                    .SetNeverUse(),

                SpriteRequirement.New(SpriteConstants.PullSwitch_GoodSprite)
                    .SetDoNotRandomize()
                    .SetIsObject()
                    .SetNeverUse()
                    .AddSubgroup3(82, 83),

                SpriteRequirement.New(SpriteConstants.PullSwitch_TrapSprite)
                    .SetDoNotRandomize()
                    .SetIsObject()
                    .SetNeverUse()
                    .AddSubgroup3(82, 83),

                SpriteRequirement.New(SpriteConstants.Octorok_OneWaySprite)
                    .SetKillable()
                    .AddSubgroup2(12, 24),

                SpriteRequirement.New(SpriteConstants.MoldormSprite)
                    .SetBoss()
                    .AddSubgroup2(48),

                SpriteRequirement.New(SpriteConstants.Octorok_FourWaySprite)
                    .SetKillable()
                    .AddSubgroup2(12),

                SpriteRequirement.New(SpriteConstants.ChickenSprite)
                    .AddSubgroup3(21, 80)
                    .AddExcludedRooms(dontUseFlyingSprites),

                // SpriteRequirement.New(SpriteConstants.Octorok_MaybeSprite),

                SpriteRequirement.New(SpriteConstants.BuzzblobSprite)
                    .SetCannotHaveKey()
                    .SetKillable()
                    .AddSubgroup3(17)
                    .AddExcludedRooms(RoomIdConstants.R268_MimicCave),

                SpriteRequirement.New(SpriteConstants.SnapdragonSprite)
                    .SetKillable()
                    .AddSubgroup0(22)
                    .AddSubgroup2(23),

                SpriteRequirement.New(SpriteConstants.OctoballoonSprite)
                    .SetCannotHaveKey()
                    .AddSubgroup2(12)
                    .AddExcludedRooms(dontUseFlyingSprites),

                SpriteRequirement.New(SpriteConstants.OctoballoonHatchlingsSprite)
                    .SetNeverUse()
                    .AddSubgroup2(12),

                SpriteRequirement.New(SpriteConstants.HinoxSprite)
                    .SetKillable()
                    .AddSubgroup0(22),

                SpriteRequirement.New(SpriteConstants.MoblinSprite)
                    .SetKillable()
                    .AddSubgroup2(23),

                SpriteRequirement.New(SpriteConstants.MiniHelmasaurSprite)
                    .SetKillable()
                    .AddSubgroup1(30),

                SpriteRequirement.New(SpriteConstants.GargoylesDomainGateSprite)
                    .SetDoNotRandomize()
                    .SetIsObject()
                    .SetNeverUse(),

                SpriteRequirement.New(SpriteConstants.AntifairySprite)
                    .AddSubgroup3(82, 83)
                    .AddExcludedRooms(RoomIdConstants.R64_AgahnimsTower_FinalBridgeRoom) // can make it almost impossible to advance without powder
                    .AddExcludedRooms(dontUseFlyingSprites),

                SpriteRequirement.New(SpriteConstants.SahasrahlaAginahSprite)
                    .SetNPC()
                    .AddSubgroup2(76),

                // if you remove their bush before killing them they won't drop a key, so exclude them from key mob pool
                SpriteRequirement.New(SpriteConstants.BushHoarderSprite)
                    .SetCannotHaveKey()
                    .SetKillable()
                    .AddSubgroup3(17)
                    .AddExcludedRooms(RoomIdConstants.R268_MimicCave),

                SpriteRequirement.New(SpriteConstants.MiniMoldormSprite)
                    .SetKillable()
                    .AddSubgroup1(30),

                SpriteRequirement.New(SpriteConstants.PoeSprite)
                    .SetCannotHaveKey()
                    .AddSubgroup3(14, 21)
                    .AddExcludedRooms(dontUseFlyingSprites),

                SpriteRequirement.New(SpriteConstants.DwarvesSprite)
                    .SetNPC()
                    .SetDoNotRandomize()
                    .AddSubgroup1(77)
                    .AddSubgroup3(21),

                SpriteRequirement.New(SpriteConstants.ArrowInWall_MaybeSprite)
                    .SetDoNotRandomize()
                    .SetNeverUse(),

                SpriteRequirement.New(SpriteConstants.StatueSprite)
                    .SetDoNotRandomize()
                    .SetIsObject()
                    .AddSubgroup3(82, 83)
                    .AddExcludedRooms(dontUseImmovableSpritesRooms)
                    .AddExcludedRooms(RoomIdConstants.R63_IcePalace_MapChestRoom), // statues break the pull switch in the second room

                SpriteRequirement.New(SpriteConstants.WeathervaneSprite)
                    .SetDoNotRandomize()
                    .SetNeverUse(),

                SpriteRequirement.New(SpriteConstants.CrystalSwitchSprite)
                    .SetDoNotRandomize()
                    .SetIsObject()
                    .SetNeverUse()
                    .AddSubgroup3(82, 83),

                SpriteRequirement.New(SpriteConstants.BugCatchingKidSprite)
                    .SetNPC()
                    .SetDoNotRandomize()
                    .AddSubgroup0(81),

                SpriteRequirement.New(SpriteConstants.SluggulaSprite)
                    .AddSubgroup2(37),

                SpriteRequirement.New(SpriteConstants.PushSwitchSprite)
                    .SetDoNotRandomize()
                    .SetIsObject()
                    .SetNeverUse()
                    .AddSubgroup3(83),

                SpriteRequirement.New(SpriteConstants.RopaSprite)
                    .SetKillable()
                    .AddSubgroup0(22),

                SpriteRequirement.New(SpriteConstants.RedBariSprite)
                    .SetKillable()
                    .SetCannotHaveKey()
                    .AddSubgroup0(31)
                    .AddDontRandomizeRooms(RoomIdConstants.R127_IcePalace_BigSpikeTrapsRoom),

                SpriteRequirement.New(SpriteConstants.BlueBariSprite)
                    .SetKillable()
                    .AddSubgroup0(31)
                    .AddDontRandomizeRooms(RoomIdConstants.R127_IcePalace_BigSpikeTrapsRoom),

                SpriteRequirement.New(SpriteConstants.TalkingTreeSprite)
                    .SetNPC()
                    .SetDoNotRandomize()
                    .AddSubgroup0(21),

                SpriteRequirement.New(SpriteConstants.HardhatBeetleSprite)
                    .AddSubgroup1(30),

                SpriteRequirement.New(SpriteConstants.DeadrockSprite)
                    .AddSubgroup3(16)
                    .AddExcludedRooms(RoomIdConstants.R127_IcePalace_BigSpikeTrapsRoom)
                    .AddExcludedRooms(RoomIdConstants.R268_MimicCave),

                SpriteRequirement.New(SpriteConstants.StorytellersSprite)
                    .SetNPC()
                    .SetDoNotRandomize(), // TODO: add

                SpriteRequirement.New(SpriteConstants.BlindHideoutAttendantSprite)
                    .SetNPC()
                    .SetDoNotRandomize()
                    .AddSubgroup0(14, 79),

                SpriteRequirement.New(SpriteConstants.SweepingLadySprite)
                    .SetNPC()
                    .SetDoNotRandomize()
                    .AddGroup(6), // TODO: add subs instead?

                SpriteRequirement.New(SpriteConstants.MultipurposeSpriteSprite)
                    .SetNeverUse()
                    .SetDoNotRandomize(), // TODO: what is this?

                SpriteRequirement.New(SpriteConstants.LumberjacksSprite)
                    .SetNPC()
                    .SetDoNotRandomize()
                    .AddSubgroup2(74),

                SpriteRequirement.New(SpriteConstants.TelepathicStones_NoIdeaWhatThisActuallyIsLikelyUnusedSprite)
                    .SetIsObject()
                    .SetNeverUse()
                    .SetDoNotRandomize(),

                // this uses sub2 for LW and sub3 for DW...
                SpriteRequirement.New(SpriteConstants.FluteBoysNotesSprite)
                    .SetNeverUse()
                    .SetDoNotRandomize(), // TODO: does this use OAM2?

                SpriteRequirement.New(SpriteConstants.RaceHPNPCsSprite)
                    .SetNPC()
                    .SetDoNotRandomize()
                    .AddGroup(6),

                SpriteRequirement.New(SpriteConstants.Person_MaybeSprite)
                    .SetNPC()
                    .SetDoNotRandomize()
                    .AddGroup(6),

                SpriteRequirement.New(SpriteConstants.FortuneTellerSprite)
                    .SetNPC()
                    .SetDoNotRandomize()
                    .AddSubgroup0(75),

                SpriteRequirement.New(SpriteConstants.AngryBrothersSprite)
                    .SetNPC()
                    .SetDoNotRandomize()
                    .AddSubgroup0(79),

                SpriteRequirement.New(SpriteConstants.PullForRupeesSpriteSprite)
                    .SetIsObject()
                    .SetNeverUse()
                    .SetDoNotRandomize(),

                SpriteRequirement.New(SpriteConstants.ScaredGirl2Sprite)
                    .SetNPC()
                    .SetDoNotRandomize()
                    .AddGroup(6),

                SpriteRequirement.New(SpriteConstants.InnkeeperSprite)
                    .SetNPC()
                    .SetDoNotRandomize(), // TODO: add

                SpriteRequirement.New(SpriteConstants.WitchSprite)
                    .SetNPC()
                    .SetDoNotRandomize()
                    .AddSubgroup2(76),

                SpriteRequirement.New(SpriteConstants.WaterfallSprite)
                    .SetIsObject()
                    .SetNeverUse()
                    .SetDoNotRandomize(),

                SpriteRequirement.New(SpriteConstants.ArrowTargetSprite)
                    .SetNeverUse()
                    .SetDoNotRandomize(),

                SpriteRequirement.New(SpriteConstants.AverageMiddleAgedManSprite)
                    .SetNPC()
                    .SetDoNotRandomize()
                    .AddSubgroup3(17),

                SpriteRequirement.New(SpriteConstants.HalfMagicBatSprite)
                    .SetNPC()
                    .SetDoNotRandomize()
                    .AddSubgroup3(29),

                SpriteRequirement.New(SpriteConstants.DashItemSprite)
                    .SetNeverUse()
                    .SetDoNotRandomize(),

                SpriteRequirement.New(SpriteConstants.VillageKidSprite)
                    .SetNPC()
                    .SetDoNotRandomize()
                    .AddGroup(6),

                SpriteRequirement.New(SpriteConstants.Signs_ChickenLadyAlsoShowedUp_ScaredLadiesOutsideHousesSprite)
                    .SetNPC()
                    .SetDoNotRandomize()
                    .AddGroup(6),

                SpriteRequirement.New(SpriteConstants.RockHoarderSprite)
                    .AddSubgroup3(17)
                    .AddExcludedRooms(RoomIdConstants.R268_MimicCave),

                SpriteRequirement.New(SpriteConstants.TutorialSoldierSprite)
                    .SetNPC()
                    .SetNeverUse()
                    .SetDoNotRandomize(),

                SpriteRequirement.New(SpriteConstants.LightningLockSprite)
                    .SetNeverUse()
                    .SetDoNotRandomize()
                    .AddSubgroup3(63),

                // probably needs 19 and 41 for sub 2 for falling animation
                SpriteRequirement.New(SpriteConstants.BlueSwordSoldier_DetectPlayerSprite)
                    .SetKillable()
                    .AddSubgroup1(13, 73),

                SpriteRequirement.New(SpriteConstants.GreenSwordSoldierSprite)
                    .SetKillable()
                    .AddSubgroup1(73),

                SpriteRequirement.New(SpriteConstants.RedSpearSoldierSprite)
                    .SetKillable()
                    .AddSubgroup1(13, 73),

                SpriteRequirement.New(SpriteConstants.AssaultSwordSoldierSprite)
                    .SetKillable()
                    .AddSubgroup0(70) // TODO: double check 70 needed
                    .AddSubgroup1(73),

                SpriteRequirement.New(SpriteConstants.GreenSpearSoldierSprite)
                    .SetKillable()
                    .AddSubgroup1(13, 73),

                SpriteRequirement.New(SpriteConstants.BlueArcherSprite)
                    .SetKillable()
                    .AddSubgroup0(72)
                    .AddSubgroup1(73),

                SpriteRequirement.New(SpriteConstants.GreenArcherSprite)
                    .SetKillable()
                    .AddSubgroup0(72)
                    .AddSubgroup1(73),

                SpriteRequirement.New(SpriteConstants.RedJavelinSoldierSprite)
                    .SetKillable()
                    .AddSubgroup0(70) // TODO: double check 70 needed
                    .AddSubgroup1(73),

                SpriteRequirement.New(SpriteConstants.RedJavelinSoldier2Sprite)
                    .SetKillable()
                    .AddSubgroup0(70) // TODO: double check 70 needed
                    .AddSubgroup1(73),

                SpriteRequirement.New(SpriteConstants.RedBombSoldiersSprite)
                    .SetKillable()
                    .AddSubgroup0(70)
                    .AddSubgroup1(73),

                SpriteRequirement.New(SpriteConstants.GreenSoldierRecruits_HMKnightSprite)
                    .SetKillable()
                    .AddSubgroup1(73)
                    .AddSubgroup2(19),

                SpriteRequirement.New(SpriteConstants.GeldmanSprite)
                    .SetCannotHaveKey()
                    .SetKillable()
                    .AddSubgroup2(18)
                    .AddExcludedRooms(RoomIdConstants.R268_MimicCave),

                SpriteRequirement.New(SpriteConstants.RabbitSprite)
                    .AddSubgroup3(17),

                SpriteRequirement.New(SpriteConstants.PopoSprite)
                    .SetKillable()
                    .AddSubgroup1(44),

                SpriteRequirement.New(SpriteConstants.Popo2Sprite)
                    .SetKillable()
                    .AddSubgroup1(44),

                SpriteRequirement.New(SpriteConstants.CannonBallsSprite)
                    .SetDoNotRandomize()
                    .SetNeverUse()
                    .AddSubgroup2(46),

                SpriteRequirement.New(SpriteConstants.ArmosSprite)
                    .SetKillable()
                    .AddSubgroup3(16)
                    .AddExcludedRooms(RoomIdConstants.R268_MimicCave),

                SpriteRequirement.New(SpriteConstants.GiantZoraSprite)
                    .SetNPC()
                    .SetDoNotRandomize()
                    .AddSubgroup3(68),

                SpriteRequirement.New(SpriteConstants.ArmosKnightsSprite)
                    .SetBoss()
                    .AddSubgroup3(29),

                SpriteRequirement.New(SpriteConstants.LanmolasSprite)
                    .SetBoss()
                    .AddSubgroup3(49),

                SpriteRequirement.New(SpriteConstants.FireballZoraSprite)
                    .SetWaterSprite()
                    .AddSubgroup2(12, 24),

                SpriteRequirement.New(SpriteConstants.WalkingZoraSprite)
                    .SetWaterSprite()
                    .SetCannotHaveKey()
                    .SetKillable()
                    .AddSubgroup2(12)
                    .AddSubgroup3(68),

                SpriteRequirement.New(SpriteConstants.DesertPalaceBarriersSprite)
                    .SetNeverUse()
                    .SetDoNotRandomize()
                    .AddSubgroup2(18),

                SpriteRequirement.New(SpriteConstants.CrabSprite)
                    .SetKillable()
                    .AddSubgroup2(12),

                SpriteRequirement.New(SpriteConstants.BirdSprite)
                    .SetNeverUse()
                    .SetDoNotRandomize()
                    .AddSubgroup2(55)
                    .AddSubgroup3(54), // TODO: check 54

                SpriteRequirement.New(SpriteConstants.SquirrelSprite)
                    .SetNeverUse()
                    .SetDoNotRandomize()
                    .AddSubgroup2(55)
                    .AddSubgroup3(54),

                SpriteRequirement.New(SpriteConstants.Spark_LeftToRightSprite)
                    .AddSubgroup0(31),

                SpriteRequirement.New(SpriteConstants.Spark_RightToLeftSprite)
                    .AddSubgroup0(31),

                // TODO: need to figure out other places they shouldn't be used. Or need to add code to check sprite position vs door position and exclude these there
                SpriteRequirement.New(SpriteConstants.Roller_VerticalMovingSprite)
                    .AddSubgroup2(39)
                    .AddExcludedRooms(dontUseImmovableSpritesRooms),

                SpriteRequirement.New(SpriteConstants.Roller_VerticalMoving2Sprite)
                    .AddSubgroup2(39)
                    .AddExcludedRooms(dontUseImmovableSpritesRooms),

                SpriteRequirement.New(SpriteConstants.RollerSprite)
                    .AddSubgroup2(39)
                    .AddExcludedRooms(dontUseImmovableSpritesRooms),

                SpriteRequirement.New(SpriteConstants.Roller_HorizontalMovingSprite)
                    .AddSubgroup2(39)
                    .AddExcludedRooms(dontUseImmovableSpritesRooms),

                SpriteRequirement.New(SpriteConstants.BeamosSprite)
                    .AddSubgroup1(44)
                    .AddExcludedRooms(dontUseImmovableSpritesRooms),

                SpriteRequirement.New(SpriteConstants.MasterSwordSprite)
                    .SetIsObject()
                    .SetNeverUse()
                    .SetDoNotRandomize()
                    .AddSubgroup2(55)
                    .AddSubgroup3(54),

                // TODO: exclude these for now. figure out how to add them later (they overload the sprites and cause odd stuff to happen)
                SpriteRequirement.New(SpriteConstants.Devalant_NonShooterSprite)
                    .SetNeverUseDungeon()
                    .SetNeverUseOverworld()
                    .SetKillable()
                    .AddSubgroup0(47),
                SpriteRequirement.New(SpriteConstants.Devalant_ShooterSprite)
                    .SetNeverUseDungeon()
                    .SetNeverUseOverworld()
                    .SetKillable()
                    .AddSubgroup0(47),

                SpriteRequirement.New(SpriteConstants.ShootingGalleryProprietorSprite)
                    .SetNPC()
                    .SetDoNotRandomize()
                    .AddSubgroup0(75),

                SpriteRequirement.New(SpriteConstants.MovingCannonBallShooters_RightSprite)
                    .SetIsObject()
                    .SetNeverUse()
                    .SetDoNotRandomize()
                    .AddSubgroup0(47), // .AddSubgroup2(46));

                SpriteRequirement.New(SpriteConstants.MovingCannonBallShooters_LeftSprite)
                    .SetIsObject()
                    .SetNeverUse()
                    .SetDoNotRandomize()
                    .AddSubgroup0(47), // .AddSubgroup2(46));

                SpriteRequirement.New(SpriteConstants.MovingCannonBallShooters_DownSprite)
                    .SetIsObject()
                    .SetNeverUse()
                    .SetDoNotRandomize()
                    .AddSubgroup0(47), // .AddSubgroup2(46));

                SpriteRequirement.New(SpriteConstants.MovingCannonBallShooters_UpSprite)
                    .SetIsObject()
                    .SetNeverUse()
                    .SetDoNotRandomize()
                    .AddSubgroup0(47), // .AddSubgroup2(46));

                SpriteRequirement.New(SpriteConstants.BallNChainTrooperSprite)
                    .SetKillable()
                    .AddSubgroup0(70)
                    .AddSubgroup1(73), // TODO: check 73

                SpriteRequirement.New(SpriteConstants.CannonSoldierSprite)
                    .SetKillable()
                    .AddSubgroup0(70)
                    .AddSubgroup1(73), // TODO: verify because these don't exist in vanilla

                SpriteRequirement.New(SpriteConstants.MirrorPortalSprite)
                    .SetNeverUse()
                    .SetDoNotRandomize(),

                SpriteRequirement.New(SpriteConstants.RatSprite)
                    .SetKillable()
                    .AddSubgroup2(28, 36),

                SpriteRequirement.New(SpriteConstants.RopeSprite)
                    .SetKillable()
                    .AddSubgroup2(28, 36), // 36 isn't used anywhere in vanilla beside a trap in TT I think

                SpriteRequirement.New(SpriteConstants.KeeseSprite)
                    .SetKillable()
                    .SetCannotHaveKey()
                    .AddSubgroup2(28, 36),

                // SpriteRequirement.New(SpriteConstants.HelmasaurKingFireballSprite),

                SpriteRequirement.New(SpriteConstants.LeeverSprite)
                    .SetKillable()
                    .AddSubgroup0(47),

                // this is for both type of big fairy. sprite picks based on room
                SpriteRequirement.New(SpriteConstants.ActivatoForThePonds_WhereYouThrowInItemsSprite)
                    .SetNeverUse()
                    .SetDoNotRandomize()
                    .AddSubgroup3(54),

                SpriteRequirement.New(SpriteConstants.UnclePriestSprite)
                    .SetNPC()
                    .SetDoNotRandomize()
                    .AddSubgroup0(71, 81),

                SpriteRequirement.New(SpriteConstants.RunningManSprite)
                    .SetNPC()
                    .SetDoNotRandomize()
                    .AddGroup(6),

                SpriteRequirement.New(SpriteConstants.BottleSalesmanSprite)
                    .SetNPC()
                    .SetDoNotRandomize()
                    .AddGroup(6),

                SpriteRequirement.New(SpriteConstants.PrincessZeldaSprite)
                    .SetNPC()
                    .SetDoNotRandomize(), // zelda uses some special sprite

                // SpriteRequirement.New(SpriteConstants.Antifairy_AlternateSprite),

                SpriteRequirement.New(SpriteConstants.VillageElderSprite)
                    .SetNPC()
                    .SetDoNotRandomize()
                    .AddSubgroup0(75)
                    .AddSubgroup1(77)
                    .AddSubgroup2(74), // TODO: check which is actually needed

                // SpriteRequirement.New(SpriteConstants.BeeSprite),

                SpriteRequirement.New(SpriteConstants.AgahnimSprite)
                    .SetNeverUse()
                    .SetBoss()
                    .AddSubgroup0(85)
                     // not sure what difference is for sub 1
                    .AddSubgroup1(26, 61)
                    .AddSubgroup2(66)
                    .AddSubgroup3(67),

                SpriteRequirement.New(SpriteConstants.AgahnimEnergyBallSprite)
                    .SetNeverUse(),

                // are these killable???
                SpriteRequirement.New(SpriteConstants.FloatingStalfosHeadSprite)
                    .AddSubgroup0(31)
                    .AddExcludedRooms(dontUseFlyingSprites), // TODO: check this because it only shows up as stalfos head in game??

                SpriteRequirement.New(SpriteConstants.BigSpikeTrapSprite)
                    .AddSubgroup3(82, 83)
                    .AddExcludedRooms(dontUseImmovableSpritesRooms),

                // TODO: any other rooms?
                SpriteRequirement.New(SpriteConstants.GuruguruBar_ClockwiseSprite)
                    .AddSubgroup0(31)
                    .AddDontRandomizeRooms(RoomIdConstants.R181_TurtleRock_DarkMaze, RoomIdConstants.R150_GanonsTower_Torches1Room),

                // TODO: any other rooms?
                SpriteRequirement.New(SpriteConstants.GuruguruBar_CounterClockwiseSprite)
                    .AddSubgroup0(31)
                    .AddDontRandomizeRooms(RoomIdConstants.R181_TurtleRock_DarkMaze, RoomIdConstants.R150_GanonsTower_Torches1Room),

                SpriteRequirement.New(SpriteConstants.WinderSprite)
                    .AddSubgroup0(31),

                SpriteRequirement.New(SpriteConstants.WaterTektiteSprite)
                    .SetWaterSprite()
                    .AddSubgroup2(34)
                    .AddDontRandomizeRooms(RoomIdConstants.R40_SwampPalace_EntranceRoom)
                    .AddExcludedRooms(dontUseFlyingSprites),

                SpriteRequirement.New(SpriteConstants.AntifairyCircleSprite)
                    .SetNeverUse()
                    .AddSubgroup3(82, 83), // lag city

                // mimics are no longer hard coded to 4 rooms. they replaced the dialogue testing sprite
                SpriteRequirement.New(SpriteConstants.GreenEyegoreSprite)
                    .SetKillable()
                    .AddSubgroup2(46)
                    // .SetCannotHaveKey() // can't be killed with bombs
                    .AddExcludedRooms(RoomIdConstants.R268_MimicCave),

                SpriteRequirement.New(SpriteConstants.RedEyegoreSprite)
                    .AddSubgroup2(46),

                // SpriteRequirement.New(SpriteConstants.YellowStalfosSprite), // TODO: add

                // just don't use them until we fix the asm
                SpriteRequirement.New(SpriteConstants.KodongosSprite)
                    .SetNeverUse()
                    .AddSubgroup2(42),

                // SpriteRequirement.New(SpriteConstants.FlamesSprite), // Kodongo fireball

                SpriteRequirement.New(SpriteConstants.MothulaSprite)
                    .SetBoss()
                    .AddSubgroup2(56)
                    .AddSubgroup3(82),

                SpriteRequirement.New(SpriteConstants.MothulasBeamSprite)
                    .SetNeverUse()
                    .AddSubgroup2(56),

                SpriteRequirement.New(SpriteConstants.SpikeTrapSprite)
                    .AddSubgroup3(82, 83)
                    .AddExcludedRooms(RoomIdConstants.R40_SwampPalace_EntranceRoom)
                    .AddExcludedRooms(dontUseImmovableSpritesRooms), // TODO: maybe we can have them? probably better not to

                SpriteRequirement.New(SpriteConstants.GibdoSprite)
                    .SetKillable()
                    .AddSubgroup2(35),

                SpriteRequirement.New(SpriteConstants.ArrghusSprite)
                    .SetBoss()
                    .AddSubgroup2(57),

                SpriteRequirement.New(SpriteConstants.ArrghusSpawnSprite)
                    .SetBoss()
                    .AddSubgroup2(57),

                SpriteRequirement.New(SpriteConstants.TerrorpinSprite)
                    .AddSubgroup2(42)
                    .AddExcludedRooms(RoomIdConstants.R268_MimicCave),

                SpriteRequirement.New(SpriteConstants.SlimeSprite_JumpsOutOfTheFloor)
                    .AddSubgroup1(32),

                // these will never work right in the overworld without rewriting the asm
                // and only work in dungeons with exits
                SpriteRequirement.New(SpriteConstants.WallmasterSprite)
                    .SetDoNotRandomize()
                    .SetNeverUseOverworld()
                    .AddSubgroup2(35)
                    .AddSpawnableRooms(dungeonRooms),

                SpriteRequirement.New(SpriteConstants.StalfosKnightSprite)
                    .AddSubgroup1(32)
                    .AddExcludedRooms(RoomIdConstants.R268_MimicCave),

                SpriteRequirement.New(SpriteConstants.HelmasaurKingSprite)
                    .SetBoss()
                    .AddSubgroup2(58)
                    .AddSubgroup3(62),

                SpriteRequirement.New(SpriteConstants.BumperSprite)
                    .SetNeverUse()
                    .SetIsObject()
                    .SetDoNotRandomize()
                    .AddSubgroup3(82, 83),

                SpriteRequirement.New(SpriteConstants.SwimmersEvilSprite)
                    .SetWaterSprite()
                    .SetNeverUse()
                    .SetDoNotRandomize(), // TODO: add? what is this? 

                SpriteRequirement.New(SpriteConstants.EyeLaser_RightSprite)
                    .SetIsObject()
                    .SetNeverUse()
                    .SetDoNotRandomize()
                    .AddSubgroup3(82, 83),

                SpriteRequirement.New(SpriteConstants.EyeLaser_LeftSprite)
                    .SetIsObject()
                    .SetNeverUse()
                    .SetDoNotRandomize()
                    .AddSubgroup3(82, 83),

                SpriteRequirement.New(SpriteConstants.EyeLaser_DownSprite)
                    .SetIsObject()
                    .SetNeverUse()
                    .SetDoNotRandomize()
                    .AddSubgroup3(82, 83),

                SpriteRequirement.New(SpriteConstants.EyeLaser_UpSprite)
                    .SetIsObject()
                    .SetNeverUse()
                    .SetDoNotRandomize()
                    .AddSubgroup3(82, 83),

                SpriteRequirement.New(SpriteConstants.PengatorSprite)
                    .SetKillable()
                    .AddSubgroup2(38),

                SpriteRequirement.New(SpriteConstants.KyameronWaterSplashSprite)
                    .SetWaterSprite()
                    .AddSubgroup2(34)
                    .AddDontRandomizeRooms(RoomIdConstants.R40_SwampPalace_EntranceRoom)
                    .AddExcludedRooms(RoomIdConstants.R268_MimicCave),

                // can't be killed with bombs so don't put them in key/shutter rooms
                SpriteRequirement.New(SpriteConstants.WizzrobeSprite)
                    .AddSubgroup2(37, 41),

                // removed from keys because key could get stuck in wall if you kill it in the wall
                SpriteRequirement.New(SpriteConstants.VerminHorizontalSprite)
                    .SetDoNotRandomize()
                    .SetCannotHaveKey()
                    .SetKillable()
                    .AddSubgroup1(32),
                SpriteRequirement.New(SpriteConstants.VerminVerticalSprite)
                    .SetDoNotRandomize()
                    .SetCannotHaveKey()
                    .SetKillable()
                    .AddSubgroup1(32),

                SpriteRequirement.New(SpriteConstants.Ostrich_HauntedGroveSprite)
                    .SetNeverUse()
                    .SetDoNotRandomize()
                    .AddSubgroup2(78),

                SpriteRequirement.New(SpriteConstants.FluteSprite)
                    .SetNeverUse()
                    .SetDoNotRandomize(), // TODO: where is this?

                SpriteRequirement.New(SpriteConstants.Birds_HauntedGroveSprite)
                    .SetNeverUse()
                    .SetDoNotRandomize()
                    .AddSubgroup2(78),

                SpriteRequirement.New(SpriteConstants.FreezorSprite)
                    .SetNeverUse()
                    .SetDoNotRandomize()
                    .AddSubgroup2(38),

                SpriteRequirement.New(SpriteConstants.KholdstareSprite)
                    .SetBoss()
                    .AddSubgroup2(60),

                SpriteRequirement.New(SpriteConstants.KholdstaresShellSprite)
                    .SetBoss(), // TODO: this is BG2

                SpriteRequirement.New(SpriteConstants.FallingIceSprite)
                    .SetBoss()
                    .AddSubgroup2(60),

                SpriteRequirement.New(SpriteConstants.BlueZazakSprite)
                    .SetKillable()
                    .AddSubgroup2(40),

                SpriteRequirement.New(SpriteConstants.RedZazakSprite)
                    .SetKillable()
                    .AddSubgroup2(40),

                SpriteRequirement.New(SpriteConstants.StalfosSprite)
                    .SetKillable()
                    .AddSubgroup0(31),

                SpriteRequirement.New(SpriteConstants.BomberFlyingCreaturesFromDarkworldSprite)
                    .SetCannotHaveKey()
                    .AddSubgroup3(27)
                    .AddExcludedRooms(dontUseFlyingSprites),

                SpriteRequirement.New(SpriteConstants.BomberFlyingCreaturesFromDarkworld2Sprite)
                    .SetCannotHaveKey()
                    .AddSubgroup3(27)
                    .AddExcludedRooms(dontUseFlyingSprites),

                SpriteRequirement.New(SpriteConstants.PikitSprite)
                    .SetCannotHaveKey()
                    .SetKillable()
                    .AddSubgroup3(27),

                // TODO: where is this?
                SpriteRequirement.New(SpriteConstants.MaidenSprite)
                    .SetNPC()
                    .SetDoNotRandomize(),

                SpriteRequirement.New(SpriteConstants.AppleSprite)
                    .SetDoNotRandomize()
                    .SetAbsorbable(),

                SpriteRequirement.New(SpriteConstants.LostOldManSprite)
                    .SetNPC()
                    .SetDoNotRandomize()
                    // TODO: figure out which is actually needed
                    .AddSubgroup0(70)
                    .AddSubgroup1(73)
                    .AddSubgroup2(28),

                SpriteRequirement.New(SpriteConstants.DownPipeSprite)
                    .SetIsObject()
                    .SetNeverUse()
                    .SetDoNotRandomize(),
                SpriteRequirement.New(SpriteConstants.UpPipeSprite)
                    .SetIsObject()
                    .SetNeverUse()
                    .SetDoNotRandomize(),
                SpriteRequirement.New(SpriteConstants.RightPipeSprite)
                    .SetIsObject()
                    .SetNeverUse()
                    .SetDoNotRandomize(),
                SpriteRequirement.New(SpriteConstants.LeftPipeSprite)
                    .SetIsObject()
                    .SetNeverUse()
                    .SetDoNotRandomize(),

                SpriteRequirement.New(SpriteConstants.GoodBee_AgainMaybeSprite)
                    .SetNeverUse()
                    .SetDoNotRandomize()
                    .AddSubgroup0(31), // TOOD: really?

                SpriteRequirement.New(SpriteConstants.HylianInscriptionSprite)
                    .SetIsObject()
                    .SetNeverUse()
                    .SetDoNotRandomize(),

                SpriteRequirement.New(SpriteConstants.ThiefsChestSprite)
                    .SetIsObject()
                    .SetNeverUse()
                    .SetDoNotRandomize()
                    .AddSubgroup3(21),

                SpriteRequirement.New(SpriteConstants.BombSalesmanSprite)
                    .SetNPC()
                    .SetDoNotRandomize()
                    .AddSubgroup1(77),

                SpriteRequirement.New(SpriteConstants.KikiSprite)
                    .SetNPC()
                    .SetDoNotRandomize()
                    .AddSubgroup3(25),

                SpriteRequirement.New(SpriteConstants.MaidenInBlindDungeonSprite)
                    .SetNPC()
                    .SetDoNotRandomize(), // TODO: special?

                SpriteRequirement.New(SpriteConstants.MimicSprite)
                    .AddSubgroup1(44),

                SpriteRequirement.New(SpriteConstants.FeudingFriendsOnDeathMountainSprite)
                    .SetNPC()
                    .SetDoNotRandomize()
                    .AddSubgroup3(20),

                SpriteRequirement.New(SpriteConstants.WhirlpoolSprite)
                    .SetNeverUse()
                    .SetDoNotRandomize(),

                // TODO: What to do????????
                SpriteRequirement.New(SpriteConstants.SalesmanChestgameGuy300RupeeGiverGuyChestGameThiefSprite)
                    .SetNPC()
                    .SetDoNotRandomize()
                    // TODO: figure out which are needed
                    .AddSubgroup0(75)
                    .AddSubgroup2(74)
                    .AddSubgroup3(90)
                    .AddSpawnableRooms(RoomIdConstants.R255_Cave0xFF,
                                       RoomIdConstants.R274_CaveShop0x112,
                                       RoomIdConstants.R287_Shop0x11F),

                SpriteRequirement.New(SpriteConstants.SalesmanChestgameGuy300RupeeGiverGuyChestGameThiefSprite)
                    .SetNPC()
                    .SetDoNotRandomize()
                    // TODO: figure out which are needed
                    .AddSubgroup0(75)
                    .AddSubgroup1(77)
                    .AddSubgroup2(74)
                    .AddSubgroup3(90)
                    .AddSpawnableRooms(RoomIdConstants.R271_Shop0x10F,
                                       RoomIdConstants.R272_Shop0x110),

                SpriteRequirement.New(SpriteConstants.SalesmanChestgameGuy300RupeeGiverGuyChestGameThiefSprite)
                    .SetNPC()
                    .SetDoNotRandomize()
                    // TODO: figure out which are needed
                    .AddSubgroup1(77)
                    .AddSubgroup2(74)
                    .AddSubgroup3(90)
                    .AddSpawnableRooms(RoomIdConstants.R272_Shop0x110),

                SpriteRequirement.New(SpriteConstants.SalesmanChestgameGuy300RupeeGiverGuyChestGameThiefSprite)
                    .SetNPC()
                    .SetDoNotRandomize()
                    // TODO: figure out which are needed
                    .AddSubgroup0(79)
                    .AddSubgroup2(74)
                    .AddSubgroup3(90)
                    .AddSpawnableRooms(RoomIdConstants.R280_Shop0x118),

                SpriteRequirement.New(SpriteConstants.SalesmanChestgameGuy300RupeeGiverGuyChestGameThiefSprite)
                    .SetNPC()
                    .SetDoNotRandomize()
                    // TODO: figure out which are needed
                    .AddSubgroup0(14)
                    .AddSpawnableRooms(RoomIdConstants.R291_MiniMoldormCave,
                                       RoomIdConstants.R292_UnknownCave_BonkCave),

                SpriteRequirement.New(SpriteConstants.SalesmanChestgameGuy300RupeeGiverGuyChestGameThiefSprite)
                    .SetNPC()
                    .SetDoNotRandomize()
                    // TODO: figure out which are needed
                    .AddSubgroup0(14)
                    .AddSubgroup2(74)
                    .AddSubgroup3(90)
                    .AddSpawnableRooms(RoomIdConstants.R291_MiniMoldormCave,
                                       RoomIdConstants.R292_UnknownCave_BonkCave),

                SpriteRequirement.New(SpriteConstants.SalesmanChestgameGuy300RupeeGiverGuyChestGameThiefSprite)
                    .SetNPC()
                    .SetDoNotRandomize()
                    // TODO: figure out which are needed
                    .AddSubgroup0(14)
                    .AddSubgroup2(74)
                    .AddSubgroup3(80)
                    .AddSpawnableRooms(RoomIdConstants.R293_Cave0x125), // TODO: where is this???????east of lake hylia under a rock. One of the rooms is light world the other is dark or so it looks
                                                                        // SpriteRequirements.Where(x => x.SpriteId == SpriteConstants.SalesmanChestgameGuy300RupeeGiverGuyChestGameThiefSprite).ToList().ForEach((x) => { x.NeverUse = true; x.NPC = true; });

                SpriteRequirement.New(SpriteConstants.SalesmanChestgameGuy300RupeeGiverGuyChestGameThiefSprite)
                    .SetNPC()
                    .SetDoNotRandomize()
                    // TODO: figure out which are needed
                    .AddSubgroup0(21)
                    .AddSpawnableRooms(RoomIdConstants.R286_HypeCave),

                SpriteRequirement.New(SpriteConstants.DrunkInTheInnSprite)
                    .SetNPC()
                    .SetDoNotRandomize()
                     // TODO: figure out which are needed
                    .AddSubgroup0(79)
                    .AddSubgroup1(77)
                    .AddSubgroup2(74)
                    .AddSubgroup3(80),

                SpriteRequirement.New(SpriteConstants.Vitreous_LargeEyeballSprite)
                    .SetBoss()
                    .AddSubgroup3(61),

                SpriteRequirement.New(SpriteConstants.Vitreous_SmallEyeballSprite)
                    .SetBoss()
                    .AddSubgroup3(61),

                SpriteRequirement.New(SpriteConstants.VitreousLightningSprite)
                    .SetBoss()
                    .AddSubgroup3(61),

                SpriteRequirement.New(SpriteConstants.CatFish_QuakeMedallionSprite)
                    .SetNPC()
                    .SetDoNotRandomize()
                    .AddSubgroup2(24),

                SpriteRequirement.New(SpriteConstants.AgahnimTeleportingZeldaToDarkworldSprite)
                    .SetBoss()
                    .AddSubgroup0(85)
                    .AddSubgroup1(61)
                    .AddSubgroup2(66)
                    .AddSubgroup3(67), // all needed?

                SpriteRequirement.New(SpriteConstants.BouldersSprite)
                    .SetNeverUse()
                    .AddSubgroup3(16),

                SpriteRequirement.New(SpriteConstants.Gibo_FloatingBlobSprite)
                    .SetKillable()
                    .AddSubgroup2(40),

                SpriteRequirement.New(SpriteConstants.ThiefSprite)
                    .SetCannotHaveKey()
                    .AddSubgroup0(14, 21),

                // These are loaded into BG as objects
                SpriteRequirement.New(SpriteConstants.MedusaSprite)
                    .SetDoNotRandomize()
                    .SetIsObject()
                    .SetNeverUse(),

                SpriteRequirement.New(SpriteConstants.FourWayFireballSpittersSprite)
                    .SetDoNotRandomize()
                    .SetIsObject()
                    .SetNeverUse(),

                SpriteRequirement.New(SpriteConstants.HokkuBokkuSprite)
                    .AddSubgroup2(39),

                SpriteRequirement.New(SpriteConstants.BigFairyWhoHealsYouSprite)
                    .SetNPC()
                    .SetDoNotRandomize()
                    .AddSubgroup2(57)
                    .AddSubgroup3(54),

                SpriteRequirement.New(SpriteConstants.TektiteSprite)
                    .SetKillable()
                    .AddSubgroup3(16),

                SpriteRequirement.New(SpriteConstants.ChainChompSprite)
                    .AddSubgroup2(39),

                SpriteRequirement.New(SpriteConstants.TrinexxSprite)
                    .SetBoss()
                    .AddSubgroup0(64)
                    .AddSubgroup3(63),

                SpriteRequirement.New(SpriteConstants.AnotherPartOfTrinexxSprite)
                    .SetBoss()
                    .AddSubgroup0(64)
                    .AddSubgroup3(63),

                SpriteRequirement.New(SpriteConstants.YetAnotherPartOfTrinexxSprite)
                    .SetBoss()
                    .AddSubgroup0(64)
                    .AddSubgroup3(63),

                SpriteRequirement.New(SpriteConstants.BlindTheThiefSprite)
                    .SetBoss()
                    .AddSubgroup1(44)
                    .AddSubgroup2(59),

                SpriteRequirement.New(SpriteConstants.SwamolaSprite)
                    .SetWaterSprite()
                    .SetCannotHaveKey()
                    .AddSubgroup3(25),

                SpriteRequirement.New(SpriteConstants.LynelSprite)
                    .AddSubgroup3(20),

                // TODO: add never use LW and DW
                SpriteRequirement.New(SpriteConstants.BunnyBeamSprite)
                    // .SetNeverUseOverworld()
                    .SetNeverUse()
                    .SetDoNotRandomize(), // TODO: find

                SpriteRequirement.New(SpriteConstants.FloppingFishSprite)
                    .SetNeverUseDungeon()
                    .SetDoNotRandomize(), // TODO: find

                SpriteRequirement.New(SpriteConstants.StalSprite)
                    .SetNeverUse()
                    .SetDoNotRandomize(), // TODO: why do these spawn so frequently in dungeons?

                SpriteRequirement.New(SpriteConstants.LandmineSprite)
                    .SetDoNotRandomize()
                    .SetNeverUse() // TODO: maybe this is a good idea? can't get the right gfx to load because it's automatic and uses OW grahics in OAM0(1)
                    .AddExcludedRooms(dontUseImmovableSpritesRooms), // TODO: find

                SpriteRequirement.New(SpriteConstants.DiggingGameProprietorSprite)
                    .SetNPC()
                    .SetDoNotRandomize()
                    .AddSubgroup1(42),

                SpriteRequirement.New(SpriteConstants.GanonSprite)
                    .SetNeverUse()
                    .SetBoss()
                    .AddSubgroup0(33)
                    .AddSubgroup1(65)
                    .AddSubgroup2(69)
                    .AddSubgroup3(51),

                SpriteRequirement.New(SpriteConstants.CopyOfGanon_ExceptInvincibleSprite)
                    .SetNeverUse()
                    .SetDoNotRandomize(),

                SpriteRequirement.New(SpriteConstants.HeartSprite)
                    .SetNeverUseOverworld()
                    .SetAbsorbable()
                    .SetDoNotRandomize(),

                SpriteRequirement.New(SpriteConstants.GreenRupeeSprite)
                    .SetNeverUseOverworld()
                    .SetAbsorbable()
                    .SetDoNotRandomize(),

                SpriteRequirement.New(SpriteConstants.BlueRupeeSprite)
                    .SetNeverUseOverworld()
                    .SetAbsorbable()
                    .SetDoNotRandomize(),

                SpriteRequirement.New(SpriteConstants.RedRupeeSprite)
                    .SetNeverUseOverworld()
                    .SetAbsorbable()
                    .SetDoNotRandomize(),

                SpriteRequirement.New(SpriteConstants.BombRefill1Sprite)
                    .SetNeverUseOverworld()
                    .SetAbsorbable()
                    .SetDoNotRandomize(),

                SpriteRequirement.New(SpriteConstants.BombRefill4Sprite)
                    .SetNeverUseOverworld()
                    .SetAbsorbable()
                    .SetDoNotRandomize(),

                SpriteRequirement.New(SpriteConstants.BombRefill8Sprite)
                    .SetNeverUseOverworld()
                    .SetAbsorbable()
                    .SetDoNotRandomize(),

                SpriteRequirement.New(SpriteConstants.SmallMagicRefillSprite)
                    .SetNeverUseOverworld()
                    .SetAbsorbable()
                    .SetDoNotRandomize(),

                SpriteRequirement.New(SpriteConstants.FullMagicRefillSprite)
                    .SetNeverUseOverworld()
                    .SetAbsorbable()
                    .SetDoNotRandomize(),

                SpriteRequirement.New(SpriteConstants.ArrowRefill5Sprite)
                    .SetNeverUseOverworld()
                    .SetAbsorbable()
                    .SetDoNotRandomize(),

                SpriteRequirement.New(SpriteConstants.ArrowRefill10Sprite)
                    .SetNeverUseOverworld()
                    .SetAbsorbable()
                    .SetDoNotRandomize(),

                SpriteRequirement.New(SpriteConstants.FairySprite)
                    .SetNeverUseOverworld()
                    .SetAbsorbable()
                    .SetDoNotRandomize(),

                SpriteRequirement.New(SpriteConstants.KeySprite)
                    .SetNeverUseOverworld()
                    .SetAbsorbable()
                    .SetDoNotRandomize(),

                SpriteRequirement.New(SpriteConstants.BigKeySprite)
                    .SetNeverUse()
                    .SetDoNotRandomize(),

                SpriteRequirement.New(SpriteConstants.ShieldEaterSprite)
                    .SetNeverUse()
                    .SetDoNotRandomize()
                    .AddSubgroup3(27), // TODO: check this is for pikit

                SpriteRequirement.New(SpriteConstants.MushroomSprite)
                    .SetNeverUse()
                    .SetDoNotRandomize()
                    .AddSubgroup3(17),

                SpriteRequirement.New(SpriteConstants.FakeMasterSwordSprite)
                    .AddSubgroup3(17), // TODO: check

                SpriteRequirement.New(SpriteConstants.MagicShopDude_HisItemsIncludingTheMagicPowderSprite)
                    .SetNPC()
                    .SetDoNotRandomize()
                    .AddSubgroup0(75)
                    .AddSubgroup3(90),

                SpriteRequirement.New(SpriteConstants.HeartContainerSprite)
                    .SetNeverUse()
                    .SetDoNotRandomize(),

                SpriteRequirement.New(SpriteConstants.HeartPieceSprite)
                    .SetNeverUse()
                    .SetDoNotRandomize(),

                SpriteRequirement.New(SpriteConstants.BushesSprite)
                    .SetNeverUse()
                    .SetDoNotRandomize(), // bush thrown sprite

                SpriteRequirement.New(SpriteConstants.CaneOfSomariaPlatformSprite)
                    .SetIsObject()
                    .SetNeverUse()
                    .SetDoNotRandomize()
                    .AddSubgroup2(39), // TODO: verify

                SpriteRequirement.New(SpriteConstants.MantleSprite)
                    .SetIsObject()
                    .SetNeverUse()
                    .SetDoNotRandomize()
                    .AddSubgroup0(93),

                SpriteRequirement.New(SpriteConstants.CaneOfSomariaPlatform_Unused1Sprite)
                    .SetIsObject()
                    .SetNeverUse()
                    .SetDoNotRandomize(),

                SpriteRequirement.New(SpriteConstants.CaneOfSomariaPlatform_Unused2Sprite)
                    .SetIsObject()
                    .SetNeverUse()
                    .SetDoNotRandomize(),

                SpriteRequirement.New(SpriteConstants.CaneOfSomariaPlatform_Unused3Sprite)
                    .SetIsObject()
                    .SetNeverUse()
                    .SetDoNotRandomize(),

                SpriteRequirement.New(SpriteConstants.MedallionTabletSprite)
                    .SetIsObject()
                    .SetNeverUse()
                    .SetDoNotRandomize()
                    .AddSubgroup2(18),

                // turn these off for now outside DM. they can only spawn in large (1024x1024 areas)
                SpriteRequirement.New(SpriteConstants.OW_OL_FallingRocks)
                    .SetOverlord()
                    .SetNeverUseDungeon()
                    .SetDoNotRandomize()
                    .AddSubgroup3(16),

                // SpriteRequirement.New(SpriteConstants.OW_OL_WallMaster_ToHoulihan)
                //     .SetOverlord()
                //     .SetNeverUseDungeon()
                //     .AddSubgroup2(35),

                // Overlords
                SpriteRequirement.New(SpriteConstants.OL_CanonBalls_EP4Walls)
                    .SetNeverUse()
                    .SetOverlord()
                    .AddSubgroup2(46),

                SpriteRequirement.New(SpriteConstants.OL_CanonBalls_EPEntrance)
                    .SetNeverUse()
                    .SetOverlord()
                    .AddSubgroup2(46),

                SpriteRequirement.New(SpriteConstants.OL_StalfosHeadTrap)
                    .SetNeverUse()
                    .SetOverlord()
                    .AddSubgroup0(31),

                SpriteRequirement.New(SpriteConstants.OL_BombDrop_RopeTrap)
                    .SetNeverUse()
                    .SetOverlord()
                    .AddSubgroup2(28, 36),

                SpriteRequirement.New(SpriteConstants.OL_MovingFloor)
                    .SetNeverUse()
                    .SetOverlord(),

                SpriteRequirement.New(SpriteConstants.OL_SlimeDropper)
                    .SetOverlord()
                    .AddSubgroup1(32),

                SpriteRequirement.New(SpriteConstants.OL_Wallmaster)
                    .SetOverlord()
                    .AddSubgroup2(35),

                SpriteRequirement.New(SpriteConstants.OL_FloorDrop_Square)
                    .SetNeverUse()
                    .SetOverlord()
                    .AddSubgroup3(82),

                SpriteRequirement.New(SpriteConstants.OL_FloorDrop_Path)
                    .SetNeverUse()
                    .SetOverlord()
                    .AddSubgroup3(82),

                SpriteRequirement.New(SpriteConstants.OL_RightEvil_PirogusuSpawner)
                    .SetNeverUse()
                    .SetOverlord()
                    .AddSubgroup2(34),

                SpriteRequirement.New(SpriteConstants.OL_LeftEvil_PirogusuSpawner)
                    .SetNeverUse()
                    .SetOverlord()
                    .AddSubgroup2(34),

                SpriteRequirement.New(SpriteConstants.OL_DownEvil_PirogusuSpawner)
                    .SetNeverUse()
                    .SetOverlord()
                    .AddSubgroup2(34),

                SpriteRequirement.New(SpriteConstants.OL_UpEvil_PirogusuSpawner)
                    .SetNeverUse()
                    .SetOverlord()
                    .AddSubgroup2(34),

                SpriteRequirement.New(SpriteConstants.OL_FlyingFloorTileTrap)
                    .SetOverlord()
                    // .AddSubgroup1(44)
                    .AddSubgroup3(82), // TODO: is this special sprites?

                SpriteRequirement.New(SpriteConstants.OL_WizzrobeSpawner)
                    .SetOverlord()
                    .AddSubgroup2(37, 41),

                SpriteRequirement.New(SpriteConstants.OL_BlackSpawn_Zoro_BombHole)
                    .SetNeverUse()
                    .SetOverlord()
                    .AddSubgroup1(32),

                SpriteRequirement.New(SpriteConstants.OL_4Skull_Trap_Pot)
                    .SetNeverUse()
                    .SetOverlord()
                    .AddSubgroup0(31),

                SpriteRequirement.New(SpriteConstants.OL_Stalfos_Spawn_Trap_EP)
                    .SetNeverUse()
                    .SetOverlord()
                    .AddSubgroup0(31),

                SpriteRequirement.New(SpriteConstants.OL_ArmosKnight_Trigger)
                    .SetNeverUse()
                    .SetOverlord(),

                SpriteRequirement.New(SpriteConstants.OL_BombDrop_BombTrap)
                    .SetNeverUse()
                    .SetOverlord()
            };

            //// "Special" sprites
            //// rat-guard = green recruit (0x4B) with sub 1=73, sub 2=28
            //SpriteRequirements.Add(SpriteRequirement.New(SpriteConstants.GreenSoldierRecruits_HMKnightSprite)
            //                                        .IsSpecialGlitched()
            //                                        .SetKillable()
            //                                        .AddSubgroup1(73)
            //                                        .AddSubgroup2(28));

            //// zombie-guard = green recruit (0x4B) with sub 1=73, sub 2=28
            //SpriteRequirements.Add(SpriteRequirement.New(SpriteConstants.GreenSoldierRecruits_HMKnightSprite)
            //                                        .IsSpecialGlitched()
            //                                        .SetKillable()
            //                                        .AddSubgroup1(73)
            //                                        .AddSubgroup2(35));

            //// Palette glitch and invisible guard (need to see if this causes any other issues)
            //SpriteRequirements.Add(SpriteRequirement.New(SpriteConstants.BlueSwordSoldier_DetectPlayerSprite)
            //                                        .IsSpecialGlitched()
            //                                        .SetKillable()
            //                                        .SetParameters(0x18) // 11000 should cause very bad things
            //                                        .AddSubgroup1(73));

            // TODO: add beefy arms
            //SpriteRequirements.Add(SpriteRequirement.New(SpriteConstants.MovingCannonBallShooters_RightSprite).SetIsObject().IsSpecialGlitched().SetNeverUse().SetDoNotRandomize().AddSubgroup0(22));
            //SpriteRequirements.Add(SpriteRequirement.New(SpriteConstants.MovingCannonBallShooters_LeftSprite).SetIsObject().IsSpecialGlitched().SetNeverUse().SetDoNotRandomize().AddSubgroup0(22));
            //SpriteRequirements.Add(SpriteRequirement.New(SpriteConstants.MovingCannonBallShooters_DownSprite).SetIsObject().IsSpecialGlitched().SetNeverUse().SetDoNotRandomize().AddSubgroup0(22));
            //SpriteRequirements.Add(SpriteRequirement.New(SpriteConstants.MovingCannonBallShooters_UpSprite).SetIsObject().IsSpecialGlitched().SetNeverUse().SetDoNotRandomize().AddSubgroup0(22));

            // make popos into dwarves
            //SpriteRequirements.Add(SpriteRequirement.New(SpriteConstants.PopoSprite).IsSpecialGlitched().SetNeverUse().SetDoNotRandomize().AddSubgroup1(77));
            //SpriteRequirements.Add(SpriteRequirement.New(SpriteConstants.Popo2Sprite).IsSpecialGlitched().SetNeverUse().SetDoNotRandomize().AddSubgroup1(77));
        }

        //void AddSpriteRequirement(int SpriteId, bool Overlord, int? GroupId, int? SubGroup0, int? SubGroup1, int? SubGroup2, int? SubGroup3, byte? Parameters = null, bool Special = false)
        //{
        //    SpriteRequirements.Add(new SpriteRequirement(SpriteId, Overlord, GroupId, SubGroup0, SubGroup1, SubGroup2, SubGroup3, Parameters, Special));
        //}

        readonly int[] dontUseImmovableSpritesRooms =
        {
            RoomIdConstants.R11_PalaceofDarkness_TurtleRoom, // TODO: test, probably the single turtle in the L section
            RoomIdConstants.R22_SwampPalace_SwimmingTreadmill,
            RoomIdConstants.R25_PalaceofDarkness_DarkMaze, // TODO: test, top mob will probably block maze
            RoomIdConstants.R30_IcePalace_BombFloor_BariRoom, // TODO: test
            RoomIdConstants.R38_SwampPalace_StatueRoom,
            RoomIdConstants.R39_TowerofHera_BigChest, // TODO: test, top left dodongo
            RoomIdConstants.R54_SwampPalace_BigChestRoom, // TODO: check bottom left waterbug
            RoomIdConstants.R63_IcePalace_MapChestRoom, // spikes block stuff
            RoomIdConstants.R66_HyruleCastle_6RopesRoom, // only if two stack, but why push it
            RoomIdConstants.R64_AgahnimsTower_FinalBridgeRoom, // spikes are bad in here
            RoomIdConstants.R70_SwampPalace_CompassChestRoom,
            RoomIdConstants.R73_SkullWoods_GibdoTorchPuzzleRoom,
            RoomIdConstants.R75_PalaceofDarkness_Warps_SouthMimicsRoom, // TODO: test
            RoomIdConstants.R78_IcePalace_Bomb_JumpRoom,
            RoomIdConstants.R85_CastleSecretEntrance_UncleDeathRoom, // TODO: test
            RoomIdConstants.R87_SkullWoods_BigKeyRoom,
            RoomIdConstants.R95_IcePalace_HiddenChest_SpikeFloorRoom, // TODO: would this cause problem in OHKO since you can't hookshot if middle mob is beamos,etc?
            RoomIdConstants.R101_ThievesTown_EastAtticRoom, // only if both bottom rats
            RoomIdConstants.R106_PalaceofDarkness_RupeeRoom, // only if two turtles in row
            RoomIdConstants.R116_DesertPalace_MapChestRoom, // only if both antlions
            RoomIdConstants.R118_SwampPalace_WaterDrainRoom, // would need 3 mobs to be impassible to possibly softlock (what are the odds?)
            RoomIdConstants.R125_GanonsTower_Winder_WarpMazeRoom, // would need a lot of things exactly right, but better safe than sorry
            RoomIdConstants.R127_IcePalace_BigSpikeTrapsRoom, // TODO: what happens to beamos over a pit?
            RoomIdConstants.R131_DesertPalace_WestEntranceRoom, // TODO: test
            RoomIdConstants.R132_DesertPalace_MainEntranceRoom, // TODO: test
            RoomIdConstants.R133_DesertPalace_EastEntranceRoom, // TODO: test (only a problem for ER?)
            RoomIdConstants.R140_GanonsTower_EastandWestDownstairs_BigChestRoom, // TODO: test (probably safe?)
            RoomIdConstants.R141_GanonsTower_Tile_TorchPuzzleRoom, // TODO: test
            RoomIdConstants.R146_MiseryMire_DarkBombWall_SwitchesRoom, // TODO: test
            RoomIdConstants.R149_GanonsTower_FinalCollapsingBridgeRoom, // TODO: test, probably safe because of conveyor belts
            RoomIdConstants.R152_MiseryMire_EntranceRoom,
            RoomIdConstants.R155_GanonsTower_ManySpikes_WarpMazeRoom, // TODO: test, middle spike covers warp, are we randomizing those?
            RoomIdConstants.R156_GanonsTower_InvisibleFloorMazeRoom, // TODO: test
            RoomIdConstants.R157_GanonsTower_CompassChest_InvisibleFloorRoom, // TODO: test
            RoomIdConstants.R158_IcePalace_BigChestRoom, // big spikes will block
            RoomIdConstants.R160_MiseryMire_Pre_VitreousRoom, // TODO: test
            RoomIdConstants.R170_EasternPalace_MapChestRoom, // TODO: test
            RoomIdConstants.R175_IcePalace_IceBridgeRoom,
            RoomIdConstants.R179_MiseryMire_SpikeKeyChestRoom, // TODO: test lower stalfos blocking door
            RoomIdConstants.R186_EasternPalace_DarkAntifairy_KeyPotRoom,
            RoomIdConstants.R187_ThievesTown_Hellway, // TODO: test, should be ok but double check
            RoomIdConstants.R188_ThievesTown_ConveyorToilet, // TODO: test
            RoomIdConstants.R198_TurtleRock0xC6, // technically a door is blocked off, but who would ever go there?
            RoomIdConstants.R203_ThievesTown_NorthWestEntranceRoom,
            RoomIdConstants.R206_IcePalace_HoletoKholdstareRoom, // spikes block stuff
            RoomIdConstants.R208_AgahnimsTower_DarkMaze, // TODO: test
            RoomIdConstants.R210_MiseryMire_Mire02_WizzrobesRoom,
            RoomIdConstants.R213_TurtleRock_LaserKeyRoom,
            RoomIdConstants.R216_EasternPalace_PreArmosKnightsRoom,
            RoomIdConstants.R220_ThievesTown_SouthEastEntranceRoom, // TODO: test
            RoomIdConstants.R223_Cave_BackwardsDeathMountainTopFloor,
            RoomIdConstants.R228_Cave_LostOldManFinalCave, // who would go that way?
            RoomIdConstants.R231_Cave0xE7,
            RoomIdConstants.R238_Cave_SpiralCave,
            RoomIdConstants.R249_Cave0xF9, // TODO: test, probably can get past
            RoomIdConstants.R253_Cave0xFD,
            RoomIdConstants.R268_MimicCave,
        };

        readonly int[] dontUseFlyingSprites =
        {
            RoomIdConstants.R210_MiseryMire_Mire02_WizzrobesRoom,
            RoomIdConstants.R268_MimicCave
        };

        readonly int[] dungeonRooms =
        {
            RoomIdConstants.R1_HyruleCastle_NorthCorridor,
            RoomIdConstants.R2_HyruleCastle_SwitchRoom,
            RoomIdConstants.R17_HyruleCastle_BombableStockRoom,
            RoomIdConstants.R33_HyruleCastle_KeyRatRoom,
            RoomIdConstants.R34_HyruleCastle_SewerTextTriggerRoom,
            RoomIdConstants.R50_HyruleCastle_SewerKeyChestRoom,
            RoomIdConstants.R65_HyruleCastle_FirstDarkRoom,
            RoomIdConstants.R66_HyruleCastle_6RopesRoom,
            RoomIdConstants.R80_HyruleCastle_WestCorridor,
            RoomIdConstants.R81_HyruleCastle_ThroneRoom,
            RoomIdConstants.R82_HyruleCastle_EastCorridor,
            RoomIdConstants.R96_HyruleCastle_WestEntranceRoom,
            RoomIdConstants.R97_HyruleCastle_MainEntranceRoom,
            RoomIdConstants.R98_HyruleCastle_EastEntranceRoom,
            RoomIdConstants.R112_HyruleCastle_SmallCorridortoJailCells,
            RoomIdConstants.R113_HyruleCastle_BoomerangChestRoom,
            RoomIdConstants.R114_HyruleCastle_MapChestRoom,
            RoomIdConstants.R128_HyruleCastle_JailCellRoom,
            RoomIdConstants.R129_HyruleCastle_NextToChasmRoom,
            RoomIdConstants.R130_HyruleCastle_BasementChasmRoom,

            RoomIdConstants.R137_EasternPalace_FairyRoom,
            RoomIdConstants.R153_EasternPalace_EyegoreKeyRoom,
            RoomIdConstants.R168_EasternPalace_StalfosSpawnRoom,
            RoomIdConstants.R169_EasternPalace_BigChestRoom,
            RoomIdConstants.R170_EasternPalace_MapChestRoom,
            RoomIdConstants.R184_EasternPalace_BigKeyRoom,
            RoomIdConstants.R185_EasternPalace_LobbyCannonballsRoom,
            RoomIdConstants.R186_EasternPalace_DarkAntifairy_KeyPotRoom,
            RoomIdConstants.R200_EasternPalace_ArmosKnights,
            RoomIdConstants.R201_EasternPalace_EntranceRoom,
            RoomIdConstants.R216_EasternPalace_PreArmosKnightsRoom,
            RoomIdConstants.R217_EasternPalace_CanonballRoom,
            RoomIdConstants.R218_EasternPalace,

            RoomIdConstants.R51_DesertPalace_Lanmolas,
            RoomIdConstants.R67_DesertPalace_TorchPuzzle_MovingWallRoom,
            RoomIdConstants.R83_DesertPalace_Popos2_BeamosHellwayRoom,
            RoomIdConstants.R99_DesertPalace_FinalSectionEntranceRoom,
            RoomIdConstants.R115_DesertPalace_BigChestRoom,
            RoomIdConstants.R116_DesertPalace_MapChestRoom,
            RoomIdConstants.R117_DesertPalace_BigKeyChestRoom,
            RoomIdConstants.R131_DesertPalace_WestEntranceRoom,
            RoomIdConstants.R132_DesertPalace_MainEntranceRoom,
            RoomIdConstants.R133_DesertPalace_EastEntranceRoom,

            RoomIdConstants.R7_TowerofHera_Moldorm,
            RoomIdConstants.R23_TowerofHera_MoldormFallRoom,
            RoomIdConstants.R39_TowerofHera_BigChest,
            RoomIdConstants.R49_TowerofHera_HardhatBeetlesRoom,
            RoomIdConstants.R119_TowerofHera_EntranceRoom,
            RoomIdConstants.R135_TowerofHera_TileRoom,
            RoomIdConstants.R167_TowerofHera_FairyRoom,

            RoomIdConstants.R32_AgahnimsTower_Agahnim,
            RoomIdConstants.R48_AgahnimsTower_MaidenSacrificeChamber,
            RoomIdConstants.R64_AgahnimsTower_FinalBridgeRoom,
            RoomIdConstants.R176_AgahnimsTower_CircleofPots,
            RoomIdConstants.R192_AgahnimsTower_DarkBridgeRoom,
            RoomIdConstants.R208_AgahnimsTower_DarkMaze,
            RoomIdConstants.R224_AgahnimsTower_EntranceRoom,

            RoomIdConstants.R9_PalaceofDarkness0x09,
            RoomIdConstants.R10_PalaceofDarkness_StalfosTrapRoom,
            RoomIdConstants.R11_PalaceofDarkness_TurtleRoom,
            RoomIdConstants.R25_PalaceofDarkness_DarkMaze,
            RoomIdConstants.R26_PalaceofDarkness_BigChestRoom,
            RoomIdConstants.R27_PalaceofDarkness_Mimics_MovingWallRoom,
            RoomIdConstants.R42_PalaceofDarkness_BigHubRoom,
            RoomIdConstants.R43_PalaceofDarkness_MapChest_FairyRoom,
            RoomIdConstants.R58_PalaceofDarkness_BombableFloorRoom,
            RoomIdConstants.R59_PalaceofDarkness_SpikeBlock_ConveyorRoom,
            RoomIdConstants.R74_PalaceofDarkness_EntranceRoom,
            RoomIdConstants.R75_PalaceofDarkness_Warps_SouthMimicsRoom,
            RoomIdConstants.R90_PalaceofDarkness_HelmasaurKing,
            RoomIdConstants.R106_PalaceofDarkness_RupeeRoom,

            RoomIdConstants.R6_SwampPalace_Arrghus,
            RoomIdConstants.R22_SwampPalace_SwimmingTreadmill,
            RoomIdConstants.R38_SwampPalace_StatueRoom,
            RoomIdConstants.R40_SwampPalace_EntranceRoom,
            RoomIdConstants.R52_SwampPalace_PushBlockPuzzle_Pre_BigKeyRoom,
            RoomIdConstants.R53_SwampPalace_BigKey_BSRoom,
            RoomIdConstants.R54_SwampPalace_BigChestRoom,
            RoomIdConstants.R55_SwampPalace_MapChest_WaterFillRoom,
            RoomIdConstants.R56_SwampPalace_KeyPotRoom,
            RoomIdConstants.R70_SwampPalace_CompassChestRoom,
            RoomIdConstants.R84_SwampPalace_UpstairsPitsRoom,
            RoomIdConstants.R102_SwampPalace_HiddenChest_HiddenDoorRoom,
            RoomIdConstants.R118_SwampPalace_WaterDrainRoom,

            RoomIdConstants.R41_SkullWoods_Mothula,
            RoomIdConstants.R57_SkullWoods_GibdoKey_MothulaHoleRoom,
            RoomIdConstants.R73_SkullWoods_GibdoTorchPuzzleRoom,
            RoomIdConstants.R86_SkullWoods_KeyPot_TrapRoom,
            RoomIdConstants.R87_SkullWoods_BigKeyRoom,
            RoomIdConstants.R88_SkullWoods_BigChestRoom,
            RoomIdConstants.R89_SkullWoods_FinalSectionEntranceRoom,
            RoomIdConstants.R103_SkullWoods_CompassChestRoom,
            RoomIdConstants.R104_SkullWoods_KeyChest_TrapRoom,

            RoomIdConstants.R68_ThievesTown_BigChestRoom,
            RoomIdConstants.R69_ThievesTown_JailCellsRoom,
            RoomIdConstants.R100_ThievesTown_WestAtticRoom,
            RoomIdConstants.R101_ThievesTown_EastAtticRoom,
            RoomIdConstants.R171_ThievesTown_MovingSpikes_KeyPotRoom,
            RoomIdConstants.R172_ThievesTown_BlindTheThief,
            RoomIdConstants.R187_ThievesTown_Hellway,
            RoomIdConstants.R188_ThievesTown_ConveyorToilet,
            RoomIdConstants.R203_ThievesTown_NorthWestEntranceRoom,
            RoomIdConstants.R204_ThievesTown_NorthEastEntranceRoom,
            RoomIdConstants.R219_ThievesTown_Main_SouthWestEntranceRoom,
            RoomIdConstants.R220_ThievesTown_SouthEastEntranceRoom,

            RoomIdConstants.R14_IcePalace_EntranceRoom,
            RoomIdConstants.R30_IcePalace_BombFloor_BariRoom,
            RoomIdConstants.R31_IcePalace_Pengator_BigKeyRoom,
            RoomIdConstants.R46_IcePalace_CompassRoom,
            RoomIdConstants.R62_IcePalace_StalfosKnights_ConveyorHellway,
            RoomIdConstants.R63_IcePalace_MapChestRoom,
            RoomIdConstants.R78_IcePalace_Bomb_JumpRoom,
            RoomIdConstants.R79_IcePalaceCloneRoom_FairyRoom,
            RoomIdConstants.R94_IcePalace_LonelyFirebar,
            RoomIdConstants.R95_IcePalace_HiddenChest_SpikeFloorRoom,
            RoomIdConstants.R110_IcePalace_PengatorsRoom,
            RoomIdConstants.R126_IcePalace_HiddenChest_BombableFloorRoom,
            RoomIdConstants.R127_IcePalace_BigSpikeTrapsRoom,
            RoomIdConstants.R142_IcePalace0x8E,
            RoomIdConstants.R158_IcePalace_BigChestRoom,
            RoomIdConstants.R159_IcePalace0x9F,
            RoomIdConstants.R174_IcePalace0xAE,
            RoomIdConstants.R175_IcePalace_IceBridgeRoom,
            RoomIdConstants.R190_IcePalace_BlockPuzzleRoom,
            RoomIdConstants.R191_IcePalaceCloneRoom_SwitchRoom,
            RoomIdConstants.R206_IcePalace_HoletoKholdstareRoom,
            RoomIdConstants.R222_IcePalace_Kholdstare,

            RoomIdConstants.R144_MiseryMire_Vitreous,
            RoomIdConstants.R145_MiseryMire_FinalSwitchRoom,
            RoomIdConstants.R146_MiseryMire_DarkBombWall_SwitchesRoom,
            RoomIdConstants.R147_MiseryMire_DarkCaneFloorSwitchPuzzleRoom,
            RoomIdConstants.R151_MiseryMire_TorchPuzzle_MovingWallRoom,
            RoomIdConstants.R152_MiseryMire_EntranceRoom,
            RoomIdConstants.R160_MiseryMire_Pre_VitreousRoom,
            RoomIdConstants.R161_MiseryMire_FishRoom,
            RoomIdConstants.R162_MiseryMire_BridgeKeyChestRoom,
            RoomIdConstants.R163_MiseryMire0xA3,
            RoomIdConstants.R177_MiseryMire_HourglassRoom,
            RoomIdConstants.R178_MiseryMire_SlugRoom,
            RoomIdConstants.R179_MiseryMire_SpikeKeyChestRoom,
            RoomIdConstants.R193_MiseryMire_CompassChest_TileRoom,
            RoomIdConstants.R194_MiseryMire_BigHubRoom,
            RoomIdConstants.R195_MiseryMire_BigChestRoom,
            RoomIdConstants.R209_MiseryMire_ConveyorSlug_BigKeyRoom,
            RoomIdConstants.R210_MiseryMire_Mire02_WizzrobesRoom,

            RoomIdConstants.R4_TurtleRock_CrystalRollerRoom,
            RoomIdConstants.R19_TurtleRock_Hokku_BokkuKeyRoom2,
            RoomIdConstants.R20_TurtleRock_BigKeyRoom,
            RoomIdConstants.R21_TurtleRock0x15,
            RoomIdConstants.R35_TurtleRock_WestExittoBalcony,
            RoomIdConstants.R36_TurtleRock_DoubleHokku_Bokku_BigchestRoom,
            RoomIdConstants.R164_TurtleRock_Trinexx,
            RoomIdConstants.R180_TurtleRock_Pre_TrinexxRoom,
            RoomIdConstants.R181_TurtleRock_DarkMaze,
            RoomIdConstants.R182_TurtleRock_ChainChompsRoom,
            RoomIdConstants.R183_TurtleRock_MapChest_KeyChest_RollerRoom,
            RoomIdConstants.R196_TurtleRock_FinalCrystalSwitchPuzzleRoom,
            RoomIdConstants.R197_TurtleRock_LaserBridge,
            RoomIdConstants.R198_TurtleRock0xC6,
            RoomIdConstants.R199_TurtleRock_TorchPuzzle,
            RoomIdConstants.R213_TurtleRock_LaserKeyRoom,
            RoomIdConstants.R214_TurtleRock_EntranceRoom,

            RoomIdConstants.R12_GanonsTower_EntranceRoom,
            RoomIdConstants.R13_GanonsTower_Agahnim2,
            RoomIdConstants.R28_GanonsTower_IceArmos,
            RoomIdConstants.R29_GanonsTower_FinalHallway,
            RoomIdConstants.R61_GanonsTower_TorchRoom2,
            RoomIdConstants.R76_GanonsTower_Mini_HelmasaurConveyorRoom,
            RoomIdConstants.R77_GanonsTower_MoldormRoom,
            RoomIdConstants.R91_GanonsTower_SpikePitRoom,
            RoomIdConstants.R92_GanonsTower_Ganon_BallZ,
            RoomIdConstants.R93_GanonsTower_Gauntlet1_2_3,
            RoomIdConstants.R107_GanonsTower_MimicsRooms,
            RoomIdConstants.R108_GanonsTower_LanmolasRoom,
            RoomIdConstants.R109_GanonsTower_Gauntlet4_5,
            RoomIdConstants.R123_GanonsTower,
            RoomIdConstants.R124_GanonsTower_EastSideCollapsingBridge_ExplodingWallRoom,
            RoomIdConstants.R125_GanonsTower_Winder_WarpMazeRoom,
            RoomIdConstants.R139_GanonsTower_BlockPuzzle_SpikeSkip_MapChestRoom,
            RoomIdConstants.R140_GanonsTower_EastandWestDownstairs_BigChestRoom,
            RoomIdConstants.R141_GanonsTower_Tile_TorchPuzzleRoom,
            RoomIdConstants.R149_GanonsTower_FinalCollapsingBridgeRoom,
            RoomIdConstants.R150_GanonsTower_Torches1Room,
            RoomIdConstants.R155_GanonsTower_ManySpikes_WarpMazeRoom,
            RoomIdConstants.R156_GanonsTower_InvisibleFloorMazeRoom,
            RoomIdConstants.R157_GanonsTower_CompassChest_InvisibleFloorRoom,
            RoomIdConstants.R165_GanonsTower_WizzrobesRooms,
            RoomIdConstants.R166_GanonsTower_MoldormFallRoom,
        };
    }
}
