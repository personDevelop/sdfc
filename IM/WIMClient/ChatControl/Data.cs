using System;
using System.Collections.Generic;

using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;

namespace WIMClient
{
    [Flags(), ComVisible(false)]
    internal enum STGM : int
    {
        STGM_READWRITE = 0x2,
        STGM_SHARE_EXCLUSIVE = 0x10,
        STGM_CREATE = 0x1000,
    }

    [Flags(), ComVisible(false)]
    internal enum DVASPECT : int
    {
        DVASPECT_CONTENT = 1,
        DVASPECT_THUMBNAIL = 2,
        DVASPECT_ICON = 4,
        DVASPECT_DOCPRINT = 8,
        DVASPECT_OPAQUE = 16,
        DVASPECT_TRANSPARENT = 32,
    }

    [ComVisible(false)]
    internal enum CLIPFORMAT : int
    {
        CF_TEXT = 1,
        CF_BITMAP = 2,
        CF_METAFILEPICT = 3,
        CF_SYLK = 4,
        CF_DIF = 5,
        CF_TIFF = 6,
        CF_OEMTEXT = 7,
        CF_DIB = 8,
        CF_PALETTE = 9,
        CF_PENDATA = 10,
        CF_RIFF = 11,
        CF_WAVE = 12,
        CF_UNICODETEXT = 13,
        CF_ENHMETAFILE = 14,
        CF_HDROP = 15,
        CF_LOCALE = 16,
        CF_MAX = 17,
        CF_OWNERDISPLAY = 0x80,
        CF_DSPTEXT = 0x81,
        CF_DSPBITMAP = 0x82,
        CF_DSPMETAFILEPICT = 0x83,
        CF_DSPENHMETAFILE = 0x8E,
    }

    [Flags(), ComVisible(false)]
    internal enum TYMED : int
    {
        TYMED_NULL = 0,
        TYMED_HGLOBAL = 1,
        TYMED_FILE = 2,
        TYMED_ISTREAM = 4,
        TYMED_ISTORAGE = 8,
        TYMED_GDI = 16,
        TYMED_MFPICT = 32,
        TYMED_ENHMF = 64,
    }

    [StructLayout(LayoutKind.Sequential), ComVisible(false)]
    internal struct FORMATETC
    {
        internal CLIPFORMAT cfFormat;
        internal IntPtr ptd;
        internal DVASPECT dwAspect;
        internal int lindex;
        internal TYMED tymed;
    }

    [StructLayout(LayoutKind.Sequential), ComVisible(false)]
    internal struct STGMEDIUM
    {
        internal int tymed;
        internal IntPtr unionmember;
        internal IntPtr pUnkForRelease;
    }

