using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

public sealed class Singleton : PasswordKeeper.MainForm
{
    private static String GUID = ((GuidAttribute)typeof(Singleton).Assembly.GetCustomAttributes(typeof(GuidAttribute), true)[0]).Value;
    private static Int32 WM_SHOWFIRSTINSTANCE = RegisterWindowMessage(GUID);
    private static IntPtr HWND_BROADCAST = (IntPtr)0xffff;
    private const Int32 SPI_GETFOREGROUNDLOCKTIMEOUT = 0x2000;
    private const Int32 SPI_SETFOREGROUNDLOCKTIMEOUT = 0x2001;
    private const Int32 SPIF_UPDATEINIFILE = 0x01;
    private const Int32 SPIF_SENDWININICHANGE = 0x02;
    private const Int32 ASFW_ANY = -1;
    private static FormWindowState lastWindowState;
    private static FormWindowState currentWindowState;
    [DllImport("user32")] private static extern Int32 RegisterWindowMessage(String message);
    [DllImport("user32")] private static extern Boolean PostMessage(IntPtr hwnd, Int32 msg, IntPtr wparam, IntPtr lparam);
    [DllImport("user32")] private static extern IntPtr GetForegroundWindow();
    [DllImport("user32")] private static extern UInt32 GetWindowThreadProcessId(IntPtr hWnd, IntPtr ProcessId);
    [DllImport("user32")] private static extern Boolean AttachThreadInput(UInt32 idAttach, UInt32 idAttachTo, Boolean fAttach);
    [DllImport("user32")] private static extern Boolean SystemParametersInfo(Int32 uiAction, UInt32 uiParam, IntPtr pvParam, Int32 fWinIni);
    [DllImport("user32")] private static extern Boolean AllowSetForegroundWindow(Int32 dwProcessId);

    protected override void WndProc(ref Message message)
    {
        if (message.Msg == WM_SHOWFIRSTINSTANCE)
        {
            UInt32 foregroundThread = GetWindowThreadProcessId(GetForegroundWindow(), IntPtr.Zero);
            UInt32 thisThread = GetWindowThreadProcessId(Handle, IntPtr.Zero);
            AttachThreadInput(foregroundThread, thisThread, true);
            SystemParametersInfo(SPI_GETFOREGROUNDLOCKTIMEOUT, 0, IntPtr.Zero, 0);
            SystemParametersInfo(SPI_SETFOREGROUNDLOCKTIMEOUT, 0, IntPtr.Zero, SPIF_SENDWININICHANGE | SPIF_UPDATEINIFILE);
            AllowSetForegroundWindow(ASFW_ANY);
            if (currentWindowState == FormWindowState.Minimized)
            {
                WindowState = lastWindowState;
            }
            else
            {
                BringToFront();
            }
            Activate();
            SystemParametersInfo(SPI_SETFOREGROUNDLOCKTIMEOUT, 0, IntPtr.Zero, SPIF_SENDWININICHANGE | SPIF_UPDATEINIFILE);
            AttachThreadInput(foregroundThread, thisThread, false);
        }
        base.WndProc(ref message);
    }

    protected override void OnClientSizeChanged(EventArgs e)
    {
        lastWindowState = currentWindowState;
        currentWindowState = WindowState;
        base.OnClientSizeChanged(e);
    }

    public static void Start()
    {
        Boolean createdNew;
        Mutex singleInstance = new Mutex(true, GUID, out createdNew);
        if (createdNew)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Singleton());
            GC.KeepAlive(singleInstance);
        }
        else
        {
            PostMessage(HWND_BROADCAST, WM_SHOWFIRSTINSTANCE, IntPtr.Zero, IntPtr.Zero);
        }
    }
}