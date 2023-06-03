using Microsoft.Win32.SafeHandles;
using Native.IO.Handles;
using System.Runtime.InteropServices;

namespace CsMsbt;

public unsafe partial class Msbt : SafeHandleZeroOrMinusOneIsInvalid
{
    [LibraryImport("cs_msbt")]
    private static partial Msbt FromBinary(byte* src, int src_len);

    [LibraryImport("cs_msbt")]
    private static partial DataMarshal ToBinary(Msbt handle);

    [LibraryImport("cs_msbt", EntryPoint = "FromText", StringMarshalling = StringMarshalling.Utf8)]
    private static partial Msbt FromTextNative(string text);

    [LibraryImport("cs_msbt")]
    private static partial StringMarshal ToText(Msbt handle);

    [LibraryImport("cs_msbt")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static partial bool Free(IntPtr handle);

    public Msbt() : base(true) { }

    public static Msbt FromBinary(ReadOnlySpan<byte> data)
    {
        fixed (byte* ptr = data) {
            return FromBinary(ptr, data.Length);
        }
    }

    public DataMarshal ToBinary()
    {
        return ToBinary(this);
    }

    public static Msbt FromText(string text)
    {
        return FromTextNative(text);
    }

    public StringMarshal ToText()
    {
        return ToText(this);
    }

    protected override bool ReleaseHandle()
    {
        return Free(handle);
    }
}