    [ComVisible(true),
    ComImport(),
    Guid("00000103-0000-0000-C000-000000000046"),
    InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IEnumFORMATETC
    {
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int Next([In, MarshalAs(UnmanagedType.U4)]int celt, [Out]FORMATETC rgelt, [In, Out, MarshalAs(UnmanagedType.LPArray)]int[] pceltFetched);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int Skip([In, MarshalAs(UnmanagedType.U4)]int celt);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int Reset();
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int Clone([Out, MarshalAs(UnmanagedType.LPArray)]IEnumFORMATETC[] ppenum);
    }

    [ComVisible(true), StructLayout(LayoutKind.Sequential)]
    internal class COMRECT
    {
        internal int left;
        internal int top;
        internal int right;
        internal int bottom;

        internal COMRECT()
        {
        }

        internal COMRECT(int left, int top, int right, int bottom)
        {
            this.left = left;
            this.top = top;
            this.right = right;
            this.bottom = bottom;
        }

        internal static COMRECT FromXYWH(int x, int y, int width, int height)
        {
            return new COMRECT(x, y, x + width, y + height);
        }
    }

    internal enum GETOBJECTOPTIONS
    {
        REO_GETOBJ_NO_INTERFACES = 0x00000000,
        REO_GETOBJ_POLEOBJ = 0x00000001,
        REO_GETOBJ_PSTG = 0x00000002,
        REO_GETOBJ_POLESITE = 0x00000004,
        REO_GETOBJ_ALL_INTERFACES = 0x00000007,
    }

    internal enum GETCLIPBOARDDATAFLAGS
    {
        RECO_PASTE = 0,
        RECO_DROP = 1,
        RECO_COPY = 2,
        RECO_CUT = 3,
        RECO_DRAG = 4
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct CHARRANGE
    {
        internal int cpMin;
        internal int cpMax;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal class REOBJECT
    {
        internal int cbStruct = Marshal.SizeOf(typeof(REOBJECT));
        internal int cp;
        internal Guid clsid;
        internal IntPtr poleobj;
        internal IStorage pstg;
        internal IOleClientSite polesite;
        internal Size sizel;
        internal uint dvAspect;
        internal uint dwFlags;
        internal uint dwUser;
    }



    [ComVisible(true), Guid("0000010F-0000-0000-C000-000000000046"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IAdviseSink
    {
        void OnDataChange([In]FORMATETC pFormatetc, [In]STGMEDIUM pStgmed);
        void OnViewChange([In, MarshalAs(UnmanagedType.U4)]int dwAspect, [In, MarshalAs(UnmanagedType.I4)]int lindex);
        void OnRename([In, MarshalAs(UnmanagedType.Interface)]object pmk);
        void OnSave();
        void OnClose();
    }

    [ComVisible(false), StructLayout(LayoutKind.Sequential)]
    internal sealed class STATDATA
    {
        [MarshalAs(UnmanagedType.U4)]
        internal int advf;
        [MarshalAs(UnmanagedType.U4)]
        internal int dwConnection;
    }

    [ComVisible(false), StructLayout(LayoutKind.Sequential)]
    internal sealed class tagOLEVERB
    {
        [MarshalAs(UnmanagedType.I4)]
        internal int lVerb;
        [MarshalAs(UnmanagedType.LPWStr)]
        internal String lpszVerbName;
        [MarshalAs(UnmanagedType.U4)]
        internal int fuFlags;
        [MarshalAs(UnmanagedType.U4)]
        internal int grfAttribs;
    }

    [ComVisible(true), ComImport(), Guid("00000104-0000-0000-C000-000000000046"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IEnumOLEVERB
    {
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int Next([MarshalAs(UnmanagedType.U4)]int celt, [Out]tagOLEVERB rgelt, [Out, MarshalAs(UnmanagedType.LPArray)]int[] pceltFetched);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int Skip([In, MarshalAs(UnmanagedType.U4)]int celt);
        void Reset();
        void Clone(out IEnumOLEVERB ppenum);
    }

    [ComVisible(true), Guid("00000105-0000-0000-C000-000000000046"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IEnumSTATDATA
    {
        void Next([In, MarshalAs(UnmanagedType.U4)]int celt, [Out]STATDATA rgelt, [Out, MarshalAs(UnmanagedType.LPArray)]int[] pceltFetched);
        void Skip([In, MarshalAs(UnmanagedType.U4)]int celt);
        void Reset();
        void Clone([Out, MarshalAs(UnmanagedType.LPArray)]IEnumSTATDATA[] ppenum);
    }

    [ComVisible(true), Guid("0000011B-0000-0000-C000-000000000046"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IOleContainer
    {
        void ParseDisplayName([In, MarshalAs(UnmanagedType.Interface)] object pbc, [In, MarshalAs(UnmanagedType.BStr)]string pszDisplayName, [Out, MarshalAs(UnmanagedType.LPArray)] int[] pchEaten, [Out, MarshalAs(UnmanagedType.LPArray)] object[] ppmkOut);
        void EnumObjects([In, MarshalAs(UnmanagedType.U4)]int grfFlags, [Out, MarshalAs(UnmanagedType.LPArray)] object[] ppenum);
        void LockContainer([In, MarshalAs(UnmanagedType.I4)] int fLock);
    }

    [ComVisible(true),
    ComImport(),
    Guid("0000010E-0000-0000-C000-000000000046"),
    InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IDataObject
    {
        [PreserveSig()]
        uint GetData(ref FORMATETC a, ref STGMEDIUM b);
        [PreserveSig()]
        uint GetDataHere(ref FORMATETC pFormatetc, out STGMEDIUM pMedium);
        [PreserveSig()]
        uint QueryGetData(ref FORMATETC pFormatetc);
        [PreserveSig()]
        uint GetCanonicalFormatEtc(ref FORMATETC pformatectIn, out	FORMATETC pformatetcOut);
        [PreserveSig()]
        uint SetData(ref FORMATETC pFormatectIn, ref STGMEDIUM pmedium, [In, MarshalAs(UnmanagedType.Bool)]bool fRelease);
        [PreserveSig()]
        uint EnumFormatEtc(uint dwDirection, IEnumFORMATETC penum);
        [PreserveSig()]
        uint DAdvise(ref FORMATETC pFormatetc, int advf, [In, MarshalAs(UnmanagedType.Interface)]IAdviseSink pAdvSink, out uint pdwConnection);
        [PreserveSig()]
        uint DUnadvise(uint dwConnection);
        [PreserveSig()]
        uint EnumDAdvise([Out, MarshalAs(UnmanagedType.Interface)]out IEnumSTATDATA ppenumAdvise);
    }

    [ComVisible(true), Guid("00000118-0000-0000-C000-000000000046"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IOleClientSite
    {
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int SaveObject();
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetMoniker([In, MarshalAs(UnmanagedType.U4)] int dwAssign, [In, MarshalAs(UnmanagedType.U4)]int dwWhichMoniker, [Out, MarshalAs(UnmanagedType.Interface)] out object ppmk);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetContainer([MarshalAs(UnmanagedType.Interface)] out IOleContainer container);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int ShowObject();
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int OnShowWindow([In, MarshalAs(UnmanagedType.I4)] int fShow);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int RequestNewObjectLayout();
    }

    [ComVisible(false), StructLayout(LayoutKind.Sequential)]
    internal sealed class tagLOGPALETTE
    {
        [MarshalAs(UnmanagedType.U2)]
        internal short palVersion;
        [MarshalAs(UnmanagedType.U2)]
        internal short palNumEntries;
    }

    [ComImport]
    [Guid("0000000b-0000-0000-C000-000000000046")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IStorage
    {
        int CreateStream(string pwcsName, uint grfMode, uint reserved1, uint reserved2, out IStream ppstm);
        int OpenStream(string pwcsName, IntPtr reserved1, uint grfMode, uint reserved2, out IStream ppstm);
        int CreateStorage(string pwcsName, uint grfMode, uint reserved1, uint reserved2, out IStorage ppstg);
        int OpenStorage(string pwcsName, IStorage pstgPriority, uint grfMode, IntPtr snbExclude, uint reserved, out IStorage ppstg);
        int CopyTo(uint ciidExclude, Guid rgiidExclude, IntPtr snbExclude, IStorage pstgDest);
        int MoveElementTo(string pwcsName, IStorage pstgDest, string pwcsNewName, uint grfFlags);
        int Commit(uint grfCommitFlags);
        int Revert();
        int DestroyElement(string pwcsName);
        int RenameElement(string pwcsOldName, string pwcsNewName);
        int SetClass(Guid clsid);
        int SetStateBits(uint grfStateBits, uint grfMask);
    }

    [ComImport]
    [Guid("0000000a-0000-0000-C000-000000000046")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface ILockBytes
    {
        int ReadAt(ulong ulOffset, IntPtr pv, uint cb, out IntPtr pcbRead);
        int WriteAt(ulong ulOffset, IntPtr pv, uint cb, out IntPtr pcbWritten);
        int Flush();
        int SetSize(ulong cb);
        int LockRegion(ulong libOffset, ulong cb, uint dwLockType);
        int UnlockRegion(ulong libOffset, ulong cb, uint dwLockType);
    }

    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("0c733a30-2a1c-11ce-ade5-00aa0044773d")]
    internal interface ISequentialStream
    {
        int Read(IntPtr pv, uint cb, out uint pcbRead);
        int Write(IntPtr pv, uint cb, out uint pcbWritten);
    };

    [ComImport]
    [Guid("0000000c-0000-0000-C000-000000000046")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IStream : ISequentialStream
    {
        int Seek(ulong dlibMove, uint dwOrigin, out ulong plibNewPosition);
        int SetSize(ulong libNewSize);
        int CopyTo([In] IStream pstm, ulong cb, out ulong pcbRead, out ulong pcbWritten);
        int Commit(uint grfCommitFlags);
        int Revert();
        int LockRegion(ulong libOffset, ulong cb, uint dwLockType);
        int UnlockRegion(ulong libOffset, ulong cb, uint dwLockType);
        int Clone(out IStream ppstm);
    };

    [ComImport(), Guid("00020D00-0000-0000-c000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IRichEditOle
    {
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetClientSite(out IOleClientSite site);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetObjectCount();
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetLinkCount();
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetObject(int iob, [In, Out] REOBJECT lpreobject, [MarshalAs(UnmanagedType.U4)]GETOBJECTOPTIONS flags);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int InsertObject(REOBJECT lpreobject);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int ConvertObject(int iob, Guid rclsidNew, string lpstrUserTypeNew);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int ActivateAs(Guid rclsid, Guid rclsidAs);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int SetHostNames(string lpstrContainerApp, string lpstrContainerObj);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int SetLinkAvailable(int iob, bool fAvailable);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int SetDvaspect(int iob, uint dvaspect);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int HandsOffStorage(int iob);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int SaveCompleted(int iob, IStorage lpstg);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int InPlaceDeactivate();
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int ContextSensitiveHelp(bool fEnterMode);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetClipboardData([In, Out] ref CHARRANGE lpchrg, [MarshalAs(UnmanagedType.U4)] GETCLIPBOARDDATAFLAGS reco, out IDataObject lplpdataobj);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int ImportDataObject(IDataObject lpdataobj, int cf, IntPtr hMetaPict);
    }
}
