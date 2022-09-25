using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace EnemizerLibrary
{
    public class Patch
    {
        readonly string patchFilename;

        public List<PatchObject> Patches { get; private set; }

        public Patch(string patchFile)
        {
            patchFilename = patchFile;

            patchFilename = Path.Combine(EnemizerBasePath.Instance.BasePath, patchFilename);

            Patches = JsonConvert.DeserializeObject<List<PatchObject>>(File.ReadAllText(this.patchFilename));
        }

        public void PatchRom(RomData rom)
        {
            foreach (var patch in Patches)
            {
                rom.PatchData(patch);
            }
        }

        public void AddPatch(PatchObject patch)
        {
            Patches.Add(patch);
        }

        public void AddPatches(List<PatchObject> patches)
        {
            Patches.AddRange(patches);
        }

        public string ExportJson()
        {
            return JsonConvert.SerializeObject(Patches);
        }
    }

    public class PatchObject
    {
        [JsonProperty("address")]
        public int Address { get; set; }
        [JsonProperty("patchData")]
        public List<byte> PatchData { get; set; } = new();
    }
}
