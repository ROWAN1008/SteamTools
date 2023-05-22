//using AppResources = BD.WTTS.Client.Resources.Strings;
//using EProxyMode = BD.WTTS.Enums.ProxyMode;

//// ReSharper disable once CheckNamespace
//namespace BD.WTTS.Settings;

//public sealed partial class ProxySettings : SettingsHost2<ProxySettings>
//{
//    /// <summary>
//    /// 启用脚本自动检查更新
//    /// </summary>
//    public static SerializableProperty<bool> IsAutoCheckScriptUpdate { get; }
//        = GetProperty(defaultValue: true);

//    /// <summary>
//    /// 启用代理脚本
//    /// </summary>
//    public static SerializableProperty<bool> IsEnableScript { get; }
//        = GetProperty(defaultValue: false);

//    /// <summary>
//    /// 代理服务启用状态
//    /// </summary>
//    public static SerializableProperty<IReadOnlyCollection<string>> SupportProxyServicesStatus { get; }
//        = GetProperty(defaultValue: (IReadOnlyCollection<string>)Array.Empty<string>(), autoSave: false);

//    /// <summary>
//    /// 脚本启用状态
//    /// </summary>
//    public static SerializableProperty<IReadOnlyCollection<int>> ScriptsStatus { get; }
//        = GetProperty(defaultValue: (IReadOnlyCollection<int>)Array.Empty<int>());

//    #region 代理设置

//    /// <summary>
//    /// 程序启动时自动启动代理
//    /// </summary>
//    public static SerializableProperty<bool> ProgramStartupRunProxy { get; }
//        = GetProperty(defaultValue: false);

//    /// <summary>
//    /// 系统代理模式端口
//    /// </summary>
//    public static SerializableProperty<int> SystemProxyPortId { get; }
//        = GetProperty(defaultValue: 26501, autoSave: false);

//    /// <summary>
//    /// 系统代理模式IP
//    /// </summary>
//    public static SerializableProperty<string> SystemProxyIp { get; }
//        = GetProperty(defaultValue: IPAddress.Any.ToString(), autoSave: false);

//    /// <summary>
//    /// 开启加速后仅代理脚本而不加速
//    /// </summary>
//    public static SerializableProperty<bool> OnlyEnableProxyScript { get; }
//        = GetProperty(defaultValue: false, autoSave: false);

//    /// <summary>
//    /// 代理时使用的解析主DNS
//    /// </summary>
//    public static SerializableProperty<string?> ProxyMasterDns { get; }
//        = GetProperty<string?>(defaultValue: "223.5.5.5", autoSave: false);

//    /// <summary>
//    /// 启用 Http 链接转发到 Https
//    /// </summary>
//    public static SerializableProperty<bool> EnableHttpProxyToHttps { get; }
//        = GetProperty(defaultValue: true);

//    #endregion

//    #region 本地代理设置

//    /// <summary>
//    /// Socks5 Enable
//    /// </summary>
//    public static SerializableProperty<bool> Socks5ProxyEnable { get; }
//        = GetProperty(defaultValue: false, autoSave: false);

//    /// <summary>
//    /// Socks5 监听端口
//    /// </summary>
//    public static SerializableProperty<int> Socks5ProxyPortId { get; }
//        = GetProperty(defaultValue: DefaultSocks5ProxyPortId, autoSave: false);

//    public const int DefaultSocks5ProxyPortId = 8868;

//    #endregion

//    #region 二级代理设置

//    /// <summary>
//    /// TwoLevelAgent Enable
//    /// </summary>
//    public static SerializableProperty<bool> TwoLevelAgentEnable { get; }
//        = GetProperty(defaultValue: false, autoSave: false);

//    /// <summary>
//    /// TwoLevelAgent ProxyType
//    /// </summary>
//    public static SerializableProperty<short> TwoLevelAgentProxyType { get; }
//        = GetProperty(defaultValue: DefaultTwoLevelAgentProxyType, autoSave: false);

//    public const short DefaultTwoLevelAgentProxyType =
//        (short)IReverseProxyService.Constants.DefaultTwoLevelAgentProxyType;

