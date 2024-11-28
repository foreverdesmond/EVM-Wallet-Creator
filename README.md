# EVM Wallet Creator

## Project Overview
EVM Wallet Creator is an application designed to generate EVM wallets by reading configuration files. It allows users to configure the number of wallets and the method of generation, utilizing log4net for logging. This project aims to provide a simple and user-friendly tool for quickly creating wallets.

## Features
- Reads configuration from the `appsettings.json` file.
- Supports configuration of wallet quantity and the option to use a lucky number.
- Utilizes log4net to log application runtime information.
- Handles missing configuration files and other exceptions, ensuring error information is logged.

## Installation
1. Clone this project to your local machine:
   ```bash
   git clone https://github.com/yourusername/yourproject.git
   cd yourproject
   ```

2. Restore the required dependencies using NuGet:
   ```bash
   dotnet restore
   ```

3. Ensure you have an `appsettings.json` configuration file in the project root with the following format:
   ```json
   {
       "WalletFilePath": "your_wallet_path",
       "WalletNumber": "10",
       "UseLuckyNumber": "1",
       "LuckyNumber": "8888"
   }
   ```

## Usage
Run the project:
```bash
dotnet run
```

## Logging
Log files will be generated based on the log4net configuration, so ensure to include a `log4net.config` file in your project.

## Contributing
Contributions are welcome! Please submit issues or pull requests.

## License
This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
