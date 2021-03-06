param(
    [Parameter(Mandatory = $true)]
    [string]
    $CrankAgentVm,

    [string]
    $BranchOrCommit = 'dev',

    [string]
    $Scenario = 'http',

    [string]
    $FunctionApp = 'HelloApp',

    [string]
    $InvokeCrankCommand,

    [switch]
    $WriteResultsToDatabase,

    [switch]
    $RefreshCrankContoller,

    [string]
    $UserName = 'Functions',

    [bool]
    $Trace = $false,

    [int]
    $Duration = 15,

    [int]
    $Warmup = 15,

    [int]
    $Iterations = 1
)

$ErrorActionPreference = 'Stop'

#region Utilities

function InstallCrankController {
    dotnet tool install -g Microsoft.Crank.Controller --version "0.1.0-*"
}

function UninstallCrankController {
    dotnet tool uninstall -g microsoft.crank.controller
}

#endregion

#region Main

if (-not $InvokeCrankCommand) {
    if (Get-Command crank -ErrorAction SilentlyContinue) {
        if ($RefreshCrankContoller) {
            Write-Warning 'Reinstalling crank controller...'
            UninstallCrankController
            InstallCrankController
        }
    } else {
        Write-Warning 'Crank controller is not found, installing...'
        InstallCrankController
    }
    $InvokeCrankCommand = 'crank'
}

$crankConfigPath = Join-Path `
                    -Path (Split-Path $PSCommandPath -Parent) `
                    -ChildPath 'benchmarks.yml'

$isLinuxApp = $CrankAgentVm -match '\blinux\b'

$homePath = if ($isLinuxApp) { "/home/$UserName/FunctionApps/$FunctionApp" } else { "C:\FunctionApps\$FunctionApp" }
$functionAppPath = if ($isLinuxApp) { "/home/$UserName/FunctionApps/$FunctionApp/site/wwwroot" } else { "C:\FunctionApps\$FunctionApp\site\wwwroot" }
$tmpLogPath = if ($isLinuxApp) { "/tmp/functions/log" } else { 'C:\Temp\Functions\Log' }

 $aspNetUrls = "http://localhost:5000"
 $profileName = "default"

$crankArgs =
    '--config', $crankConfigPath,
    '--scenario', $Scenario,
    '--profile', $profileName,
    '--chart',
    '--chart-type hex',
    '--application.collectCounters', $true,
    '--variable', "CrankAgentVm=$CrankAgentVm",
    '--variable', "FunctionAppPath=`"$functionAppPath`"",
    '--variable', "HomePath=`"$homePath`"",
    '--variable', "TempLogPath=`"$tmpLogPath`"",
    '--variable', "BranchOrCommit=$BranchOrCommit",
    '--variable', "duration=$Duration",
    '--variable', "warmup=$Warmup",
    '--variable', "AspNetUrls=$aspNetUrls"

if ($Trace) {
    $crankArgs += '--application.collect', $true
}

if ($WriteResultsToDatabase) {
    Set-AzContext -Subscription 'Antares-Demo' > $null
    $sqlPassword = (Get-AzKeyVaultSecret -vaultName 'functions-crank-kv' -name 'SqlAdminPassword').SecretValueText

    $sqlConnectionString = "Server=tcp:functions-crank-sql.database.windows.net,1433;Initial Catalog=functions-crank-db;Persist Security Info=False;User ID=Functions;Password=$sqlPassword;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"

    $crankArgs += '--sql', $sqlConnectionString
    $crankArgs += '--table', 'FunctionsPerf'
}

if ($Iterations -gt 1) {
    $crankArgs += '--iterations', $Iterations
    $crankArgs += '--display-iterations'
}

& $InvokeCrankCommand $crankArgs 2>&1 | Tee-Object -Variable crankOutput

$badResponses = $crankOutput | Where-Object { $_ -match '\bBad responses\b\s*\|\s*(\S*)\s' } | ForEach-Object { $Matches[1] }
if ($null -eq $badResponses) {
    Write-Warning "Could not detect the number of bad responses. The performance results may be unreliable."
}
if ($badResponses -ne 0) {
    Write-Warning "Detected $badResponses bad response(s). The performance results may be unreliable."
}

#endregion