//    /// <summary>
//    /// 二级代理 IP
//    /// </summary>
//    public static SerializableProperty<string> TwoLevelAgentIp { get; }
//        = GetProperty(defaultValue: IPAddress.Loopback.ToString(), autoSave: false);

//    /// <summary>
//    /// 二级代理 监听端口
//    /// </summary>
//    public static SerializableProperty<int> TwoLevelAgentPortId { get; }
//        = GetProperty(defaultValue: DefaultTwoLevelAgentPortId, autoSave: false);

//    public const int DefaultTwoLevelAgentPortId = 7890;

//    /// <summary>
//    /// TwoLevelAgent UserName
//    /// </summary>
//    public static SerializableProperty<string> TwoLevelAgentUserName { get; }
//        = GetProperty(defaultValue: string.Empty, autoSave: false);

//    /// <summary>
//    /// TwoLevelAgent Password
//    /// </summary>
//    public static SerializableProperty<string> TwoLevelAgentPassword { get; }
//        = GetProperty(defaultValue: string.Empty, autoSave: false);

//    #endregion

//    #region 代理模式设置

//    static EProxyMode DefaultProxyMode => ProxyModes[0];

//    static IEnumerable<EProxyMode> GetProxyModes()
//    {
//#if WINDOWS
//        yield return EProxyMode.Hosts;
//        yield return EProxyMode.DNSIntercept;
//        yield return EProxyMode.PAC;
//        yield return EProxyMode.System;
//#elif ANDROID
//        yield return EProxyMode.VPN;
//        yield return EProxyMode.ProxyOnly;
//#elif LINUX || MACOS || MACCATALYST
//#if MACCATALYST
//        if (OperatingSystem.IsMacOS())
//#endif
//        {
//            yield return EProxyMode.Hosts;
//            yield return EProxyMode.System;
//        }
//#else
//        return Array.Empty<EProxyMode>();
//#endif
//    }

//    public static IReadOnlyList<EProxyMode> ProxyModes => mProxyModes.Value;

//    static readonly Lazy<IReadOnlyList<EProxyMode>> mProxyModes = new(() => GetProxyModes().ToArray());

//    /// <summary>
//    /// 当前代理模式
//    /// </summary>
//    public static SerializableProperty<EProxyMode> ProxyMode { get; }
//       = GetProperty(defaultValue: DefaultProxyMode);

//    /// <inheritdoc cref="ProxyMode"/>
//    public static EProxyMode ProxyModeValue
//    {
//        get
//        {
//            var value = ProxyMode.Value;
//            if (ProxyModes.Contains(value)) return value;
//            return DefaultProxyMode;
//        }
//        set => ProxyMode.Value = value;
//    }

//    public static string ToStringByProxyMode(EProxyMode mode) => mode switch
//    {
//        EProxyMode.DNSIntercept => AppResources.ProxyMode_DNSIntercept,
//        EProxyMode.Hosts => AppResources.ProxyMode_Hosts,
//        EProxyMode.System => AppResources.ProxyMode_System,
//        EProxyMode.VPN => AppResources.ProxyMode_VPN,
//        EProxyMode.ProxyOnly => AppResources.ProxyMode_ProxyOnly,
//        _ => string.Empty,
//    };

//    public static string ProxyModeValueString => ToStringByProxyMode(ProxyModeValue);

//    #endregion

//#if (WINDOWS || MACCATALYST || MACOS || LINUX) && !(IOS || ANDROID)

//    static readonly SerializableProperty<bool> _IsProxyGOG
//       = GetProperty(defaultValue: false);

//    /// <summary>
//    /// 启用 GOG 插件代理
//    /// </summary>
//    public static SerializableProperty<bool> IsProxyGOG => _IsProxyGOG;

//    static readonly SerializableProperty<bool> _IsOnlyWorkSteamBrowser
//         = GetProperty(defaultValue: false);

//    /// <summary>
//    /// 是否只针对 Steam 内置浏览器启用脚本
//    /// </summary>
//    public static SerializableProperty<bool> IsOnlyWorkSteamBrowser => _IsOnlyWorkSteamBrowser;

//#endif
//}