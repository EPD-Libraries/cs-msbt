using CsMsbt;
using Native.IO.Services;

namespace Tests;

[TestClass]
public class IOTest
{
    const string _pathMsbt = @"D:\Bin\Msbt\Attachment.msbt";
    const string _pathYaml = @"D:\Bin\Msbt\Attachment.yml";

    static IOTest()
    {
        NativeLibraryManager
            .RegisterAssembly(typeof(Msbt).Assembly, out bool isCommonLoaded)
            .Register(new MsbtLibrary(), out bool isMsbtLoaded);

        Console.WriteLine(isCommonLoaded);
        Console.WriteLine(isMsbtLoaded);
    }

    [TestMethod]
    public void ReadWriteBinary()
    {
        byte[] data = File.ReadAllBytes(_pathMsbt);
        using Msbt msbt = Msbt.FromBinary(data);

        using FileStream fs = File.Create(_pathMsbt);
        fs.Write(msbt.ToBinary());
    }

    [TestMethod]
    public void ReadWriteText()
    {
        string text = File.ReadAllText(_pathYaml);
        using Msbt msbt = Msbt.FromText(text);

        using FileStream fs = File.Create(_pathYaml);
        fs.Write(msbt.ToText());
    }
}
