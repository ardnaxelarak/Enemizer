using System;

namespace EnemizerLibrary
{
    public class DoorDungeonObject
    {
        public static DoorDungeonObject GetDungeonObjectFromBytes(byte[] bytes)
        {
            if(bytes.Length != 2)
            {
                throw new Exception("Door Dungeon Objects must be built from 2 byte chunks.");
            }

            return new DoorDungeonObject(bytes);
        }
        protected byte[] _bytes;
        public byte[] Bytes
        {
            get { return _bytes; }
            set
            {
                if (value.Length != 2)
                {
                    throw new Exception("DoorDungeonObject must be composed from 2 bytes");
                }
                _bytes = value;
            }
        }

        public DoorDungeonObject(byte[] bytes)
        {
            this.Bytes = bytes;
        }
    }
}
