using Native.IO;
using Native.IO.Services;

namespace CsMsbt;
public class MsbtLibrary : NativeLibrary<MsbtLibrary>, INativeLibrary
{
    protected override string Name { get; } = "cs_msbt";
}
