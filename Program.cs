using log4net;
using Microsoft.Extensions.Configuration;

public class Program
{
    private static readonly ILog log = LogManager.GetLogger(typeof(Program));
    static void Main(string[] args)
    {
        //加载Log4net
        try
        {
            //log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo("/Users/richy/Projects/BecomeRich/BecomeRich/log4net.config"));
            log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(System.IO.Path.Combine(AppContext.BaseDirectory, "log4net.config")));
            log.Info("log4net initialized successfully.");
        }
        catch (Exception ex)
        {
            log.Error(ex);
        }

        try
        {
            log.Info("程序开始");
            // Create configuration builder
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory) // 更新为使用应用程序目录
                .AddJsonFile("appsettings.json"); // 直接使用文件名

            // Build configuration
            IConfiguration configuration = builder.Build();

            //// Read WalletFilePath configuration item
            string walletFilePath = configuration["WalletFilePath"];
            if (!Directory.Exists(walletFilePath))
            {
                Directory.CreateDirectory(walletFilePath);
            }
            string walletName = DateTime.Now.ToLongDateString() + "Wallet.txt";

            int walletNumber = Convert.ToInt32(configuration["WalletNumber"]);

             // 读取新配置项并转换为布尔值
            string isLuckyNumberString = configuration["UseLuckyNumber"];
            bool isLuckyNumber = (isLuckyNumberString == "1");
            
            string luckyNumber = configuration["LuckyNumber"]; // 读取字符串

            log.Info($"UseLuckyNumber: {isLuckyNumber}");
            log.Info($"LuckyNumber: {luckyNumber}");

            var creatWallet = new CreatWallet.CreatWallet();
            ////creatWallet.CreateWallets(10000, walletFilePath+walletName);
            ////creatWallet.CreateWallets(walletFilePath + walletName, "88888888");
            if (isLuckyNumber)
            {
                creatWallet.CreateWallets(walletNumber, walletFilePath + walletName, luckyNumber);
            }
            else
            {
                creatWallet.CreateWallets(walletNumber, walletFilePath + walletName);
            }
            //RandomAmount randomAmount = new RandomAmount();
            //randomAmount.CreatRandomAmount();
        }
        catch (FileNotFoundException ex)
        {
            log.Error("Error: Configuration file 'appsettings.json' was not found.", ex); 
            log.Error(ex.Message); 
        }
        catch (Exception ex)
        {
            log.Error("An error occurred while creating wallets.");
            log.Error(ex.Message);
        }

    }
}
