using System;
using System.Collections.Generic;

namespace BinComp
{
	// Token: 0x02000003 RID: 3
	public class Patch
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000006 RID: 6 RVA: 0x000024FC File Offset: 0x000006FC
		// (set) Token: 0x06000007 RID: 7 RVA: 0x00002504 File Offset: 0x00000704
		public int address { get; set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000008 RID: 8 RVA: 0x0000250D File Offset: 0x0000070D
		// (set) Token: 0x06000009 RID: 9 RVA: 0x00002515 File Offset: 0x00000715
		public List<byte> patchData { get; set; }

		// Token: 0x0600000A RID: 10 RVA: 0x0000251E File Offset: 0x0000071E
		public Patch()
		{
			this.patchData = new List<byte>();
		}
	}
}
