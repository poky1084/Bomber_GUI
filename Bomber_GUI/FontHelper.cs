using System;
using System.Drawing;
using System.Drawing.Text;
using System.Reflection;
using System.Runtime.InteropServices;

public static class FontHelper
{
    private static PrivateFontCollection _fonts = new PrivateFontCollection();
    public static FontFamily Montserrat { get; private set; }

    static FontHelper()
    {
        var assembly = Assembly.GetExecutingAssembly();
        using (var stream = assembly.GetManifestResourceStream("Bomber_GUI.Fonts.Montserrat-Regular.ttf"))
        {
            byte[] data = new byte[stream.Length];
            stream.Read(data, 0, data.Length);
            IntPtr ptr = Marshal.AllocCoTaskMem(data.Length);
            Marshal.Copy(data, 0, ptr, data.Length);
            _fonts.AddMemoryFont(ptr, data.Length);
            Marshal.FreeCoTaskMem(ptr);
        }
        Montserrat = _fonts.Families[0];
    }
}