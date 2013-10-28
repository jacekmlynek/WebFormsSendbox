using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace WebFormsSendBoxIntegrationTests
{
    [Guid("7FD52380-4E07-101B-AE2D-08002B2EC713")]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPersistStreamInit
    {
        void GetClassID(out Guid pClassID);
        int IsDirty();
        void Load(System.Runtime.InteropServices.ComTypes.IStream pStm);
        void Save(System.Runtime.InteropServices.ComTypes.IStream pStm, bool fClearDirty);
        void GetSizeMax(out long pcbSize);
        void InitNew();
    }
}
